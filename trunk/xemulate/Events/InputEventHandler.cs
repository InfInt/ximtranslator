using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;
using DxI = Microsoft.DirectX.DirectInput;
using Xna = Microsoft.Xna.Framework;

namespace xEmulate
{
    abstract class InputEventHandler
    {
        private List<InputEvent> m_currentEvents;
        private List<InputEvent> m_futureEvents;
        private int m_futureEventIndex;
        private InputEvent m_blockingEvent;
        private bool m_blocking;

        public InputEventHandler(List<InputEvent> futureEvents)
        {
            if (futureEvents != null)
            {
                m_futureEvents = new List<InputEvent>(futureEvents);
            }
            m_currentEvents = new List<InputEvent>();
            m_futureEventIndex = 0;
            m_blocking = false;
        }


        protected bool Run(double elapsed, bool keyStillPressed, ref Xim.Input input, ref Xim.Input startState)
        {
            Stack<InputEvent> finishedEvents = new Stack<InputEvent>();
            foreach (InputEvent inputEvent in m_currentEvents)
            {
                if (inputEvent.Run(false/*firstRun*/, elapsed, keyStillPressed, ref input, ref startState ) == InputEvent.Status.Complete )
                {
                    finishedEvents.Push(inputEvent);
                }
            }

            while (finishedEvents.Count!=0)
            {
                m_currentEvents.Remove(finishedEvents.Pop());
            }

            if (m_blocking)
            {
                InputEvent.Status status = m_blockingEvent.Run(false/*firstRun*/, elapsed, keyStillPressed, ref input, ref startState);
                switch (status)
                {
                    case InputEvent.Status.Complete:
                        m_blocking = false;
                        break;
                    case InputEvent.Status.Running:
                        m_blocking = false;
                        m_currentEvents.Add(m_blockingEvent.Clone());
                        break;
                }
            }

            if (!m_blocking)
            {
                while (m_futureEventIndex < m_futureEvents.Count)
                {
                    InputEvent nextEvent = m_futureEvents[m_futureEventIndex];
                    InputEvent.Status status = nextEvent.Run(true/*firstRun*/, elapsed, keyStillPressed, ref input, ref startState);
                    
                    m_futureEventIndex++;
                    
                    if (status == InputEvent.Status.Blocking)
                    {
                        m_blockingEvent = nextEvent.Clone();
                        m_blocking = true;
                        break;
                    }
                    else if (status == InputEvent.Status.Running)
                    {
                        m_currentEvents.Add(nextEvent.Clone());
                    }
                    else if (status == InputEvent.Status.Break)
                    {
                        m_futureEventIndex = m_futureEvents.Count;
                    }
                }
            }

            return !(m_currentEvents.Count == 0 && m_futureEventIndex >= m_futureEvents.Count);
        }

