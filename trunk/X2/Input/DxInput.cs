using System;
using System.Collections.Generic;
using System.Text;
using DxI = Microsoft.DirectX.DirectInput;

namespace X2
{
    class DxInput
    {
        private DxI.Device m_keyboard = null;
        private DxI.Device m_mouse = null;
        private X2 m_form;

        public DxInput(X2 form)
        {
            m_form = form;
        }

        ~DxInput()
        {
            
        }

        private void AcquireKeyboard()
        {
            m_keyboard = new DxI.Device(DxI.SystemGuid.Keyboard);
            m_keyboard.SetCooperativeLevel(m_form,
                                            DxI.CooperativeLevelFlags.Foreground |
                                            DxI.CooperativeLevelFlags.Exclusive |
                                            DxI.CooperativeLevelFlags.NoWindowsKey);
            m_keyboard.Acquire();
        }

        private void AcquireMouse()
        {
            m_mouse = new DxI.Device(DxI.SystemGuid.Mouse);
            m_mouse.SetCooperativeLevel(m_form,
                                            DxI.CooperativeLevelFlags.Foreground |
                                            DxI.CooperativeLevelFlags.Exclusive);
            m_mouse.Acquire();
        }

        public void Acquire()
        {
            AcquireMouse();
            AcquireKeyboard();
        }

        public void Unaquire()
        {
                m_keyboard.Unacquire();
                m_mouse.Unacquire();
        }

        public DxI.Key[] GetPressedKeys()
        {
            m_keyboard.Poll();
            return m_keyboard.GetPressedKeys();
        }

        public DxI.MouseState GetMouseState()
        {
            m_keyboard.Poll();
            return m_mouse.CurrentMouseState;
        }
    }
}
