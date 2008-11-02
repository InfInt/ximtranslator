using System;
using System.Collections.Generic;
using System.Text;
using Common;
using XimApi;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    class BindingManager
    {
        private Dictionary<InputKey<DxI.Key>, List<InputEvent>> m_keyboardBindings = new Dictionary<InputKey<DxI.Key>, List<InputEvent>>(40);
        private Dictionary<InputKey<Mouse.Button>, List<InputEvent>> m_mouseBindings = new Dictionary<InputKey<Mouse.Button>, List<InputEvent>>(10);
        private Dictionary<InputKey<Joystick.Button>, List<InputEvent>> m_joyBindings = new Dictionary<InputKey<Joystick.Button>, List<InputEvent>>(10);
        private Dictionary<InputKey<Joystick.Analog>, List<InputEvent>> m_joyAnalogBindings = new Dictionary<InputKey<Joystick.Analog>, List<InputEvent>>(5);
        private Dictionary<InputKey<Xim.Button>, List<InputEvent>> m_linkBindings = new Dictionary<InputKey<Xim.Button>, List<InputEvent>>(5);
        private SortedDictionary<String, DxI.Key> m_keyMap = new SortedDictionary<String, DxI.Key>();
        private SortedDictionary<String, Mouse.Button> m_mouseMap = new SortedDictionary<String, Mouse.Button>();
        private SortedDictionary<String, Joystick.Button> m_joyMap = new SortedDictionary<String, Joystick.Button>();
        private SortedDictionary<String, Joystick.Analog> m_joyAnalogMap = new SortedDictionary<String, Joystick.Analog>();
        private SortedDictionary<String, Xim.Button> m_linkMap = new SortedDictionary<String, Xim.Button>();
        
        private BindingManager()
        {
            PopulateKeyMap(typeof(DxI.Key), m_keyMap);
            PopulateKeyMap(typeof(Mouse.Button), m_mouseMap);
            PopulateKeyMap(typeof(Joystick.Button), m_joyMap);
            PopulateKeyMap(typeof(Joystick.Analog), m_joyAnalogMap);
            PopulateKeyMap(typeof(Xim.Button), m_linkMap);
        }

        public static BindingManager Instance
        {
            get { return Singleton<BindingManager>.Instance; }
        }

        private static void PopulateKeyMap<T>(Type type, SortedDictionary<String, T> dict)
        {
            String[] keyNames = Enum.GetNames(type);
            Array keys = Enum.GetValues(type);
            for (int i = 0; i < keyNames.Length; i++)
            {
                dict.Add(keyNames[i].ToLower(), (T)keys.GetValue(i));
            }
        }

        public bool IsKey(String keyName)
        {
            return m_keyMap.ContainsKey(keyName)
                || m_mouseMap.ContainsKey(keyName)
                || m_joyMap.ContainsKey(keyName);
        }

        public bool IsAnalogKey(String keyName)
        {
            return m_joyAnalogMap.ContainsKey(keyName);
        }

        public bool IsLinkKey(String keyName)
        {
            return m_linkMap.ContainsKey(keyName);
        }

        private Dictionary<KeyType, List<InputEvent>> GetBindingDict<KeyType>(KeyType key)
        {
            if (key is InputKey<DxI.Key>)
                return m_keyboardBindings as Dictionary<KeyType, List<InputEvent>>;
            else if (key is InputKey<Mouse.Button>)
                return m_mouseBindings as Dictionary<KeyType, List<InputEvent>>;
            else if (key is InputKey<Joystick.Button>)
                return m_joyBindings as Dictionary<KeyType, List<InputEvent>>;
            else if (key is InputKey<Joystick.Analog>)
                return m_joyAnalogBindings as Dictionary<KeyType, List<InputEvent>>;
            else if (key is InputKey<Xim.Button>)
                return m_linkBindings as Dictionary<KeyType, List<InputEvent>>;
            return null;
        }

        public void SetKeyBind(String key, List<InputEvent> events)
        {
            if (m_keyMap.ContainsKey(key))
                SetKeyBind(InputKey.Make(m_keyMap[key]),events);
            else if (m_mouseMap.ContainsKey(key))
                SetKeyBind(InputKey.Make(m_mouseMap[key]), events);
            else if (m_joyMap.ContainsKey(key))
                SetKeyBind(InputKey.Make(m_joyMap[key]), events);
            else if (m_joyAnalogMap.ContainsKey(key))
                SetKeyBind(InputKey.Make(m_joyAnalogMap[key]), events);
            else if (m_linkMap.ContainsKey(key))
                SetKeyBind(InputKey.Make(m_linkMap[key]), events);
        }

        private void SetKeyBind<KeyType>(KeyType key, List<InputEvent> val) where KeyType : IKey
        {
            GetBindingDict(key)[key] = val;
        }

        public bool GetKeyBind<KeyType>(KeyType key, out List<InputEvent> val) where KeyType : IKey
        {
            Dictionary<KeyType, List<InputEvent>> dict = GetBindingDict(key);
            if (dict.ContainsKey(key))
            {
                val = dict[key];
                return true;
            }
            val = default(List<InputEvent>);
            return false;
        }

        public bool IsBound<KeyType>(KeyType key) where KeyType : IKey
        {
            return GetBindingDict<KeyType>(key).ContainsKey(key);
        }

        public String GetBindString(String key)
        {
            if (m_keyMap.ContainsKey(key))
                return GetBindString(InputKey.Make(m_keyMap[key]));
            else if (m_mouseMap.ContainsKey(key))
                return GetBindString(InputKey.Make(m_mouseMap[key]));
            else if (m_joyMap.ContainsKey(key))
                return GetBindString(InputKey.Make(m_joyMap[key]));
            else if (m_joyAnalogMap.ContainsKey(key))
                return GetBindString(InputKey.Make(m_joyAnalogMap[key]));
            else if (m_linkMap.ContainsKey(key))
                return GetBindString(InputKey.Make(m_linkMap[key]));
            return default(String);
        }

        public String GetBindString<KeyType>(KeyType key) where KeyType : IKey
        {
            String s;
            if (GetBindingDict(key).ContainsKey(key))
            {
                GetEventAsString(GetBindingDict(key)[key], out s);
            }
            else
                s = "Key \"" + key.ToString().ToLower() + "\" not bound/linked to anything";
            return s;
        }

        public void Unbind(String key)
        {
            if (m_keyMap.ContainsKey(key))
                Unbind(m_keyMap[key]);
            else if (m_mouseMap.ContainsKey(key))
                Unbind(m_mouseMap[key]);
            else if (m_joyMap.ContainsKey(key))
                Unbind(m_joyMap[key]);
            else if (m_joyAnalogMap.ContainsKey(key))
                Unbind(m_joyAnalogMap[key]);
            else if (m_linkMap.ContainsKey(key))
                Unbind(m_linkMap[key]);
        }

        private void Unbind<KeyType>(KeyType key)
        {
            InputKey<KeyType> ikey = InputKey.Make(key);
            if (GetBindingDict(ikey).ContainsKey(ikey))
            {
                GetBindingDict(ikey).Remove(ikey);
            }
        }

        public Dictionary<InputKey<Joystick.Analog>, List<InputEvent>> GetJoyAnalogBinds()
        {
            return m_joyAnalogBindings;
        }

        public void GetBindStringArray(out List<String> binds)
        {
            binds = new List<String>();
            foreach (KeyValuePair<InputKey<DxI.Key>, List<InputEvent>> pair in m_keyboardBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }

            foreach (KeyValuePair<InputKey<Mouse.Button>, List<InputEvent>> pair in m_mouseBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }

            foreach (KeyValuePair<InputKey<Joystick.Button>, List<InputEvent>> pair in m_joyBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }

            foreach (KeyValuePair<InputKey<Joystick.Analog>, List<InputEvent>> pair in m_joyAnalogBindings)
            {
                if(pair.Value.Count == 1)
                    binds.Add("bind " + pair.Key.ToString().ToLower() + " " + pair.Value[0].ToString()+";");
            }

            foreach (KeyValuePair<InputKey<Xim.Button>, List<InputEvent>> pair in m_linkBindings)
            {
                if(pair.Value.Count == 1)
                    binds.Add("link " + pair.Key.ToString().ToLower() + " " + pair.Value[0].ToString()+";");
            }
        }

        private void GetEventAsString(List<InputEvent> events, out String strBind)
        {
            StringBuilder s = new StringBuilder();
            foreach( InputEvent inputEvent in events )
            {
                s.Append(inputEvent.ToString() + ";");
            }
            strBind = s.ToString();
        }

        public void UnbindAll()
        {
            m_mouseBindings.Clear();
            m_keyboardBindings.Clear();
            m_joyAnalogBindings.Clear();
            m_joyBindings.Clear();
            m_linkMap.Clear();
        }
    }
}
