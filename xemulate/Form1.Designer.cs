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
            this.cbInvertY = new System.Windows.Forms.CheckBox();
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
            this.tabOutput = new System.Windows.Forms.TabControl();
            this.tabControllerOutput = new System.Windows.Forms.TabPage();
            this.tabRawOutput = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRawLTrigger = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRawRTrigger = new System.Windows.Forms.TextBox();
            this.cbRawLBumper = new System.Windows.Forms.CheckBox();
            this.cbRawRBumper = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRawDUp = new System.Windows.Forms.CheckBox();
            this.cbRawDLeft = new System.Windows.Forms.CheckBox();
            this.cbRawDDown = new System.Windows.Forms.CheckBox();
            this.cbRawDRight = new System.Windows.Forms.CheckBox();
            this.tbRawLY = new System.Windows.Forms.TextBox();
            this.tbRawLX = new System.Windows.Forms.TextBox();
            this.tbRawRY = new System.Windows.Forms.TextBox();
            this.tbRawRX = new System.Windows.Forms.TextBox();
            this.cbRawGuide = new System.Windows.Forms.CheckBox();
            this.cbRawBack = new System.Windows.Forms.CheckBox();
            this.cbRawStart = new System.Windows.Forms.CheckBox();
            this.cbRawY = new System.Windows.Forms.CheckBox();
            this.cbRawX = new System.Windows.Forms.CheckBox();
            this.cbRawA = new System.Windows.Forms.CheckBox();
            this.cbRawB = new System.Windows.Forms.CheckBox();
            this.gbSettings.SuspendLayout();
            this.x2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbAccel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbSens)).BeginInit();
            this.ximPanel.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabRawOutput.SuspendLayout();
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
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.tabRawOutput);
            this.tabOutput.Controls.Add(this.tabControllerOutput);
            this.tabOutput.Location = new System.Drawing.Point(12, 12);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.SelectedIndex = 0;
            this.tabOutput.Size = new System.Drawing.Size(299, 271);
            this.tabOutput.TabIndex = 7;
            // 
            // tabControllerOutput
            // 
            this.tabControllerOutput.Location = new System.Drawing.Point(4, 22);
            this.tabControllerOutput.Name = "tabControllerOutput";
            this.tabControllerOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabControllerOutput.Size = new System.Drawing.Size(291, 245);
            this.tabControllerOutput.TabIndex = 0;
            this.tabControllerOutput.Text = "Controller Output";
            this.tabControllerOutput.UseVisualStyleBackColor = true;
            // 
            // tabRawOutput
            // 
            this.tabRawOutput.Controls.Add(this.label8);
            this.tabRawOutput.Controls.Add(this.tbRawLTrigger);
            this.tabRawOutput.Controls.Add(this.label7);
            this.tabRawOutput.Controls.Add(this.tbRawRTrigger);
            this.tabRawOutput.Controls.Add(this.cbRawLBumper);
            this.tabRawOutput.Controls.Add(this.cbRawRBumper);
            this.tabRawOutput.Controls.Add(this.label5);
            this.tabRawOutput.Controls.Add(this.label6);
            this.tabRawOutput.Controls.Add(this.label4);
            this.tabRawOutput.Controls.Add(this.label3);
            this.tabRawOutput.Controls.Add(this.label2);
            this.tabRawOutput.Controls.Add(this.cbRawDUp);
            this.tabRawOutput.Controls.Add(this.cbRawDLeft);
            this.tabRawOutput.Controls.Add(this.cbRawDDown);
            this.tabRawOutput.Controls.Add(this.cbRawDRight);
            this.tabRawOutput.Controls.Add(this.tbRawLY);
            this.tabRawOutput.Controls.Add(this.tbRawLX);
            this.tabRawOutput.Controls.Add(this.tbRawRY);
            this.tabRawOutput.Controls.Add(this.tbRawRX);
            this.tabRawOutput.Controls.Add(this.cbRawGuide);
            this.tabRawOutput.Controls.Add(this.cbRawBack);
            this.tabRawOutput.Controls.Add(this.cbRawStart);
            this.tabRawOutput.Controls.Add(this.cbRawY);
            this.tabRawOutput.Controls.Add(this.cbRawX);
            this.tabRawOutput.Controls.Add(this.cbRawA);
            this.tabRawOutput.Controls.Add(this.cbRawB);
            this.tabRawOutput.Location = new System.Drawing.Point(4, 22);
            this.tabRawOutput.Name = "tabRawOutput";
            this.tabRawOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabRawOutput.Size = new System.Drawing.Size(291, 245);
            this.tabRawOutput.TabIndex = 1;
            this.tabRawOutput.Text = "Raw Output";
            this.tabRawOutput.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(14, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Left Trigger";
            // 
            // tbRawLTrigger
            // 
            this.tbRawLTrigger.Enabled = false;
            this.tbRawLTrigger.Location = new System.Drawing.Point(80, 5);
            this.tbRawLTrigger.Name = "tbRawLTrigger";
            this.tbRawLTrigger.Size = new System.Drawing.Size(66, 20);
            this.tbRawLTrigger.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(214, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "RightTrigger";
            // 
            // tbRawRTrigger
            // 
            this.tbRawRTrigger.Enabled = false;
            this.tbRawRTrigger.Location = new System.Drawing.Point(152, 6);
            this.tbRawRTrigger.Name = "tbRawRTrigger";
            this.tbRawRTrigger.Size = new System.Drawing.Size(58, 20);
            this.tbRawRTrigger.TabIndex = 21;
            // 
            // cbRawLBumper
            // 
            this.cbRawLBumper.AutoSize = true;
            this.cbRawLBumper.Enabled = false;
            this.cbRawLBumper.Location = new System.Drawing.Point(6, 29);
            this.cbRawLBumper.Name = "cbRawLBumper";
            this.cbRawLBumper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbRawLBumper.Size = new System.Drawing.Size(83, 17);
            this.cbRawLBumper.TabIndex = 20;
            this.cbRawLBumper.Text = "Left Bumper";
            this.cbRawLBumper.UseVisualStyleBackColor = true;
            // 
            // cbRawRBumper
            // 
            this.cbRawRBumper.AutoSize = true;
            this.cbRawRBumper.Enabled = false;
            this.cbRawRBumper.Location = new System.Drawing.Point(198, 29);
            this.cbRawRBumper.Name = "cbRawRBumper";
            this.cbRawRBumper.Size = new System.Drawing.Size(90, 17);
            this.cbRawRBumper.TabIndex = 19;
            this.cbRawRBumper.Text = "Right Bumper";
            this.cbRawRBumper.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(68, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "LeftStickY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(68, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "LeftStickX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(127, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "RightStickY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(127, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "RightStickX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(44, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "D Pad";
            // 
            // cbRawDUp
            // 
            this.cbRawDUp.AutoSize = true;
            this.cbRawDUp.Enabled = false;
            this.cbRawDUp.Location = new System.Drawing.Point(54, 149);
            this.cbRawDUp.Name = "cbRawDUp";
            this.cbRawDUp.Size = new System.Drawing.Size(15, 14);
            this.cbRawDUp.TabIndex = 14;
            this.cbRawDUp.UseVisualStyleBackColor = false;
            // 
            // cbRawDLeft
            // 
            this.cbRawDLeft.AutoSize = true;
            this.cbRawDLeft.Enabled = false;
            this.cbRawDLeft.Location = new System.Drawing.Point(38, 167);
            this.cbRawDLeft.Name = "cbRawDLeft";
            this.cbRawDLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbRawDLeft.Size = new System.Drawing.Size(15, 14);
            this.cbRawDLeft.TabIndex = 13;
            this.cbRawDLeft.UseVisualStyleBackColor = false;
            // 
            // cbRawDDown
            // 
            this.cbRawDDown.AutoSize = true;
            this.cbRawDDown.Enabled = false;
            this.cbRawDDown.Location = new System.Drawing.Point(54, 184);
            this.cbRawDDown.Name = "cbRawDDown";
            this.cbRawDDown.Size = new System.Drawing.Size(15, 14);
            this.cbRawDDown.TabIndex = 12;
            this.cbRawDDown.UseVisualStyleBackColor = false;
            // 
            // cbRawDRight
            // 
            this.cbRawDRight.AutoSize = true;
            this.cbRawDRight.Enabled = false;
            this.cbRawDRight.Location = new System.Drawing.Point(71, 167);
            this.cbRawDRight.Name = "cbRawDRight";
            this.cbRawDRight.Size = new System.Drawing.Size(15, 14);
            this.cbRawDRight.TabIndex = 11;
            this.cbRawDRight.UseVisualStyleBackColor = false;
            // 
            // tbRawLY
            // 
            this.tbRawLY.Enabled = false;
            this.tbRawLY.Location = new System.Drawing.Point(6, 120);
            this.tbRawLY.Name = "tbRawLY";
            this.tbRawLY.Size = new System.Drawing.Size(58, 20);
            this.tbRawLY.TabIndex = 10;
            // 
            // tbRawLX
            // 
            this.tbRawLX.Enabled = false;
            this.tbRawLX.Location = new System.Drawing.Point(6, 95);
            this.tbRawLX.Name = "tbRawLX";
            this.tbRawLX.Size = new System.Drawing.Size(58, 20);
            this.tbRawLX.TabIndex = 9;
            // 
            // tbRawRY
            // 
            this.tbRawRY.Enabled = false;
            this.tbRawRY.Location = new System.Drawing.Point(196, 189);
            this.tbRawRY.Name = "tbRawRY";
            this.tbRawRY.Size = new System.Drawing.Size(66, 20);
            this.tbRawRY.TabIndex = 8;
            // 
            // tbRawRX
            // 
            this.tbRawRX.Enabled = false;
            this.tbRawRX.Location = new System.Drawing.Point(196, 164);
            this.tbRawRX.Name = "tbRawRX";
            this.tbRawRX.Size = new System.Drawing.Size(66, 20);
            this.tbRawRX.TabIndex = 7;
            // 
            // cbRawGuide
            // 
            this.cbRawGuide.AutoSize = true;
            this.cbRawGuide.Enabled = false;
            this.cbRawGuide.Location = new System.Drawing.Point(142, 54);
            this.cbRawGuide.Name = "cbRawGuide";
            this.cbRawGuide.Size = new System.Drawing.Size(54, 17);
            this.cbRawGuide.TabIndex = 6;
            this.cbRawGuide.Text = "Guide";
            this.cbRawGuide.UseVisualStyleBackColor = true;
            // 
            // cbRawBack
            // 
            this.cbRawBack.AutoSize = true;
            this.cbRawBack.Enabled = false;
            this.cbRawBack.Location = new System.Drawing.Point(88, 72);
            this.cbRawBack.Name = "cbRawBack";
            this.cbRawBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbRawBack.Size = new System.Drawing.Size(51, 17);
            this.cbRawBack.TabIndex = 5;
            this.cbRawBack.Text = "Back";
            this.cbRawBack.UseVisualStyleBackColor = true;
            // 
            // cbRawStart
            // 
            this.cbRawStart.AutoSize = true;
            this.cbRawStart.Enabled = false;
            this.cbRawStart.Location = new System.Drawing.Point(159, 73);
            this.cbRawStart.Name = "cbRawStart";
            this.cbRawStart.Size = new System.Drawing.Size(48, 17);
            this.cbRawStart.TabIndex = 4;
            this.cbRawStart.Text = "Start";
            this.cbRawStart.UseVisualStyleBackColor = true;
            // 
            // cbRawY
            // 
            this.cbRawY.AutoSize = true;
            this.cbRawY.BackColor = System.Drawing.Color.Yellow;
            this.cbRawY.Enabled = false;
            this.cbRawY.Location = new System.Drawing.Point(212, 90);
            this.cbRawY.Name = "cbRawY";
            this.cbRawY.Size = new System.Drawing.Size(33, 17);
            this.cbRawY.TabIndex = 3;
            this.cbRawY.Text = "Y";
            this.cbRawY.UseVisualStyleBackColor = false;
            // 
            // cbRawX
            // 
            this.cbRawX.AutoSize = true;
            this.cbRawX.BackColor = System.Drawing.Color.Blue;
            this.cbRawX.Enabled = false;
            this.cbRawX.ForeColor = System.Drawing.Color.White;
            this.cbRawX.Location = new System.Drawing.Point(196, 108);
            this.cbRawX.Name = "cbRawX";
            this.cbRawX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbRawX.Size = new System.Drawing.Size(33, 17);
            this.cbRawX.TabIndex = 2;
            this.cbRawX.Text = "X";
            this.cbRawX.UseVisualStyleBackColor = false;
            // 
            // cbRawA
            // 
            this.cbRawA.AutoSize = true;
            this.cbRawA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cbRawA.Enabled = false;
            this.cbRawA.ForeColor = System.Drawing.Color.White;
            this.cbRawA.Location = new System.Drawing.Point(212, 125);
            this.cbRawA.Name = "cbRawA";
            this.cbRawA.Size = new System.Drawing.Size(33, 17);
            this.cbRawA.TabIndex = 1;
            this.cbRawA.Text = "A";
            this.cbRawA.UseVisualStyleBackColor = false;
            // 
            // cbRawB
            // 
            this.cbRawB.AutoSize = true;
            this.cbRawB.BackColor = System.Drawing.Color.Red;
            this.cbRawB.Enabled = false;
            this.cbRawB.ForeColor = System.Drawing.Color.White;
            this.cbRawB.Location = new System.Drawing.Point(229, 108);
            this.cbRawB.Name = "cbRawB";
            this.cbRawB.Size = new System.Drawing.Size(33, 17);
            this.cbRawB.TabIndex = 0;
            this.cbRawB.Text = "B";
            this.cbRawB.UseVisualStyleBackColor = false;
            // 
            // X2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(863, 520);
            this.Controls.Add(this.tabOutput);
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
            this.Text = "xEmulate";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.x2Panel.ResumeLayout(false);
            this.x2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbAccel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbSens)).EndInit();
            this.ximPanel.ResumeLayout(false);
            this.ximPanel.PerformLayout();
            this.tabOutput.ResumeLayout(false);
            this.tabRawOutput.ResumeLayout(false);
            this.tabRawOutput.PerformLayout();
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
        private System.Windows.Forms.TabControl tabOutput;
        private System.Windows.Forms.TabPage tabControllerOutput;
        private System.Windows.Forms.TabPage tabRawOutput;
        private System.Windows.Forms.CheckBox cbRawA;
        private System.Windows.Forms.CheckBox cbRawB;
        private System.Windows.Forms.CheckBox cbRawY;
        private System.Windows.Forms.CheckBox cbRawX;
        private System.Windows.Forms.CheckBox cbRawBack;
        private System.Windows.Forms.CheckBox cbRawStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbRawDUp;
        private System.Windows.Forms.CheckBox cbRawDLeft;
        private System.Windows.Forms.CheckBox cbRawDDown;
        private System.Windows.Forms.CheckBox cbRawDRight;
        private System.Windows.Forms.TextBox tbRawLY;
        private System.Windows.Forms.TextBox tbRawLX;
        private System.Windows.Forms.TextBox tbRawRY;
        private System.Windows.Forms.TextBox tbRawRX;
        private System.Windows.Forms.CheckBox cbRawGuide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRawLTrigger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRawRTrigger;
        private System.Windows.Forms.CheckBox cbRawLBumper;
        private System.Windows.Forms.CheckBox cbRawRBumper;
    }
}

