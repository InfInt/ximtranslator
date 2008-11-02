using System;
using System.Collections.Generic;
using System.Text;
using Common;
using XimApi;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    interface IKey { }

    public static class InputKey
    {
        public static InputKey<U> Make<U>(U key)
        {
            return new InputKey<U>(key);
        }
    }

    public class InputKey<T> : IKey
    {
        public T key { get; set; }

        public InputKey(T key)
        {
            this.key = key;
        }

        public override string ToString()
        {
            return key.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj is InputKey<T>)
                return this.key.Equals((obj as InputKey<T>).key);
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 31 * this.key.GetHashCode();
            return hash;
        }
    }
}
