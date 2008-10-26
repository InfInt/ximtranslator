namespace xdeadzone
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.rbCircular = new System.Windows.Forms.RadioButton();
            this.txDeadzone = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.plus100 = new System.Windows.Forms.Button();
            this.min100 = new System.Windows.Forms.Button();
            this.min20 = new System.Windows.Forms.Button();
            this.plus20 = new System.Windows.Forms.Button();
            this.min5 = new System.Windows.Forms.Button();
            this.plus5 = new System.Windows.Forms.Button();
            this.min1000 = new System.Windows.Forms.Button();
            this.plus1000 = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.bLeft = new System.Windows.Forms.Button();
            this.bRight = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.bGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(27, 40);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(59, 17);
            this.rbSquare.TabIndex = 0;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            // 
            // rbCircular
            // 
            this.rbCircular.AutoSize = true;
            this.rbCircular.Checked = true;
            this.rbCircular.Location = new System.Drawing.Point(27, 17);
            this.rbCircular.Name = "rbCircular";
            this.rbCircular.Size = new System.Drawing.Size(60, 17);
            this.rbCircular.TabIndex = 1;
            this.rbCircular.TabStop = true;
            this.rbCircular.Text = "Circular";
            this.rbCircular.UseVisualStyleBackColor = true;
            this.rbCircular.CheckedChanged += new System.EventHandler(this.rbCircular_CheckedChanged);
            // 
            // txDeadzone
            // 
            this.txDeadzone.Location = new System.Drawing.Point(27, 63);
            this.txDeadzone.Name = "txDeadzone";
            this.txDeadzone.Size = new System.Drawing.Size(100, 20);
            this.txDeadzone.TabIndex = 2;
            this.txDeadzone.Text = "6000";
            this.txDeadzone.TextChanged += new System.EventHandler(this.txDeadzone_TextChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1,
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(284, 264);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(92, 43);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(14, 12);
            // 
            // ovalShape1
            // 
            this.ovalShape1.Location = new System.Drawing.Point(91, 18);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(16, 13);
            // 
            // plus100
            // 
            this.plus100.Location = new System.Drawing.Point(23, 119);
            this.plus100.Name = "plus100";
            this.plus100.Size = new System.Drawing.Size(51, 22);
            this.plus100.TabIndex = 4;
            this.plus100.Text = "+100";
            this.plus100.UseVisualStyleBackColor = true;
            this.plus100.Click += new System.EventHandler(this.plus100_Click);
            // 
            // min100
            // 
            this.min100.Location = new System.Drawing.Point(80, 119);
            this.min100.Name = "min100";
            this.min100.Size = new System.Drawing.Size(48, 22);
            this.min100.TabIndex = 5;
            this.min100.Text = "-100";
            this.min100.UseVisualStyleBackColor = true;
            this.min100.Click += new System.EventHandler(this.min100_Click);
            // 
            // min20
            // 
            this.min20.Location = new System.Drawing.Point(80, 147);
            this.min20.Name = "min20";
            this.min20.Size = new System.Drawing.Size(48, 22);
            this.min20.TabIndex = 7;
            this.min20.Text = "-20";
            this.min20.UseVisualStyleBackColor = true;
            this.min20.Click += new System.EventHandler(this.min20_Click);
            // 
            // plus20
            // 
            this.plus20.Location = new System.Drawing.Point(23, 147);
            this.plus20.Name = "plus20";
            this.plus20.Size = new System.Drawing.Size(51, 22);
            this.plus20.TabIndex = 6;
            this.plus20.Text = "+20";
            this.plus20.UseVisualStyleBackColor = true;
            this.plus20.Click += new System.EventHandler(this.plus20_Click);
            // 
            // min5
            // 
            this.min5.Location = new System.Drawing.Point(80, 175);
            this.min5.Name = "min5";
            this.min5.Size = new System.Drawing.Size(48, 22);
            this.min5.TabIndex = 9;
            this.min5.Text = "-5";
            this.min5.UseVisualStyleBackColor = true;
            this.min5.Click += new System.EventHandler(this.button3_Click);
            // 
            // plus5
            // 
            this.plus5.Location = new System.Drawing.Point(23, 175);
            this.plus5.Name = "plus5";
            this.plus5.Size = new System.Drawing.Size(51, 22);
            this.plus5.TabIndex = 8;
            this.plus5.Text = "+5";
            this.plus5.UseVisualStyleBackColor = true;
            this.plus5.Click += new System.EventHandler(this.button4_Click);
            // 
            // min1000
            // 
            this.min1000.Location = new System.Drawing.Point(80, 91);
            this.min1000.Name = "min1000";
            this.min1000.Size = new System.Drawing.Size(48, 22);
            this.min1000.TabIndex = 11;
            this.min1000.Text = "-1000";
            this.min1000.UseVisualStyleBackColor = true;
            this.min1000.Click += new System.EventHandler(this.min1000_Click);
            // 
            // plus1000
            // 
            this.plus1000.Location = new System.Drawing.Point(23, 91);
            this.plus1000.Name = "plus1000";
            this.plus1000.Size = new System.Drawing.Size(51, 22);
            this.plus1000.TabIndex = 10;
            this.plus1000.Text = "+1000";
            this.plus1000.UseVisualStyleBackColor = true;
            this.plus1000.Click += new System.EventHandler(this.plus1000_Click);
            // 
            // bUp
            // 
            this.bUp.Enabled = false;
            this.bUp.Location = new System.Drawing.Point(206, 147);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(48, 34);
            this.bUp.TabIndex = 12;
            this.bUp.Text = "Up";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Enabled = false;
            this.bDown.Location = new System.Drawing.Point(206, 218);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(48, 34);
            this.bDown.TabIndex = 13;
            this.bDown.Text = "Down";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bLeft
            // 
            this.bLeft.Enabled = false;
            this.bLeft.Location = new System.Drawing.Point(179, 183);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(48, 34);
            this.bLeft.TabIndex = 14;
            this.bLeft.Text = "Left";
            this.bLeft.UseVisualStyleBackColor = true;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // bRight
            // 
            this.bRight.Enabled = false;
            this.bRight.Location = new System.Drawing.Point(233, 183);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(48, 34);
            this.bRight.TabIndex = 15;
            this.bRight.Text = "Right";
            this.bRight.UseVisualStyleBackColor = true;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(197, 3);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 16;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Location = new System.Drawing.Point(197, 32);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 23);
            this.disconnect.TabIndex = 17;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // bGo
            // 
            this.bGo.Enabled = false;
            this.bGo.Location = new System.Drawing.Point(133, 63);
            this.bGo.Name = "bGo";
            this.bGo.Size = new System.Drawing.Size(30, 20);
            this.bGo.TabIndex = 18;
            this.bGo.Text = "Go";
            this.bGo.UseVisualStyleBackColor = true;
            this.bGo.Click += new System.EventHandler(this.bGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.bGo);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.bRight);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.min1000);
            this.Controls.Add(this.plus1000);
            this.Controls.Add(this.min5);
            this.Controls.Add(this.plus5);
            this.Controls.Add(this.min20);
            this.Controls.Add(this.plus20);
            this.Controls.Add(this.min100);
            this.Controls.Add(this.plus100);
            this.Controls.Add(this.txDeadzone);
            this.Controls.Add(this.rbCircular);
            this.Controls.Add(this.rbSquare);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Form1";
            this.Text = "xDeadzone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.RadioButton rbCircular;
        private System.Windows.Forms.TextBox txDeadzone;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Button plus100;
        private System.Windows.Forms.Button min100;
        private System.Windows.Forms.Button min20;
        private System.Windows.Forms.Button plus20;
        private System.Windows.Forms.Button min5;
        private System.Windows.Forms.Button plus5;
        private System.Windows.Forms.Button min1000;
        private System.Windows.Forms.Button plus1000;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.Button bRight;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button bGo;
    }
}

