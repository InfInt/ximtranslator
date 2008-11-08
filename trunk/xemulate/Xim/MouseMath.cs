using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Common;
using XimApi;

namespace xEmulate
{
    class MouseMath
    {
        private VarManager.Var m_speed;
        private VarManager.Var m_speed2;
        private VarManager.Var m_speed3;
        private VarManager.Var m_speed4;
        private VarManager.Var m_accel;
        private VarManager.Var m_accel2;
        private VarManager.Var m_accel3;
        private VarManager.Var m_accel4;

        private VarManager.Var m_altSens;
        private VarManager.Var m_altSens2;
        private VarManager.Var m_altSens3;

        private VarManager.Var m_sensitivity1;
        private VarManager.Var m_sensitivity2;
        private VarManager.Var m_transExp1;
        private VarManager.Var m_deadzone;
        private VarManager.Var m_circularDeadzone;
        private VarManager.Var m_yxratio;
        private VarManager.Var m_smoothness;
        private VarManager.Var m_rate;
        private VarManager.Var m_autoAnalogDisconnect;
        private VarManager.Var m_useXimApiMouseMath;
        private VarManager.Var m_diagonalDampen;
        private VarManager.Var m_currentGame;
        private VarManager.Var m_mouseStickX;
        private VarManager.Var m_mouseStickY;
        private VarManager.Var m_inverty;
        private VarManager.Var m_mouseDpi;
        private IntPtr m_mouseSmoothPtr = (IntPtr)0;

        private VarManager varManager;
        private InputManager inputManager;
        private GamesManager gamesManager;
        private Vector2 lastFrame = new Vector2(0, 0);

        public MouseMath()
        {
            this.varManager = VarManager.Instance;
            this.inputManager = InputManager.Instance;
            this.gamesManager = GamesManager.Instance;

            this.varManager.GetVar(VarManager.Names.Speed, out m_speed);
            this.varManager.GetVar(VarManager.Names.Speed2, out m_speed2);
            this.varManager.GetVar(VarManager.Names.Speed3, out m_speed3);
            this.varManager.GetVar(VarManager.Names.Speed4, out m_speed4);
            this.varManager.GetVar(VarManager.Names.Accel, out m_accel);
            this.varManager.GetVar(VarManager.Names.Accel2, out m_accel2);
            this.varManager.GetVar(VarManager.Names.Accel3, out m_accel3);
            this.varManager.GetVar(VarManager.Names.Accel4, out m_accel4);
            this.varManager.GetVar(VarManager.Names.Sensitivity1, out m_sensitivity1);
            this.varManager.GetVar(VarManager.Names.Sensitivity2, out m_sensitivity2);
            this.varManager.GetVar(VarManager.Names.AltSens, out m_altSens);
            this.varManager.GetVar(VarManager.Names.AltSens2, out m_altSens2);
            this.varManager.GetVar(VarManager.Names.AltSens3, out m_altSens3);
            this.varManager.GetVar(VarManager.Names.Deadzone, out m_deadzone);
            this.varManager.GetVar(VarManager.Names.YXRatio, out m_yxratio);
            this.varManager.GetVar(VarManager.Names.TransExponent1, out m_transExp1);
            this.varManager.GetVar(VarManager.Names.Smoothness, out m_smoothness);
            this.varManager.GetVar(VarManager.Names.Rate, out m_rate);
            this.varManager.GetVar(VarManager.Names.AutoAnalogDisconnect, out m_autoAnalogDisconnect);
            this.varManager.GetVar(VarManager.Names.CircularDeadzone, out m_circularDeadzone);
            this.varManager.GetVar(VarManager.Names.UseXimApiMouseMath, out m_useXimApiMouseMath);
            this.varManager.GetVar(VarManager.Names.DiagonalDampen, out m_diagonalDampen);
            this.varManager.GetVar(VarManager.Names.CurrentGame, out m_currentGame);
            this.varManager.GetVar(VarManager.Names.MouseStickX, out m_mouseStickX);
            this.varManager.GetVar(VarManager.Names.MouseStickY, out m_mouseStickY);
            this.varManager.GetVar(VarManager.Names.InvertY, out m_inverty);
            this.varManager.GetVar(VarManager.Names.MouseDPI, out m_mouseDpi);
        }

