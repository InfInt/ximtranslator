using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common
{
    public class Mouse
    {
        public enum Button : int
        {
            MouseLeft = 0,
            MouseRight = 1,
            MouseMiddle = 2,
            Mouse4 = 3,
            Mouse5 = 4,
            Mouse6 = 5,
            Mouse7 = 6,
            Mouse8 = 8,
            MWheelUp = 8,
            MWheelDown = 9,
        }
    }

    public class Joystick
    {
        public const int Max = 65534;

        public enum Button : int
        {
            Joy1 = 0,
            Joy2 = 1,
            Joy3 = 2,
            Joy4 = 3,
            Joy5 = 4,
            Joy6 = 5,
            Joy7 = 6,
            Joy8 = 7,
            Joy9 = 8,
            Joy10 = 9,
            JoyMax = Joy10, // actually its 128 but im lazy

            PovUp = 200,
            PovStart = PovUp,
            PovDown = 201,
            PovLeft = 202,
            PovRight = 203,
            PovMax = PovRight,
        }

        public enum POV : int
        {
            Up,
            Down,
            Left,
            Right,
        }

        public enum Analog : int
        {
            JoyX = 0,
            JoyY,
            JoyZ,
            JoyRx,
            JoyRy,
            JoyRz,
            JoyPosX,
            JoyPosY,
            JoyPosZ,
            JoyPosRx,
            JoyPosRy,
            JoyPosRz,
            JoyNegX,
            JoyNegY,
            JoyNegZ,
            JoyNegRx,
            JoyNegRy,
            JoyNegRz,
        }

        [Flags]
        public enum Flags : int
        {
            Invert=1,
            Scale=2,
        }
    }

    public static class Singleton<T> where T : class
    {
        static Singleton()
        {
        }

        public static readonly T Instance =
          typeof(T).InvokeMember(typeof(T).Name,
                                 BindingFlags.CreateInstance |
                                 BindingFlags.Instance |
                                 BindingFlags.NonPublic,
                                 null, null, null) as T;
    }
}