        public abstract bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input, 
            ref Xim.Input startState);
    }

    class MouseEventHandler : InputEventHandler
    {
        private Mouse.Button m_button;
        private bool m_stillPressed = true;

        public MouseEventHandler(Mouse.Button button, List<InputEvent> futureEvents)
            :base(futureEvents)
        {
            m_button = button;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedState.mouseButtons.Contains(m_button);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }

    class KeyboardEventHandler : InputEventHandler
    {
        private DxI.Key m_key;
        private bool m_stillPressed = true;

        public KeyboardEventHandler(DxI.Key key, List<InputEvent> futureEvents)
            : base(futureEvents)
        {
            m_key = key;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedState.keys.Contains(m_key);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }

    class JoyEventHandler : InputEventHandler
    {
        private Joystick.Button button;
        private bool m_stillPressed = true;

        public JoyEventHandler(Joystick.Button button, List<InputEvent> futureEvents)
            : base(futureEvents)
        {
            this.button = button;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedState.joyButtons.Contains(this.button);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }

    class JoyAnalogEventHandler : InputEventHandler
    {
        private Joystick.Analog button;
        private AnalogEvent inputEvent;

        public JoyAnalogEventHandler(Joystick.Analog button, AnalogEvent inputEvent)
            : base(null)
        {
            this.button = button;
            this.inputEvent = inputEvent;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            int analogVal = 0;
            switch (button)
            {
                case Joystick.Analog.JoyRx:
                    analogVal = pressedState.joyState.Rx;
                    break;
                case Joystick.Analog.JoyRy:
                    analogVal = pressedState.joyState.Ry;
                    break;
                case Joystick.Analog.JoyRz:
                    analogVal = pressedState.joyState.Rz;
                    break;
                case Joystick.Analog.JoyX:
                    analogVal = pressedState.joyState.X;
                    break;
                case Joystick.Analog.JoyY:
                    analogVal = pressedState.joyState.Y;
                    break;
                case Joystick.Analog.JoyZ:
                    analogVal = pressedState.joyState.Z;
                    break;
                case Joystick.Analog.JoySlider0:
                    {
                        int[] sliders = pressedState.joyState.GetSlider();
                        if (sliders != null && sliders.Length != 0)
                        {
                            analogVal = pressedState.joyState.GetSlider()[0];
                        }
                        else
                        {
                            InfoTextManager.Instance.WriteLine("There is an active bind for Slider0 but no sliders are available on this controller");
                            return false;
                        }
                    }
                    break;
                case Joystick.Analog.JoySlider1:
                    {
                        int[] sliders = pressedState.joyState.GetSlider();
                        if (sliders != null && sliders.Length != 0)
                        {
                            analogVal = pressedState.joyState.GetSlider()[1];
                        }
                        else
                        {
                            InfoTextManager.Instance.WriteLine("There is an active bind for Slider1 but no sliders are available on this controller");
                            return false;
                        }
                    }
                    break;
                default:
                    return false;
            }

            inputEvent.Run(false, elapsed, analogVal, ref input, ref startState);
            return true;
        }
    }

    class XInputEventHandler : InputEventHandler
    {
        private Xna.Input.Buttons button;
        private bool m_stillPressed = true;

        public XInputEventHandler(Xna.Input.Buttons button, List<InputEvent> futureEvents)
            : base(futureEvents)
        {
            this.button = button;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedState.xinputState.IsButtonDown(this.button);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }

    class XInputAnalogEventHandler : InputEventHandler
    {
        private Xim.Analog button;
        private AnalogEvent inputEvent;

        public XInputAnalogEventHandler(Xim.Analog button, AnalogEvent inputEvent)
            : base(null)
        {
            this.button = button;
            this.inputEvent = inputEvent;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            int analogVal = 0;
            float controllerValue = 0;
            switch (button)
            {
                case Xim.Analog.LeftStickX:
                    controllerValue = pressedState.xinputState.ThumbSticks.Left.X;
                    break;
                case Xim.Analog.LeftStickY:
                    controllerValue = pressedState.xinputState.ThumbSticks.Left.Y;
                    break;
                case Xim.Analog.LeftTrigger:
                    controllerValue = pressedState.xinputState.Triggers.Left;
                    break;
                case Xim.Analog.RightStickX:
                    controllerValue = pressedState.xinputState.ThumbSticks.Right.X;
                    break;
                case Xim.Analog.RightStickY:
                    controllerValue = pressedState.xinputState.ThumbSticks.Right.Y;
                    break;
                case Xim.Analog.RightTrigger:
                    controllerValue = pressedState.xinputState.Triggers.Right;
                    break;
                default:
                    return false;
            }

            analogVal = (int)(controllerValue * (int)Xim.Stick.Max + (int)Xim.Stick.Max);

            inputEvent.Run(false, elapsed, analogVal, ref input, ref startState);
            return true;
        }
    }

    class LinkEventHandler : InputEventHandler
    {
        private Xim.Button button;
        private bool m_stillPressed = true;

        public LinkEventHandler(Xim.Button button, List<InputEvent> futureEvents)
            : base(futureEvents)
        {
            this.button = button;
        }

        public override bool Run(double elapsed,
            PressedState pressedState,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && Xim.GetButtonState(button, ref input) == Xim.ButtonState.Pressed;
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }
}
