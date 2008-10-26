using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;

namespace X2
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
            m_futureEvents = new List<InputEvent>(futureEvents);
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
                }
            }

            return !(m_currentEvents.Count == 0 && m_futureEventIndex >= m_futureEvents.Count) ;
        }

        public abstract bool Run(double elapsed, 
            List<Mouse.Button> pressedMouseButtons,
            List<Win32Api.VirtualKeys> pressedKeys, 
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
            List<Mouse.Button> pressedMouseButtons,
            List<Win32Api.VirtualKeys> pressedKeys,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedMouseButtons.Contains(m_button);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }

    class KeyboardEventHandler : InputEventHandler
    {
        private Win32Api.VirtualKeys m_key;
        private bool m_stillPressed = true;

        public KeyboardEventHandler(Win32Api.VirtualKeys key, List<InputEvent> futureEvents)
            : base(futureEvents)
        {
            m_key = key;
        }

        public override bool Run(double elapsed,
            List<Mouse.Button> pressedMouseButtons,
            List<Win32Api.VirtualKeys> pressedKeys,
            ref Xim.Input input,
            ref Xim.Input startState)
        {
            m_stillPressed = m_stillPressed && pressedKeys.Contains(m_key);
            return base.Run(elapsed, m_stillPressed, ref input, ref startState);
        }
    }
}
