using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using Common;

namespace XimApi
{
    public class XimDyn
    {
        bool fInit;

        public DConnect Connect;
        public DDisconnect Disconnect;
        public DSetMode SetMode;
        public DComputeStickValues ComputeStickValues;
        public DSendInput SendInput;
        public DAllocSmoothness AllocSmoothness;
        public DFreeSmoothness FreeSmoothness;

        private IntPtr XIMCore;
        public String ximPath;

        private XimDyn()
        {
            this.fInit = false;
            this.ximPath = "";
        }

        public static XimDyn Instance
        {
            get { return Singleton<XimDyn>.Instance; }
        }

        private bool GetProcAddress(string funcName, ref IntPtr procAddr)
        {
            procAddr = Win32Api.Kernel32.GetProcAddress(this.XIMCore, funcName);
            return procAddr != IntPtr.Zero;
        }

        public static bool GetXim360Dir(out String ximPath)
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey("Software");
            ximPath = "";
            if (key != null)
            {
                key = key.OpenSubKey("XIM");
                if (key != null)
                {
                    ximPath = (String)key.GetValue("");
                }
            }
            return ximPath.Length > 0;
        }

        public void Init()
        {
            if (!this.fInit)
            {
                GetXim360Dir(out this.ximPath);

                if (this.ximPath.Length == 0)
                {
                    MessageBox.Show("Could not locate the XIM360 registry key, please ensure that Xim is installed ( www.xim360.com )");
                    return;
                }

                // Load Xim core
                this.XIMCore = Win32Api.Kernel32.LoadLibrary("ximcore.dll");
                if (this.XIMCore == IntPtr.Zero)
                {
                    // MAKE A PATH!
                    String path = Environment.GetEnvironmentVariable("path");
                    Environment.SetEnvironmentVariable("path", path + ";" + this.ximPath);

                    // Try again
                    this.XIMCore = Win32Api.Kernel32.LoadLibrary("ximcore.dll");

                }

                if (this.XIMCore == IntPtr.Zero)
                {
                    MessageBox.Show("Could not load XIMCore.dll, please ensure that XIM360 is installed!");
                    return;
                }

                if (!File.Exists(Environment.CurrentDirectory+"\\XIMCalibrate.ini"))
                {
                    CopyCalibrate();
                }

                // Load my functions
                IntPtr procAddr = new IntPtr();
                if( GetProcAddress("XIMConnect", ref procAddr ))
                    this.Connect = (DConnect)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DConnect));
                if (GetProcAddress("XIMDisconnect", ref procAddr))
                    this.Disconnect = (DDisconnect)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DDisconnect));
                if (GetProcAddress("XIMSetMode", ref procAddr))
                    this.SetMode = (DSetMode)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DSetMode));
                if (GetProcAddress("XIMSendXbox360Input", ref procAddr))
                    this.SendInput = (DSendInput)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DSendInput));
                if (GetProcAddress("XIMAllocSmoothness", ref procAddr))
                    this.AllocSmoothness = (DAllocSmoothness)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DAllocSmoothness));
                if (GetProcAddress("XIMFreeSmoothness", ref procAddr))
                    this.FreeSmoothness = (DFreeSmoothness)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DFreeSmoothness));
                if (GetProcAddress("XIMComputeStickValues", ref procAddr))
                    this.ComputeStickValues = (DComputeStickValues)Marshal.GetDelegateForFunctionPointer(procAddr, typeof(DComputeStickValues));

                this.fInit = true;
            }
        }

        public void CopyCalibrate()
        {
            if (File.Exists(this.ximPath + "\\XIMCalibrate.ini"))
            {
                Process p = new Process();
                p.StartInfo.FileName = "xcopy.exe";
                p.StartInfo.Arguments = "\""+this.ximPath + "\\XIMCalibrate.ini\" \""+Environment.CurrentDirectory+"\\\" /Y /R";
                p.StartInfo.Verb = "runas";
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; 
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                p.WaitForExit();
            }
            else if (File.Exists(this.ximPath + "\\XIMCalibrate.exe"))
            {
                DialogResult dlgResult =  MessageBox.Show("Could not locate a XIMCalibrate ini file.  If you would like to run XIMCalibrate then plug both Xbox controller cables into the computer and hit OK, hit Cancel to avoid that :)", "Want to Calibrate?", MessageBoxButtons.OKCancel);
                if (dlgResult == DialogResult.OK)
                {
                    RunCalibrate();
                }
            }
        }

        public void RunCalibrate()
        {
            Process p = new Process();
            p.StartInfo.FileName = this.ximPath + "\\XIMCalibrate.exe";
            p.StartInfo.Verb = "runas";
            p.Start();

            p.WaitForExit();
        }


        //XIMDisconnect
        public delegate Xim.Status DConnect();

        // Disconnect from XIM hardware.
        public delegate void DDisconnect();

        // Set runtime mode option (combined flags).
        public delegate Xim.Status DSetMode(Xim.Mode mode);

        // Send Xbox 360 controller state.
        // Controller state will persist (latch) until the next call. Method
        // will not return until state is fully committed to the Xbox 360 controller and
        // the specified timeout was met.
        public delegate Xim.Status DSendInput(ref Xim.Input input, float timeoutMS);

        public delegate IntPtr DAllocSmoothness(float intensity, int inputUpdateFrequency, float stickYXRatio, float stickTranslationExponent, float stickSensitivity);

        public delegate void DFreeSmoothness(IntPtr smoothness);

        public delegate Xim.Status DComputeStickValues(
            float deltaX, float deltaY,
            float stickYXRatio, float stickTranslationExponent, float stickSensitivity,
            float stickDiagonalDampen,
            IntPtr stickSmoothness,
            Xim.Deadzone stickDeadZoneType, float stickDeadZone,
            ref short stickResultX, ref short stickResultY);
    }
}
