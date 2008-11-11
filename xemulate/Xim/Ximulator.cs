using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using XimApi;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    public class UtilThread
    {
        public bool m_fConnected = false;
        public bool m_fConnecting = false;
        public Xim.Status m_StatusMsg = Xim.Status.OK;
        private XimDyn ximDyn;

        public UtilThread()
        {
            ximDyn = XimDyn.Instance;
        }

        public void Connect()
        {
            if (!m_fConnected)
            {
                m_fConnecting = true;
                m_StatusMsg = Xim.Status.Hung;
                m_StatusMsg = this.ximDyn.Connect();
                m_fConnected = m_StatusMsg == Xim.Status.OK;
                m_fConnecting = false;
            }

            while (m_fConnected)
            {
                Thread.Sleep(500);
            }

            this.ximDyn.Disconnect();
        }
    };


    class Ximulator
    {
        private Xim.Input m_blankInput = new Xim.Input();
        private VarManager m_varManager;
        private TextModeManager m_textModeManager;
        private EventManager m_eventManager;
        private InputManager m_inputManager;
        private UtilThread m_utilThread;
        private InfoTextManager m_infoTextManager;
       
        private Queue<Vector2> m_prevMouseStates;
        
        private X2 m_form;
        private bool m_connected = false;
        private bool m_fXimRunning = false;

        private VarManager.Var m_rate;
        private VarManager.Var m_textMode;
        private VarManager.Var m_textModeRate;
        private VarManager.Var m_autoAnalogDisconnect;
        private VarManager.Var m_useXimApiMouseMath;

        private MouseMath mouseMath;
        private BetaMouseMath betaMouseMath;
        private Thread myThread;

        public XimDyn ximDyn;

        ~Ximulator()
        {
            if(myThread != null)
                myThread.Abort();
        }

        public Ximulator(X2 form)
        {
            this.ximDyn = XimDyn.Instance;

            m_form = form;

            m_varManager = VarManager.Instance;
            m_eventManager = EventManager.Instance;
            m_textModeManager = TextModeManager.Instance;
            m_inputManager = InputManager.Instance;
            m_infoTextManager = InfoTextManager.Instance;

            m_prevMouseStates = new Queue<Vector2>();
           
            // Init the vars so we dont have to get them again.
            m_varManager.GetVar("rate", out m_rate);
            m_varManager.GetVar("textmode", out m_textMode);
            m_varManager.GetVar("textmoderate", out m_textModeRate);
            m_varManager.GetVar("autoanalogdisconnect", out m_autoAnalogDisconnect);
            m_varManager.GetVar("useximapimousemath", out m_useXimApiMouseMath);

            this.mouseMath = new MouseMath();
            this.betaMouseMath = new BetaMouseMath();
            
            m_utilThread = new UtilThread();
        }

        private bool Connect()
        {
            if (!m_connected)
            {
                Log("Connecting...");
                myThread = new Thread(new ThreadStart(m_utilThread.Connect));
                myThread.Start();
                Thread.Sleep(100);

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

                watch.Start();
                while (watch.ElapsedMilliseconds < 5000 && m_utilThread.m_fConnecting && !m_utilThread.m_fConnected)
                {
                    System.Windows.Forms.Application.DoEvents();
                    Thread.Sleep(100);
                }

                if (watch.ElapsedMilliseconds > 5000 && m_utilThread.m_StatusMsg == Xim.Status.DeviceNotFound)
                    m_utilThread.m_StatusMsg = Xim.Status.Hung;

                m_connected = m_utilThread.m_fConnected;

                if (m_connected)
                {
                    Log("Connected.");
                }
                else
                {
                    switch (m_utilThread.m_StatusMsg)
                    {
                        case Xim.Status.Hung:
                            Log("Xim is hung, disconnect Xim from the computer and reconnect it, then try again.");
                            break;
                        default:
                            Log("Unable to connect to Xim:" + m_utilThread.m_StatusMsg.ToString());
                            break;
                    }
                    myThread.Abort();
                }
            }
            return m_connected;
        }

        private void Disconnect()
        {
            Log("Disconnected.");
            m_connected = false;
            m_utilThread.m_fConnected = false;
            Xim.Disconnect();
        }

        public bool IsRunning()
        {
            return m_fXimRunning;
        }

        public void Go()
        {
            if (Connect())
            {
                m_fXimRunning = true;

                // Get thing set up.
                DxInputManager dxInputManager = DxInputManager.Instance;
                
                System.Drawing.Point cursorPosition = Cursor.Position;
                Xim.Input input = new Xim.Input();
                Xim.Input startState = new Xim.Input();
                ximDyn.SetMode((bool)m_autoAnalogDisconnect.Value ? Xim.Mode.AutoAnalogDisconnect : Xim.Mode.None);
                ximDyn.SendInput(ref input, 0);
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                bool bTextMode = false;
                bool done = false;

                watch.Start();
                Cursor.Hide();
                
                // 
                
                m_textMode.Value = false;
                TimeSpan prevTick = watch.Elapsed;
                Log("Press ESCAPE to stop X2 processing");

                dxInputManager.Acquire();
                if (dxInputManager.ControllersPresent())
                    m_eventManager.QueueAnalogJoyBinds();

                // Main Processing Loop
                while (!done)
                {
                    System.Windows.Forms.Application.DoEvents();
                    double wait = (bool)m_textMode.Value ? (1000 / (double)m_textModeRate.Value) : (1000 / (double)m_rate.Value);
                    while (watch.Elapsed.TotalMilliseconds - prevTick.TotalMilliseconds < wait) 
                    {
                        if (m_form.ContainsFocus)
                        {
                            Cursor.Position = cursorPosition;
                        }
                        System.Threading.Thread.Sleep(2); 
                    }

                    if (!m_form.ContainsFocus)
                    {
                        m_inputManager.ClearInput();
                        continue;
                    }
                    else
                    {
                        dxInputManager.PollAndProcess(!(bool)m_textMode.Value);
                    }

                    input.CopyFrom(startState);
                    TimeSpan thisTick = watch.Elapsed;
                    double delay = thisTick.TotalMilliseconds - prevTick.TotalMilliseconds;
                    prevTick = thisTick;
                    
                    if (delay > 1000)
                        continue;

                    if ((bool)m_textMode.Value)
                    {
                        if (!bTextMode)
                        {
                            Log("Entering Text Mode. Press END to exit text mode" + Environment.NewLine);
                            bTextMode = true;
                        }
                        m_textModeManager.ProcessOutput(delay, ref input, ref startState);

                        if (m_inputManager.IsKeyDown(DxI.Key.End))
                        {
                            m_textModeManager.Reset();
                            m_textMode.Value = false;
                            bTextMode = false;
                            Log("Exiting Text Mode");
                        }
                    }
                    else
                    {
                        m_eventManager.ProcessEvents(delay, ref input, ref startState);
                        if ((bool)m_useXimApiMouseMath.Value)
                        {
                            this.mouseMath.ProcessMouseMovement(ref input, ref startState);
                            //this.betaMouseMath.XSoftMouseMovement(ref input, ref startState);
                        }
                        else
                        {
                            this.mouseMath.XSoftMouseMovement(ref input, ref startState);
                        }
                        m_eventManager.ProcessLinks(delay, ref input, ref startState);
                    }

                    if ( m_inputManager.IsKeyDown(DxI.Key.Escape))
                    {
                        break;
                    }

                    if (m_form.ContainsFocus)
                    {
                        m_form.UpdateOutputView(input);
                        ximDyn.SendInput(ref input, 1);
                    }
                    else
                    {
                        ximDyn.SendInput(ref m_blankInput, 1);
                    }
                }

                // Shutdown and clear events and input
                m_form.UpdateOutputView(m_blankInput);
                m_inputManager.ClearInput();
                m_eventManager.ClearEvents();
                DxInputManager.Instance.Unaquire();
                m_fXimRunning = false;
                Disconnect();
            }
        }

        #region ProcessInput

        public bool ProcessChar(char ch)
        {
            if ((bool)m_textMode.Value && m_fXimRunning)
            {
                Debug.Write(ch);
                m_textModeManager.ProcessInput(ch);
                return true;
            }
            return false;
        }

        public bool ProcessMWheel(bool fWheelUp)
        {
            return false;
            //return m_rawInputManager.ProcessMWheel(fWheelUp);
        }

        public bool ProcessMessage(ref System.Windows.Forms.Message m)
        {
            return false;
            //return m_rawInputManager.ProcessMessage(ref m, m_fXimRunning && !(bool)m_textMode.Value);
        }

        #endregion

        private void Log(String s)
        {
            m_infoTextManager.WriteLine(s);
        }
    }
}
