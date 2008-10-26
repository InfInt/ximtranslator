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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(X2));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.cbAutoAnalogDisc = new System.Windows.Forms.CheckBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.txTextModeRate = new System.Windows.Forms.TextBox();
            this.txYxRatio = new System.Windows.Forms.TextBox();
            this.txTransExponent1 = new System.Windows.Forms.TextBox();
            this.txSmoothness = new System.Windows.Forms.TextBox();
            this.txRate = new System.Windows.Forms.TextBox();
            this.lbTextRate = new System.Windows.Forms.Label();
            this.txDiagonalDampen = new System.Windows.Forms.TextBox();
            this.lbRate = new System.Windows.Forms.Label();
            this.txSensitivity2 = new System.Windows.Forms.TextBox();
            this.lbSmoothness = new System.Windows.Forms.Label();
            this.txSensitivity1 = new System.Windows.Forms.TextBox();
            this.lbDampen = new System.Windows.Forms.Label();
            this.txDeadzone = new System.Windows.Forms.TextBox();
            this.lbYxRatio = new System.Windows.Forms.Label();
            this.lbTransExp1 = new System.Windows.Forms.Label();
            this.lbSens2 = new System.Windows.Forms.Label();
            this.lbSens1 = new System.Windows.Forms.Label();
            this.lbDeadzone = new System.Windows.Forms.Label();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.labelDeadzone = new System.Windows.Forms.Label();
            this.rbCircular = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.calibration = new System.Windows.Forms.Button();
            this.ximPanel = new System.Windows.Forms.Panel();
            this.x2Panel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSens = new System.Windows.Forms.TrackBar();
            this.tbAccel = new System.Windows.Forms.TrackBar();
            this.lbSensitivity = new System.Windows.Forms.Label();
            this.txSensitivity = new System.Windows.Forms.TextBox();
            this.txAccel = new System.Windows.Forms.TextBox();
            this.lbAccel = new System.Windows.Forms.Label();
            this.gbSettings.SuspendLayout();
            this.ximPanel.SuspendLayout();
            this.x2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAccel)).BeginInit();
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
            this.cbAutoAnalogDisc.Location = new System.Drawing.Point(13, 139);
            this.cbAutoAnalogDisc.Name = "cbAutoAnalogDisc";
            this.cbAutoAnalogDisc.Size = new System.Drawing.Size(141, 17);
            this.cbAutoAnalogDisc.TabIndex = 4;
            this.cbAutoAnalogDisc.Text = "Auto Analog Disconnect";
            this.cbAutoAnalogDisc.UseVisualStyleBackColor = true;
            this.cbAutoAnalogDisc.CheckedChanged += new System.EventHandler(this.autoAnalogDisconnect_CheckedChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.x2Panel);
            this.gbSettings.Controls.Add(this.ximPanel);
            this.gbSettings.Location = new System.Drawing.Point(528, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(323, 496);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "General Settings";
            // 
            // tbTextModeRate
            // 
            this.txTextModeRate.Location = new System.Drawing.Point(410, 71);
            this.txTextModeRate.Name = "tbTextModeRate";
            this.txTextModeRate.Size = new System.Drawing.Size(43, 20);
            this.txTextModeRate.TabIndex = 41;
            this.txTextModeRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbYxRatio
            // 
            this.txYxRatio.Location = new System.Drawing.Point(229, 90);
            this.txYxRatio.Name = "tbYxRatio";
            this.txYxRatio.Size = new System.Drawing.Size(43, 20);
            this.txYxRatio.TabIndex = 40;
            this.txYxRatio.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbTransExponent1
            // 
            this.txTransExponent1.Location = new System.Drawing.Point(229, 67);
            this.txTransExponent1.Name = "tbTransExponent1";
            this.txTransExponent1.Size = new System.Drawing.Size(43, 20);
            this.txTransExponent1.TabIndex = 38;
            this.txTransExponent1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbSmoothness
            // 
            this.txSmoothness.Location = new System.Drawing.Point(229, 43);
            this.txSmoothness.Name = "tbSmoothness";
            this.txSmoothness.Size = new System.Drawing.Size(43, 20);
            this.txSmoothness.TabIndex = 37;
            this.txSmoothness.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // tbRate
            // 
            this.txRate.Location = new System.Drawing.Point(410, 31);
            this.txRate.Name = "tbRate";
            this.txRate.Size = new System.Drawing.Size(43, 20);
            this.txRate.TabIndex = 36;
            this.txRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbTextRate
            // 
            this.lbTextRate.AutoSize = true;
            this.lbTextRate.Location = new System.Drawing.Point(350, 74);
            this.lbTextRate.Name = "lbTextRate";
            this.lbTextRate.Size = new System.Drawing.Size(54, 13);
            this.lbTextRate.TabIndex = 26;
            this.lbTextRate.Text = "Text Rate";
            // 
            // tbDiagonalDampen
            // 
            this.txDiagonalDampen.Location = new System.Drawing.Point(111, 113);
            this.txDiagonalDampen.Name = "tbDiagonalDampen";
            this.txDiagonalDampen.Size = new System.Drawing.Size(43, 20);
            this.txDiagonalDampen.TabIndex = 35;
            this.txDiagonalDampen.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.Location = new System.Drawing.Point(350, 31);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(30, 13);
            this.lbRate.TabIndex = 24;
            this.lbRate.Text = "Rate";
            // 
            // tbSensitivity2
            // 
            this.txSensitivity2.Location = new System.Drawing.Point(111, 90);
            this.txSensitivity2.Name = "tbSensitivity2";
            this.txSensitivity2.Size = new System.Drawing.Size(43, 20);
            this.txSensitivity2.TabIndex = 34;
            this.txSensitivity2.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbSmoothness
            // 
            this.lbSmoothness.AutoSize = true;
            this.lbSmoothness.Location = new System.Drawing.Point(158, 46);
            this.lbSmoothness.Name = "lbSmoothness";
            this.lbSmoothness.Size = new System.Drawing.Size(65, 13);
            this.lbSmoothness.TabIndex = 22;
            this.lbSmoothness.Text = "Smoothness";
            // 
            // tbSensitivity1
            // 
            this.txSensitivity1.Location = new System.Drawing.Point(111, 67);
            this.txSensitivity1.Name = "tbSensitivity1";
            this.txSensitivity1.Size = new System.Drawing.Size(43, 20);
            this.txSensitivity1.TabIndex = 33;
            this.txSensitivity1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbDampen
            // 
            this.lbDampen.AutoSize = true;
            this.lbDampen.Location = new System.Drawing.Point(10, 116);
            this.lbDampen.Name = "lbDampen";
            this.lbDampen.Size = new System.Drawing.Size(92, 13);
            this.lbDampen.TabIndex = 20;
            this.lbDampen.Text = "Diagonal Dampen";
            // 
            // tbDeadzone
            // 
            this.txDeadzone.Location = new System.Drawing.Point(111, 43);
            this.txDeadzone.Name = "tbDeadzone";
            this.txDeadzone.Size = new System.Drawing.Size(43, 20);
            this.txDeadzone.TabIndex = 32;
            this.toolTip1.SetToolTip(this.txDeadzone, "test");
            this.txDeadzone.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            // 
            // lbYxRatio
            // 
            this.lbYxRatio.AutoSize = true;
            this.lbYxRatio.Location = new System.Drawing.Point(171, 93);
            this.lbYxRatio.Name = "lbYxRatio";
            this.lbYxRatio.Size = new System.Drawing.Size(52, 13);
            this.lbYxRatio.TabIndex = 18;
            this.lbYxRatio.Text = "Y:X Ratio";
            // 
            // lbTransExp1
            // 
            this.lbTransExp1.AutoSize = true;
            this.lbTransExp1.Location = new System.Drawing.Point(165, 70);
            this.lbTransExp1.Name = "lbTransExp1";
            this.lbTransExp1.Size = new System.Drawing.Size(58, 13);
            this.lbTransExp1.TabIndex = 14;
            this.lbTransExp1.Text = "TransExp1";
            // 
            // lbSens2
            // 
            this.lbSens2.AutoSize = true;
            this.lbSens2.Location = new System.Drawing.Point(10, 93);
            this.lbSens2.Name = "lbSens2";
            this.lbSens2.Size = new System.Drawing.Size(60, 13);
            this.lbSens2.TabIndex = 12;
            this.lbSens2.Text = "Sensitivity2";
            // 
            // lbSens1
            // 
            this.lbSens1.AutoSize = true;
            this.lbSens1.Location = new System.Drawing.Point(10, 70);
            this.lbSens1.Name = "lbSens1";
            this.lbSens1.Size = new System.Drawing.Size(60, 13);
            this.lbSens1.TabIndex = 10;
            this.lbSens1.Text = "Sensitivity1";
            // 
            // lbDeadzone
            // 
            this.lbDeadzone.AutoSize = true;
            this.lbDeadzone.Location = new System.Drawing.Point(10, 46);
            this.lbDeadzone.Name = "lbDeadzone";
            this.lbDeadzone.Size = new System.Drawing.Size(79, 13);
            this.lbDeadzone.TabIndex = 8;
            this.lbDeadzone.Text = "Deadzone Size";
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(168, 15);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(59, 17);
            this.rbSquare.TabIndex = 7;
            this.rbSquare.TabStop = true;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            this.rbSquare.CheckedChanged += new System.EventHandler(this.rbDeadzoneType_CheckedChanged);
            // 
            // labelDeadzone
            // 
            this.labelDeadzone.AutoSize = true;
            this.labelDeadzone.Location = new System.Drawing.Point(10, 17);
            this.labelDeadzone.Name = "labelDeadzone";
            this.labelDeadzone.Size = new System.Drawing.Size(83, 13);
            this.labelDeadzone.TabIndex = 6;
            this.labelDeadzone.Text = "Deadzone Type";
            // 
            // rbCircular
            // 
            this.rbCircular.AutoSize = true;
            this.rbCircular.Location = new System.Drawing.Point(102, 15);
            this.rbCircular.Name = "rbCircular";
            this.rbCircular.Size = new System.Drawing.Size(60, 17);
            this.rbCircular.TabIndex = 5;
            this.rbCircular.TabStop = true;
            this.rbCircular.Text = "Circular";
            this.rbCircular.UseVisualStyleBackColor = true;
            this.rbCircular.CheckedChanged += new System.EventHandler(this.rbDeadzoneType_CheckedChanged);
            // 
            // calibration
            // 
            this.calibration.Location = new System.Drawing.Point(447, 389);
            this.calibration.Name = "calibration";
            this.calibration.Size = new System.Drawing.Size(75, 23);
            this.calibration.TabIndex = 6;
            this.calibration.Text = "Calibrate";
            this.calibration.UseVisualStyleBackColor = true;
            this.calibration.Click += new System.EventHandler(this.calibration_Click);
            // 
            // ximPanel
            // 
            this.ximPanel.Controls.Add(this.cbAutoAnalogDisc);
            this.ximPanel.Controls.Add(this.labelDeadzone);
            this.ximPanel.Controls.Add(this.rbSquare);
            this.ximPanel.Controls.Add(this.txDiagonalDampen);
            this.ximPanel.Controls.Add(this.txYxRatio);
            this.ximPanel.Controls.Add(this.lbDampen);
            this.ximPanel.Controls.Add(this.txSensitivity2);
            this.ximPanel.Controls.Add(this.rbCircular);
            this.ximPanel.Controls.Add(this.lbYxRatio);
            this.ximPanel.Controls.Add(this.txTransExponent1);
            this.ximPanel.Controls.Add(this.lbSens2);
            this.ximPanel.Controls.Add(this.lbDeadzone);
            this.ximPanel.Controls.Add(this.txSensitivity1);
            this.ximPanel.Controls.Add(this.txSmoothness);
            this.ximPanel.Controls.Add(this.lbSens1);
            this.ximPanel.Controls.Add(this.lbTransExp1);
            this.ximPanel.Controls.Add(this.lbSmoothness);
            this.ximPanel.Controls.Add(this.txDeadzone);
            this.ximPanel.Location = new System.Drawing.Point(6, 319);
            this.ximPanel.Name = "ximPanel";
            this.ximPanel.Size = new System.Drawing.Size(311, 171);
            this.ximPanel.TabIndex = 42;
            // 
            // x2Panel
            // 
            this.x2Panel.Controls.Add(this.txAccel);
            this.x2Panel.Controls.Add(this.lbAccel);
            this.x2Panel.Controls.Add(this.txSensitivity);
            this.x2Panel.Controls.Add(this.lbSensitivity);
            this.x2Panel.Controls.Add(this.tbAccel);
            this.x2Panel.Controls.Add(this.tbSens);
            this.x2Panel.Controls.Add(this.label1);
            this.x2Panel.Controls.Add(this.comboBox1);
            this.x2Panel.Location = new System.Drawing.Point(6, 319);
            this.x2Panel.Name = "x2Panel";
            this.x2Panel.Size = new System.Drawing.Size(311, 171);
            this.x2Panel.TabIndex = 42;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game";
            // 
            // tbSens
            // 
            this.tbSens.Location = new System.Drawing.Point(88, 36);
            this.tbSens.Maximum = 20000;
            this.tbSens.Name = "tbSens";
            this.tbSens.Size = new System.Drawing.Size(220, 45);
            this.tbSens.SmallChange = 10;
            this.tbSens.TabIndex = 4;
            this.tbSens.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // tbAccel
            // 
            this.tbAccel.Location = new System.Drawing.Point(88, 87);
            this.tbAccel.Maximum = 500;
            this.tbAccel.Minimum = -500;
            this.tbAccel.Name = "tbAccel";
            this.tbAccel.Size = new System.Drawing.Size(220, 45);
            this.tbAccel.SmallChange = 10;
            this.tbAccel.TabIndex = 5;
            this.tbAccel.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lbSensitivity
            // 
            this.lbSensitivity.AutoSize = true;
            this.lbSensitivity.Location = new System.Drawing.Point(16, 36);
            this.lbSensitivity.Name = "lbSensitivity";
            this.lbSensitivity.Size = new System.Drawing.Size(54, 13);
            this.lbSensitivity.TabIndex = 6;
            this.lbSensitivity.Text = "Sensitivity";
            // 
            // txSensitivity
            // 
            this.txSensitivity.Location = new System.Drawing.Point(13, 52);
            this.txSensitivity.Name = "txSensitivity";
            this.txSensitivity.Size = new System.Drawing.Size(69, 20);
            this.txSensitivity.TabIndex = 7;
            // 
            // txAccel
            // 
            this.txAccel.Location = new System.Drawing.Point(13, 103);
            this.txAccel.Name = "txAccel";
            this.txAccel.Size = new System.Drawing.Size(69, 20);
            this.txAccel.TabIndex = 9;
            // 
            // lbAccel
            // 
            this.lbAccel.AutoSize = true;
            this.lbAccel.Location = new System.Drawing.Point(16, 87);
            this.lbAccel.Name = "lbAccel";
            this.lbAccel.Size = new System.Drawing.Size(66, 13);
            this.lbAccel.TabIndex = 8;
            this.lbAccel.Text = "Acceleration";
            // 
            // X2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.txTextModeRate);
            this.Controls.Add(this.calibration);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbTextRate);
            this.Controls.Add(this.txRate);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbRate);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "X2";
            this.Text = "Xim Translator by Xod";
            this.gbSettings.ResumeLayout(false);
            this.ximPanel.ResumeLayout(false);
            this.ximPanel.PerformLayout();
            this.x2Panel.ResumeLayout(false);
            this.x2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAccel)).EndInit();
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
        private System.Windows.Forms.Label lbTransExp1;
        private System.Windows.Forms.Label lbYxRatio;
        private System.Windows.Forms.Label lbDampen;
        private System.Windows.Forms.Label lbSmoothness;
        private System.Windows.Forms.Label lbTextRate;
        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.TextBox txRate;
        private System.Windows.Forms.TextBox txDiagonalDampen;
        private System.Windows.Forms.TextBox txSensitivity2;
        private System.Windows.Forms.TextBox txSensitivity1;
        private System.Windows.Forms.TextBox txDeadzone;
        private System.Windows.Forms.TextBox txTextModeRate;
        private System.Windows.Forms.TextBox txYxRatio;
        private System.Windows.Forms.TextBox txTransExponent1;
        private System.Windows.Forms.TextBox txSmoothness;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button calibration;
        private System.Windows.Forms.Panel x2Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel ximPanel;
        private System.Windows.Forms.TrackBar tbSens;
        private System.Windows.Forms.TrackBar tbAccel;
        private System.Windows.Forms.TextBox txAccel;
        private System.Windows.Forms.Label lbAccel;
        private System.Windows.Forms.TextBox txSensitivity;
        private System.Windows.Forms.Label lbSensitivity;
    }
}

