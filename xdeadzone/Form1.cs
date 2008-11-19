using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XimApi;
using Win32Api;
using Common;

namespace xdeadzone
{
    public partial class Form1 : Form
    {
        XimDyn dyn;
        UtilThread myThread = new UtilThread();
        public Form1()
        {
            InitializeComponent();
            dyn = XimDyn.Instance;
            dyn.Init();

            Thread thread = new Thread(new ThreadStart(myThread.Go));
            thread.Start();
            myThread.deadzone = short.Parse(txDeadzone.Text);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            myThread.abort = true;
            if (myThread.connected)
            {
                Xim.Disconnect();
            }
                
            base.OnClosing(e);
        }

        private void DoEnabled()
        {
            this.connect.Enabled = !myThread.connected;

            this.disconnect.Enabled = myThread.connected;
            this.bGo.Enabled = myThread.connected;
            this.bLeft.Enabled = myThread.connected;
            this.bRight.Enabled = myThread.connected;
            this.bUp.Enabled = myThread.connected;
            this.bDown.Enabled = myThread.connected;
        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (!myThread.connected)
            {
                myThread.connected = Xim.Connect() == Xim.Status.OK;
                DoEnabled();
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            if (myThread.connected)
            {
                myThread.connected = false;
                myThread.going = false;
                Xim.Disconnect();
                DoEnabled();
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            myThread.going = false;
            if (myThread.connected)
            {
                Xim.Input input = new Xim.Input();
                input.RightStickY = (short)Xim.Stick.Max;
                Xim.SendInput(ref input, 200);
                input.RightStickY = (short)Xim.Stick.Rest;
                Xim.SendInput(ref input, 20);
            }
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            myThread.going = false;
            if (myThread.connected)
            {
                Xim.Input input = new Xim.Input();
                input.RightStickX = (short)27000;
                Xim.SendInput(ref input, 100);
                input.RightStickX = (short)Xim.Stick.Rest;
                Xim.SendInput(ref input, 20);
            }
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            myThread.going = false;
            if (myThread.connected)
            {
                Xim.Input input = new Xim.Input();
                input.RightStickY = -(short)Xim.Stick.Max;
                Xim.SendInput(ref input, 200);
                input.RightStickY = -(short)Xim.Stick.Rest;
                Xim.SendInput(ref input, 20);
            }
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            myThread.going = false;
            if (myThread.connected)
            {
                Xim.Input input = new Xim.Input();
                input.RightStickX = -(short)27000;
                Xim.SendInput(ref input, 200);
                input.RightStickX = -(short)Xim.Stick.Rest;
                Xim.SendInput(ref input, 20);
            }
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            if (!myThread.going)
            {
                myThread.going = true;
            }
        }

        private void rbCircular_CheckedChanged(object sender, EventArgs e)
        {
            myThread.circular = rbCircular.Checked;
        }

        private void txDeadzone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myThread.deadzone = short.Parse(txDeadzone.Text);
            }
            catch { }
        }

        private void plus1000_Click(object sender, EventArgs e)
        {
            myThread.deadzone += 1000;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void min1000_Click(object sender, EventArgs e)
        {
            myThread.deadzone -= 1000;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void plus100_Click(object sender, EventArgs e)
        {
            myThread.deadzone += 100;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void min100_Click(object sender, EventArgs e)
        {
            myThread.deadzone -= 100;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void plus20_Click(object sender, EventArgs e)
        {
            myThread.deadzone += 20;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void min20_Click(object sender, EventArgs e)
        {
            myThread.deadzone -= 20;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myThread.deadzone += 5;
            txDeadzone.Text = myThread.deadzone.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myThread.deadzone -= 5;
            txDeadzone.Text = myThread.deadzone.ToString();
        }
    }

    public class UtilThread
    {
        public bool connected = false;
        public bool going = false;
        public bool abort = false;
        public short deadzone = 0;
        public bool circular = true;
        private XimDyn ximDyn;

        public UtilThread()
        {
            ximDyn = XimDyn.Instance;
        }

        public enum Dir
        {
            Up,
            Down,
            Left,
            Right
        }

        public void Go()
        {
            Xim.Input input = new Xim.Input();
            Xim.Input blankInput = new Xim.Input();
            Vector2 spot = new Vector2(deadzone,0);
            Dir direction = Dir.Down;
            double incVal = 500;
            while (!abort)
            {
                if (going)
                {
                    if (circular)
                    {
                        spot.Rotate(Math.PI / 90);
                        input.RightStickX = (short)(/*Math.Sign(spot.X) * 9600 +*/ (short)spot.X);
                        input.RightStickY = (short)(/*Math.Sign(spot.Y) * 9600 +*/ (short)spot.Y);
                        Xim.SendInput(ref input, 25);
                        //Xim.SendInput(ref blankInput, 0);
                    }
                    else
                    {
                        switch (direction)
                        {
                            case Dir.Up:
                                if (spot.Y < deadzone)
                                {
                                    spot.Y = spot.Y + incVal;
                                }
                                if (spot.Y >= deadzone)
                                {
                                    spot.Y = deadzone;
                                    direction = Dir.Right;
                                }
                                break;
                            case Dir.Right:
                                if (spot.X < deadzone)
                                {
                                    spot.X = spot.X + incVal;
                                }
                                if (spot.X >= deadzone)
                                {
                                    spot.X = deadzone;
                                    direction = Dir.Down;
                                }
                                break;
                            case Dir.Down:
                                if (spot.Y > -deadzone)
                                {
                                    spot.Y = spot.Y - incVal;
                                }
                                if (spot.Y <= -deadzone)
                                {
                                    spot.Y = -deadzone;
                                    direction = Dir.Left;
                                }
                                break;
                            case Dir.Left:
                                if (spot.X > -deadzone)
                                {
                                    spot.X = spot.X - incVal;
                                }
                                if (spot.X <= -deadzone)
                                {
                                    spot.X = -deadzone;
                                    direction = Dir.Up;
                                }
                                break;
                        }
                        input.RightStickX = (short)spot.X;
                        input.RightStickY = (short)spot.Y;
                        //input.LeftTrigger = (short)Xim.Stick.Max;
                        Xim.SendInput(ref input, 30);
                        //Xim.SendInput(ref blankInput, 0);
                    }
                }
                else
                {
                    spot.X = deadzone;
                    spot.Y = 0;
                }
            }
            this.ximDyn.Disconnect();
            this.connected = false;
        }
    };
}
