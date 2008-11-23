using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Win32Api;
using Common;
using XimApi;

namespace xEmulate
{
    public partial class xEmulateForm : Form
    {
        Ximulator m_ximulator;
        CommandParser m_commandParser;
        ConfigManager m_configManager;
        VarManager m_varManager;

        Vector2 drawSticksCenter;
        int drawSticksSize;

        public xEmulateForm(string[] args)
        {
            InitializeComponent();

            Singleton<InfoTextManager>.Instance.Init(ref infoText);
            Singleton<InputManager>.Instance.Init();
            Singleton<DxInputManager>.Instance.Init(this);
            Singleton<XimDyn>.Instance.Init();

            m_commandParser = CommandParser.Instance;
            m_ximulator = new Ximulator(this);

            m_configManager = ConfigManager.Instance;
            m_varManager = VarManager.Instance;
            
            if (args.Length == 0 || !m_configManager.LoadConfig(args[0]))
            {
                m_configManager.LoadDefaultConfig();
            }

            this.cbGame.Items.AddRange(GamesManager.GameNames);

            if(System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                this.version.Text = "Version: "+System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

            this.drawSticksCenter = new Vector2(this.mouseDisplayRect.Location.X + this.mouseDisplayRect.Size.Width / 2,
                                            this.mouseDisplayRect.Location.Y + this.mouseDisplayRect.Size.Height / 2);
            drawSticksSize = this.mouseDisplayRect.Size.Height;

            SyncUI();
            SetTooltips();
            commandBox.Focus();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            m_configManager.SaveDefaultConfig();
            base.OnClosing(e);
        }

        private void SetTooltips()
        {
            SetToolTip(txDiagonalDampen);
            SetToolTip(txDeadzone);
            SetToolTip(txRate);
            SetToolTip(txSensitivity1);
            SetToolTip(txSensitivity2);
            SetToolTip(txSmoothness);
            SetToolTip(txTextModeRate);
            SetToolTip(txTransExponent1);
            SetToolTip(txYxRatio);
            SetToolTip(cbInvertY);
            SetToolTip(cbDrivingMode);

            toolTip1.SetToolTip(cbAutoAnalogDisc, "Autoanalogdisconnect... yea it does something");
            toolTip1.SetToolTip(rbCircular, "Use a circular deadzone when translating mouse movement.");
            toolTip1.SetToolTip(rbSquare, "Use a square deadzone when translating mouse movement.");

            toolTip1.SetToolTip(rbX2, "Use game specific mouse translation ( Not recommended )");
            toolTip1.SetToolTip(rbXimCore, "Use Xim Core provided mouse translation ( Recommended )");
        }

        private void SetToolTip(Control tb)
        {
            toolTip1.SetToolTip(tb, m_varManager.GetVarInfo(tb.Name.ToLower().Substring(2)));
        }

        private void Connect(object sender, EventArgs e)
        {
            if (!m_ximulator.IsRunning())
            {
                SetFormControlsEnabled(false);
                commandBox.Focus();
                m_ximulator.Go();
                Cursor.Show();
                SetFormControlsEnabled(true);
                SyncUI();
            }
        }

        private void SetFormControlsEnabled( bool f )
        {
            foreach(Control control in this.Controls)
            {
                if( control != commandBox )
                    control.Enabled = f;
            }
        }

        private void LoadConfig(object sender, EventArgs e)
        {
            m_configManager.LoadFileDlg();
            SyncUI();
        }

        protected override bool ProcessDialogChar(char charCode)
        {
            if (m_ximulator.IsRunning())
            {
                m_ximulator.ProcessChar(charCode);
                return true;
            }

            return base.ProcessDialogChar(charCode);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (m_ximulator.IsRunning())
            {
                if( keyData == Keys.Return )
                {
                    m_ximulator.ProcessChar('\r');
                }
                Win32Api.User32.TranslateMessage(ref msg);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if( !m_ximulator.IsRunning() )
                base.OnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (m_ximulator.IsRunning())
            {
                m_ximulator.ProcessMWheel(e.Delta > 0);
            }
            else
            {
                base.OnMouseWheel(e);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m_ximulator != null)
            {
                if (m_ximulator.ProcessMessage(ref m))
                {
                    return;
                }
                if (m_ximulator.IsRunning())
                {
                }
            }
            base.WndProc(ref m);
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            m_configManager.SaveFileDlg();
        }


        private void CommandBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (m_ximulator.IsRunning())
            {
                e.Handled = true;
                m_ximulator.ProcessChar(e.KeyChar);
            }
            else if (e.KeyChar == '\r')
            {
                TextBox cmdBox = ((TextBox)sender);
                String cmd = cmdBox.Text.ToLower();
                Singleton<InfoTextManager>.Instance.WriteLine(cmd);
                if (!m_commandParser.ParseLine(cmd))
                {
                    Singleton<InfoTextManager>.Instance.WriteLine(
                        "Parser didnt like your command very much, check your syntax");
                }

                cmdBox.Text = "";
                e.Handled = true;
                SyncUI();
                cmdBox.Focus();
            }
        }

        private void SyncUI()
        {

            bool ximMath = m_varManager.GetVar<bool>(VarManager.Names.UseXimApiMouseMath);

            this.x2Panel.Visible = this.rbX2.Checked = !ximMath;
            this.ximPanel.Visible = this.rbXimCore.Checked = ximMath;

            this.cbGame.SelectedIndex = (int)m_varManager.GetVar<GamesManager.Games>(VarManager.Names.CurrentGame);

            this.txSpeed.Text = m_varManager.GetVarStr(VarManager.Names.Speed);
            this.txAccel.Text = m_varManager.GetVarStr(VarManager.Names.Accel);
            this.txSpeed2.Text = m_varManager.GetVarStr(VarManager.Names.Speed2);
            this.txAccel2.Text = m_varManager.GetVarStr(VarManager.Names.Accel2);

            // Sensitivity and accel on the slider are 1000* the decimal value.
            this.sbSpeed.Value = (int)(double.Parse(this.txSpeed.Text)*1000);
            this.sbAccel.Value = (int)(double.Parse(this.txAccel.Text) * 1000);
            this.sbSpeed2.Value = (int)(double.Parse(this.txSpeed2.Text) * 1000);
            this.sbAccel2.Value = (int)(double.Parse(this.txAccel2.Text) * 1000);

            this.txMouseDpi.Text = m_varManager.GetVarStr(VarManager.Names.MouseDPI);

            this.txDiagonalDampen.Text = m_varManager.GetVarStr(VarManager.Names.DiagonalDampen);
            this.txDeadzone.Text = m_varManager.GetVarStr(VarManager.Names.Deadzone);
            this.txRate.Text = m_varManager.GetVarStr(VarManager.Names.Rate);
            this.txSensitivity1.Text = m_varManager.GetVarStr(VarManager.Names.Sensitivity1);
            this.txSensitivity2.Text = m_varManager.GetVarStr(VarManager.Names.Sensitivity2);
            this.txSmoothness.Text = m_varManager.GetVarStr(VarManager.Names.Smoothness);
            this.txTextModeRate.Text = m_varManager.GetVarStr(VarManager.Names.TextModeRate);
            this.txTransExponent1.Text = m_varManager.GetVarStr(VarManager.Names.TransExponent1);
            this.txYxRatio.Text = m_varManager.GetVarStr(VarManager.Names.YXRatio);

            bool circular;
            this.m_varManager.GetVar(VarManager.Names.CircularDeadzone, out circular);
            this.rbCircular.Checked = circular;
            this.rbSquare.Checked = !circular;

            VarManager.Sticks mouseStick = m_varManager.GetVar<VarManager.Sticks>(VarManager.Names.MouseStickX);
            this.rbMouseXRight.Checked = mouseStick == VarManager.Sticks.Right;
            this.rbMouseXLeft.Checked = mouseStick == VarManager.Sticks.Left;
            this.rbMouseXNone.Checked = mouseStick == VarManager.Sticks.None;

            mouseStick = m_varManager.GetVar<VarManager.Sticks>(VarManager.Names.MouseStickY);
            this.rbMouseYRight.Checked = mouseStick == VarManager.Sticks.Right;
            this.rbMouseYLeft.Checked = mouseStick == VarManager.Sticks.Left;
            this.rbMouseYNone.Checked = mouseStick == VarManager.Sticks.None;

            this.cbAutoAnalogDisc.Checked = m_varManager.GetVar<bool>(VarManager.Names.AutoAnalogDisconnect);

            this.cbInvertY.Checked = m_varManager.GetVar<bool>(VarManager.Names.InvertY);
        }

        private void nameMappedSettingTextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int sel = tb.SelectionStart;
            String varName = tb.Name.Substring(2).ToLower();
            m_varManager.SetVar(varName, tb.Text);
        }

