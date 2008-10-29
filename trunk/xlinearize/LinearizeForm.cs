using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                input.RightStickY = 50;
                input.RightStickX = short.Parse(this.mouseInput.Text);
                this.watch.Start();
                this.xim.SendInput(ref input, 1);
            }
            else
            {
                this.outputBox.Text+=Environment.NewLine+" Input: "+this.mouseInput.Text+" \tTime: "+ Math.Round((double)watch.ElapsedMilliseconds) + "\t Revolutions: ";
                this.xim.Disconnect();
            }
        }
    }
}
