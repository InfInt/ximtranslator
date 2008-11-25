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
            Mouse8 = 7,
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
            Joy11 = 10,
            Joy12 = 11,
            Joy13 = 12,
            Joy14 = 13,
            Joy15 = 14,
            Joy16 = 15,
            Joy17 = 16,
            Joy18 = 17,
            Joy19 = 18,
            Joy20 = 19,
            Joy21 = 20,
            Joy22 = 21,
            Joy23 = 22,
            Joy24 = 23,
            Joy25 = 24,
            Joy26 = 25,
            Joy27 = 26,
            Joy28 = 27,
            Joy29 = 28,
            Joy30 = 29,
            JoyMax = Joy30, // actually its 128 but im lazy

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
            JoySlider0,
            JoySlider1,
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
        public enum AnalogFlags : int
        {
            None=0,
            Invert,
            Scale,
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
