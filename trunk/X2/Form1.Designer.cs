namespace X2
{
    partial class X2
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.cbAutoAnalogDisc = new System.Windows.Forms.CheckBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tbTextModeRate = new System.Windows.Forms.TextBox();
            this.tbYxRatio = new System.Windows.Forms.TextBox();
            this.tbTransExponent2 = new System.Windows.Forms.TextBox();
            this.tbTransExponent1 = new System.Windows.Forms.TextBox();
            this.tbSmoothness = new System.Windows.Forms.TextBox();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.lbTextRate = new System.Windows.Forms.Label();
            this.tbDiagonalDampen = new System.Windows.Forms.TextBox();
            this.lbRate = new System.Windows.Forms.Label();
            this.tbSensitivity2 = new System.Windows.Forms.TextBox();
            this.lbSmoothness = new System.Windows.Forms.Label();
            this.tbSensitivity1 = new System.Windows.Forms.TextBox();
            this.lbDampen = new System.Windows.Forms.Label();
            this.tbDeadzone = new System.Windows.Forms.TextBox();
            this.lbYxRatio = new System.Windows.Forms.Label();
            this.lbTransExp2 = new System.Windows.Forms.Label();
            this.lbTransExp1 = new System.Windows.Forms.Label();
            this.lbSens2 = new System.Windows.Forms.Label();
            this.lbSens1 = new System.Windows.Forms.Label();
            this.lbDeadzone = new System.Windows.Forms.Label();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.labelDeadzone = new System.Windows.Forms.Label();
            this.rbCircular = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Connect);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(447, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LoadConfig);
            // 
            // infoText
            // 
            this.infoText.Location = new System.Drawing.Point(12, 302);
            this.infoText.Multiline = true;
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoText.Size = new System.Drawing.Size(429, 184);
            this.infoText.TabIndex = 0;
            this.infoText.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(447, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save Config";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SaveConfig);
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(12, 492);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(429, 20);
            this.commandBox.TabIndex = 0;
            this.commandBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandBoxKeyPressed);
            // 
            // cbAutoAnalogDisc
            // 
            this.cbAutoAnalogDisc.AutoSize = true;
            this.cbAutoAnalogDisc.Location = new System.Drawing.Point(10, 19);
            this.cbAutoAnalogDisc.Name = "cbAutoAnalogDisc";
            this.cbAutoAnalogDisc.Size = new System.Drawing.Size(141, 17);
            this.cbAutoAnalogDisc.TabIndex = 4;
            this.cbAutoAnalogDisc.Text = "Auto Analog Disconnect";
            this.cbAutoAnalogDisc.UseVisualStyleBackColor = true;
            this.cbAutoAnalogDisc.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tbTextModeRate);
            this.gbSettings.Controls.Add(this.tbYxRatio);
            this.gbSettings.Controls.Add(this.tbTransExponent2);
            this.gbSettings.Controls.Add(this.tbTransExponent1);
            this.gbSettings.Controls.Add(this.tbSmoothness);
            this.gbSettings.Controls.Add(this.tbRate);
            this.gbSettings.Controls.Add(this.lbTextRate);
            this.gbSettings.Controls.Add(this.tbDiagonalDampen);
            this.gbSettings.Controls.Add(this.lbRate);
            this.gbSettings.Controls.Add(this.tbSensitivity2);
            this.gbSettings.Controls.Add(this.lbSmoothness);
            this.gbSettings.Controls.Add(this.tbSensitivity1);
            this.gbSettings.Controls.Add(this.lbDampen);
            this.gbSettings.Controls.Add(this.tbDeadzone);
            this.gbSettings.Controls.Add(this.lbYxRatio);
            this.gbSettings.Controls.Add(this.lbTransExp2);
            this.gbSettings.Controls.Add(this.lbTransExp1);
            this.gbSettings.Controls.Add(this.lbSens2);
            this.gbSettings.Controls.Add(this.lbSens1);
            this.gbSettings.Controls.Add(this.lbDeadzone);
            this.gbSettings.Controls.Add(this.rbSquare);
            this.gbSettings.Controls.Add(this.labelDeadzone);
            this.gbSettings.Controls.Add(this.rbCircular);
            this.gbSettings.Controls.Add(this.cbAutoAnalogDisc);
            this.gbSettings.Location = new System.Drawing.Point(528, 302);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(323, 206);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // tbTextModeRate
            // 
            this.tbTextModeRate.Location = new System.Drawing.Point(240, 166);
            this.tbTextModeRate.Name = "tbTextModeRate";
            this.tbTextModeRate.Size = new System.Drawing.Size(43, 20);
            this.tbTextModeRate.TabIndex = 41;
            this.tbTextModeRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbYxRatio
            // 
            this.tbYxRatio.Location = new System.Drawing.Point(240, 140);
            this.tbYxRatio.Name = "tbYxRatio";
            this.tbYxRatio.Size = new System.Drawing.Size(43, 20);
            this.tbYxRatio.TabIndex = 40;
            this.tbYxRatio.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbTransExponent2
            // 
            this.tbTransExponent2.AcceptsReturn = true;
            this.tbTransExponent2.Location = new System.Drawing.Point(240, 114);
            this.tbTransExponent2.Name = "tbTransExponent2";
            this.tbTransExponent2.Size = new System.Drawing.Size(43, 20);
            this.tbTransExponent2.TabIndex = 39;
            this.tbTransExponent2.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbTransExponent1
            // 
            this.tbTransExponent1.Location = new System.Drawing.Point(240, 88);
            this.tbTransExponent1.Name = "tbTransExponent1";
            this.tbTransExponent1.Size = new System.Drawing.Size(43, 20);
            this.tbTransExponent1.TabIndex = 38;
            this.tbTransExponent1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbSmoothness
            // 
            this.tbSmoothness.Location = new System.Drawing.Point(240, 62);
            this.tbSmoothness.Name = "tbSmoothness";
            this.tbSmoothness.Size = new System.Drawing.Size(43, 20);
            this.tbSmoothness.TabIndex = 37;
            this.tbSmoothness.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(108, 166);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(43, 20);
            this.tbRate.TabIndex = 36;
            this.tbRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbTextRate
            // 
            this.lbTextRate.AutoSize = true;
            this.lbTextRate.Location = new System.Drawing.Point(180, 169);
            this.lbTextRate.Name = "lbTextRate";
            this.lbTextRate.Size = new System.Drawing.Size(54, 13);
            this.lbTextRate.TabIndex = 26;
            this.lbTextRate.Text = "Text Rate";
            // 
            // tbDiagonalDampen
            // 
            this.tbDiagonalDampen.Location = new System.Drawing.Point(108, 140);
            this.tbDiagonalDampen.Name = "tbDiagonalDampen";
            this.tbDiagonalDampen.Size = new System.Drawing.Size(43, 20);
            this.tbDiagonalDampen.TabIndex = 35;
            this.tbDiagonalDampen.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.Location = new System.Drawing.Point(7, 169);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(30, 13);
            this.lbRate.TabIndex = 24;
            this.lbRate.Text = "Rate";
            // 
            // tbSensitivity2
            // 
            this.tbSensitivity2.Location = new System.Drawing.Point(108, 114);
            this.tbSensitivity2.Name = "tbSensitivity2";
            this.tbSensitivity2.Size = new System.Drawing.Size(43, 20);
            this.tbSensitivity2.TabIndex = 34;
            this.tbSensitivity2.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbSmoothness
            // 
            this.lbSmoothness.AutoSize = true;
            this.lbSmoothness.Location = new System.Drawing.Point(169, 65);
            this.lbSmoothness.Name = "lbSmoothness";
            this.lbSmoothness.Size = new System.Drawing.Size(65, 13);
            this.lbSmoothness.TabIndex = 22;
            this.lbSmoothness.Text = "Smoothness";
            // 
            // tbSensitivity1
            // 
            this.tbSensitivity1.Location = new System.Drawing.Point(108, 88);
            this.tbSensitivity1.Name = "tbSensitivity1";
            this.tbSensitivity1.Size = new System.Drawing.Size(43, 20);
            this.tbSensitivity1.TabIndex = 33;
            this.tbSensitivity1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbDampen
            // 
            this.lbDampen.AutoSize = true;
            this.lbDampen.Location = new System.Drawing.Point(7, 143);
            this.lbDampen.Name = "lbDampen";
            this.lbDampen.Size = new System.Drawing.Size(92, 13);
            this.lbDampen.TabIndex = 20;
            this.lbDampen.Text = "Diagonal Dampen";
            // 
            // tbDeadzone
            // 
            this.tbDeadzone.Location = new System.Drawing.Point(108, 62);
            this.tbDeadzone.Name = "tbDeadzone";
            this.tbDeadzone.Size = new System.Drawing.Size(43, 20);
            this.tbDeadzone.TabIndex = 32;
            this.toolTip1.SetToolTip(this.tbDeadzone, "test");
            // 
            // lbYxRatio
            // 
            this.lbYxRatio.AutoSize = true;
            this.lbYxRatio.Location = new System.Drawing.Point(182, 143);
            this.lbYxRatio.Name = "lbYxRatio";
            this.lbYxRatio.Size = new System.Drawing.Size(52, 13);
            this.lbYxRatio.TabIndex = 18;
            this.lbYxRatio.Text = "Y:X Ratio";
            // 
            // lbTransExp2
            // 
            this.lbTransExp2.AutoSize = true;
            this.lbTransExp2.Location = new System.Drawing.Point(176, 117);
            this.lbTransExp2.Name = "lbTransExp2";
            this.lbTransExp2.Size = new System.Drawing.Size(58, 13);
            this.lbTransExp2.TabIndex = 16;
            this.lbTransExp2.Text = "TransExp2";
            // 
            // lbTransExp1
            // 
            this.lbTransExp1.AutoSize = true;
            this.lbTransExp1.Location = new System.Drawing.Point(176, 91);
            this.lbTransExp1.Name = "lbTransExp1";
            this.lbTransExp1.Size = new System.Drawing.Size(58, 13);
            this.lbTransExp1.TabIndex = 14;
            this.lbTransExp1.Text = "TransExp1";
            // 
            // lbSens2
            // 
            this.lbSens2.AutoSize = true;
            this.lbSens2.Location = new System.Drawing.Point(7, 117);
            this.lbSens2.Name = "lbSens2";
            this.lbSens2.Size = new System.Drawing.Size(60, 13);
            this.lbSens2.TabIndex = 12;
            this.lbSens2.Text = "Sensitivity2";
            // 
            // lbSens1
            // 
            this.lbSens1.AutoSize = true;
            this.lbSens1.Location = new System.Drawing.Point(7, 91);
            this.lbSens1.Name = "lbSens1";
            this.lbSens1.Size = new System.Drawing.Size(60, 13);
            this.lbSens1.TabIndex = 10;
            this.lbSens1.Text = "Sensitivity1";
            // 
            // lbDeadzone
            // 
            this.lbDeadzone.AutoSize = true;
            this.lbDeadzone.Location = new System.Drawing.Point(7, 65);
            this.lbDeadzone.Name = "lbDeadzone";
            this.lbDeadzone.Size = new System.Drawing.Size(79, 13);
            this.lbDeadzone.TabIndex = 8;
            this.lbDeadzone.Text = "Deadzone Size";
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(162, 37);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(59, 17);
            this.rbSquare.TabIndex = 7;
            this.rbSquare.TabStop = true;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            // 
            // labelDeadzone
            // 
            this.labelDeadzone.AutoSize = true;
            this.labelDeadzone.Location = new System.Drawing.Point(7, 39);
            this.labelDeadzone.Name = "labelDeadzone";
            this.labelDeadzone.Size = new System.Drawing.Size(83, 13);
            this.labelDeadzone.TabIndex = 6;
            this.labelDeadzone.Text = "Deadzone Type";
            // 
            // rbCircular
            // 
            this.rbCircular.AutoSize = true;
            this.rbCircular.Location = new System.Drawing.Point(96, 37);
            this.rbCircular.Name = "rbCircular";
            this.rbCircular.Size = new System.Drawing.Size(60, 17);
            this.rbCircular.TabIndex = 5;
            this.rbCircular.TabStop = true;
            this.rbCircular.Text = "Circular";
            this.rbCircular.UseVisualStyleBackColor = true;
            this.rbCircular.CheckedChanged += new System.EventHandler(this.rbDeadzoneType_CheckedChanged);
            // 
            // X2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "X2";
            this.ShowIcon = false;
            this.Text = "Xim Translator by Xod";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.CheckBox cbAutoAnalogDisc;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.Label labelDeadzone;
        private System.Windows.Forms.RadioButton rbCircular;
        private System.Windows.Forms.Label lbDeadzone;
        private System.Windows.Forms.Label lbSens1;
        private System.Windows.Forms.Label lbSens2;
        private System.Windows.Forms.Label lbTransExp2;
        private System.Windows.Forms.Label lbTransExp1;
        private System.Windows.Forms.Label lbYxRatio;
        private System.Windows.Forms.Label lbDampen;
        private System.Windows.Forms.Label lbSmoothness;
        private System.Windows.Forms.Label lbTextRate;
        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.TextBox tbDiagonalDampen;
        private System.Windows.Forms.TextBox tbSensitivity2;
        private System.Windows.Forms.TextBox tbSensitivity1;
        private System.Windows.Forms.TextBox tbDeadzone;
        private System.Windows.Forms.TextBox tbTextModeRate;
        private System.Windows.Forms.TextBox tbYxRatio;
        private System.Windows.Forms.TextBox tbTransExponent2;
        private System.Windows.Forms.TextBox tbTransExponent1;
        private System.Windows.Forms.TextBox tbSmoothness;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

