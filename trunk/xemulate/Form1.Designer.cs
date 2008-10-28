namespace xEmulate
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
            this.x2Panel = new System.Windows.Forms.Panel();
            this.txAccel = new System.Windows.Forms.TextBox();
            this.lbAccel = new System.Windows.Forms.Label();
            this.txSensitivity = new System.Windows.Forms.TextBox();
            this.lbSensitivity = new System.Windows.Forms.Label();
            this.sbAccel = new System.Windows.Forms.TrackBar();
            this.sbSens = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.rbX2 = new System.Windows.Forms.RadioButton();
            this.rbXimCore = new System.Windows.Forms.RadioButton();
            this.lbMouseAlgorithm = new System.Windows.Forms.Label();
            this.ximPanel = new System.Windows.Forms.Panel();
            this.labelDeadzone = new System.Windows.Forms.Label();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.txDiagonalDampen = new System.Windows.Forms.TextBox();
            this.txYxRatio = new System.Windows.Forms.TextBox();
            this.lbDampen = new System.Windows.Forms.Label();
            this.txSensitivity2 = new System.Windows.Forms.TextBox();
            this.rbCircular = new System.Windows.Forms.RadioButton();
            this.lbYxRatio = new System.Windows.Forms.Label();
            this.txTransExponent1 = new System.Windows.Forms.TextBox();
            this.lbSens2 = new System.Windows.Forms.Label();
            this.lbDeadzone = new System.Windows.Forms.Label();
            this.txSensitivity1 = new System.Windows.Forms.TextBox();
            this.txSmoothness = new System.Windows.Forms.TextBox();
            this.lbSens1 = new System.Windows.Forms.Label();
            this.lbTransExp1 = new System.Windows.Forms.Label();
            this.lbSmoothness = new System.Windows.Forms.Label();
            this.txDeadzone = new System.Windows.Forms.TextBox();
            this.lbTextRate = new System.Windows.Forms.Label();
            this.lbRate = new System.Windows.Forms.Label();
            this.txRate = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.calibration = new System.Windows.Forms.Button();
            this.cbInvertY = new System.Windows.Forms.CheckBox();
            this.gbSettings.SuspendLayout();
            this.x2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbSens)).BeginInit();
            this.ximPanel.SuspendLayout();
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
            this.gbSettings.Controls.Add(this.cbInvertY);
            this.gbSettings.Controls.Add(this.txTextModeRate);
            this.gbSettings.Controls.Add(this.x2Panel);
            this.gbSettings.Controls.Add(this.rbX2);
            this.gbSettings.Controls.Add(this.rbXimCore);
            this.gbSettings.Controls.Add(this.lbMouseAlgorithm);
            this.gbSettings.Controls.Add(this.ximPanel);
            this.gbSettings.Controls.Add(this.lbTextRate);
            this.gbSettings.Controls.Add(this.lbRate);
            this.gbSettings.Controls.Add(this.txRate);
            this.gbSettings.Location = new System.Drawing.Point(528, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(323, 496);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "General Settings";
            // 
            // txTextModeRate
            // 
            this.txTextModeRate.Location = new System.Drawing.Point(76, 52);
            this.txTextModeRate.Name = "txTextModeRate";
            this.txTextModeRate.Size = new System.Drawing.Size(43, 20);
            this.txTextModeRate.TabIndex = 41;
            this.txTextModeRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txTextModeRate.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txTextModeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
            // 
            // x2Panel
            // 
            this.x2Panel.Controls.Add(this.txAccel);
            this.x2Panel.Controls.Add(this.lbAccel);
            this.x2Panel.Controls.Add(this.txSensitivity);
            this.x2Panel.Controls.Add(this.lbSensitivity);
            this.x2Panel.Controls.Add(this.sbAccel);
            this.x2Panel.Controls.Add(this.sbSens);
            this.x2Panel.Controls.Add(this.label1);
            this.x2Panel.Controls.Add(this.cbGame);
            this.x2Panel.Location = new System.Drawing.Point(6, 316);
            this.x2Panel.Name = "x2Panel";
            this.x2Panel.Size = new System.Drawing.Size(311, 171);
            this.x2Panel.TabIndex = 42;
            this.x2Panel.Visible = false;
            // 
            // txAccel
            // 
            this.txAccel.Location = new System.Drawing.Point(13, 106);
            this.txAccel.Name = "txAccel";
            this.txAccel.Size = new System.Drawing.Size(69, 20);
            this.txAccel.TabIndex = 9;
            this.txAccel.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txAccel.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txAccel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // txSensitivity
            // 
            this.txSensitivity.Location = new System.Drawing.Point(13, 55);
            this.txSensitivity.Name = "txSensitivity";
            this.txSensitivity.Size = new System.Drawing.Size(69, 20);
            this.txSensitivity.TabIndex = 7;
            this.txSensitivity.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txSensitivity.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txSensitivity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // sbAccel
            // 
            this.sbAccel.Location = new System.Drawing.Point(88, 90);
            this.sbAccel.Maximum = 1000;
            this.sbAccel.Minimum = -1000;
            this.sbAccel.Name = "sbAccel";
            this.sbAccel.Size = new System.Drawing.Size(220, 45);
            this.sbAccel.SmallChange = 10;
            this.sbAccel.TabIndex = 5;
            this.sbAccel.TickFrequency = 50;
            this.sbAccel.Scroll += new System.EventHandler(this.sbAccel_Scroll);
            // 
            // sbSens
            // 
            this.sbSens.Location = new System.Drawing.Point(88, 39);
            this.sbSens.Maximum = 20000;
            this.sbSens.Name = "sbSens";
            this.sbSens.Size = new System.Drawing.Size(220, 45);
            this.sbSens.SmallChange = 10;
            this.sbSens.TabIndex = 4;
            this.sbSens.TickFrequency = 1000;
            this.sbSens.Scroll += new System.EventHandler(this.sbSens_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game";
            // 
            // cbGame
            // 
            this.cbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Location = new System.Drawing.Point(51, 12);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(203, 21);
            this.cbGame.TabIndex = 0;
            this.cbGame.SelectedIndexChanged += new System.EventHandler(this.cbGame_SelectedIndexChanged);
            // 
            // rbX2
            // 
            this.rbX2.AutoSize = true;
            this.rbX2.Location = new System.Drawing.Point(10, 274);
            this.rbX2.Name = "rbX2";
            this.rbX2.Size = new System.Drawing.Size(140, 17);
            this.rbX2.TabIndex = 45;
            this.rbX2.TabStop = true;
            this.rbX2.Text = "Game Specific Algorithm";
            this.rbX2.UseVisualStyleBackColor = true;
            this.rbX2.CheckedChanged += new System.EventHandler(this.rbX2_CheckedChanged);
            // 
            // rbXimCore
            // 
            this.rbXimCore.AutoSize = true;
            this.rbXimCore.Location = new System.Drawing.Point(10, 297);
            this.rbXimCore.Name = "rbXimCore";
            this.rbXimCore.Size = new System.Drawing.Size(113, 17);
            this.rbXimCore.TabIndex = 44;
            this.rbXimCore.TabStop = true;
            this.rbXimCore.Text = "Xim Core Algorithm";
            this.rbXimCore.UseVisualStyleBackColor = true;
            // 
            // lbMouseAlgorithm
            // 
            this.lbMouseAlgorithm.AutoSize = true;
            this.lbMouseAlgorithm.Location = new System.Drawing.Point(10, 258);
            this.lbMouseAlgorithm.Name = "lbMouseAlgorithm";
            this.lbMouseAlgorithm.Size = new System.Drawing.Size(85, 13);
            this.lbMouseAlgorithm.TabIndex = 43;
            this.lbMouseAlgorithm.Text = "Mouse Algorithm";
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
            // labelDeadzone
            // 
            this.labelDeadzone.AutoSize = true;
            this.labelDeadzone.Location = new System.Drawing.Point(10, 17);
            this.labelDeadzone.Name = "labelDeadzone";
            this.labelDeadzone.Size = new System.Drawing.Size(83, 13);
            this.labelDeadzone.TabIndex = 6;
            this.labelDeadzone.Text = "Deadzone Type";
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
            // txDiagonalDampen
            // 
            this.txDiagonalDampen.Location = new System.Drawing.Point(111, 113);
            this.txDiagonalDampen.Name = "txDiagonalDampen";
            this.txDiagonalDampen.Size = new System.Drawing.Size(43, 20);
            this.txDiagonalDampen.TabIndex = 35;
            this.txDiagonalDampen.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txDiagonalDampen.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txDiagonalDampen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
            // 
            // txYxRatio
            // 
            this.txYxRatio.Location = new System.Drawing.Point(229, 90);
            this.txYxRatio.Name = "txYxRatio";
            this.txYxRatio.Size = new System.Drawing.Size(43, 20);
            this.txYxRatio.TabIndex = 40;
            this.txYxRatio.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txYxRatio.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txYxRatio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // txSensitivity2
            // 
            this.txSensitivity2.Location = new System.Drawing.Point(111, 90);
            this.txSensitivity2.Name = "txSensitivity2";
            this.txSensitivity2.Size = new System.Drawing.Size(43, 20);
            this.txSensitivity2.TabIndex = 34;
            this.txSensitivity2.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txSensitivity2.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txSensitivity2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // lbYxRatio
            // 
            this.lbYxRatio.AutoSize = true;
            this.lbYxRatio.Location = new System.Drawing.Point(171, 93);
            this.lbYxRatio.Name = "lbYxRatio";
            this.lbYxRatio.Size = new System.Drawing.Size(52, 13);
            this.lbYxRatio.TabIndex = 18;
            this.lbYxRatio.Text = "Y:X Ratio";
            // 
            // txTransExponent1
            // 
            this.txTransExponent1.Location = new System.Drawing.Point(229, 67);
            this.txTransExponent1.Name = "txTransExponent1";
            this.txTransExponent1.Size = new System.Drawing.Size(43, 20);
            this.txTransExponent1.TabIndex = 38;
            this.txTransExponent1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txTransExponent1.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txTransExponent1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // lbDeadzone
            // 
            this.lbDeadzone.AutoSize = true;
            this.lbDeadzone.Location = new System.Drawing.Point(10, 46);
            this.lbDeadzone.Name = "lbDeadzone";
            this.lbDeadzone.Size = new System.Drawing.Size(79, 13);
            this.lbDeadzone.TabIndex = 8;
            this.lbDeadzone.Text = "Deadzone Size";
            // 
            // txSensitivity1
            // 
            this.txSensitivity1.Location = new System.Drawing.Point(111, 67);
            this.txSensitivity1.Name = "txSensitivity1";
            this.txSensitivity1.Size = new System.Drawing.Size(43, 20);
            this.txSensitivity1.TabIndex = 33;
            this.txSensitivity1.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txSensitivity1.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txSensitivity1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
            // 
            // txSmoothness
            // 
            this.txSmoothness.Location = new System.Drawing.Point(229, 43);
            this.txSmoothness.Name = "txSmoothness";
            this.txSmoothness.Size = new System.Drawing.Size(43, 20);
            this.txSmoothness.TabIndex = 37;
            this.txSmoothness.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txSmoothness.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txSmoothness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // lbTransExp1
            // 
            this.lbTransExp1.AutoSize = true;
            this.lbTransExp1.Location = new System.Drawing.Point(165, 70);
            this.lbTransExp1.Name = "lbTransExp1";
            this.lbTransExp1.Size = new System.Drawing.Size(58, 13);
            this.lbTransExp1.TabIndex = 14;
            this.lbTransExp1.Text = "TransExp1";
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
            // txDeadzone
            // 
            this.txDeadzone.Location = new System.Drawing.Point(111, 43);
            this.txDeadzone.Name = "txDeadzone";
            this.txDeadzone.Size = new System.Drawing.Size(43, 20);
            this.txDeadzone.TabIndex = 32;
            this.toolTip1.SetToolTip(this.txDeadzone, "test");
            this.txDeadzone.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txDeadzone.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txDeadzone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
            // 
            // lbTextRate
            // 
            this.lbTextRate.AutoSize = true;
            this.lbTextRate.Location = new System.Drawing.Point(16, 55);
            this.lbTextRate.Name = "lbTextRate";
            this.lbTextRate.Size = new System.Drawing.Size(54, 13);
            this.lbTextRate.TabIndex = 26;
            this.lbTextRate.Text = "Text Rate";
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.Location = new System.Drawing.Point(16, 28);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(30, 13);
            this.lbRate.TabIndex = 24;
            this.lbRate.Text = "Rate";
            // 
            // txRate
            // 
            this.txRate.Location = new System.Drawing.Point(76, 25);
            this.txRate.Name = "txRate";
            this.txRate.Size = new System.Drawing.Size(43, 20);
            this.txRate.TabIndex = 36;
            this.txRate.TextChanged += new System.EventHandler(this.nameMappedSettingTextChanged);
            this.txRate.Leave += new System.EventHandler(this.nameMappedSettingTextLeft);
            this.txRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameMappedSettingTextReturn);
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
            // cbInvertY
            // 
            this.cbInvertY.AutoSize = true;
            this.cbInvertY.Location = new System.Drawing.Point(19, 78);
            this.cbInvertY.Name = "cbInvertY";
            this.cbInvertY.Size = new System.Drawing.Size(85, 17);
            this.cbInvertY.TabIndex = 46;
            this.cbInvertY.Text = "Invert Y Axis";
            this.cbInvertY.UseVisualStyleBackColor = true;
            this.cbInvertY.CheckedChanged += new System.EventHandler(this.cbInvertY_CheckedChanged);
            // 
            // X2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.calibration);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "X2";
            this.Text = "Xim Translator by Xod";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.x2Panel.ResumeLayout(false);
            this.x2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbSens)).EndInit();
            this.ximPanel.ResumeLayout(false);
            this.ximPanel.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGame;
        private System.Windows.Forms.TrackBar sbSens;
        private System.Windows.Forms.TrackBar sbAccel;
        private System.Windows.Forms.TextBox txAccel;
        private System.Windows.Forms.Label lbAccel;
        private System.Windows.Forms.TextBox txSensitivity;
        private System.Windows.Forms.Label lbSensitivity;
        private System.Windows.Forms.RadioButton rbX2;
        private System.Windows.Forms.RadioButton rbXimCore;
        private System.Windows.Forms.Label lbMouseAlgorithm;
        private System.Windows.Forms.Panel x2Panel;
        private System.Windows.Forms.Panel ximPanel;
        private System.Windows.Forms.CheckBox cbInvertY;
    }
}

