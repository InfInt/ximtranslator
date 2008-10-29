using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Win32Api;
using Common;
using XimApi;

namespace xEmulate
{
    public class RawInputManager
    {
        private bool m_fInit = false;
        private RawInput.RAWINPUTDEVICE m_keyboardDevice;
        private RawInput.RAWINPUTDEVICE m_mouseDevice;

        private InputManager inputManager;

        private struct MouseKey
        {
            public Mouse.Button button;
            public bool fReleased;

            public MouseKey( Mouse.Button b, bool f )
            {
                button = b;
                fReleased = f;
            }
        }

        private Dictionary<RawInput.RawMouseButtons, MouseKey> m_mouseMap;
            
        private EventManager m_eventManager;

        private RawInputManager()
        {
            inputManager = InputManager.Instance;
            m_mouseMap = new Dictionary<RawInput.RawMouseButtons, MouseKey>();
            m_mouseMap.Add(RawInput.RawMouseButtons.LeftDown, new MouseKey(Mouse.Button.MouseLeft, false/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.LeftUp, new MouseKey(Mouse.Button.MouseLeft, true/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.RightDown, new MouseKey(Mouse.Button.MouseRight, false/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.RightUp, new MouseKey(Mouse.Button.MouseRight, true/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.MiddleDown, new MouseKey(Mouse.Button.MouseMiddle, false/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.MiddleUp, new MouseKey(Mouse.Button.MouseMiddle, true/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.Button4Down, new MouseKey(Mouse.Button.Mouse4, false/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.Button4Up, new MouseKey(Mouse.Button.Mouse4, true/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.Button5Down, new MouseKey(Mouse.Button.Mouse5, false/*fReleased*/));
            m_mouseMap.Add(RawInput.RawMouseButtons.Button5Up, new MouseKey(Mouse.Button.Mouse5, true/*fReleased*/));
        }

        public static RawInputManager Instance
        {
            get { return Singleton<RawInputManager>.Instance; }
        }

        public void Init(IntPtr hwnd)
        {
            if (!m_fInit)
            {
                m_fInit = true;

                // Register 
                m_mouseDevice.WindowHandle = hwnd;
                m_mouseDevice.Usage = RawInput.Usage.Mouse;
                m_mouseDevice.UsagePage = RawInput.UsagePage.Generic;
                m_mouseDevice.Flags = RawInput.DeviceFlags.InputSink;

                RegisterRawInputDevice(m_mouseDevice);

                m_keyboardDevice.WindowHandle = hwnd;
                m_keyboardDevice.Usage = RawInput.Usage.Keyboard;
                m_keyboardDevice.UsagePage = RawInput.UsagePage.Generic;
                m_keyboardDevice.Flags = RawInput.DeviceFlags.InputSink;

                RegisterRawInputDevice(m_keyboardDevice);

                // Register

                m_eventManager = EventManager.Instance;
            }
        }

        private static bool RegisterRawInputDevice(Win32Api.RawInput.RAWINPUTDEVICE device)
        {
            RawInput.RAWINPUTDEVICE[] devices = new RawInput.RAWINPUTDEVICE[1];        // Raw input devices.

            devices[0] = device;
            return RawInput.RegisterRawInputDevices(devices, 1, Marshal.SizeOf(typeof(RawInput.RAWINPUTDEVICE)));
        }

        public bool ProcessMWheel(bool mWheelUp)
        {
            m_eventManager.FireButtonDownEvent(mWheelUp ? Mouse.Button.MWheelUp : Mouse.Button.MWheelDown);
            return true;
        }

        public bool ProcessMessage(ref Message m, bool m_fCreateEvents)
        {
            if (m.Msg == (int)WindowsMessages.INPUT)
            {
                RawInput.RAWINPUT input = new RawInput.RAWINPUT();
                int outSize = 0;
                int size = Marshal.SizeOf(typeof(RawInput.RAWINPUT));

                outSize = RawInput.GetRawInputData(m.LParam, RawInput.Command.Input, out input, ref size, Marshal.SizeOf(typeof(RawInput.RAWINPUTHEADER)));
                if (outSize != -1)
                {
                    if (input.Header.Type == RawInput.RawInputType.Mouse)
                    {
                        
                        if (input.Mouse.ButtonFlags != RawInput.RawMouseButtons.None)
                        {
                            MouseKey mKey;
                            if (m_mouseMap.TryGetValue(input.Mouse.ButtonFlags, out mKey))
                            {
                                if (mKey.fReleased)
                                {
                                    this.inputManager.KeyUp(mKey.button);
                                }
                                else
                                {
                                    this.inputManager.KeyDown(mKey.button, m_fCreateEvents);
                                }
                            }
                            if (input.Mouse.ButtonFlags == RawInput.RawMouseButtons.MouseWheel)
                            {
                                // Todo: Why arent mouse wheels working
                            }
                        }

                        if (input.Mouse.LastX != 0 || input.Mouse.LastY != 0)
                        {
                            this.inputManager.AddMouseDelta(new Vector2(input.Mouse.LastX, input.Mouse.LastY));
                        }

                    }
                    else if (input.Header.Type == RawInput.RawInputType.Keyboard)
                    {
                        if (input.Keyboard.Message == WindowsMessages.KEYFIRST || input.Keyboard.Message == WindowsMessages.SYSKEYDOWN)
                        {
                            //this.inputManager.KeyDown(input.Keyboard.VirtualKey, m_fCreateEvents);
                        }
                        else if (input.Keyboard.Message == WindowsMessages.KEYUP || input.Keyboard.Message == WindowsMessages.SYSKEYUP)
                        {
                            //this.inputManager.KeyUp(input.Keyboard.VirtualKey);
                        }
                    }
                    else if (input.Header.Type == RawInput.RawInputType.HID)
                    {

                    }
                }
                return m_fCreateEvents;
            }
            return false;
        }
    }
}
