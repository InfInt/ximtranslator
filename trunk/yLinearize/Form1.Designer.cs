namespace yLinearize
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.min1000 = new System.Windows.Forms.Button();
            this.plus1000 = new System.Windows.Forms.Button();
            this.min5 = new System.Windows.Forms.Button();
            this.plus5 = new System.Windows.Forms.Button();
            this.min20 = new System.Windows.Forms.Button();
            this.plus20 = new System.Windows.Forms.Button();
            this.min100 = new System.Windows.Forms.Button();
            this.plus100 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "15000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Y Speed";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 123);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(382, 129);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(71, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "1000";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Period";
            // 
            // min1000
            // 
            this.min1000.Location = new System.Drawing.Point(238, 9);
            this.min1000.Name = "min1000";
            this.min1000.Size = new System.Drawing.Size(48, 22);
            this.min1000.TabIndex = 19;
            this.min1000.Text = "-1000";
            this.min1000.UseVisualStyleBackColor = true;
            this.min1000.Click += new System.EventHandler(this.min1000_Click);
            // 
            // plus1000
            // 
            this.plus1000.Location = new System.Drawing.Point(181, 9);
            this.plus1000.Name = "plus1000";
            this.plus1000.Size = new System.Drawing.Size(51, 22);
            this.plus1000.TabIndex = 18;
            this.plus1000.Text = "+1000";
            this.plus1000.UseVisualStyleBackColor = true;
            this.plus1000.Click += new System.EventHandler(this.plus1000_Click);
            // 
            // min5
            // 
            this.min5.Location = new System.Drawing.Point(238, 93);
            this.min5.Name = "min5";
            this.min5.Size = new System.Drawing.Size(48, 22);
            this.min5.TabIndex = 17;
            this.min5.Text = "-5";
            this.min5.UseVisualStyleBackColor = true;
            this.min5.Click += new System.EventHandler(this.min5_Click);
            // 
            // plus5
            // 
            this.plus5.Location = new System.Drawing.Point(181, 93);
            this.plus5.Name = "plus5";
            this.plus5.Size = new System.Drawing.Size(51, 22);
            this.plus5.TabIndex = 16;
            this.plus5.Text = "+5";
            this.plus5.UseVisualStyleBackColor = true;
            this.plus5.Click += new System.EventHandler(this.plus5_Click);
            // 
            // min20
            // 
            this.min20.Location = new System.Drawing.Point(238, 65);
            this.min20.Name = "min20";
            this.min20.Size = new System.Drawing.Size(48, 22);
            this.min20.TabIndex = 15;
            this.min20.Text = "-20";
            this.min20.UseVisualStyleBackColor = true;
            this.min20.Click += new System.EventHandler(this.min20_Click);
            // 
            // plus20
            // 
            this.plus20.Location = new System.Drawing.Point(181, 65);
            this.plus20.Name = "plus20";
            this.plus20.Size = new System.Drawing.Size(51, 22);
            this.plus20.TabIndex = 14;
            this.plus20.Text = "+20";
            this.plus20.UseVisualStyleBackColor = true;
            this.plus20.Click += new System.EventHandler(this.plus20_Click);
            // 
            // min100
            // 
            this.min100.Location = new System.Drawing.Point(238, 37);
            this.min100.Name = "min100";
            this.min100.Size = new System.Drawing.Size(48, 22);
            this.min100.TabIndex = 13;
            this.min100.Text = "-100";
            this.min100.UseVisualStyleBackColor = true;
            this.min100.Click += new System.EventHandler(this.min100_Click);
            // 
            // plus100
            // 
            this.plus100.Location = new System.Drawing.Point(181, 37);
            this.plus100.Name = "plus100";
            this.plus100.Size = new System.Drawing.Size(51, 22);
            this.plus100.TabIndex = 12;
            this.plus100.Text = "+100";
            this.plus100.UseVisualStyleBackColor = true;
            this.plus100.Click += new System.EventHandler(this.plus100_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(71, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "15000";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "X Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 264);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.min1000);
            this.Controls.Add(this.plus1000);
            this.Controls.Add(this.min5);
            this.Controls.Add(this.plus5);
            this.Controls.Add(this.min20);
            this.Controls.Add(this.plus20);
            this.Controls.Add(this.min100);
            this.Controls.Add(this.plus100);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button min1000;
        private System.Windows.Forms.Button plus1000;
        private System.Windows.Forms.Button min5;
        private System.Windows.Forms.Button plus5;
        private System.Windows.Forms.Button min20;
        private System.Windows.Forms.Button plus20;
        private System.Windows.Forms.Button min100;
        private System.Windows.Forms.Button plus100;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
    }
}