        public void ProcessMouseMovement(ref Xim.Input input, ref Xim.Input startState)
        {
            Vector2 delta;
            this.inputManager.GetAndResetMouseDelta(out delta);

            double sensitivity;
            if ((bool)m_altSens.Value)
            {
                VarManager.GetVarValue(m_sensitivity2, out sensitivity);
            }
            else
            {
                VarManager.GetVarValue(m_sensitivity1, out sensitivity);
            }

            if (this.m_smoothness.Updated)
            {
                this.m_smoothness.Updated = false;
                Xim.FreeSmoothness(m_mouseSmoothPtr);
                m_mouseSmoothPtr = IntPtr.Zero;
            }

            if (m_mouseSmoothPtr == IntPtr.Zero)
            {
                // Alloc the smooth ptr.
                m_mouseSmoothPtr = Xim.AllocSmoothness((float)((double)this.m_smoothness.Value), (int)(1000 / Xim.Delay), (float)((double)m_yxratio.Value), (float)((double)m_transExp1.Value), (float)sensitivity);
            }
            short deltaX = 0, deltaY = 0;
            Xim.ComputeStickValues((float)delta.X,
                (float)-delta.Y,
                (float)((double)this.m_yxratio.Value),
                (float)((double)this.m_transExp1.Value),
                (int)sensitivity,
                (float)((double)this.m_diagonalDampen.Value),
                this.m_mouseSmoothPtr,
                (bool)this.m_circularDeadzone.Value ? Xim.Deadzone.Circular : Xim.Deadzone.Square,
                (float)((int)this.m_deadzone.Value),
                ref deltaX,
                ref deltaY);

            // Dont set the xbox controller unless we have moved the mouse, this allows analog controllers to work :)
            if (delta.X == 0 && delta.Y == 0)
                return;

            SetXboxInput(ref input, new Vector2(deltaX, deltaY));
        }

        private static Vector2 lowEndCarry = new Vector2(0, 0);
        private static Vector2 highEndCarry = new Vector2(0, 0);

        public void GetUserSettings(out double speed, out double accel, out double mouseDpi, out double pitch, out double yaw)
        {
            if ((bool)m_altSens3.Value)
            {
                speed = (double)m_speed4.Value;
                accel = 1.0 + (double)m_accel4.Value;
            }
            else if ((bool)m_altSens2.Value)
            {
                speed = (double)m_speed3.Value;
                accel = 1.0 + (double)m_accel3.Value;
            }
            else if ((bool)m_altSens.Value)
            {
                speed = (double)m_speed2.Value;
                accel = 1.0 + (double)m_accel2.Value;
            }
            else
            {
                speed = (double)m_speed.Value;
                accel = 1.0 + (double)m_accel.Value;
            }
            mouseDpi = (int)m_mouseDpi.Value; ;
            pitch = 1;
            yaw = 1;
        }

