using System;
using System.Collections.Generic;
using System.Text;
using Common;
using XimApi;
using DxI = Microsoft.DirectX.DirectInput;
using Xna = Microsoft.Xna.Framework;

namespace xEmulate
{
    public interface IKey {
        bool IsAnalog{get;}
        bool IsLink { get; }
        String Prefix { get; }
    }

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
            if( !IsLink )
                return Prefix + key.ToString();
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

        public bool IsAnalog
        {
            get { return (this.key is Xim.Analog || this.key is Joystick.Analog); }
        }
        public bool IsLink
        {
            get { return (this.key is Xim.Button); }
        }

        public String Prefix
        { 
            get {
                if(this.key is Xna.Input.Buttons)
                    return "360";
                else if(this.key is Xim.Analog)
                    return "360a";
                else if(this.key is Xim.Button)
                    return "link";

                // Keyboard, Joystick and Mouse do not need a prefix
                return "";
            }
        }
    }

    public class KeysManager
    {
        public Dictionary<String, IKey> m_keys = new Dictionary<String, IKey>(400);
        
        private KeysManager()
        {
            PopulateKeyMap(DxI.Key.A);
            PopulateKeyMap(Mouse.Button.Mouse4);
            PopulateKeyMap(Joystick.Button.Joy1);
            PopulateKeyMap(Joystick.Analog.JoyX);
            PopulateKeyMap(Xna.Input.Buttons.A);
            PopulateKeyMap(Xim.Analog.LeftStickX);
            PopulateKeyMap(Xim.Button.A);
        }

        public static KeysManager Instance
        {
            get { return Singleton<KeysManager>.Instance; }
        }

        private void PopulateKeyMap<T>(T sample)
        {
            String[] keyNames = Enum.GetNames(typeof(T));
            Array keys = Enum.GetValues(typeof(T));
            for (int i = 0; i < keyNames.Length; i++)
            {
                IKey iKey = InputKey.Make<T>((T)keys.GetValue(i));
                m_keys.Add(iKey.Prefix + keyNames[i].ToLower(), iKey);
            }
        }

        public bool IsKey(String keyName)
        {
            IKey iKey;
            if (m_keys.TryGetValue(keyName, out iKey))
            {
                return !iKey.IsAnalog;
            }
            return false;
        }

        public bool GetKey(String keyName, out IKey iKey)
        {
            if (m_keys.TryGetValue(keyName, out iKey))
            {
                return true;
            }
            return false;
        }

        public bool IsAnalogKey(String keyName)
        {
            IKey iKey;
            if (m_keys.TryGetValue(keyName, out iKey))
            {
                return iKey.IsAnalog;
            }
            return false;
        }

        public bool IsLinkKey(String keyName)
        {
            IKey iKey;
            if (m_keys.TryGetValue(keyName, out iKey))
            {
                return iKey.IsLink;
            }
            return false;
        }
    }
}
