using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace X2
{
    public partial class X2 : Form
    {
        Ximulator m_ximulator;
        CommandParser m_commandParser;
        ConfigManager m_configManager;
        VarManager m_varManager;

        public X2()
        {
            InitializeComponent();

            Singleton<InfoTextManager>.Instance.Init(ref infoText);
            Singleton<InputManager>.Instance.Init(Handle);

            m_commandParser = new CommandParser();
            m_ximulator = new Ximulator(this);

            m_configManager = ConfigManager.Instance;
            m_varManager = VarManager.Instance;
            m_configManager.LoadDefaultConfig();
            SyncUI();
            SetTooltips();
        }

        private void SetTooltips()
        {
            SetToolTip(tbDiagonalDampen);
            SetToolTip(tbDeadzone);
            SetToolTip(tbRate);
            SetToolTip(tbSensitivity1);
            SetToolTip(tbSensitivity2);
            SetToolTip(tbSmoothness);
            SetToolTip(tbTextModeRate);
            SetToolTip(tbTransExponent1);
            SetToolTip(tbTransExponent2);
            SetToolTip(tbYxRatio);

            toolTip1.SetToolTip(cbAutoAnalogDisc, "Autoanalogdisconnect... yea it does something");
            toolTip1.SetToolTip(rbCircular, "Use a circular deadzone when translating mouse movement.");
            toolTip1.SetToolTip(rbSquare, "Use a square deadzone when translating mouse movement.");
        }

        private void SetToolTip(TextBox tb)
        {
            toolTip1.SetToolTip(tb, m_varManager.GetVarInfo(tb.Name.ToLower().Substring(2)));
        }

        private void Connect(object sender, EventArgs e)
        {
            if (!m_ximulator.IsRunning())
            {
                SetFormControlsEnabled(false);
                commandBox.Focus();
                Cursor.Hide();
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
            m_configManager.SaveDefaultConfig();
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
                String cmd = cmdBox.Text;
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
            tbDiagonalDampen.Text = m_varManager.GetVarStr("diagonaldampen");
            tbDeadzone.Text = m_varManager.GetVarStr("deadzone");
            tbRate.Text = m_varManager.GetVarStr("rate");
            tbSensitivity1.Text = m_varManager.GetVarStr("sensitivity1");
            tbSensitivity2.Text = m_varManager.GetVarStr("sensitivity2");
            tbSmoothness.Text = m_varManager.GetVarStr("smoothness");
            tbTextModeRate.Text = m_varManager.GetVarStr("textmoderate");
            tbTransExponent1.Text = m_varManager.GetVarStr("transexponent1");
            tbTransExponent2.Text = m_varManager.GetVarStr("transexponent2");
            tbYxRatio.Text = m_varManager.GetVarStr("yxratio");

            bool circular;
            m_varManager.GetVar("circulardeadzone", out circular);
            if (circular)
                rbCircular.Select();
            else
                rbSquare.Select();

            bool aadc;
            m_varManager.GetVar("autoanalogdisconnect", out aadc);
            cbAutoAnalogDisc.Checked = aadc;
        }

        private void nameMappedSettingTextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int sel = tb.SelectionStart;
            String varName = tb.Name.Substring(2).ToLower();
            if (!m_varManager.SetVar(varName, tb.Text))
            {
                tb.Text = m_varManager.GetVarStr(varName);
                tb.SelectionStart = sel > tb.Text.Length ? tb.Text.Length : sel;
            }
        }

        private void rbDeadzoneType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            m_varManager.SetVar("circulardeadzone", rb.Name == "rbCircular");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            m_varManager.SetVar("autoanalogdisconnect", ((CheckBox)sender).Checked);
        }
    }
}