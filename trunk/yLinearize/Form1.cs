using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XimApi;

namespace yLinearize
{
    public partial class Form1 : Form
    {
        MyThreadObj threadObj;
        
        public Form1()
        {
            InitializeComponent();

            threadObj = new MyThreadObj();
            threadObj.speed = short.Parse(textBox1.Text);
            threadObj.time = short.Parse(textBox3.Text);

            Thread myThread = new Thread(new ThreadStart(threadObj.Go));
            myThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            threadObj.abort = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                threadObj.speed = short.Parse(textBox1.Text);
            }
            catch { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                threadObj.time = short.Parse(textBox3.Text);
            }
            catch { }
        }

        private void plus1000_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s += 1000;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void min1000_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s -= 1000;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void plus100_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s += 100;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void plus20_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s += 20;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void min100_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s -= 100;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void min20_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s -= 20;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void plus5_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s += 5;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void min5_Click(object sender, EventArgs e)
        {
            try
            {
                short s = short.Parse(textBox3.Text);
                s -= 5;
                textBox3.Text = s.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            threadObj.going = !threadObj.going;
            button1.Text = threadObj.going ? "Stop" : "Start";
        }
    }

    public class MyThreadObj
    {
        private XimDyn xim;
        public bool abort = false;
        public bool going = false;
        public bool connected = false;
        public short speed = 0;
        public short time = 0;
        private bool up = true;

        public MyThreadObj()
        {
            xim = XimDyn.Instance;
            xim.Init();
        }

        public void Go()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            double wait = 16.666666;
            TimeSpan prevTick = watch.Elapsed;
            TimeSpan flipTime = watch.Elapsed;

            while (!abort)
            {
                
                while (watch.Elapsed.TotalMilliseconds - prevTick.TotalMilliseconds < wait)
                {
                    System.Threading.Thread.Sleep(0);
                }
                prevTick = watch.Elapsed;

                if (watch.Elapsed.TotalMilliseconds - flipTime.TotalMilliseconds > this.time)
                {
                    flipTime = watch.Elapsed;
                    up = !up;
                }

                if (going)
                {
                    if (!connected)
                    {
                        connected = Xim.Connect() == Xim.Status.OK;
                    }

                    if (connected)
                    {
                        Xim.Input input = new Xim.Input();
                        input.RightStickY = up ? (short)speed : (short)-speed;
                        Xim.SendInput(ref input, 1);
                    }
                }
                else
                {
                    if (connected)
                    {
                        Xim.Disconnect();
                        connected = false;
                    }
                }
            }
        }
    }
}
