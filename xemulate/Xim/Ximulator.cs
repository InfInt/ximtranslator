using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace X2
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
        private IntPtr m_mouseSmoothPtr = (IntPtr)0;

        private Queue<Vector2> m_prevMouseStates;
        
        private X2 m_form;
        private bool m_connected = false;
        private bool m_fXimRunning = false;

        private VarManager.Var m_sensitivity1;
        private VarManager.Var m_sensitivity2;
        private VarManager.Var m_altSens;
        private VarManager.Var m_transExp1;
        private VarManager.Var m_transExp2;
        private VarManager.Var m_deadzone;
        private VarManager.Var m_circularDeadzone;
        private VarManager.Var m_yxratio;
        private VarManager.Var m_mouseSmooth;
        private VarManager.Var m_clearSmoothOnStop;
        private VarManager.Var m_rate;
        private VarManager.Var m_textMode;
        private VarManager.Var m_textModeRate;
        private VarManager.Var m_autoAnalogDisconnect;
        private VarManager.Var m_useXimApiMouseMath;
        private VarManager.Var m_diagonalDampen;

        private XimDyn ximDyn;


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
            m_varManager.GetVar("sensitivity1", out m_sensitivity1);
            m_varManager.GetVar("sensitivity2", out m_sensitivity2);
            m_varManager.GetVar("altsens", out m_altSens);
            m_varManager.GetVar("deadzone", out m_deadzone);
            m_varManager.GetVar("yxratio", out m_yxratio);
            m_varManager.GetVar("transexponent1", out m_transExp1);
            m_varManager.GetVar("transexponent2", out m_transExp2);
            m_varManager.GetVar("smoothness", out m_mouseSmooth);
            m_varManager.GetVar("clearsmoothonstop", out m_clearSmoothOnStop);
            m_varManager.GetVar("rate", out m_rate);
            m_varManager.GetVar("textmode", out m_textMode);
            m_varManager.GetVar("textmoderate", out m_textModeRate);
            m_varManager.GetVar("autoanalogdisconnect", out m_autoAnalogDisconnect);
            m_varManager.GetVar("circulardeadzone", out m_circularDeadzone);
            m_varManager.GetVar("useximapimousemath", out m_useXimApiMouseMath);
            m_varManager.GetVar("diagonaldampen", out m_diagonalDampen);

            m_utilThread = new UtilThread();
        }

        private bool Connect()
        {
            if (!m_connected)
            {
                Log("Connecting...");
                Thread thread = new Thread(new ThreadStart(m_utilThread.Connect));
                thread.Start();
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
                    thread.Abort();
                }
            }
            return m_connected;
        }

        private void Disconnect()
        {
            Log("Disconnected.");
            m_connected = false;
            m_utilThread.m_fConnected = false;
        }

        public bool IsRunning()
        {
            return m_fXimRunning;
        }

        public void Go()
        {
            if (Connect())
            {
                System.Drawing.Point cursorPosition = Cursor.Position;
                Xim.Input input = new Xim.Input();
                Xim.Input startState = new Xim.Input();
                ximDyn.SetMode((bool)m_autoAnalogDisconnect.value ? Xim.Mode.AutoAnalogDisconnect : Xim.Mode.None);
                ximDyn.SendInput(ref input, 0);
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                bool bTextMode = false;
                bool done = false;

                watch.Start();

                m_fXimRunning = true;
                m_textMode.value = false;
                TimeSpan prevTick = watch.Elapsed;
                Log("Press ESCAPE to stop X2 processing");
                while (!done)
                {
                    System.Windows.Forms.Application.DoEvents();
                    double wait = (bool)m_textMode.value ? (1000 / (double)m_textModeRate.value) : (1000 / (double)m_rate.value);
                    while (watch.Elapsed.TotalMilliseconds - prevTick.TotalMilliseconds < wait) 
                    {
                        if (m_form.ContainsFocus)
                        {
                            Cursor.Position = cursorPosition;
                        }
                        System.Threading.Thread.Sleep(1); 
                    }

                    input.CopyFrom(startState);
                    TimeSpan thisTick = watch.Elapsed;
                    double delay = thisTick.TotalMilliseconds - prevTick.TotalMilliseconds;
                    prevTick = thisTick;

                    if ((bool)m_textMode.value)
                    {
                        if (!bTextMode)
                        {
                            Log("Entering Text Mode. Press END to exit text mode" + Environment.NewLine);
                            bTextMode = true;
                        }
                        m_textModeManager.ProcessOutput(delay, ref input, ref startState);

                        if (m_inputManager.IsKeyDown(Win32Api.VirtualKeys.End))
                        {
                            m_textModeManager.Reset();
                            m_textMode.value = false;
                            bTextMode = false;
                            Log("Exiting Text Mode");
                        }
                    }
                    else
                    {
                        ProcessMouseMovement(ref input, ref startState);
                        m_eventManager.ProcessEvents(delay, ref input, ref startState);
                    }

                    if ( m_inputManager.IsKeyDown(Win32Api.VirtualKeys.Escape))
                    {
                        break;
                    }

                    if (m_form.ContainsFocus)
                    {
                        ximDyn.SendInput(ref input, 0);
                    }
                    else
                    {
                        ximDyn.SendInput(ref m_blankInput, 0);
                    }
                }
                m_fXimRunning = false;
                Disconnect();
            }
        }

        #region ProcessInput

        public bool ProcessChar(char ch)
        {
            if ((bool)m_textMode.value && m_fXimRunning)
            {
                Debug.Write(ch);
                m_textModeManager.ProcessInput(ch);
                return true;
            }
            return false;
        }

        public bool ProcessMWheel(bool fWheelUp)
        {
            return m_inputManager.ProcessMWheel(fWheelUp);
        }

        public bool ProcessMessage(ref System.Windows.Forms.Message m)
        {
            return m_inputManager.ProcessMessage(ref m, m_fXimRunning && !(bool)m_textMode.value);
        }

        private void ProcessMouseMovement(ref Xim.Input input, ref Xim.Input startState)
        {
            int sensitivity;
            int deadzoneFactor;
            double yxratio;
            double transExp;
            double mouseSmooth;
            double diagonalDampen;
            bool fClearSmoothOnStop;
            bool fCircularDeadzone;
            bool fUseXimMath;

            Vector2 delta;
            m_inputManager.GetAndResetMouseDelta(out delta);

            if ((bool)m_altSens.value)
            {
                VarManager.GetVarValue(m_sensitivity2, out sensitivity);
                VarManager.GetVarValue(m_transExp2, out transExp);
            }
            else
            {
                VarManager.GetVarValue(m_sensitivity1, out sensitivity);
                VarManager.GetVarValue(m_transExp1, out transExp);
            }

            VarManager.GetVarValue(m_deadzone, out deadzoneFactor);
            VarManager.GetVarValue(m_yxratio, out yxratio);
            VarManager.GetVarValue(m_mouseSmooth, out mouseSmooth);
            VarManager.GetVarValue(m_clearSmoothOnStop, out fClearSmoothOnStop);
            VarManager.GetVarValue(m_circularDeadzone, out fCircularDeadzone);
            VarManager.GetVarValue(m_useXimApiMouseMath, out fUseXimMath);
            VarManager.GetVarValue(m_diagonalDampen, out diagonalDampen);

            if (fUseXimMath)
            {
                if (m_mouseSmoothPtr == (IntPtr)0)
                {
                    // Alloc the smooth ptr.
                    m_mouseSmoothPtr = Xim.AllocSmoothness((float)mouseSmooth, (int)(1000 / Xim.Delay), (float)yxratio, (float)transExp, (float)sensitivity);
                }

                Xim.ComputeStickValues((float)delta.X,
                    (float)-delta.Y,
                    (float)yxratio,
                    (float)transExp,
                    sensitivity,
                    (float)diagonalDampen,
                    m_mouseSmoothPtr,
                    fCircularDeadzone ? Xim.Deadzone.Circular : Xim.Deadzone.Square,
                    deadzoneFactor,
                    ref input.RightStickX,
                    ref input.RightStickY);
            }
            else
            {
                if (mouseSmooth == 0)
                    mouseSmooth++;

                if (fClearSmoothOnStop && delta.X == 0 && delta.Y == 0)
                {
                    m_prevMouseStates.Clear();
                    input.RightStickX = 0;
                    input.RightStickY = 0;
                    return;
                }
                else if (m_prevMouseStates.Count == mouseSmooth)
                {
                    m_prevMouseStates.Dequeue();
                }

                m_prevMouseStates.Enqueue(delta);

                Vector2 mouseDelta = new Vector2(0, 0);
                foreach (Vector2 curState in m_prevMouseStates)
                {
                    mouseDelta.X += curState.X;
                    mouseDelta.Y -= curState.Y;
                }

                mouseDelta.X = mouseDelta.X / m_prevMouseStates.Count;
                mouseDelta.Y = mouseDelta.Y / m_prevMouseStates.Count;

                CalculateMouseToXbox(mouseDelta, sensitivity, deadzoneFactor, transExp, yxratio, diagonalDampen, fCircularDeadzone, ref mouseDelta);

 
            }
        }

        private void CalculateMouseToXbox(Vector2 mouseDelta, int sensitivity, int deadzoneFactor, double transExp, double yxratio, double diagonalDampen, bool fCircularDeadzone, ref Vector2 xboxDelta )
        {
            Vector2 delta = new Vector2(mouseDelta.X, mouseDelta.Y);

            delta.Y = delta.Y * yxratio;

            Vector2 deadzone = null;
            if (fCircularDeadzone)
            {
                deadzone = new Vector2(delta.X, delta.Y);
                deadzone.Normalize();
                deadzone.Scale(deadzoneFactor);
            }
            else
            {
                deadzone = new Vector2(deadzoneFactor, deadzoneFactor);
            }

            double mouseVectorLen = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            mouseVectorLen = Math.Pow(mouseVectorLen, transExp);
            delta.Normalize();
            delta.Scale(mouseVectorLen);

            delta.Scale(sensitivity);
            delta.Add(deadzone);

            delta.Cap(-(double)Xim.Stick.Max, (double)Xim.Stick.Max);

            xboxDelta.X = delta.X;
            xboxDelta.Y = delta.Y;
        }

        #endregion

        private void Log(String s)
        {
            m_infoTextManager.WriteLine(s);
        }
    }
}
