using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    class CommandParser
    {
        private static char[] c_delims = { ';' };
        private static char[] c_spacedelim = { ' ' };

        private SortedDictionary<String, Xim.Button> m_buttonMap = new SortedDictionary<String, Xim.Button>();
        private SortedDictionary<String, Xim.Analog> m_ximAnalogMap =  new SortedDictionary<String, Xim.Analog>();
        
        private BindingManager m_bindingManager;
        private InfoTextManager m_infoTextManager;
        private VarManager m_varManager;

        public CommandParser()
        {
            m_infoTextManager = InfoTextManager.Instance;
            m_bindingManager = BindingManager.Instance;
            m_varManager = VarManager.Instance;

            foreach (Xim.Button button in Enum.GetValues(typeof(Xim.Button)))
            {
                String name = Enum.GetName(typeof(Xim.Button), button);
                m_buttonMap.Add(name.ToLower(), button);
            }

            foreach (Xim.Analog button in Enum.GetValues(typeof(Xim.Analog)))
            {
                String name = Enum.GetName(typeof(Xim.Analog), button);
                m_ximAnalogMap.Add(name.ToLower(), button);
            }
        }

        public bool ParseLine(String line)
        {
            if (line.StartsWith("unbindall"))
            {
                m_bindingManager.UnbindAll();
                return true;
            }
            if (line.StartsWith("bind "))
            {
                line = line.Substring(5);
                int firstSpace = line.IndexOf(' ');
                if (firstSpace == -1)
                    firstSpace = line.Length;
                String key = line.Substring(0,firstSpace);

                if (key == line)
                {
                    // Just display the current bind for that key if one exists.
                    if (m_bindingManager.IsKey(key) || m_bindingManager.IsAnalogKey(key))
                    {
                        m_infoTextManager.WriteLine(m_bindingManager.GetBindString(key));
                        return true;
                    }
                }
                else
                {
                    String macro = line.Substring(firstSpace + 1);
                    if (m_bindingManager.IsKey(key))
                    {
                        List<InputEvent> events;
                        CreateEventList(macro, out events);
                        if (events.Count > 0)
                        {
                            m_bindingManager.SetKeyBind(key, events);
                            return true;
                        }
                    }
                    else if (m_bindingManager.IsAnalogKey(key))
                    {
                        macro = macro.TrimEnd(c_delims);
                        AnalogEvent analogEvent;
                        if (CreateAnalogEvent(macro, out analogEvent))
                        {
                            List<InputEvent> events = new List<InputEvent>();
                            events.Add(analogEvent);
                            m_bindingManager.SetKeyBind(key, events);
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (line.IndexOf(' ') == -1 && m_varManager.IsVar(line))
                {
                    VarManager.Var v;
                    m_varManager.GetVar(line, out v);
                    m_infoTextManager.Write(" = " + v.Value + Environment.NewLine +
                                            v.Info);
                    return true;
                }
                else
                {
                    List<InputEvent> events;
                    CreateEventList(line, out events);
                    if (events.Count >= 1)
                    {
                        foreach (InputEvent inputEvent in events)
                        {
                            Xim.Input input = new Xim.Input();
                            inputEvent.Run(true, 0, false, ref input, ref input);
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CreateSetVarEvent(VarManager.Var v, String val, out SetVarEvent e)
        {
            Object valAsObject;
            if (v.CanSetValue(val, out valAsObject))
            {
                e = new SetVarEvent(v, valAsObject);
                return true;
            }
            e = new SetVarEvent(null, null);
            return false;
        }

        public bool CreateAnalogEvent(String macro, out AnalogEvent analogEvent)
        {
            String[] tokens = macro.Split( c_spacedelim );
            if(tokens.Length > 0 && m_ximAnalogMap.ContainsKey(tokens[0]))
            {
                Xim.Analog ximAnalog;
                ximAnalog = m_ximAnalogMap[tokens[0]];
                int deadzone = 0;
                Joystick.AnalogFlags flags = 0;

                for( uint i = 1;i < tokens.Length ; i++)
                {
                    int tryDeadzone;
                    String token = tokens[i];
                    if (token.StartsWith("-"))
                    {
                        // parse modifiers.
                        token = token.Substring(1);
                        Joystick.AnalogFlags flag = (Joystick.AnalogFlags)Enum.Parse(typeof(Joystick.AnalogFlags), token, true);
                        flags |= flag;
                    }
                    else if (int.TryParse(token, out tryDeadzone))
                    {
                        deadzone = tryDeadzone;
                    }
                }
                analogEvent = new AnalogEvent(ximAnalog, deadzone, flags);
                return true;
            }
            
            analogEvent = default(AnalogEvent);
            return false;
        }

        public bool CreateEventList(String macro, out List<InputEvent> events)
        {
            events = new List<InputEvent>();
            String[] tokens = macro.Split( c_delims );
            for (int i=0;i<tokens.Length;i++)
            {
                String token = tokens[i];
                // Ignore this but it isnt an error.
                if (token.Length == 0)
                    continue;

                if (token.StartsWith("exec"))
                {
                    String[] execTokens = token.Split(c_spacedelim);
                    if (execTokens.Length == 2)
                    {
                        events.Add(new LoadConfigEvent(execTokens[1]));
                    }
                }
                else if (token.StartsWith("echo"))
                {
                    String[] execTokens = token.Split(c_spacedelim);
                    if (execTokens.Length == 2)
                    {
                        events.Add(new EchoEvent(execTokens[1]));
                    }
                }
                else if(token.StartsWith("set"))
                {
                    String[] setTokens = token.Split(c_spacedelim);
                    if (setTokens.Length == 3)
                    {
                        VarManager.Var v;
                        if (m_varManager.GetVar(setTokens[1], out v))
                        {
                            SetVarEvent setVarEvent;
                            if(CreateSetVarEvent(v, setTokens[2], out setVarEvent))
                                events.Add(setVarEvent);
                        }
                    }
                }
                else if (token.StartsWith("wait"))
                {
                    String[] waitTokens = token.Split( c_spacedelim );
                    if( waitTokens.Length == 2 )
                    {
                        double waitTimeInMs = 0;
                        if (double.TryParse(waitTokens[1], out waitTimeInMs))
                        {
                            events.Add(new WaitEvent(waitTimeInMs));
                        }
                    }
                }
                else if (token[0] == '+')
                {
                    token = token.Substring(1);
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new PressEvent(button, Xim.ButtonState.Pressed));
                    }
                }
                else if (token[0] == '-')
                {
                    token = token.Substring(1);
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new PressEvent(button, Xim.ButtonState.Released));
                    }
                }
                else if (token[0] == '.')
                {
                    token = token.Substring(1);
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new HoldEvent(button));
                    }
                    else if (m_varManager.IsVar(token))
                    {
                        // Toggle var events must be applied to bools.
                        VarManager.Var v;
                        m_varManager.GetVar(token, out v);
                        if (v.VarType == typeof(bool))
                        {
                            events.Add(new HoldVarEvent(ref v, true));
                        }
                    }
                }
                else if (token[0] == '!')
                {
                    token = token.Substring(1);
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new ToggleEvent(button));
                    }
                    else if (m_varManager.IsVar(token))
                    {
                        // Toggle var events must be applied to bools.
                        VarManager.Var v;
                        m_varManager.GetVar(token, out v);
                        if (v.VarType == typeof(bool))
                        {
                            events.Add(new ToggleVarEvent(ref v));
                        }
                    }
                }
                else if (token[0] == '*')
                {
                    token = token.Substring(1);
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new RapidEvent(button));
                    }
                }
                else if (m_buttonMap.ContainsKey(token))
                {
                    Xim.Button button;
                    if (m_buttonMap.TryGetValue(token, out button))
                    {
                        events.Add(new ButtonEvent(button));
                    }
                } 
                else
                {
                    String[] setTokens = token.Split(c_spacedelim);
                    if (setTokens.Length == 2)
                    {
                        VarManager.Var v;
                        if (m_varManager.GetVar(setTokens[0], out v))
                        {
                            SetVarEvent setVarEvent;
                            if( CreateSetVarEvent(v, setTokens[1], out setVarEvent) )
                                events.Add(setVarEvent);
                        }
                    }
                }
            }
            return true;
        }
       
    }
}
