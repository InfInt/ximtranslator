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
        private VarManager.Var m_sens;
        private VarManager.Var m_accel;

        private VarManager.Var m_sensitivity1;
        private VarManager.Var m_sensitivity2;
        private VarManager.Var m_altSens;
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
        private VarManager.Var m_mouseStick;
        private VarManager.Var m_inverty;
        private IntPtr m_mouseSmoothPtr = (IntPtr)0;

        private VarManager varManager;
        private InputManager inputManager;
        private GamesManager gamesManager;

        public MouseMath()
        {
            this.varManager = VarManager.Instance;
            this.inputManager = InputManager.Instance;
            this.gamesManager = GamesManager.Instance;

            this.varManager.GetVar(VarManager.Names.Sensitivity, out m_sens);
            this.varManager.GetVar(VarManager.Names.Accel, out m_accel);
            this.varManager.GetVar(VarManager.Names.Sensitivity1, out m_sensitivity1);
            this.varManager.GetVar(VarManager.Names.Sensitivity2, out m_sensitivity2);
            this.varManager.GetVar(VarManager.Names.AltSens, out m_altSens);
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
            this.varManager.GetVar(VarManager.Names.MouseStick, out m_mouseStick);
            this.varManager.GetVar(VarManager.Names.InvertY, out m_inverty);
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

            if (m_mouseSmoothPtr == (IntPtr)0)
            {
                // Alloc the smooth ptr.
                m_mouseSmoothPtr = Xim.AllocSmoothness((float)((double)this.m_smoothness.Value), (int)(1000 / Xim.Delay), (float)((double)m_yxratio.Value), (float)((double)m_transExp1.Value), (float)sensitivity);
            }
            short deltaX=0, deltaY=0;
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

            SetXboxInput(ref input, new Vector2(deltaX, deltaY));
        }

        private static Vector2 lowEndCarry = new Vector2(0, 0);
        private static Vector2 highEndCarry = new Vector2(0, 0);

        public void XSoftMouseMovement(ref Xim.Input input, ref Xim.Input startState)
        {
            GamesManager.Settings gameSettings = gamesManager.GetGameSettings((GamesManager.Games)m_currentGame.Value);
            // User Values
            double sens = (double)m_sens.Value;
            double accel = 1.0 + (double)m_accel.Value;

            double pitch = 0.22; // revolutions per pixel per s
            double yaw = 0.22; // revolutions per pixel per s

            double delay = ( 1 / (double)m_rate.Value );

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
            mouseDelta.Scale(sens);
            mouseDelta.Scale(delay);

            // Factor in game Y:X ratio
            mouseDelta.X = mouseDelta.X * yaw;
            mouseDelta.Y = mouseDelta.Y * pitch;

            // Transform by the found linearize formula delta^exp * speed + deadzone
            mouseDelta.Pow(gameSettings.Exp);
            mouseDelta.Scale(gameSettings.Speed);

            Vector2 deadzoneVec = CalculateDeadzone(mouseDelta, gameSettings.Deadzone, gameSettings.Circular);
            
            mouseDelta.Add(deadzoneVec);

            // Cap at the linearize formula cap.
            mouseDelta.Cap(-(double)gameSettings.Cap, (double)gameSettings.Cap);

            // Post Processing

            // pixelCap is the number of pixels per frame that can be processed by the current angular velocity formula.
            // Anything above this value is useless to translate but we can carry the leftover value to the next frame.
            double pixelCapX = Math.Pow((Math.Pow((gameSettings.Cap - gameSettings.Deadzone) / gameSettings.Speed, (double)1 / gameSettings.Exp) / (sens * yaw * delay)), (double)1 / accel);
            double pixelCapY = Math.Pow((Math.Pow((gameSettings.Cap - gameSettings.Deadzone) / gameSettings.Speed, (double)1 / gameSettings.Exp) / (sens * pitch * delay)), (double)1 / accel);

            if (Math.Abs(delta.X) > pixelCapX)
            {
                int sign = Math.Sign(delta.X);

                highEndCarry.X = (Math.Abs(delta.X) - pixelCapX) * sign;
                //lowEndCarry.Y = delta.Y;
                mouseDelta.X = (short)(gameSettings.Cap * sign);
            }

            if (Math.Abs(delta.Y) > pixelCapY)
            {
                int sign = Math.Sign(mouseDelta.Y);

                highEndCarry.Y = (Math.Abs(delta.Y) - pixelCapY) * sign;
                //lowEndCarry.Y = delta.Y;
                mouseDelta.Y = (short)(gameSettings.Cap * sign);
            }

            // pixelsAtMax is the number of pixels we can process when moving at Xim.Stick.Max, if we have moved more than 
            // this number of pixels then we should carry the leftover and use Xim.Stick.Max for our output.
            double pixelsAtMaxX = Math.Pow((gameSettings.MaxSpeed) / (delay * sens * yaw), 1 / accel);
            double pixelsAtMaxY = Math.Pow((gameSettings.MaxSpeed) / (delay * sens * pitch), 1 / accel);


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
            if (Math.Abs(mouseDelta.Y) < gameSettings.CarryZone.Y)
            {
                lowEndCarry.Y = delta.Y;
                mouseDelta.Y = 0;
            }

            if (Math.Abs(mouseDelta.X) < gameSettings.CarryZone.X)
            {
                lowEndCarry.X = delta.X;
                mouseDelta.Y = 0;
            }

            mouseDelta.Cap(-(double)Xim.Stick.Max, (double)Xim.Stick.Max);

            SetXboxInput(ref input, mouseDelta);
        }

        private static Vector2 CalculateDeadzone(Vector2 mouseDelta, double deadzoneFactor, bool circular)
        {
            Vector2 deadzone = null;
            if (circular)
            {
                deadzone = new Vector2(mouseDelta.X, mouseDelta.Y);
                deadzone.Normalize();
                deadzone.Scale(deadzoneFactor);
            }
            else
            {
                deadzone = new Vector2(deadzoneFactor * Math.Sign(mouseDelta.X), deadzoneFactor * Math.Sign(mouseDelta.Y));
            }
            return deadzone;
        }

        private void SetXboxInput( ref Xim.Input input, Vector2 mouseDelta )
        {
            int sign = ((bool)m_inverty.Value) ? -1 : 1;
            switch((VarManager.Sticks)m_mouseStick.Value)
            {
                case VarManager.Sticks.Both:
                    input.RightStickX = (short)mouseDelta.X;
                    input.RightStickY = (short)(mouseDelta.Y * sign);
                    input.LeftStickX = (short)mouseDelta.X;
                    input.LeftStickY = (short)(mouseDelta.Y * sign);
                    break;
                case VarManager.Sticks.Left:
                    input.LeftStickX = (short)mouseDelta.X;
                    input.LeftStickY = (short)(mouseDelta.Y * sign);
                    break;
                case VarManager.Sticks.Right:
                    input.RightStickX = (short)mouseDelta.X;
                    input.RightStickY = (short)(mouseDelta.Y * sign);
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

       /* private void oldMath()
        {
            else
            {
                if (mouseSmooth == 0)
                    mouseSmooth++;

                if (fClearSmoothOnStop && delta.X == 0 && delta.Y == 0)
                {
                    m_prevMouseStates.Clear();
                    input.RightStickX = 0;
                    input.RightStickY = 0;
                    return;
                }
                else if (m_prevMouseStates.Count == mouseSmooth)
                {
                    m_prevMouseStates.Dequeue();
                }

                m_prevMouseStates.Enqueue(delta);

                Vector2 mouseDelta = new Vector2(0, 0);
                foreach (Vector2 curState in m_prevMouseStates)
                {
                    mouseDelta.X += curState.X;
                    mouseDelta.Y -= curState.Y;
                }

                mouseDelta.X = mouseDelta.X / m_prevMouseStates.Count;
                mouseDelta.Y = mouseDelta.Y / m_prevMouseStates.Count;

                CalculateMouseToXbox(mouseDelta, sensitivity, deadzoneFactor, transExp, yxratio, diagonalDampen, fCircularDeadzone, ref mouseDelta);

                mouseDelta.Cap(-(double)Xim.Stick.Max, (double)Xim.Stick.Max);

                input.RightStickX = (short)mouseDelta.X;
                input.RightStickY = (short)mouseDelta.Y;
            }
        }*/
    }
}
