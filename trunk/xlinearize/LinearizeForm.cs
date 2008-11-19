using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XimApi;
using Common;

namespace Linearize
{
    public partial class LinearizeForm : Form
    {
        XimDyn xim;
        private System.Diagnostics.Stopwatch watch;
        private int count = 0;
        public LinearizeForm()
        {
            InitializeComponent();

            this.watch = new System.Diagnostics.Stopwatch();
            this.xim = Singleton<XimDyn>.Instance;
            this.xim.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (xim.Connect() == Xim.Status.OK)
            {
                this.watch.Reset();
                Xim.Input input = new Xim.Input();
                //input.LeftTrigger = (short)Xim.Stick.Max;
                this.xim.SendInput(ref input, 500);
                input.RightStickY = 0;
                input.RightStickX = short.Parse(this.mouseInput.Text);
                this.watch.Start();
                this.xim.SendInput(ref input, 1);
            }
            else
            {
                this.count++;
                this.outputBox.Text += Environment.NewLine + " Input: " + this.mouseInput.Text + " \tTime: " + Math.Round((double)watch.ElapsedMilliseconds) + "\t Revolutions: " + this.count;
                this.count = 0;
                this.xim.Disconnect();
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'n')
            {
                this.count++;
                this.revCount.Text = "Rev Count: " + this.count;
            }
        }
    }
}
