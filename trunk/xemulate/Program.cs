using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace xEmulate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool HasAllPrereqs = true;
            String missing = "";
            // check all the required files, if any missing, return false
            if (!System.IO.File.Exists(System.Environment.SystemDirectory
                + "\\xactengine2_9.dll")) 
            {
                missing+= " xactengine2_9.dll";
                HasAllPrereqs = false;
            }
            if (!System.IO.File.Exists(System.Environment.SystemDirectory
                + "\\d3dx9_31.dll"))
            {
                missing+= " d3dx9_31.dll";
                HasAllPrereqs = false;
            }
            if (!System.IO.File.Exists(System.Environment.SystemDirectory
                + "\\x3daudio1_2.dll"))
            {
                missing+= " x3daudio1_2.dll";
                HasAllPrereqs = false;
            }
            if (!System.IO.File.Exists(System.Environment.SystemDirectory
                + "\\xinput1_3.dll"))
            {
                missing+= " xinput1_3.dll";
                HasAllPrereqs = false;
            }

            if (!HasAllPrereqs)
            {
                MessageBox.Show("Xna Framework Dependencies Missing : " + missing );
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new X2(args));
            }
        }
    }
}