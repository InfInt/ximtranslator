using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;

namespace xEmulate
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
        private VarManager.Var buttonDownTime;
        private double m_elapsed = 0;

        public ButtonEvent(Xim.Button button)
        {
            m_button = button;
            VarManager.Instance.GetVar(VarManager.Names.ButtonDownTime, out buttonDownTime);
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            Xim.SetButtonState(m_button, Xim.ButtonState.Pressed, ref input);

            if (!firstRun)
                m_elapsed += elapsed;

            return m_elapsed > (double)(int)buttonDownTime.Value ? InputEvent.Status.Complete : InputEvent.Status.Running;
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
        private Xim.Button button;
        private double delay;
        private double elapsed = 0;

        public RapidEvent(Xim.Button button, double delay)
        {
            this.button = button;
            this.delay = delay;
        }

        public override Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if (keyStillPressed)
            {
                if (firstRun)
                {
                    Xim.ToggleButtonState(this.button, ref input);
                    //Xim.ToggleButtonState(this.button, ref startState);
                }
                else
                {
                    this.elapsed += elapsed;
                    if (this.elapsed > delay)
                    {
                        this.elapsed = this.elapsed - delay;
                        Xim.ToggleButtonState(this.button, ref startState);
                    }
                }
            }
            else
            {
                Xim.SetButtonState(this.button, Xim.ButtonState.Released, ref startState);
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            String delayStr = "";
            if (this.delay > 0)
                delayStr = " " +this.delay.ToString();
            return "*" + this.button.ToString().ToLower() + delayStr;
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

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class HoldAnalogEvent : InputEvent
    {
        private Xim.Analog m_button;
        private short analogVal;

        public HoldAnalogEvent(Xim.Analog button, short analogVal)
        {
            m_button = button;
            this.analogVal = analogVal;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            if (keyStillPressed)
            {
                Xim.SetAnalogState(m_button, this.analogVal, ref input);
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            return "." + m_button.ToString().ToLower() + " " + analogVal.ToString(); ;
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
            m_var.Value = m_value;
            return Status.Complete;
        }

        public override string ToString()
        {
            return "set "+ m_var.VarName.ToString().ToLower() + " " + m_value.ToString().ToLower();
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
            m_var.Value = !(bool)m_var.Value;
            return Status.Complete;
        }

        public override string ToString()
        {
            return "!"+m_var.VarName.ToLower();
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
                m_oldValue = m_var.Value;
                m_var.Value = m_newValue;
            }
            if (!keyStillPressed)
            {
                m_var.Value = m_oldValue;
            }

            return keyStillPressed ? Status.Running : Status.Complete;
        }

        public override string ToString()
        {
            return "." + m_var.VarName.ToString().ToLower();
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
    class CommandLineEvent : InputEvent
    {
        String cmdLine;

        public CommandLineEvent(String cmdLine)
        {
            this.cmdLine = cmdLine;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            CommandParser.Instance.ParseLine(this.cmdLine);
            return Status.Complete;
        }

        public override string ToString()
        {
            return this.cmdLine;
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

    /*
     * Sets the state of a button on the startState, it will not release until it is reset.
     * */
    class AnalogEvent : InputEvent
    {
        private Joystick.AnalogFlags analog;
        private Xim.Analog button;
        private int deadzone;

        public AnalogEvent(Xim.Analog button, int deadzone, Joystick.AnalogFlags flags)
        {
            this.analog = flags;
            this.button = button;
            this.deadzone = deadzone;
        }

        public override InputEvent.Status Run(bool firstRun, double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            // This should never get hit.
            return Status.Complete;
        }

        public InputEvent.Status Run(bool firstRun, double elapsed, int analogVal, ref Xim.Input input, ref Xim.Input startState)
        {
            analogVal -= (int)Xim.Stick.Max;
            if ((this.analog & Joystick.AnalogFlags.Invert) != 0)
                analogVal = -analogVal;

            if (deadzone != 0 && analogVal != 0)
            {
                if ((this.analog & Joystick.AnalogFlags.Scale) != 0)
                {
                    analogVal *= (int)(Xim.Stick.Max) - deadzone / (int)(Xim.Stick.Max);
                }
                analogVal += Math.Sign(analogVal) * deadzone;
            }

            if (button == Xim.Analog.LeftTrigger || button == Xim.Analog.RightTrigger)
            {
                if ((this.analog & Joystick.AnalogFlags.Scale) != 0)
                {
                    analogVal += (int)Xim.Stick.Max;
                    analogVal = (int)((double)analogVal * 0.5);
                }
                if (analogVal < 0)
                    analogVal = 0;
            }

            Xim.AddAnalogValue(button, analogVal, ref input);
            return Status.Running;
        }

        public override string ToString()
        {
            string result = button.ToString().ToLower();
            if (deadzone != 0)
            {
                result += " " + deadzone;
            }

            if (this.analog != 0)
            {
                foreach (Joystick.AnalogFlags flag in Enum.GetValues(typeof(Joystick.AnalogFlags)))
                {
                    if ((this.analog & flag) != 0)
                        result += " -" + flag.ToString().ToLower();
                }
            }
            return result;
        }
    }
}