        private void rbDeadzoneType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Checked)
                m_varManager.SetVar(VarManager.Names.CircularDeadzone, rb == rbCircular);
        }

        private void autoAnalogDisconnect_CheckedChanged(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.AutoAnalogDisconnect, ((CheckBox)sender).Checked);
        }

        private void calibration_Click(object sender, EventArgs e)
        {
            XimDyn.Instance.RunCalibrate();
        }

        private void rbX2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            m_varManager.SetVar(VarManager.Names.UseXimApiMouseMath, !rb.Checked);
            SyncUI();
        }

        private void sbSens_Scroll(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.Speed, (double)sbSpeed.Value / 1000);
            SyncUI();
        }

        private void sbAccel_Scroll(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.Accel, (double)sbAccel.Value / 1000);
            SyncUI();
        }

        private void sbSpeed2_Scroll(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.Speed2, (double)sbSpeed2.Value / 1000);
            SyncUI();
        }

        private void sbAccel2_Scroll(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.Accel2, (double)sbAccel2.Value / 1000);
            SyncUI();
        }

        private void nameMappedSettingTextLeft(object sender, EventArgs e)
        {
            nameMappedSettingTextChanged(sender, e);
            TextBox tb = (TextBox)sender;
            String varName = tb.Name.Substring(2).ToLower();
            tb.Text = m_varManager.GetVarStr(varName);
            SyncUI();
        }

        private void nameMappedSettingTextReturn(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                nameMappedSettingTextChanged(sender, e);
                TextBox tb = (TextBox)sender;
                String varName = tb.Name.Substring(2).ToLower();
                tb.Text = m_varManager.GetVarStr(varName);
                SyncUI();
                e.Handled = true;
            }
        }

        private void cbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.CurrentGame, (GamesManager.Games)cbGame.SelectedIndex);
        }

        private void cbInvertY_CheckedChanged(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.InvertY, cbInvertY.Checked); 
        }

        private void cbDrivingMode_CheckedChanged(object sender, EventArgs e)
        {
            m_varManager.SetVar(VarManager.Names.DrivingMode, cbDrivingMode.Checked); 
        }

        public void UpdateOutputView(Xim.Input input)
        {
            this.cbRawA.Checked = input.A == Xim.ButtonState.Pressed;
            this.cbRawB.Checked = input.B == Xim.ButtonState.Pressed;
            this.cbRawY.Checked = input.Y == Xim.ButtonState.Pressed;
            this.cbRawX.Checked = input.X == Xim.ButtonState.Pressed;
            this.cbRawStart.Checked = input.Start == Xim.ButtonState.Pressed;
            this.cbRawBack.Checked = input.Back == Xim.ButtonState.Pressed;
            this.cbRawGuide.Checked = input.Guide == Xim.ButtonState.Pressed;
            this.cbRawDDown.Checked = input.Down == Xim.ButtonState.Pressed;
            this.cbRawDUp.Checked = input.Up == Xim.ButtonState.Pressed;
            this.cbRawDLeft.Checked = input.Left == Xim.ButtonState.Pressed;
            this.cbRawDRight.Checked = input.Right == Xim.ButtonState.Pressed;
            this.cbRawRBumper.Checked = input.RightBumper == Xim.ButtonState.Pressed;
            this.cbRawLBumper.Checked = input.LeftBumper == Xim.ButtonState.Pressed;
            this.cbRawRightStick.Checked = input.RightStick == Xim.ButtonState.Pressed;
            this.cbRawLeftStick.Checked = input.LeftStick == Xim.ButtonState.Pressed;
            this.tbRawLTrigger.Text = input.LeftTrigger.ToString();
            this.tbRawRTrigger.Text = input.RightTrigger.ToString();
            this.tbRawLX.Text = input.LeftStickX.ToString();
            this.tbRawLY.Text = input.LeftStickY.ToString();
            this.tbRawRX.Text = input.RightStickX.ToString();
            this.tbRawRY.Text = input.RightStickY.ToString();

            this.leftStick.Location = new System.Drawing.Point(
                                             (int)this.drawSticksCenter.X + (int)(((double)input.LeftStickX / (short)Xim.Stick.Max) * (this.drawSticksSize / 2))
                                             , (int)this.drawSticksCenter.Y - (int)(((double)input.LeftStickY / (short)Xim.Stick.Max) * (this.drawSticksSize / 2)));

            this.rightStick.Location = new System.Drawing.Point(
                                             (int)this.drawSticksCenter.X + (int)(((double)input.RightStickX / (short)Xim.Stick.Max) * (this.drawSticksSize / 2))
                                             , (int)this.drawSticksCenter.Y - (int)(((double)input.RightStickY / (short)Xim.Stick.Max) * (this.drawSticksSize / 2)));

        }

        private void rbMouseXLeft_Changed(object sender, EventArgs e){ m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickX, VarManager.Sticks.Left); }
        private void rbMouseXRight_Changed(object sender, EventArgs e) { m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickX, VarManager.Sticks.Right); }
        private void rbMouseXNone_Changed(object sender, EventArgs e) { m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickX, VarManager.Sticks.None); }

        private void rbMouseYLeft_Changed(object sender, EventArgs e) { m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickY, VarManager.Sticks.Left); }
        private void rbMouseYRight_Changed(object sender, EventArgs e) { m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickY, VarManager.Sticks.Right); }
        private void rbMouseYNone_Changed(object sender, EventArgs e) { m_varManager.SetVar<VarManager.Sticks>(VarManager.Names.MouseStickY, VarManager.Sticks.None); }

        private void button4_Click(object sender, EventArgs e)
        {
            DxInputManager.Instance.InitJoy();
        }
    }
}
        