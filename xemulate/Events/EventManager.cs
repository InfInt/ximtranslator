using System;
using System.Collections.Generic;
using System.Text;
using XimApi;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    public class PressedState
    {
        public List<Mouse.Button> mouseButtons;
        public List<DxI.Key> keys;
        public List<Joystick.Button> joyButtons;
        public DxI.JoystickState joyState;
    };

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

        public void ClearEvents()
        {
            m_inputEventHandlers.Clear();
        }

        public void FireKeyDownEvent(DxI.Key key)
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

        public void FireButtonDownEvent(Joystick.Button button)
        {
            // Key is now down, check if there is an event for this key and fire it.
            List<InputEvent> events;
            if (m_bindingManager.GetJoyBind(button, out events))
            {
                InputEventHandler inputEventHandler = new JoyEventHandler(button, events);
                m_inputEventHandlers.Add(inputEventHandler);
            }
        }

        public void QueueAnalogJoyBinds()
        {
            // Key is now down, check if there is an event for this key and fire it.
            Dictionary<Joystick.Analog, AnalogEvent> binds;
            binds = m_bindingManager.GetJoyAnalogBinds();
            foreach (KeyValuePair<Joystick.Analog, AnalogEvent> pair in binds )
            {
                InputEventHandler inputEventHandler = new JoyAnalogEventHandler(pair.Key, pair.Value);
                m_inputEventHandlers.Add(inputEventHandler);
            }
        }

        public void ProcessEvents(double elapsed, ref Xim.Input input, ref Xim.Input startState)
        {
            PressedState pressedState = new PressedState();
            pressedState.mouseButtons = m_inputManager.GetMouseButtons();
            pressedState.keys = m_inputManager.GetPressedKeys();
            pressedState.joyButtons = m_inputManager.GetJoyButtons();
            pressedState.joyState = m_inputManager.GetJoyState();
            Stack<InputEventHandler> finishedHandlers = new Stack<InputEventHandler>();
            foreach (InputEventHandler inputEventHandler in m_inputEventHandlers)
            {
                if (!inputEventHandler.Run(elapsed, pressedState, ref input, ref startState))
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