        public void XSoftMouseMovement(ref Xim.Input input, ref Xim.Input startState)
        {
            GamesManager.GameSettings gameSettings = gamesManager.GetGameSettings((GamesManager.Games)m_currentGame.Value);
            // User Values

            double speed, accel, yaw, pitch, mouseDpi;

            GetUserSettings(out speed, out accel, out mouseDpi, out pitch, out yaw);

            double delay = (1000 / (1000 / (double)m_rate.Value));
            double revolutionsperinch = speed / 15;

            double userScale = revolutionsperinch * delay / mouseDpi;

            Vector2 delta;
            InputManager.Instance.GetAndResetMouseDelta(out delta);

            delta.Y = -delta.Y;

            delta.Add(highEndCarry);
            highEndCarry.X = highEndCarry.Y = 0;

            delta.Add(lowEndCarry);
            lowEndCarry.X = lowEndCarry.Y = 0;

            if (delta.X == 0 && delta.Y == 0)
                return;

            Vector2 mouseDelta = new Vector2(delta.X, delta.Y);

            // Transform mouseDelta into Angular Velocity ( revolutions / time ) = delta^accel * sens * delay 
            mouseDelta.Pow(accel);
            mouseDelta.Scale(userScale);

            // Factor in game Y:X ratio
            mouseDelta.X = mouseDelta.X * yaw;
            mouseDelta.Y = mouseDelta.Y * pitch;

            CalcDelta(mouseDelta, gameSettings);

            CalcDiag(mouseDelta, gameSettings);

            CalcAveraging(mouseDelta, gameSettings);

            // Add deadzone
            Vector2 deadzoneVec = CalcDeadzone(mouseDelta, gameSettings);

            mouseDelta.Add(deadzoneVec);

            // Cap at the linearize formula cap.
            mouseDelta.CapX(-(double)gameSettings.XAxis.Cap, (double)gameSettings.XAxis.Cap);
            mouseDelta.CapY(-(double)gameSettings.YAxis.Cap, (double)gameSettings.YAxis.Cap);

            // Post Processing

            // pixelCap is the number of pixels per frame that can be processed by the current angular velocity formula.
            // Anything above this value is useless to translate but we can carry the leftover value to the next frame.
            double pixelCapX = Math.Pow((gameSettings.XAxis.GetPixelCapValue(gameSettings.Deadzone) / (userScale * yaw)), (double)1 / accel);
            double pixelCapY = Math.Pow((gameSettings.YAxis.GetPixelCapValue(gameSettings.Deadzone) / (userScale * pitch)), (double)1 / accel);

            if (Math.Abs(delta.X) > pixelCapX)
            {
                int sign = Math.Sign(delta.X);

                highEndCarry.X = (Math.Abs(delta.X) - pixelCapX) * sign;
                mouseDelta.X = (short)(gameSettings.XAxis.Cap * sign);
            }

            if (Math.Abs(delta.Y) > pixelCapY)
            {
                int sign = Math.Sign(mouseDelta.Y);

                highEndCarry.Y = (Math.Abs(delta.Y) - pixelCapY) * sign;
                mouseDelta.Y = (short)(gameSettings.YAxis.Cap * sign);
            }

            // pixelsAtMax is the number of pixels we can process when moving at Xim.Stick.Max, if we have moved more than 
            // this number of pixels then we should carry the leftover and use Xim.Stick.Max for our output.
            double pixelsAtMaxX = Math.Pow((gameSettings.XAxis.MaxSpeed) / (userScale * pitch), 1 / accel);
            double pixelsAtMaxY = Math.Pow((gameSettings.XAxis.MaxSpeed) / (userScale * yaw), 1 / accel);

            if (Math.Abs(delta.X) > pixelsAtMaxX)
            {
                InfoTextManager.Instance.WriteLineDebug("CarryX!" + delta.X);
                int sign = Math.Sign(delta.X);
                highEndCarry.X = (Math.Abs(delta.X) - pixelsAtMaxX) * sign;
                mouseDelta.X = ((short)Xim.Stick.Max * sign);
            }

            if (Math.Abs(delta.Y) > pixelsAtMaxY)
            {
                InfoTextManager.Instance.WriteLineDebug("CarryY!" + delta.Y);
                int sign = Math.Sign(delta.Y);
                highEndCarry.Y = (Math.Abs(delta.Y) - pixelsAtMaxY) * sign;
                mouseDelta.Y = ((short)Xim.Stick.Max * sign);
            }

            // Some games ( like UT3 ) have a strange Y step function going on, account for that.
            if (Math.Abs(mouseDelta.Y) < gameSettings.YAxis.CarryZone)
            {
                lowEndCarry.Y = delta.Y;
                mouseDelta.Y = 0;
            }

            if (Math.Abs(mouseDelta.X) < gameSettings.XAxis.CarryZone)
            {
                lowEndCarry.X = delta.X;
                mouseDelta.Y = 0;
            }

            mouseDelta.Cap(-(double)Xim.Stick.Max, (double)Xim.Stick.Max);

            SetXboxInput(ref input, mouseDelta);
        }

        private void CalcDelta(Vector2 mouseDelta, GamesManager.GameSettings gs)
        {
            Vector2 mouseDeltaCopy = new Vector2(mouseDelta);
            mouseDelta.X = gs.XAxis.CalcOutputDelta(mouseDeltaCopy.X, mouseDeltaCopy.Y);
            mouseDelta.Y = gs.YAxis.CalcOutputDelta(mouseDeltaCopy.Y, mouseDeltaCopy.X);
        }

        private void CalcAveraging(Vector2 mouseDelta, GamesManager.GameSettings gs)
        {
            mouseDelta.X = (mouseDelta.X + lastFrame.X * gs.Smoothing) / (1 + gs.Smoothing);
            mouseDelta.Y = (mouseDelta.Y + lastFrame.Y * gs.Smoothing) / (1 + gs.Smoothing);
            this.lastFrame = mouseDelta;
        }

