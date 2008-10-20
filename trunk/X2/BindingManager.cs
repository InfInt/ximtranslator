using System;
using System.Collections.Generic;
using System.Text;
using DxI = Microsoft.DirectX.DirectInput;

namespace X2
{
    class BindingManager
    {
        private Dictionary<Win32Api.VirtualKeys, List<InputEvent>> m_keyboardBindings;
        private Dictionary<Mouse.Button, List<InputEvent>> m_mouseBindings;

        private BindingManager()
        {
            m_keyboardBindings = new Dictionary<Win32Api.VirtualKeys, List<InputEvent>>();
            m_mouseBindings = new Dictionary<Mouse.Button, List<InputEvent>>();
        }

        public static BindingManager Instance
        {
            get { return Singleton<BindingManager>.Instance; }
        }

        public void SetKeyBind(Win32Api.VirtualKeys key, List<InputEvent> eventList)
        {
            m_keyboardBindings[key] = eventList;
        }

        public bool GetKeyBind(Win32Api.VirtualKeys key, out List<InputEvent> eventList)
        {
            if (m_keyboardBindings.ContainsKey(key))
            {
                eventList = m_keyboardBindings[key];
                return true;
            }
            eventList = new List<InputEvent>();
            return false;
        }

        public bool IsBound(Mouse.Button key)
        {
            return m_mouseBindings.ContainsKey(key);
        }

        public bool IsBound(Win32Api.VirtualKeys key)
        {
            return m_keyboardBindings.ContainsKey(key);
        }

        public void SetMouseBind(Mouse.Button key, List<InputEvent> eventList)
        {
            m_mouseBindings[key] = eventList;
        }

        public bool GetMouseBind(Mouse.Button key, out List<InputEvent> eventList)
        {
            if (m_mouseBindings.ContainsKey(key))
            {
                eventList = m_mouseBindings[key];
                return true;
            }
            eventList = new List<InputEvent>();
            return false;
        }

        public void GetBindStringArray(out List<String> binds)
        {
            binds = new List<String>();
            foreach (KeyValuePair<Win32Api.VirtualKeys, List<InputEvent>> pair in m_keyboardBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }

            foreach (KeyValuePair<Mouse.Button, List<InputEvent>> pair in m_mouseBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }
        }

        public String GetBindString(Win32Api.VirtualKeys key)
        {
            String s;
            if (m_keyboardBindings.ContainsKey(key))
            {
                GetEventAsString(m_keyboardBindings[key], out s);
            }
            else
                s = "Key \""+key.ToString().ToLower()+"\" not bound to anything";
            return s;
        }

        public String GetBindString(Mouse.Button key)
        {
            String s;
            if (m_mouseBindings.ContainsKey(key))
            {
                GetEventAsString(m_mouseBindings[key], out s);
            }
            else
                s = "Key \"" + key.ToString().ToLower() + "\" not bound to anything";
            return s;
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
        }
    }
}
