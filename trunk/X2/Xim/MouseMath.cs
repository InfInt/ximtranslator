using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Common;
using XimApi;

namespace X2
{
    class MouseMath
    {

        private static Vector2 lowEndCarry = new Vector2(0, 0);
        private static Vector2 lowEndCarryZone = new Vector2(0, 10000);
        private static Vector2 highEndCarry = new Vector2(0, 0);

        public static void XSoftMouseMovement(ref Xim.Input input, ref Xim.Input startState)
        {
            // User Values
            double sens = 4.0;
            double accel = 1.4;

            double pitch = 0.22; // revolutions per pixel per s
            double yaw = 0.22; // revolutions per pixel per s

            double speed = 31075;
            double exp = 0.4789;
            int deadzone = 6000;
            int cap = 32200;
            double maxSpeed = 3.0;
            double delay = 0.01666;
            bool circular = false;

            Vector2 delta;
            InputManager.Instance.GetAndResetMouseDelta(out delta);

            delta.Y = -delta.Y;

            delta.Add(highEndCarry);
            highEndCarry.X = highEndCarry.Y = 0;

            delta.Add(lowEndCarry);
            lowEndCarry.X = lowEndCarry.Y = 0;

            Vector2 mouseDelta = new Vector2(delta.X, delta.Y);

            // cap = (((x^accel)*sens*pitch)^exp)*speed+deadzone
            //cap - deadzone = (((x^accel)*sens*pitch*delay)^exp)*speed
            // (cap - deadzone ) / speed = (((x^accel)*sens*pitch*delay)^exp)
            // (cap - deadzone ) / speed)^ 1/exp = (x^accel)*sens*pitch*delay
            // ((cap - deadzone ) / speed)^ 1/exp) / (sens * pitch*delay) = (x^accel)
            // x = (((cap - deadzone ) / speed)^ 1/exp) (*sens*pitch*delay))^ 1/accel)

            //32500 = capspeed * delay * sens * pitch

            // ((x^accel)*sens*pitch) = maxSpeed;

            // pixelCap is the number of pixels per frame that can be processed by the current angular velocity formula.
            // Anything above this value is useless to translate but we can carry the leftover value to the next frame.
            double pixelCap = Math.Pow((Math.Pow((cap - deadzone) / speed, (double)1 / exp) / (sens * pitch * delay)), (double)1 / accel);

            if (Math.Abs(mouseDelta.X) > pixelCap)
            {
                int sign = Math.Sign(mouseDelta.X);

                highEndCarry.X = (Math.Abs(mouseDelta.X) - pixelCap) * sign;
                mouseDelta.X = (short)(cap * sign);
            }
            else
            {
                // Transform mouseDelta into Angular Velocity ( revolutions / time ) = delta^accel * sens * delay 
                mouseDelta.Pow(accel);
                mouseDelta.Scale(sens);
                mouseDelta.Scale(delay);

                // Factor in game Y:X ratio
                mouseDelta.X = mouseDelta.X * yaw;
                mouseDelta.Y = mouseDelta.Y * pitch;

                // Transform by the found linearize formula delta^exp * speed + deadzone
                mouseDelta.Pow(exp);
                mouseDelta.Scale(speed);

                Vector2 deadzoneVec = CalculateDeadzone(mouseDelta, deadzone, circular);
                
                mouseDelta.Add(deadzoneVec);

                // Cap at the linearize formula cap.
                mouseDelta.Cap(-(double)cap, (double)cap);
            }

            // Post Processing

            // pixelsAtMax is the number of pixels we can process when moving at Xim.Stick.Max, if we have moved more than 
            // this number of pixels then we should carry the leftover and use Xim.Stick.Max for our output.
            double pixelsAtMax = Math.Pow((maxSpeed) / (delay * sens * pitch), 1 / accel);
            
            if (Math.Abs(delta.X) > pixelsAtMax)
            {
                InfoTextManager.Instance.WriteLine("Carry!" + delta.X);
                int sign = Math.Sign(delta.X);
                highEndCarry.X = (Math.Abs(delta.X) - pixelsAtMax) * sign;
                mouseDelta.X = ((short)Xim.Stick.Max * sign);
            }

            if (Math.Abs(delta.Y) > pixelsAtMax)
            {
                InfoTextManager.Instance.WriteLine("Carry!" + delta.Y);
                int sign = Math.Sign(delta.Y);
                highEndCarry.Y = (Math.Abs(delta.Y) - pixelsAtMax) * sign;
                mouseDelta.Y = ((short)Xim.Stick.Max * sign);
            }

            // Some games ( like UT3 ) have a strange Y step function going on, account for that.
            if (Math.Abs(mouseDelta.Y) < lowEndCarryZone.Y)
            {
                lowEndCarry.Y = delta.Y;
                mouseDelta.Y = 0;
            }

            if (Math.Abs(mouseDelta.X) < lowEndCarryZone.X)
            {
                lowEndCarry.X = delta.X;
                mouseDelta.Y = 0;
            }

            mouseDelta.Cap(-(double)Xim.Stick.Max, (double)Xim.Stick.Max);

            input.RightStickX = (short)mouseDelta.X;
            input.RightStickY = (short)mouseDelta.Y;
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
                deadzone = new Vector2(deadzoneFactor, deadzoneFactor);
            }
            return deadzone;
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
