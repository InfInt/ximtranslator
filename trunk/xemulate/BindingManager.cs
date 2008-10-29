using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    class BindingManager
    {
        private Dictionary<DxI.Key, List<InputEvent>> m_keyboardBindings;
        private Dictionary<Mouse.Button, List<InputEvent>> m_mouseBindings;
        private Dictionary<Joystick.Button, List<InputEvent>> m_joyBindings;
        private Dictionary<Joystick.Analog, AnalogEvent> m_joyAnalogBindings;

        private BindingManager()
        {
            m_keyboardBindings = new Dictionary<DxI.Key, List<InputEvent>>(40);
            m_mouseBindings = new Dictionary<Mouse.Button, List<InputEvent>>(10);
            m_joyBindings = new Dictionary<Joystick.Button, List<InputEvent>>(10);
            m_joyAnalogBindings = new Dictionary<Joystick.Analog,AnalogEvent>(5);
        }

        public static BindingManager Instance
        {
            get { return Singleton<BindingManager>.Instance; }
        }

        public void SetKeyBind(DxI.Key key, List<InputEvent> eventList)
        {
            m_keyboardBindings[key] = eventList;
        }

        public bool GetKeyBind(DxI.Key key, out List<InputEvent> eventList)
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

        public void SetJoyBind(Joystick.Button button, List<InputEvent> eventList)
        {
            m_joyBindings[button] = eventList;
        }

        public bool GetJoyBind(Joystick.Button button, out List<InputEvent> eventList)
        {
            if (m_joyBindings.ContainsKey(button))
            {
                eventList = m_joyBindings[button];
                return true;
            }
            eventList = new List<InputEvent>();
            return false;
        }

        public bool IsBound(Joystick.Button button)
        {
            return m_joyBindings.ContainsKey(button);
        }

        public void SetJoyBind(Joystick.Analog button, AnalogEvent inputEvent)
        {
            m_joyAnalogBindings[button] = inputEvent;
        }

        public bool GetJoyBind(Joystick.Analog button, out AnalogEvent inputEvent)
        {
            if (m_joyAnalogBindings.ContainsKey(button))
            {
                inputEvent = m_joyAnalogBindings[button];
                return true;
            }
            inputEvent = null;
            return false;
        }

        public Dictionary<Joystick.Analog, AnalogEvent> GetJoyAnalogBinds()
        {
            return m_joyAnalogBindings;
        }

        public bool IsBound(Joystick.Analog button)
        {
            return m_joyAnalogBindings.ContainsKey(button);
        }

        public bool IsBound(DxI.Key key)
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
            foreach (KeyValuePair<DxI.Key, List<InputEvent>> pair in m_keyboardBindings)
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

            foreach (KeyValuePair<Joystick.Button, List<InputEvent>> pair in m_joyBindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }

            foreach (KeyValuePair<Joystick.Analog, AnalogEvent> pair in m_joyAnalogBindings)
            {
                binds.Add("bind " + pair.Key.ToString().ToLower() + " " + pair.Value.ToString()+";");
            }
        }

        public String GetBindString(DxI.Key key)
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

        public String GetBindString(Joystick.Button key)
        {
            String s;
            if (m_joyBindings.ContainsKey(key))
            {
                GetEventAsString(m_joyBindings[key], out s);
            }
            else
                s = "Key \"" + key.ToString().ToLower() + "\" not bound to anything";
            return s;
        }

        public String GetBindString(Joystick.Analog key)
        {
            String s;
            if (m_joyAnalogBindings.ContainsKey(key))
            {
                s = "bind " + key.ToString().ToLower() + " " + m_joyAnalogBindings[key].ToString() + ";";
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
