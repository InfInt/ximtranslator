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
            MWheelUp = 8,
            MWheelDown = 9,
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
