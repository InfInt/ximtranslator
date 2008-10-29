﻿using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    class InputManager
    {
        private List<DxI.Key> m_pressedKeys;
        private List<Mouse.Button> m_pressedMouseButtons;
        private List<Joystick.Button> m_pressedJoyButtons;
        private DxI.JoystickState m_currentJoyState;
        private Vector2 m_mouseDelta;

        private EventManager eventManager;
        private bool initialized = false;

        private InputManager()
        {
            m_pressedKeys = new List<DxI.Key>(30);
            m_pressedMouseButtons = new List<Mouse.Button>(3);
            m_pressedJoyButtons = new List<Joystick.Button>(10);
            m_mouseDelta = new Vector2(0, 0);
        }

        public void Init()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                eventManager = EventManager.Instance;
            }
        }

        public static InputManager Instance
        {
            get { return Singleton<InputManager>.Instance; }
        }

        public void ClearInput()
        {
            m_pressedJoyButtons.Clear();
            m_pressedMouseButtons.Clear();
            m_pressedKeys.Clear();
            m_currentJoyState = new Microsoft.DirectX.DirectInput.JoystickState { };
        }

        public List<DxI.Key> GetPressedKeys()
        {
            return m_pressedKeys;
        }

        public List<Mouse.Button> GetMouseButtons()
        {
            return m_pressedMouseButtons;
        }

        public List<Joystick.Button> GetJoyButtons()
        {
            return m_pressedJoyButtons;
        }

        public DxI.JoystickState GetJoyState()
        {
            return m_currentJoyState;
        }

        public bool IsKeyDown(DxI.Key key)
        {
            return m_pressedKeys.Contains(key);
        }

        public void GetAndResetMouseDelta(out Vector2 delta)
        {
            delta = m_mouseDelta;
            m_mouseDelta = new Vector2(0, 0);
        }

        public bool KeyUp(DxI.Key button)
        {
            if (m_pressedKeys.Contains(button))
            {
                m_pressedKeys.Remove(button);
                return true;
            }
            return false;
        }

        public bool KeyDown(DxI.Key button, bool fCreateEvents)
        {
            if (!m_pressedKeys.Contains(button))
            {
                m_pressedKeys.Add(button);
                if (fCreateEvents)
                {
                    eventManager.FireKeyDownEvent(button);
                }
                return true;
            }
            return false;
        }

        public bool KeyUp(Mouse.Button button)
        {
            if (m_pressedMouseButtons.Contains(button))
            {
                m_pressedMouseButtons.Remove(button);
                return true;
            }
            return false;
        }

        public bool KeyDown(Mouse.Button button, bool fCreateEvents)
        {
            if (!m_pressedMouseButtons.Contains(button))
            {
                m_pressedMouseButtons.Add(button);
                if (fCreateEvents)
                {
                    eventManager.FireButtonDownEvent(button);
                }
                return true;
            }
            return false;
        }

        public void AddMouseDelta(Vector2 delta)
        {
            m_mouseDelta.Add(delta);
        }

        public void SetMouseDelta(Vector2 delta)
        {
            m_mouseDelta = delta;
        }

        public void SetAndFirePressedKeys(DxI.Key[] keys, bool fCreateEvents)
        {
            if (fCreateEvents)
            {
                foreach (DxI.Key key in keys)
                {
                    if (!m_pressedKeys.Contains(key))
                    {
                        eventManager.FireKeyDownEvent(key);
                    }
                }
            }

            m_pressedKeys.Clear();
            foreach (DxI.Key key in keys)
                m_pressedKeys.Add(key);
        }

        public void SetAndFirePressedButtons(DxI.MouseState mouseState, bool fCreateEvents)
        {
            Byte[] mouseButtons = mouseState.GetMouseButtons();
            List<Mouse.Button> buttons = new List<Mouse.Button>(6);
            for( int i=0;i < mouseButtons.Length;i++)
            {
                if( mouseButtons[i] != 0 )
                {
                   buttons.Add((Mouse.Button)i);
                }
            }

            if (fCreateEvents)
            {
                if (mouseState.Z > 0)
                {
                    eventManager.FireButtonDownEvent(Mouse.Button.MWheelUp);
                }
                if (mouseState.Z < 0)
                {
                    eventManager.FireButtonDownEvent(Mouse.Button.MWheelDown);
                }
            }

            if (fCreateEvents)
            {
                foreach (Mouse.Button button in buttons)
                {
                    if(!m_pressedMouseButtons.Contains(button))
                    {
                        eventManager.FireButtonDownEvent(button);
                    }
                }
            }

            m_pressedMouseButtons = buttons;
        }

        public void SetAndFireJoyButtons(DxI.JoystickState joyState, bool fCreateEvents)
        {
            this.m_currentJoyState = joyState;
            Byte[] joyButtons = joyState.GetButtons();
            List<Joystick.Button> buttons = new List<Joystick.Button>(6);
            for (int i = 0; i < joyButtons.Length; i++)
            {
                if (joyButtons[i] != 0)
                {
                    buttons.Add((Joystick.Button)i);
                }
            }

            int[] joyHat = joyState.GetPointOfView();
            switch (joyHat[0])
            {
                case 0:
                    buttons.Add(Joystick.Button.PovUp);
                    break;
                case 4500:
                    buttons.Add(Joystick.Button.PovUp);
                    buttons.Add(Joystick.Button.PovRight);
                    break;
                case 9000:
                    buttons.Add(Joystick.Button.PovRight);
                    break;
                case 13500:
                    buttons.Add(Joystick.Button.PovRight);
                    buttons.Add(Joystick.Button.PovDown);
                    break;
                case 18000:
                    buttons.Add(Joystick.Button.PovDown);
                    break;
                case 22500:
                    buttons.Add(Joystick.Button.PovDown);
                    buttons.Add(Joystick.Button.PovLeft);
                    break;
                case 27000:
                    buttons.Add(Joystick.Button.PovLeft);
                    break;
                case 31500:
                    buttons.Add(Joystick.Button.PovLeft);
                    buttons.Add(Joystick.Button.PovUp);
                    break;
            }
                   

            if (fCreateEvents)
            {
                foreach (Joystick.Button button in buttons)
                {
                    if (!m_pressedJoyButtons.Contains(button))
                    {
                        eventManager.FireButtonDownEvent(button);
                    }
                }
            }
            m_pressedJoyButtons = buttons;
        }
    }
}
