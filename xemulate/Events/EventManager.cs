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
        private List<LinkEventHandler> m_linkEventHandlers;
        private BindingManager m_bindingManager;
        private InputManager m_inputManager;
        private Xim.Input lastXimInput;
        
        private EventManager()
        {
            m_inputEventHandlers = new List<InputEventHandler>();
            m_linkEventHandlers = new List<LinkEventHandler>();
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

        public void FireKeyDownEvent<KeyType>(KeyType key) where KeyType : IKey
        {
            // Key is now down, check if there is an event for this key and fire it.
            List<InputEvent> events;
            if (m_bindingManager.GetKeyBind(key, out events))
            {
                InputEventHandler inputEventHandler = CreateEventHandler(key, events);
                m_inputEventHandlers.Add(inputEventHandler);
            }
        }

        public InputEventHandler CreateEventHandler<KeyType>(KeyType key, List<InputEvent> events)
        {
            if (key is InputKey<Mouse.Button>)
                return new MouseEventHandler((key as InputKey<Mouse.Button>).key, events);
            else if (key is InputKey<DxI.Key>)
                return new KeyboardEventHandler((key as InputKey<DxI.Key>).key, events);
            else if (key is InputKey<Joystick.Button>)
                return new JoyEventHandler((key as InputKey<Joystick.Button>).key, events);
            return null;
        }

        public void QueueAnalogJoyBinds()
        {
            // Key is now down, check if there is an event for this key and fire it.
            Dictionary<InputKey<Joystick.Analog>, List<InputEvent>> binds;
            binds = m_bindingManager.GetJoyAnalogBinds();
            foreach (KeyValuePair<InputKey<Joystick.Analog>, List<InputEvent>> pair in binds)
            {
                if (pair.Value.Count == 1)
                {
                    InputEventHandler inputEventHandler = new JoyAnalogEventHandler(pair.Key.key, pair.Value[0] as AnalogEvent);
                    m_inputEventHandlers.Add(inputEventHandler);
                }
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

        public void ProcessLinks(double elapsed, ref Xim.Input input, ref Xim.Input startState)
        {
            // Check for links to fire
            foreach (Xim.Button button in Enum.GetValues(typeof(Xim.Button)))
            {
                if( Xim.GetButtonState(button,ref input) == Xim.ButtonState.Pressed 
                    && Xim.GetButtonState(button, ref this.lastXimInput) == Xim.ButtonState.Released
                    && m_bindingManager.IsBound(InputKey.Make(button)) )
                {
                    List<InputEvent> events;
                    m_bindingManager.GetKeyBind(InputKey.Make(button), out events);
                    m_linkEventHandlers.Add(new LinkEventHandler(button, events));
                }
            }

            // Run all events
            PressedState pressedState = new PressedState();
            Stack<LinkEventHandler> finishedHandlers = new Stack<LinkEventHandler>();
            foreach (LinkEventHandler inputEventHandler in m_linkEventHandlers)
            {
                if (!inputEventHandler.Run(elapsed, pressedState, ref input, ref startState))
                {
                    finishedHandlers.Push(inputEventHandler);
                }
            }

            while (finishedHandlers.Count != 0)
            {
                m_linkEventHandlers.Remove(finishedHandlers.Pop());
            }
            this.lastXimInput = input;
        }
    }
}
