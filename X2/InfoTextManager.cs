using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace X2
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

    }
}
