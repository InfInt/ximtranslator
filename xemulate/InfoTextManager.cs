using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common;

namespace xEmulate
{
    class InfoTextManager
    {
        private TextBox m_textBox;

        private InfoTextManager()
        {
            m_textBox = null;
        }

        public static InfoTextManager Instance
        {
            get { return Singleton<InfoTextManager>.Instance; }
        }

        public void Init( ref TextBox t )
        {
            m_textBox = t;
        }

        public void WriteLine(String s)
        {
            Write(Environment.NewLine + s);
        }

        public void Write(String s)
        {
            m_textBox.Text += s;
            m_textBox.SelectionStart = m_textBox.Text.Length;
            m_textBox.ScrollToCaret();
        }

        public void WriteLineDebug(String s)
        {
#if DEBUG
            WriteLine(s);
#endif
        }

        public void WriteLineDebugCls(String s)
        {
#if DEBUG
            Cls();
            WriteLine(s);
#endif
        }

        public void Cls()
        {
            m_textBox.Text = "";
        }

    }
}
