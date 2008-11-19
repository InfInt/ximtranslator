using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Common;
using XimApi;

namespace xEmulate
{
    class BetaMouseMath
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

        private VarManager varManager;
        private InputManager inputManager;
        private BetaGamesManager gamesManager;
        private Vector2 lastFrame = new Vector2(0, 0);

        public BetaMouseMath()
        {
            this.varManager = VarManager.Instance;
            this.inputManager = InputManager.Instance;
            this.gamesManager = BetaGamesManager.Instance;

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

        private static Vector2 lowEndCarry = new Vector2(0, 0);
        private static Vector2 highEndCarry = new Vector2(0, 0);
        private static Vector2 spot = new Vector2(0.2, 0);

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
            mouseDpi = (int)m_mouseDpi.Value;
            pitch = 1;
            yaw = 1;
        }

        public void CalcAngularVelocity(Vector2 delta, out Vector2 angularVelocity)
        {
            double speed, accel, yaw, pitch, mouseDpi;

            GetUserSettings(out speed, out accel, out mouseDpi, out pitch, out yaw);

            double delay = (1000 / (1000 / (double)m_rate.Value));
            double revolutionsperinch = speed / 15;

            double userScale = revolutionsperinch * delay / mouseDpi;

            
            angularVelocity = new Vector2(delta.X, delta.Y);

            // Short circuit if we know we have no movement;
            if (angularVelocity.X != 0 || angularVelocity.Y != 0)
            {
                // Transform mouseDelta into Angular Velocity ( revolutions / time ) = delta^accel * sens * delay 
                angularVelocity.Pow(accel);
                angularVelocity.Scale(userScale);

                // Factor in user Y:X ratio
                angularVelocity.X = angularVelocity.X * yaw;
                angularVelocity.Y = angularVelocity.Y * pitch;
            }

            InfoTextManager.Instance.WriteLine(highEndCarry.X.ToString());
            angularVelocity.Add(highEndCarry);
            highEndCarry.X = highEndCarry.Y = 0;

            angularVelocity.Add(lowEndCarry);
            lowEndCarry.X = lowEndCarry.Y = 0;
        }

        public void XSoftMouseMovement(double delayInMs, ref Xim.Input input, ref Xim.Input startState)
        {
            BetaGamesManager.GameSettings gameSettings = gamesManager.GetGameSettings((GamesManager.Games)m_currentGame.Value);

            // Get the user input
            Vector2 rawDelta;
            InputManager.Instance.GetAndResetMouseDelta(out rawDelta);
            rawDelta.Y = -rawDelta.Y;

            Vector2 angVelocity;
            CalcAngularVelocity(rawDelta, out angVelocity);

            if (angVelocity.X == 0 && angVelocity.Y == 0)
                return;

            //angVelocity = new Vector2(spot);
            //spot.Rotate(Math.PI / 45);

            Vector2 outputDelta = new Vector2(angVelocity);

            CalcDelta(delayInMs, angVelocity, ref outputDelta, gameSettings);

            /*if(outputDelta.X != 0 && outputDelta.Y != 0)
            {
                double association = 0;
                double xy = 0;
                if (Math.Abs(outputDelta.X) > Math.Abs(outputDelta.Y))
                {
                    association = Math.Abs(outputDelta.Y / outputDelta.X);
                    xy = outputDelta.X;
                }
                else
                {
                    association = Math.Abs(outputDelta.X / outputDelta.Y);
                    xy = outputDelta.Y;
                }

                xy = Math.Sqrt(2 * xy * xy);

                double newLen = outputDelta.Length *( 1.0 - association * .30  );
                
                outputDelta.Normalize();
                outputDelta.Scale(newLen);
            }*/

            outputDelta.Add(CalcDeadzone(outputDelta, gameSettings));

            SetXboxInput(ref input, outputDelta);
        }

        private void CalcDelta(double delayInMs, Vector2 angVelocity, ref Vector2 mouseDelta, BetaGamesManager.GameSettings gs)
        {
            gs.TransAlg.CalcOutputDelta(delayInMs, angVelocity, ref mouseDelta, ref highEndCarry);
        }
            /*Vector2 absAngVelocity = new Vector2(Math.Abs(angVelocity.X),Math.Abs(angVelocity.Y));
            MouseAlgs.Algorithm xAlg = gs.XAxis[0];
            MouseAlgs.Algorithm yAlg = gs.YAxis[0];
            foreach (MouseAlgs.Algorithm alg in gs.XAxis)
            {
                if (absAngVelocity.X < alg.MinSpeed)
                    break;

                xAlg = alg;

                if (absAngVelocity.X < alg.MaxSpeed)
                    break;
            }

            if (absAngVelocity.X > xAlg.MaxSpeed)
            {
                highEndCarry.X = Math.Sign(angVelocity.X) * (absAngVelocity.X - xAlg.MaxSpeed);
                absAngVelocity.X = xAlg.MaxSpeed;
            }

            foreach (MouseAlgs.Algorithm alg in gs.YAxis)
            {
                if (absAngVelocity.Y < alg.MinSpeed)
                    break;

                yAlg = alg;

                if (Math.Abs(absAngVelocity.Y) < alg.MaxSpeed)
                    break;
            }

            if (absAngVelocity.Y > yAlg.MaxSpeed)
            {
                highEndCarry.Y = Math.Sign(angVelocity.Y) * (absAngVelocity.Y - yAlg.MaxSpeed);
                absAngVelocity.Y = yAlg.MaxSpeed;
            }

            mouseDelta.X = Math.Sign(mouseDelta.X) * xAlg.CalcOutputDelta(absAngVelocity.X, absAngVelocity.Y);
            mouseDelta.Y = Math.Sign(mouseDelta.Y) * yAlg.CalcOutputDelta(absAngVelocity.Y, absAngVelocity.X);*/
        //}

        private void CalcAveraging(Vector2 mouseDelta, BetaGamesManager.GameSettings gs)
        {
            mouseDelta.X = (mouseDelta.X + lastFrame.X * gs.Smoothing) / (1 + gs.Smoothing);
            mouseDelta.Y = (mouseDelta.Y + lastFrame.Y * gs.Smoothing) / (1 + gs.Smoothing);
            this.lastFrame = mouseDelta;
        }

        private void CalcDiag(Vector2 mouseDelta, BetaGamesManager.GameSettings gs)
        {
            if (gs.DiagonalCoeff != 0)
            {
                Vector2 absDelta = new Vector2(Math.Abs(mouseDelta.X), Math.Abs(mouseDelta.Y));
                absDelta.Cap(0, (double)Xim.Stick.Max);

                double association = 0;
                if (absDelta.X > absDelta.Y)
                {
                    association = absDelta.Y / absDelta.X;
                    if (association != 0 && !Double.IsNaN(association) && !Double.IsInfinity(association))
                    {
                        //mouseDelta.Y = mouseDelta.Y + mouseDelta.Y * (0.1 - association / 10) * gs.DiagonalCoeff;
                        mouseDelta.Scale(1 - association * gs.DiagonalCoeff);
                    }
                }
                else
                {
                    association = absDelta.X / absDelta.Y;
                    if (association != 0 && !Double.IsNaN(association) && !Double.IsInfinity(association))
                    {
                        //mouseDelta.X = mouseDelta.X + mouseDelta.X * (0.1 - association / 10) * gs.DiagonalCoeff;
                        mouseDelta.Scale(1 - association * gs.DiagonalCoeff);
                    }
                }
            }
        }


        private static Vector2 CalcDeadzone(Vector2 mouseDelta, BetaGamesManager.GameSettings gs)
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
    }
}
