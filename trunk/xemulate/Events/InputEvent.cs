using System;
using System.Collections.Generic;
using System.Text;

namespace X2
{
    

    abstract class InputEvent: ICloneable
    {
        object ICloneable.Clone()
        {
            // simply delegate to our type-safe cousin
            return this.Clone();
        }

        public enum Status
        {
            Complete,
            Blocking,
            Running
        }
        /*
         * Return value: True if the event is finished.
         * */
        public abstract Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState);
        public InputEvent Clone() { InputEvent clone = this.MemberwiseClone() as InputEvent; return clone; }
    }

    /*
     * Waits for time waitTime, in milliseconds.
     * */
    class WaitEvent : InputEvent
    {
        private double m_elapsed = 0;
        private double m_waitTime;

        public WaitEvent(double waitTime)
        {
            m_waitTime = waitTime;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if( !firstRun )
                m_elapsed+=elapsed;
            return m_elapsed > m_waitTime ? InputEvent.Status.Complete : InputEvent.Status.Blocking;
        }

        public override string ToString()
        {
            return "wait "+m_waitTime;
        }

    }

    /*
     * "Click" a button 
     * */
    class ButtonEvent : InputEvent
    {
        private Xim.Button m_button;

        public ButtonEvent(Xim.Button button)
        {
            m_button = button;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            Xim.SetButtonState(m_button, Xim.ButtonState.Pressed, ref input);
            return InputEvent.Status.Complete;
        }

        public override string ToString()
        {
            return m_button.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class PressEvent : InputEvent
    {
        private Xim.Button m_button;
        private Xim.ButtonState m_state;

        public PressEvent(Xim.Button button, Xim.ButtonState state)
        {
            m_button = button;
            m_state = state;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            Xim.SetButtonState(m_button, m_state, ref startState);
            Xim.SetButtonState(m_button, m_state, ref input);

            return InputEvent.Status.Complete;
        }

        public override string ToString()
        {
            String prefix = m_state == Xim.ButtonState.Pressed ? "+" : "-";
            return prefix + m_button.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class ToggleEvent : InputEvent
    {
        private Xim.Button m_button;

        public ToggleEvent(Xim.Button button)
        {
            m_button = button;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            Xim.ToggleButtonState(m_button, ref startState);
            Xim.ToggleButtonState(m_button, ref input);

            return Status.Complete;
        }

        public override string ToString()
        {
            return "!"+m_button.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class RapidEvent : InputEvent
    {
        private Xim.Button m_button;

        public RapidEvent(Xim.Button button)
        {
            m_button = button;
        }

        public override Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if (keyStillPressed)
            {
                if (firstRun)
                    Xim.ToggleButtonState(m_button, ref input);
                else
                    Xim.ToggleButtonState(m_button, ref startState);
            }
            else
            {
                Xim.SetButtonState(m_button, Xim.ButtonState.Released, ref startState);
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            return "*" + m_button.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class HoldEvent : InputEvent
    {
        private Xim.Button m_button;

        public HoldEvent(Xim.Button button)
        {
            m_button = button;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if (keyStillPressed)
            {
                Xim.SetButtonState(m_button, Xim.ButtonState.Pressed, ref input);
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            return "."+ m_button.ToString().ToLower();
        }
    }

    class SetVarEvent : InputEvent
    {
        VarManager.Var m_var;
        Object m_value;
        public SetVarEvent(VarManager.Var var, Object val)
        {
            m_var = var;
            m_value = val;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            m_var.value = m_value;
            return Status.Complete;
        }

        public override string ToString()
        {
            return "set "+ m_var.ToString().ToLower() + " " + m_value.ToString().ToLower();
        }
    }

    class ToggleVarEvent : InputEvent
    {
        VarManager.Var m_var;
        public ToggleVarEvent(ref VarManager.Var var)
        {
            m_var = var;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            m_var.value = !(bool)m_var.value;
            return Status.Complete;
        }

        public override string ToString()
        {
            return "!"+m_var.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class HoldVarEvent : InputEvent
    {
        VarManager.Var m_var;
        Object m_oldValue;
        Object m_newValue;

        public HoldVarEvent(ref VarManager.Var var, Object newVal)
        {
            m_var = var;
            m_newValue = newVal;
            m_oldValue = null;
        }

        public override Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if (firstRun)
            {
                m_oldValue = m_var.value;
                m_var.value = m_newValue;
            }
            if (!keyStillPressed)
            {
                m_var.value = m_oldValue;
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            return "." + m_var.varName.ToString().ToLower();
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class LoadConfigEvent : InputEvent
    {
        String m_filePath;

        public LoadConfigEvent(String filePath)
        {
            m_filePath = filePath;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            ConfigManager.Instance.LoadConfig(m_filePath);

            return Status.Complete;
        }

        public override string ToString()
        {
            return "exec "+m_filePath;
        }
    }

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class EchoEvent : InputEvent
    {
        String m_echo;

        public EchoEvent(String echo)
        {
            m_echo = echo;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            InfoTextManager.Instance.WriteLine(m_echo);

            return Status.Complete;
        }

        public override string ToString()
        {
            return "echo " + m_echo;
        }
    }

}
