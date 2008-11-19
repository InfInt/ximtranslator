using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using XimApi;
using Common;
using System.Threading;

namespace xEmulate
{
    class TextModeManager
    {
        String m_keyOrder = "abcdefg123hijklmn456opqrstu789vwxyz-@_0.";
        String m_upperKeyOrder;

        struct Destination
        {
            public Vector2 coord;
            public bool shift;
            public Xim.Button toPressOnFinished;
            public bool hasDest;
        }

        Mutex mutex;

        private Destination m_current;
        private int m_idleFrame = 0;
        private bool done = false;

        private Queue<Destination> m_keyqueue;
        
        private TextModeManager()
        {
            this.mutex = new Mutex();
            m_current.shift = false;
            m_current.coord = new Vector2(0, 0);

            m_upperKeyOrder = m_keyOrder.ToUpper();
            
            m_keyqueue = new Queue<Destination>();
        }

        public static TextModeManager Instance
        {
            get { return Singleton<TextModeManager>.Instance; }
        }

        public void Log(char ch)
        {
            InfoTextManager.Instance.Write(ch.ToString());
        }

        public void ProcessInput(char ch)
        {
            mutex.WaitOne();
            if (m_keyOrder.IndexOf(ch) != -1)
            {
                int idx = m_keyOrder.IndexOf(ch);

                int row = idx / 10;
                int col = idx % 10;

                Destination dest = new Destination();
                dest.shift = false;
                dest.coord = new Vector2(row, col);
                dest.hasDest = true;
                dest.toPressOnFinished = Xim.Button.A;

                Log(ch);

                m_keyqueue.Enqueue(dest);
            }
            else if (m_upperKeyOrder.IndexOf(ch) != -1)
            {
                int idx = m_upperKeyOrder.IndexOf(ch);

                int row = idx / 10;
                int col = idx % 10;

                Destination dest = new Destination();
                dest.shift = true;
                dest.coord = new Vector2(row, col);
                dest.hasDest = true;
                dest.toPressOnFinished = Xim.Button.A;

                m_keyqueue.Enqueue(dest);
            }
            else if (ch == ' ')
            {
                Destination dest = new Destination();
                dest.shift = false;
                dest.hasDest = false;
                dest.toPressOnFinished = Xim.Button.Y;

                Log(ch);

                m_keyqueue.Enqueue(dest);
            }
            else if (ch == '\b')
            {
                Destination dest = new Destination();
                dest.shift = false;
                dest.hasDest = false;
                dest.toPressOnFinished = Xim.Button.X;

                Log(ch);

                m_keyqueue.Enqueue(dest);
            }
            else if (ch == '\r')
            {
                Destination dest = new Destination();
                dest.shift = false;
                dest.hasDest = false;
                dest.toPressOnFinished = Xim.Button.Start;

                m_keyqueue.Enqueue(dest);
            }
            mutex.ReleaseMutex();
        }

        public void ProcessOutput(double delay, ref Xim.Input input, ref Xim.Input startState)
        {
            
            if (done)
            {
                done = false;
                VarManager.Instance.SetVar(VarManager.Names.TextMode, false);
                return;
            }
            input = new Xim.Input();
            if (m_idleFrame == 0)
            {
                m_idleFrame++;
            }
            else if (m_keyqueue.Count != 0)
            {
                m_idleFrame = 0;

                mutex.WaitOne();

                if (FAtDestination())
                {
                    Xim.SetButtonState(m_keyqueue.Peek().toPressOnFinished, Xim.ButtonState.Pressed, ref input);

                    if (m_keyqueue.Peek().toPressOnFinished == Xim.Button.Start)
                    {
                        InfoTextManager.Instance.WriteLine("Sending message and exiting TextMode");
                        this.done = true;
                        m_keyqueue.Clear();
                    }
                    else
                    {
                        m_keyqueue.Dequeue();
                    }
                }
                else
                {
                    Destination d = m_keyqueue.Peek();
                    if (d.coord.X != m_current.coord.X)
                    {
                        if (d.coord.X > m_current.coord.X)
                        {
                            m_current.coord.X++;
                            input.Down = Xim.ButtonState.Pressed;
                        }
                        else
                        {
                            m_current.coord.X--;
                            input.Up = Xim.ButtonState.Pressed;
                        }
                    }
                    else if (d.coord.Y != m_current.coord.Y)
                    {
                        if (d.coord.Y > m_current.coord.Y)
                        {
                            m_current.coord.Y++;
                            input.Right = Xim.ButtonState.Pressed;
                        }
                        else
                        {
                            m_current.coord.Y--;
                            input.Left = Xim.ButtonState.Pressed;
                        }
                    }
                    else if (m_current.shift != m_keyqueue.Peek().shift)
                    {
                        m_current.shift = m_keyqueue.Peek().shift;
                        Xim.SetButtonState(Xim.Button.LeftStick, Xim.ButtonState.Pressed, ref input);
                    }
                }
                mutex.ReleaseMutex();
            }
        }

        private bool FAtDestination()
        {
            if (m_keyqueue.Count == 0)
                return false;

            Destination d = m_keyqueue.Peek();
            return !d.hasDest || 
                (d.coord.X == m_current.coord.X && 
                d.coord.Y == m_current.coord.Y && 
                d.shift == m_current.shift);
        }

        public void Reset()
        {
            m_keyqueue.Clear();
            m_current.coord.X = 0;
            m_current.coord.Y = 0;
            m_current.shift = false;
            m_current.hasDest = false;
        }
    }
}
