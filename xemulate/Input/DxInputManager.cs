using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DxI = Microsoft.DirectX.DirectInput;
using Xna = Microsoft.Xna.Framework;
using Common;

namespace xEmulate
{
    public class DxInputManager
    {
        private DxI.Device m_keyboard = null;
        private DxI.Device m_mouse = null;
        private DxI.Device m_joy = null;
        private bool useXInput = false;
        private xEmulateForm form;

        private InputManager inputManager;

        private DxInputManager()
        {
            this.inputManager = InputManager.Instance;
        }

        public static DxInputManager Instance
        {
            get { return Singleton<DxInputManager>.Instance; }
        }

        public void Init(xEmulateForm form)
        {
            InfoTextManager.Instance.WriteLine("Initializing DirectInput...");
            this.form = form;
            m_keyboard = new DxI.Device(DxI.SystemGuid.Keyboard);
            m_keyboard.Properties.BufferSize = 20;
            m_keyboard.SetCooperativeLevel(form.Handle,
                                            DxI.CooperativeLevelFlags.Foreground |
                                            DxI.CooperativeLevelFlags.NonExclusive |
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

            InfoTextManager.Instance.Write("Complete.");
            InitJoy();
        }

        public void InitJoy()
        {
            Xna.Input.GamePadState gamePadState = Xna.Input.GamePad.GetState(Xna.PlayerIndex.One);
            if (gamePadState.IsConnected)
            {
                this.useXInput = true;
                InfoTextManager.Instance.WriteLine("Initialized 1 XInput Controller, skipping Joysticks");
            }
            else
            {

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

                if (m_joy != null)
                {
                    InfoTextManager.Instance.WriteLine("Initialized 1 Joystick");
                }
                else
                {
                    InfoTextManager.Instance.WriteLine("No Joysticks Found, Joystick functionality disabled");
                }
            }
        }

        public bool ControllersPresent()
        {
            Xna.Input.GamePadState gamePadState = Xna.Input.GamePad.GetState(Xna.PlayerIndex.One);
            return gamePadState.IsConnected || m_joy != null;
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
                /*DxI.BufferedDataCollection buffData = m_mouse.GetBufferedData();
                if (buffData != null)
                {

                    foreach (DxI.BufferedData data in buffData)
                    {
                        js
                    }
                }*/
                Vector2 delta = new Vector2(mouseState.X, mouseState.Y);
                this.inputManager.AddMouseDelta(delta);

                this.inputManager.SetAndFirePressedButtons(mouseState, fCreateEvents);
            }

            // Joystick
            DxI.JoystickState joyState;
            if (m_joy != null && GetJoyState(out joyState))
            {
                this.inputManager.SetAndFireJoyButtons(joyState, fCreateEvents);
            }

            // XInput
            if(this.useXInput)
            {
                Xna.Input.GamePadState gamePadState = Xna.Input.GamePad.GetState(Xna.PlayerIndex.One);
                if (gamePadState.IsConnected)
                {
                    this.inputManager.SetAndFireXInput(gamePadState, fCreateEvents);
                }
            }
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

        public void OutputJoyCaps()
        {
            if (m_joy != null)
            {
                DxI.JoystickState js;
                if( GetJoyState(out js) )
                {
                    DxI.DeviceCaps caps = m_joy.Caps;

                    InfoTextManager infoMan = InfoTextManager.Instance;
                    

                    infoMan.WriteLine("Joystick Caps: ");
                    infoMan.WriteLine(" Type: " + caps.DeviceType);
                    infoMan.WriteLine(" Axes: " + caps.NumberAxes);
                    infoMan.WriteLine(" Buttons: " + caps.NumberButtons);
                    infoMan.WriteLine(" PoV: " + caps.NumberPointOfViews);
                    infoMan.WriteLine(" Ax:" + js.AX);
                    infoMan.Write(" Ay:" + js.AY);
                    infoMan.Write(" Az:" + js.AZ);
                    infoMan.Write(" ARx:" + js.ARx);
                    infoMan.Write(" ARy:" + js.ARy);
                    infoMan.Write(" ARz:" + js.ARz);
                    infoMan.WriteLine(" Fx:" + js.FX);
                    infoMan.Write(" Fy:" + js.FY);
                    infoMan.Write(" Fz:" + js.FZ);
                    infoMan.Write(" FRx:" + js.FRx);
                    infoMan.Write(" FRy:" + js.FRy);
                    infoMan.Write(" FRz:" + js.FRz);
                    infoMan.WriteLine(" X:" + js.X);
                    infoMan.Write(" Y:" + js.Y);
                    infoMan.Write(" Z:" + js.Z);
                    infoMan.Write(" Rx:" + js.Rx);
                    infoMan.Write(" Ry:" + js.Ry);
                    infoMan.Write(" Rz:" + js.Rz);
                }
            }
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
            state = default(DxI.MouseState);
            return false;
        }

        public bool GetJoyState(out DxI.JoystickState joyState)
        {
            try
            {
                m_joy.Poll();
                joyState = m_joy.CurrentJoystickState;
                return true;
            }
            catch
            {
                try
                {
                    AcquireJoy();
                    m_joy.Poll();
                    joyState = m_joy.CurrentJoystickState;
                    return true;
                }
                catch
                {
                }
            }
            joyState = default(DxI.JoystickState);
            return false;
        }
    }
}
