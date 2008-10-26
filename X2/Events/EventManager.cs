using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;

namespace X2
{
    class EventManager
    {
        private List<InputEventHandler> m_inputEventHandlers;
        private BindingManager m_bindingManager;
        private InputManager m_inputManager;
        
        private EventManager()
        {
            m_inputEventHandlers = new List<InputEventHandler>();
            m_bindingManager = BindingManager.Instance;
            m_inputManager = InputManager.Instance;
        }

        public static EventManager Instance
        {
            get { return Singleton<EventManager>.Instance; }
        }

        public void FireKeyDownEvent(Win32Api.VirtualKeys key)
        {
            // Key is now down, check if there is an event for this key and fire it.
            List<InputEvent> events;
            if (m_bindingManager.GetKeyBind(key, out events))
            {
                InputEventHandler inputEventHandler = new KeyboardEventHandler(key, events);
                m_inputEventHandlers.Add(inputEventHandler);
            }
        }

        public void FireButtonDownEvent(Mouse.Button button)
        {
            // Key is now down, check if there is an event for this key and fire it.
            List<InputEvent> events;
            if (m_bindingManager.GetMouseBind(button, out events))
            {
                InputEventHandler inputEventHandler = new MouseEventHandler(button, events);
                m_inputEventHandlers.Add(inputEventHandler);
            }
        }

        public void ProcessEvents(double elapsed, ref Xim.Input input, ref Xim.Input startState)
        {
            List<Win32Api.VirtualKeys> pressedKeys = m_inputManager.GetPressedKeys();
            List<Mouse.Button> pressedButtons = m_inputManager.GetMouseButtons();
            Stack<InputEventHandler> finishedHandlers = new Stack<InputEventHandler>();
            foreach (InputEventHandler inputEventHandler in m_inputEventHandlers)
            {
                if (!inputEventHandler.Run(elapsed, pressedButtons, pressedKeys, ref input, ref startState))
                {
                    finishedHandlers.Push(inputEventHandler);
                }
            }

            while (finishedHandlers.Count != 0)
            {
                m_inputEventHandlers.Remove(finishedHandlers.Pop());
            }
        }
    }
}
