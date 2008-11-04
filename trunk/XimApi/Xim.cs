using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace XimApi
{
    public class Xim
    {
        public static float Delay = 16.6666f;

        public enum Button
        {
            RightBumper = 0,
            RightStick,
            LeftBumper,
            LeftStick,
            A,
            B,
            X,
            Y,
            Up,
            Down,
            Left,
            Right,
            Start,
            Back,
            Guide,
            RightStickPositiveX,
            RightStickNegativeX,
            RightStickPositiveY,
            RightStickNegativeY,
            LeftStickPositiveX,
            LeftStickNegativeX,
            LeftStickPositiveY,
            LeftStickNegativeY,
            RightTrigger,
            LeftTrigger
        }

        public enum Analog : int
        {
            RightStickX,
            RightStickY,
            LeftStickX,
            LeftStickY,
            LeftTrigger,
            RightTrigger,
        }

        public enum Status : int
        {
            OK                          = 0,
            Hung                        = 1,
            InvalidInputReference       = 101,
            InvalidMode                 = 102,
            InvalidStickValue           = 103,
            InvalidTriggerValue         = 104,
            InvalidTimeoutValue         = 105,
            InvalidBuffer               = 107,
            InvalidDeadzoneType         = 108,
            HardwareAlreadyConnected    = 109,
            HardwareNotConnected        = 109,
            DeviceNotFound              = 401,
            DeviceConnectionFailed      = 402,
            ConfigurationFailed         = 403,
            ReadFailed                  = 404,
            WriteFailed                 = 405,
            TransferCorruption          = 406,
            NeedsCalibration            = 407      // returned when XIMCalibrate.ini is not found by XIMCore.dll
        }

        public enum Mode : int
        {
            None                    = 0x00000000,
            AutoAnalogDisconnect    = 0x00000001
        }

        public enum ButtonState : byte
        {
            Pressed = 1,
            Released = 0
        }

        public enum Stick : short
        {
            Max         = 32767,
            Rest        = 0,
            Right       = Stick.Max,
            Left        = -Stick.Max,
            Up          = Stick.Max,
            Down        = -Stick.Max
        }

        public enum Trigger : short
        {
            Rest = 0,
            Max = 32767
        }

        [StructLayout(LayoutKind.Explicit,Pack = 1,Size=28)]
        public struct Input
        {
            [FieldOffset(0)]
            public ButtonState RightBumper;
            [FieldOffset(1)]
            public ButtonState RightStick;
            [FieldOffset(2)]
            public ButtonState LeftBumper;
            [FieldOffset(3)]
            public ButtonState LeftStick;
            [FieldOffset(4)]
            public ButtonState A;
            [FieldOffset(5)]
            public ButtonState B;
            [FieldOffset(6)]
            public ButtonState X;
            [FieldOffset(7)]
            public ButtonState Y;
            [FieldOffset(8)]
            public ButtonState Up;
            [FieldOffset(9)]
            public ButtonState Down;
            [FieldOffset(10)]
            public ButtonState Left;
            [FieldOffset(11)]
            public ButtonState Right;
            [FieldOffset(12)]
            public ButtonState Start;
            [FieldOffset(13)]
            public ButtonState Back;
            [FieldOffset(14)]
            public ButtonState Guide;
            [FieldOffset(16)]
            public short RightStickX;
            [FieldOffset(18)]
            public short RightStickY;
            [FieldOffset(20)]
            public short LeftStickX;
            [FieldOffset(22)]
            public short LeftStickY;
            [FieldOffset(24)]
            public short RightTrigger;
            [FieldOffset(26)]
            public short LeftTrigger;

            public void CopyFrom(Input other)
            {
                this.RightBumper = other.RightBumper;
                this.LeftBumper = other.LeftBumper;
                this.RightStick = other.RightStick;
                this.LeftStick = other.LeftStick;
                this.A = other.A;
                this.B = other.B;
                this.Y = other.Y;
                this.X = other.X;
                this.Up = other.Up;
                this.Down = other.Down;
                this.Left = other.Left;
                this.Start = other.Start;
                this.Right = other.Right;
                this.Back = other.Back;
                this.Guide = other.Guide;
                this.RightStickX = other.RightStickX;
                this.RightStickY = other.RightStickY;
                this.LeftStickX = other.LeftStickX;
                this.LeftStickY = other.LeftStickY;
                this.RightTrigger = other.RightTrigger;
                this.LeftTrigger = other.LeftTrigger;
                this.RightBumper = other.RightBumper;
                this.RightBumper = other.RightBumper;
                this.RightBumper = other.RightBumper;
                this.RightBumper = other.RightBumper;
                this.RightBumper = other.RightBumper;
            }
        }

        public enum Deadzone
        {
            Circular = 0,
            Square = 1
        }

        [DllImport("XimCore.dll", EntryPoint="XIMConnect")]
        public static extern Status Connect();

        // Disconnect from XIM hardware.
        [DllImport("ximcore.dll", EntryPoint="XIMDisconnect")]
        public static extern void Disconnect();

        // Set runtime mode option (combined flags).
        [DllImport("ximcore.dll", EntryPoint="XIMSetMode")]
        public static extern Status SetMode(Mode mode);

        // Send Xbox 360 controller state.
        // Controller state will persist (latch) until the next call. Method
        // will not return until state is fully committed to the Xbox 360 controller and
        // the specified timeout was met.
        [DllImport("ximcore.dll", EntryPoint = "XIMSendXbox360Input")]
        public static extern Status SendInput(ref Input input, float timeoutMS);

        [DllImport("ximcore.dll", EntryPoint = "XIMAllocSmoothness")]
        public static extern IntPtr AllocSmoothness(float intensity, int inputUpdateFrequency, float stickYXRatio, float stickTranslationExponent, float stickSensitivity);
        
        [DllImport("ximcore.dll", EntryPoint = "XIMFreeSmoothness")]
        public static extern void FreeSmoothness(IntPtr smoothness);

        [DllImport("ximcore.dll", EntryPoint = "XIMComputeStickValues")]
        public static extern Status ComputeStickValues(
            float deltaX, float deltaY,
            float stickYXRatio, float stickTranslationExponent, float stickSensitivity,
            float stickDiagonalDampen,
            IntPtr stickSmoothness,
            Deadzone stickDeadZoneType, float stickDeadZone,
            ref short stickResultX, ref short stickResultY);

        private static short AddStickValue(short currentValue, short add)
        {
            int sum = (int)currentValue + add;
            if (sum > (short)Stick.Max)
                sum = (short)Stick.Max;
            else if (sum < -(short)Stick.Max)
                sum = -(short)Stick.Max;
            return (short)sum;
        }

        public static bool SetButtonState(Button button, ButtonState buttonState, ref Input input)
        {
            switch( button )
            {
                case Button.A:
                    input.A = buttonState;
                    break;
                case Button.B:
                    input.B = buttonState;
                    break;
                case Button.X:
                    input.X = buttonState;
                    break;
                case Button.Y:
                    input.Y = buttonState;
                    break;
                case Button.Guide:
                    input.Guide = buttonState;
                    break;
                case Button.Back:
                    input.Back = buttonState;
                    break;
                case Button.Down:
                    input.Down = buttonState;
                    break;
                case Button.Up:
                    input.Up = buttonState;
                    break;
                case Button.Left:
                    input.Left = buttonState;
                    break;
                case Button.Right:
                    input.Right = buttonState;
                    break;
                case Button.Start:
                    input.Start = buttonState;
                    break;
                case Button.LeftBumper:
                    input.LeftBumper = buttonState;
                    break;
                case Button.RightBumper:
                    input.RightBumper = buttonState;
                    break;
                case Button.LeftStick:
                    input.LeftStick = buttonState;
                    break;
                case Button.RightStick:
                    input.RightStick = buttonState;
                    break;
                case Button.LeftTrigger:
                    input.LeftTrigger = buttonState == ButtonState.Pressed ? (short)Trigger.Max : (short)Trigger.Rest;
                    break;
                case Button.RightTrigger:
                    input.RightTrigger = buttonState == ButtonState.Pressed ? (short)Trigger.Max : (short)Trigger.Rest;
                    break;
                case Button.RightStickPositiveX:
                    if (buttonState == ButtonState.Pressed)
                        input.RightStickX = AddStickValue(input.RightStickX, (short)Stick.Max);
                    else
                        input.RightStickX = (short)Stick.Rest;
                    break;
                case Button.RightStickNegativeX:
                    if (buttonState == ButtonState.Pressed)
                        input.RightStickX = AddStickValue(input.RightStickX, -(short)Stick.Max);
                    else 
                        input.RightStickX = (short)Stick.Rest;
                    break;
                case Button.LeftStickPositiveX:
                    if (buttonState == ButtonState.Pressed)
                        input.LeftStickX = AddStickValue(input.LeftStickX, (short)Stick.Max);
                    else
                        input.LeftStickX = (short)Stick.Rest;
                    break;
                case Button.LeftStickNegativeX:
                    if (buttonState == ButtonState.Pressed)
                        input.LeftStickX = AddStickValue(input.LeftStickX, -(short)Stick.Max);
                    else
                        input.LeftStickX = (short)Stick.Rest;
                    break;
                case Button.RightStickPositiveY:
                    if (buttonState == ButtonState.Pressed)
                        input.RightStickY = AddStickValue(input.RightStickY, (short)Stick.Max);
                    else
                        input.RightStickY = (short)Stick.Rest;
                    break;
                case Button.RightStickNegativeY:
                    if (buttonState == ButtonState.Pressed)
                        input.RightStickY = AddStickValue(input.RightStickY, -(short)Stick.Max);
                    else
                        input.RightStickY = (short)Stick.Rest;
                    break;
                case Button.LeftStickPositiveY:
                    if (buttonState == ButtonState.Pressed)
                        input.LeftStickY = AddStickValue(input.LeftStickY, (short)Stick.Max);
                    else
                        input.LeftStickY = (short)Stick.Rest;
                    break;
                case Button.LeftStickNegativeY:
                    if (buttonState == ButtonState.Pressed)
                        input.LeftStickY = AddStickValue(input.LeftStickY, -(short)Stick.Max);
                    else
                        input.LeftStickY = (short)Stick.Rest;
                    break;
                default:
                    return  false;
            }
            return true;
        }

        public static ButtonState GetButtonState(Button button, ref Input input)
        {
            switch (button)
            {
                case Button.A:
                    return input.A;
                case Button.B:
                    return input.B;
                case Button.X:
                    return input.X;
                case Button.Y:
                    return input.Y;
                case Button.Guide:
                    return input.Guide;
                case Button.Back:
                    return input.Back;
                case Button.Down:
                    return input.Down;
                case Button.Up:
                    return input.Up;
                case Button.Left:
                    return input.Left;
                case Button.Right:
                    return input.Right;
                case Button.Start:
                    return input.Start;
                case Button.LeftBumper:
                    return input.LeftBumper;
                case Button.RightBumper:
                    return input.RightBumper;
                case Button.LeftStick:
                    return input.LeftStick;
                case Button.RightStick:
                    return input.RightStick;
                case Button.LeftTrigger:
                    return input.LeftTrigger == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.RightTrigger:
                    return input.RightTrigger == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.RightStickPositiveX:
                    return input.RightStickX == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.RightStickNegativeX:
                    return input.RightStickX == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.LeftStickPositiveX:
                    return input.LeftStickX == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.LeftStickNegativeX:
                    return input.LeftStickX == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.RightStickPositiveY:
                    return input.RightStickY == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.RightStickNegativeY:
                    return input.RightStickY == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.LeftStickPositiveY:
                    return input.LeftStickY == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
                case Button.LeftStickNegativeY:
                    return input.LeftStickY == (int)Xim.Trigger.Max ? ButtonState.Pressed : ButtonState.Released;
            }
            return ButtonState.Released;
        }

        private static ButtonState ToggleState(ButtonState b)
        {
            return b == ButtonState.Pressed ? ButtonState.Released : ButtonState.Pressed; 
        }

        private static short ToggleState(short b)
        {
            return (short)(Trigger.Max - b);
        }

        public static bool ToggleButtonState(Button button, ref Input input)
        {
            switch (button)
            {
                case Button.A:
                    input.A = ToggleState(input.A);
                    break;
                case Button.B:
                    input.B = ToggleState(input.A);
                    break;
                case Button.X:
                    input.X = ToggleState(input.A);
                    break;
                case Button.Y:
                    input.Y = ToggleState(input.A);
                    break;
                case Button.Guide:
                    input.Guide = ToggleState(input.A);
                    break;
                case Button.Back:
                    input.Back = ToggleState(input.A);
                    break;
                case Button.Down:
                    input.Down = ToggleState(input.A);
                    break;
                case Button.Up:
                    input.Up = ToggleState(input.A);
                    break;
                case Button.Left:
                    input.Left = ToggleState(input.A);
                    break;
                case Button.Right:
                    input.Right = ToggleState(input.A);
                    break;
                case Button.Start:
                    input.Start = ToggleState(input.A);
                    break;
                case Button.LeftBumper:
                    input.LeftBumper = ToggleState(input.A);
                    break;
                case Button.RightBumper:
                    input.RightBumper = ToggleState(input.A);
                    break;
                case Button.LeftStick:
                    input.LeftStick = ToggleState(input.A);
                    break;
                case Button.RightStick:
                    input.RightStick = ToggleState(input.A);
                    break;
                case Button.LeftTrigger:
                    input.LeftTrigger = (short)(Trigger.Max - input.LeftTrigger);
                    break;
                case Button.RightTrigger:
                    input.RightTrigger = (short)(Trigger.Max - input.RightTrigger);
                    break;
                case Button.RightStickPositiveX:
                    input.RightStickX = ToggleState(input.RightStickX);
                    break;
                case Button.RightStickNegativeX:
                    input.RightStickX = ToggleState(input.RightStickX);
                    break;
                case Button.LeftStickPositiveX:
                    input.LeftStickX = ToggleState(input.LeftStickX);
                    break;
                case Button.LeftStickNegativeX:
                    input.LeftStickX = ToggleState(input.LeftStickX);
                    break;
                case Button.RightStickPositiveY:
                    input.RightStickY = ToggleState(input.RightStickY);
                    break;
                case Button.RightStickNegativeY:
                    input.RightStickY = ToggleState(input.RightStickY);
                    break;
                case Button.LeftStickPositiveY:
                    input.LeftStickY = ToggleState(input.LeftStickY);
                    break;
                case Button.LeftStickNegativeY:
                    input.LeftStickY = ToggleState(input.LeftStickY);
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static bool SetAnalogState(Analog button, int analogVal, ref Input input)
        {
            if (analogVal > (short)Xim.Stick.Max)
            {
                analogVal = (short)Xim.Stick.Max;
            }
            else if( analogVal < -(short)Xim.Stick.Max )
            {
                analogVal = -(short)Xim.Stick.Max;
            }

            switch (button)
            {
                case Analog.LeftStickX:
                    input.LeftStickX = (short)analogVal;
                    break;
                case Analog.LeftStickY:
                    input.LeftStickY = (short)analogVal;
                    break;
                case Analog.RightStickX:
                    input.RightStickX = (short)analogVal;
                    break;
                case Analog.RightStickY:
                    input.RightStickY = (short)analogVal;
                    break;
                case Analog.LeftTrigger:
                    input.LeftTrigger = (short)analogVal;
                    break;
                case Analog.RightTrigger:
                    input.RightTrigger = (short)analogVal;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static bool AddAnalogValue(Analog button, int analogVal, ref Input input)
        {
            if (analogVal > (short)Xim.Stick.Max)
                analogVal = (short)Xim.Stick.Max;
            else if (analogVal < -(short)Xim.Stick.Max)
                analogVal = -(short)Xim.Stick.Max;

            switch (button)
            {
                case Analog.LeftStickX:
                    input.LeftStickX = AddStickValue(input.LeftStickX, (short)analogVal);
                    break;
                case Analog.LeftStickY:
                    input.LeftStickY = AddStickValue(input.LeftStickY, (short)analogVal);
                    break;
                case Analog.RightStickX:
                    input.RightStickX = AddStickValue(input.RightStickX, (short)analogVal);
                    break;
                case Analog.RightStickY:
                    input.RightStickY = AddStickValue(input.RightStickY, (short)analogVal);
                    break;
                case Analog.LeftTrigger:
                    input.LeftTrigger = AddStickValue(input.LeftTrigger, (short)analogVal);
                    break;
                case Analog.RightTrigger:
                    input.RightTrigger = AddStickValue(input.RightTrigger, (short)analogVal);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
