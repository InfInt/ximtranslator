namespace Linearize
{
    partial class LinearizeForm
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
            this.mouseInput = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.revCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button1_KeyPress);
            // 
            // mouseInput
            // 
            this.mouseInput.Location = new System.Drawing.Point(12, 15);
            this.mouseInput.Multiline = true;
            this.mouseInput.Name = "mouseInput";
            this.mouseInput.Size = new System.Drawing.Size(100, 20);
            this.mouseInput.TabIndex = 1;
            this.mouseInput.Text = "1000";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 63);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(401, 147);
            this.outputBox.TabIndex = 3;
            // 
            // revCount
            // 
            this.revCount.AutoSize = true;
            this.revCount.Location = new System.Drawing.Point(147, 18);
            this.revCount.Name = "revCount";
            this.revCount.Size = new System.Drawing.Size(70, 13);
            this.revCount.TabIndex = 4;
            this.revCount.Text = "Rev Count: 0";
            // 
            // LinearizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 266);
            this.Controls.Add(this.revCount);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.mouseInput);
            this.Controls.Add(this.button1);
            this.Name = "LinearizeForm";
            this.Text = "Linearize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mouseInput;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label revCount;
    }
}

