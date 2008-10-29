using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DxI = Microsoft.DirectX.DirectInput;
using Common;

namespace xEmulate
{
    public class DxInputManager
    {
        private DxI.Device m_keyboard = null;
        private DxI.Device m_mouse = null;
        private DxI.Device m_joy = null;
        private DxI.JoystickState joyState;
        private X2 form;

        private InputManager inputManager;

        private DxInputManager()
        {
            this.inputManager = InputManager.Instance;
        }

        public static DxInputManager Instance
        {
            get { return Singleton<DxInputManager>.Instance; }
        }

        public void Init(X2 form)
        {
            this.form = form;

            m_keyboard = new DxI.Device(DxI.SystemGuid.Keyboard);
            m_keyboard.Properties.BufferSize = 20;
            m_keyboard.SetCooperativeLevel(form.Handle,
                                            DxI.CooperativeLevelFlags.Foreground |
#if DEBUG
                                            DxI.CooperativeLevelFlags.NonExclusive |
#else
                                            DxI.CooperativeLevelFlags.Exclusive |
#endif
                                            DxI.CooperativeLevelFlags.NoWindowsKey);

            m_mouse = new DxI.Device(DxI.SystemGuid.Mouse);
            m_mouse.Properties.BufferSize = 20;

            m_mouse.SetCooperativeLevel(form,
                                            
#if DEBUG
                                            DxI.CooperativeLevelFlags.Background |
                                            DxI.CooperativeLevelFlags.NonExclusive);
#else
                                            DxI.CooperativeLevelFlags.Foreground |
                                            DxI.CooperativeLevelFlags.Exclusive);
#endif


            foreach (DxI.DeviceInstance pad in DxI.Manager.GetDevices(DxI.DeviceClass.GameControl, DxI.EnumDevicesFlags.AttachedOnly))
            {
                m_joy = new DxI.Device(pad.InstanceGuid);
                m_joy.SetCooperativeLevel(form, DxI.CooperativeLevelFlags.Background |
#if DEBUG
                                            DxI.CooperativeLevelFlags.NonExclusive);
#else
                                            DxI.CooperativeLevelFlags.Exclusive);
#endif
            }
        }

        public bool ControllersPresent()
        {
            return m_joy != null;
        }

        public void PollAndProcess(bool fCreateEvents)
        {
            // Keyboard
            DxI.Key[] keys = null;
            keys = GetPressedKeys();

           
            if (keys != null)
            {
                DxI.BufferedDataCollection buffData = m_keyboard.GetBufferedData();
                if (buffData != null)
                {
                    foreach (DxI.BufferedData data in buffData)
                    {
                        DxI.Key key = (DxI.Key)data.Offset;
                        if (data.Data != 0)
                        {
                            this.inputManager.KeyDown(key, fCreateEvents);
                        }
                        else
                        {
                            this.inputManager.KeyUp(key);
                        }
                    }
                }
            }
            
            // Mouse
            DxI.MouseState mouseState;
            if (GetMouseState(out mouseState))
            {
                DxI.BufferedDataCollection buffData = m_mouse.GetBufferedData();
                if (buffData != null)
                {

                    foreach (DxI.BufferedData data in buffData)
                    {
                        
                    }
                }
                Vector2 delta = new Vector2(mouseState.X, mouseState.Y);
                this.inputManager.SetMouseDelta(delta);

                this.inputManager.SetAndFirePressedButtons(mouseState, fCreateEvents);
            }

            // Joystick
            if (m_joy != null)
            {
                m_joy.Poll();
                joyState = m_joy.CurrentJoystickState;
                this.inputManager.SetAndFireJoyButtons(joyState, fCreateEvents);
            }

        }

        public short GetJoyYValue()
        {
            return (short)(joyState.X - (short)XimApi.Xim.Stick.Max ) ;
        }

        private void AcquireKeyboard()
        {
            m_keyboard.Acquire();
        }

        private void AcquireMouse()
        {
            m_mouse.Acquire();
        }

        private void AcquireJoy()
        {
            if (m_joy != null)
                m_joy.Acquire();
        }

        public void Acquire()
        {
            AcquireMouse();
            AcquireKeyboard();
            AcquireJoy();
        }

        public void Unaquire()
        {
            m_keyboard.Unacquire();
            m_mouse.Unacquire();
            if (m_joy != null)
                m_joy.Unacquire();
        }

        public DxI.Key[] GetPressedKeys()
        {
            DxI.Key[] keys = null;
            try
            {
                m_keyboard.Poll();
                keys = m_keyboard.GetPressedKeys();
            }
            catch
            {
                try
                {
                    AcquireKeyboard();
                    keys = m_keyboard.GetPressedKeys();
                }
                catch
                {
                }
            }
            return keys;
        }

        public bool GetMouseState(out DxI.MouseState state)
        {
            try
            {
                m_mouse.Poll();
                state = m_mouse.CurrentMouseState;
                return true;
            }
            catch
            {
                try
                {
                    AcquireMouse();
                    m_mouse.Poll();
                    state = m_mouse.CurrentMouseState;
                    return true;
                }
                catch
                {
                }
            }
            state = m_mouse.CurrentMouseState;
            return false;
        }
    }
}