        private void CalcDiag(Vector2 mouseDelta, GamesManager.GameSettings gs)
        {
            if (gs.DiagonalCoeff != 0)
            {
                double newLength = mouseDelta.Length;
                Vector2 absDelta = new Vector2(Math.Abs(mouseDelta.X), Math.Abs(mouseDelta.Y));
                absDelta.Cap(0, (double)Xim.Stick.Max);

                double association = 0;
                if (absDelta.X > absDelta.Y)
                {
                    association = absDelta.Y / absDelta.X;
                    if (association != 0 && !Double.IsNaN(association) && !Double.IsInfinity(association))
                    {
                        mouseDelta.Y = mouseDelta.Y + mouseDelta.X * (0.333 - association / 3) * gs.DiagonalCoeff * (newLength / (double)Xim.Stick.Max);
                        mouseDelta.Scale(1 - ((newLength / (double)Xim.Stick.Max) * association * gs.DiagonalCoeff));
                    }
                }
                else
                {
                    association = absDelta.X / absDelta.Y;
                    if (association != 0 && !Double.IsNaN(association) && !Double.IsInfinity(association))
                    {
                        mouseDelta.X = mouseDelta.X + mouseDelta.X * (0.333 - association / 3) * gs.DiagonalCoeff * (newLength / (double)Xim.Stick.Max);
                        mouseDelta.Scale(1 - ((newLength / (double)Xim.Stick.Max) * association * gs.DiagonalCoeff));
                    }
                }
            }
        }


        private static Vector2 CalcDeadzone(Vector2 mouseDelta, GamesManager.GameSettings gs)
        {
            Vector2 deadzone = null;
            if (gs.Circular)
            {
                deadzone = new Vector2(mouseDelta.X, mouseDelta.Y);
                deadzone.Normalize();
                deadzone.Scale(gs.Deadzone);
            }
            else
            {
                deadzone = new Vector2(gs.Deadzone * Math.Sign(mouseDelta.X), gs.Deadzone * Math.Sign(mouseDelta.Y));
            }
            return deadzone;
        }

        private void SetXboxInput(ref Xim.Input input, Vector2 mouseDelta)
        {
            int sign = ((bool)m_inverty.Value) ? -1 : 1;
            switch ((VarManager.Sticks)m_mouseStickX.Value)
            {
                case VarManager.Sticks.Left:
                    Xim.AddAnalogValue(Xim.Analog.LeftStickX, (int)mouseDelta.X, ref input);
                    break;
                case VarManager.Sticks.Right:
                    Xim.AddAnalogValue(Xim.Analog.RightStickX, (int)mouseDelta.X, ref input);
                    break;
            }

            switch ((VarManager.Sticks)m_mouseStickY.Value)
            {
                case VarManager.Sticks.Left:
                    Xim.AddAnalogValue(Xim.Analog.LeftStickY, (int)(mouseDelta.Y * sign), ref input);
                    break;
                case VarManager.Sticks.Right:
                    Xim.AddAnalogValue(Xim.Analog.RightStickY, (int)(mouseDelta.Y * sign), ref input);
                    break;
            }
        }

        private void CalculateMouseToXbox(Vector2 mouseDelta, double sensitivity, int deadzoneFactor, double transExp, double yxratio, double diagonalDampen, bool fCircularDeadzone, ref Vector2 xboxDelta)
        {
            Vector2 delta = new Vector2(mouseDelta.X, mouseDelta.Y);

            delta.Y = delta.Y * yxratio;

            Vector2 deadzone = null;
            if (fCircularDeadzone)
            {
                deadzone = new Vector2(delta.X, delta.Y);
                deadzone.Normalize();
                deadzone.Scale(deadzoneFactor);
            }
            else
            {
                deadzone = new Vector2(deadzoneFactor, deadzoneFactor);
            }

            double mouseVectorLen = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            mouseVectorLen = Math.Pow(mouseVectorLen, transExp);
            delta.Normalize();
            delta.Scale(mouseVectorLen);

            delta.Scale(sensitivity);
            delta.Add(deadzone);

            xboxDelta.X = delta.X;
            xboxDelta.Y = delta.Y;
        }
    }
}
