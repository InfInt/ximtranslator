using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace X2
{
    class ConfigManager
    {
        InfoTextManager m_infoTextManager;
        Dictionary<String, Win32Api.VirtualKeys> m_key;
        Dictionary<String, Mouse.Button> m_mouse;
        Dictionary<String, Xim.Button> m_xim;

        String m_x2DataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\X2";
                

        private ConfigManager()
        {
            m_infoTextManager = InfoTextManager.Instance;
            m_key = new Dictionary<string, Win32Api.VirtualKeys>();
            m_mouse = new Dictionary<string, Mouse.Button>();
            m_xim = new Dictionary<string, Xim.Button>();

            m_key.Add("key0",Win32Api.VirtualKeys.N0);
            m_key.Add("key1",Win32Api.VirtualKeys.N1);
            m_key.Add("key2",Win32Api.VirtualKeys.N2);
            m_key.Add("key3",Win32Api.VirtualKeys.N3);
            m_key.Add("key4",Win32Api.VirtualKeys.N4);
            m_key.Add("key5",Win32Api.VirtualKeys.N5);
            m_key.Add("key6",Win32Api.VirtualKeys.N6);
            m_key.Add("key7",Win32Api.VirtualKeys.N7);
            m_key.Add("key8",Win32Api.VirtualKeys.N8);
            m_key.Add("key9",Win32Api.VirtualKeys.N9);
            m_key.Add("keya",Win32Api.VirtualKeys.A);
            m_key.Add("keyadd",Win32Api.VirtualKeys.Add);
            m_key.Add("keyapostrophe",Win32Api.VirtualKeys.Apostrophe);
            m_key.Add("keyapplications",Win32Api.VirtualKeys.Application);
            //m_key.Add("keyat",Win32Api.VirtualKeys.At);
            m_key.Add("keyb",Win32Api.VirtualKeys.B);
            m_key.Add("keybackslash",Win32Api.VirtualKeys.Backslash);
            m_key.Add("keybackspace",Win32Api.VirtualKeys.Back);
            m_key.Add("keyc",Win32Api.VirtualKeys.C);
            m_key.Add("keycalculator",Win32Api.VirtualKeys.LaunchApplication1);
            m_key.Add("keycaptial",Win32Api.VirtualKeys.Capital);
            m_key.Add("keycolon",Win32Api.VirtualKeys.Semicolon);
            m_key.Add("keycomma",Win32Api.VirtualKeys.Comma);
            //m_key.Add("keyconvert",Win32Api.VirtualKeys.Convert);
            m_key.Add("keyd",Win32Api.VirtualKeys.D);
            m_key.Add("keydecimal",Win32Api.VirtualKeys.Decimal);
            m_key.Add("keydelete",Win32Api.VirtualKeys.Delete);
            m_key.Add("keydivide",Win32Api.VirtualKeys.Divide);
            m_key.Add("keydown",Win32Api.VirtualKeys.Down);
            m_key.Add("keye",Win32Api.VirtualKeys.E);
            m_key.Add("keyend",Win32Api.VirtualKeys.End);
            m_key.Add("keyenter",Win32Api.VirtualKeys.Return);
            m_key.Add("keyequals",Win32Api.VirtualKeys.Plus);
            m_key.Add("keyescape",Win32Api.VirtualKeys.Escape);
            m_key.Add("keyf",Win32Api.VirtualKeys.F);
            m_key.Add("keyf1",Win32Api.VirtualKeys.F1);
            m_key.Add("keyf10",Win32Api.VirtualKeys.F10);
            m_key.Add("keyf11",Win32Api.VirtualKeys.F11);
            m_key.Add("keyf12",Win32Api.VirtualKeys.F12);
            m_key.Add("keyf13",Win32Api.VirtualKeys.F13);
            m_key.Add("keyf14",Win32Api.VirtualKeys.F14);
            m_key.Add("keyf15",Win32Api.VirtualKeys.F15);
            m_key.Add("keyf2",Win32Api.VirtualKeys.F2);
            m_key.Add("keyf3",Win32Api.VirtualKeys.F3);
            m_key.Add("keyf4",Win32Api.VirtualKeys.F4);
            m_key.Add("keyf5",Win32Api.VirtualKeys.F5);
            m_key.Add("keyf6",Win32Api.VirtualKeys.F6);
            m_key.Add("keyf7",Win32Api.VirtualKeys.F7);
            m_key.Add("keyf8",Win32Api.VirtualKeys.F8);
            m_key.Add("keyf9",Win32Api.VirtualKeys.F9);
            m_key.Add("keyg",Win32Api.VirtualKeys.G);
            m_key.Add("keyh",Win32Api.VirtualKeys.H);
            m_key.Add("keyhome",Win32Api.VirtualKeys.Home);
            m_key.Add("keyi",Win32Api.VirtualKeys.I);
            m_key.Add("keyinsert",Win32Api.VirtualKeys.Insert);
            m_key.Add("keyj",Win32Api.VirtualKeys.J);
            m_key.Add("keyk",Win32Api.VirtualKeys.K);
            //m_key.Add("keykana",Win32Api.VirtualKeys.Kana);
            //m_key.Add("keykanji",Win32Api.VirtualKeys.Kanji);
            m_key.Add("keyl",Win32Api.VirtualKeys.L);
            m_key.Add("keyleft",Win32Api.VirtualKeys.Left);
            m_key.Add("keyleftalt",Win32Api.VirtualKeys.Menu);
            m_key.Add("keyleftbracket",Win32Api.VirtualKeys.LeftBracket);
            m_key.Add("keyleftcontrol",Win32Api.VirtualKeys.Control);
            m_key.Add("keyleftshift",Win32Api.VirtualKeys.Shift);
            m_key.Add("keyleftwindows",Win32Api.VirtualKeys.LeftWindows);
            m_key.Add("keym",Win32Api.VirtualKeys.M);
            m_key.Add("keymail",Win32Api.VirtualKeys.Mail);
            m_key.Add("keymediaselect",Win32Api.VirtualKeys.MediaSelect);
            m_key.Add("keymediastop",Win32Api.VirtualKeys.MediaStop);
            m_key.Add("keyminus",Win32Api.VirtualKeys.Minus);
            m_key.Add("keymultiply",Win32Api.VirtualKeys.Multiply);
            m_key.Add("keymute",Win32Api.VirtualKeys.VolumeMute);
            //m_key.Add("keymycomputer",Win32Api.VirtualKeys.media);
            m_key.Add("keyn",Win32Api.VirtualKeys.N);
            m_key.Add("keynexttrack",Win32Api.VirtualKeys.MediaNextTrack);
            //m_key.Add("keynoconvert",Win32Api.VirtualKeys.NoConvert);
            m_key.Add("keynumlock", Win32Api.VirtualKeys.NumLock);
            m_key.Add("keynumpad0", Win32Api.VirtualKeys.Numpad0);
            m_key.Add("keynumpad1", Win32Api.VirtualKeys.Numpad1);
            m_key.Add("keynumpad2", Win32Api.VirtualKeys.Numpad2);
            m_key.Add("keynumpad3", Win32Api.VirtualKeys.Numpad3);
            m_key.Add("keynumpad4", Win32Api.VirtualKeys.Numpad4);
            m_key.Add("keynumpad5", Win32Api.VirtualKeys.Numpad5);
            m_key.Add("keynumpad6", Win32Api.VirtualKeys.Numpad6);
            m_key.Add("keynumpad7", Win32Api.VirtualKeys.Numpad7);
            m_key.Add("keynumpad8", Win32Api.VirtualKeys.Numpad8);
            m_key.Add("keynumpad9", Win32Api.VirtualKeys.Numpad9);
            //m_key.Add("keynumpadcomma",Win32Api.VirtualKeys.NumPadComma);
            m_key.Add("keynumpadenter",Win32Api.VirtualKeys.Return);
            //m_key.Add("keynumpadequals",Win32Api.VirtualKeys.NumPadEquals);
            m_key.Add("keyo",Win32Api.VirtualKeys.O);
            m_key.Add("keyp",Win32Api.VirtualKeys.P);
            m_key.Add("keypagedown",Win32Api.VirtualKeys.Next);
            m_key.Add("keypageup",Win32Api.VirtualKeys.Prior);
            m_key.Add("keypause",Win32Api.VirtualKeys.Pause);
            m_key.Add("keyperiod",Win32Api.VirtualKeys.Period);
            m_key.Add("keyplaypause",Win32Api.VirtualKeys.Play);
            //m_key.Add("keypower",Win32Api.VirtualKeys.Power);
            m_key.Add("keyprevioustrack",Win32Api.VirtualKeys.MediaPrevTrack);
            m_key.Add("keyq",Win32Api.VirtualKeys.Q);
            m_key.Add("keyr",Win32Api.VirtualKeys.R);
            m_key.Add("keyright",Win32Api.VirtualKeys.Right);
            m_key.Add("keyrightalt",Win32Api.VirtualKeys.Menu);
            m_key.Add("keyrightcontrol",Win32Api.VirtualKeys.Control);
            m_key.Add("keyrightshift",Win32Api.VirtualKeys.Shift);
            m_key.Add("keyrightwindows",Win32Api.VirtualKeys.RightWindows);
            m_key.Add("keyrrightbracket",Win32Api.VirtualKeys.RightBracket);
            m_key.Add("keys", Win32Api.VirtualKeys.S);
            m_key.Add("keyscroll",Win32Api.VirtualKeys.ScrollLock);
            m_key.Add("keysemicolon",Win32Api.VirtualKeys.Semicolon);
            m_key.Add("keyslash",Win32Api.VirtualKeys.Slash);
            m_key.Add("keysleep",Win32Api.VirtualKeys.Sleep);
            m_key.Add("keyspace",Win32Api.VirtualKeys.Space);
            //m_key.Add("keystop",Win32Api.VirtualKeys.Stop);
            m_key.Add("keysubtract",Win32Api.VirtualKeys.Subtract);
            m_key.Add("keyprint",Win32Api.VirtualKeys.Print);
            m_key.Add("keyt",Win32Api.VirtualKeys.T);
            m_key.Add("keytab",Win32Api.VirtualKeys.Tab);
            m_key.Add("keytilde",Win32Api.VirtualKeys.Tilde);
            m_key.Add("keyu",Win32Api.VirtualKeys.U);
            m_key.Add("keyunderline",Win32Api.VirtualKeys.Minus);
            //m_key.Add("keyunlabeled",Win32Api.VirtualKeys.Unlabeled);
            m_key.Add("keyup",Win32Api.VirtualKeys.Up);
            m_key.Add("keyv",Win32Api.VirtualKeys.V);
            m_key.Add("keyvolumedown",Win32Api.VirtualKeys.VolumeDown);
            m_key.Add("keyvolumeup",Win32Api.VirtualKeys.VolumeUp);
            m_key.Add("keyw",Win32Api.VirtualKeys.W);
            //m_key.Add("keywake",Win32Api.VirtualKeys.Wake);
            m_key.Add("keywebback",Win32Api.VirtualKeys.BrowserBack);
            m_key.Add("keywebfavorites",Win32Api.VirtualKeys.BrowserFavorites);
            m_key.Add("keywebforward",Win32Api.VirtualKeys.BrowserForward);
            m_key.Add("keywebhome",Win32Api.VirtualKeys.BrowserHome);
            m_key.Add("keywebrefresh",Win32Api.VirtualKeys.BrowserRefresh);
            m_key.Add("keywebsearch",Win32Api.VirtualKeys.BrowserSearch);
            m_key.Add("keywebstop",Win32Api.VirtualKeys.BrowserStop);
            m_key.Add("keyx",Win32Api.VirtualKeys.X);
            m_key.Add("keyy",Win32Api.VirtualKeys.Y);
            //m_key.Add("keyyen",Win32Api.VirtualKeys.Yen);
            m_key.Add("keyz",Win32Api.VirtualKeys.Z);

            m_mouse.Add("mouseleft",Mouse.Button.MouseLeft );
            m_mouse.Add("mouseright",Mouse.Button.MouseRight );
            m_mouse.Add("mousemiddle",Mouse.Button.MouseMiddle );
            m_mouse.Add("mouseback",Mouse.Button.Mouse4 );
            m_mouse.Add("mouseforward",Mouse.Button.Mouse5 );
            //m_mouse.Add("mouseaux1",Mouse.Button.Mouse6 );
            //m_mouse.Add("mouseaux2",Mouse.Button.Mouse7 );
            //m_mouse.Add("mouseaux3",Mouse.Button.Mouse8 );
            m_mouse.Add("mousescrollup", Mouse.Button.MWheelUp);
            m_mouse.Add("mousescrolldown", Mouse.Button.MWheelDown);

            m_xim.Add("rightstickup", Xim.Button.RightStickPositiveY);
            m_xim.Add("rightstickdown", Xim.Button.RightStickNegativeY);
            m_xim.Add("rightstickright", Xim.Button.RightStickPositiveX);
            m_xim.Add("rightstickleft", Xim.Button.RightStickNegativeX);
            m_xim.Add("leftstickup", Xim.Button.LeftStickPositiveY);
            m_xim.Add("leftstickdown", Xim.Button.LeftStickNegativeY);
            m_xim.Add("leftstickright", Xim.Button.LeftStickPositiveX);
            m_xim.Add("leftstickleft", Xim.Button.LeftStickNegativeX);
            m_xim.Add("buttonsup", Xim.Button.Up);
            m_xim.Add("buttonsdown", Xim.Button.Down);
            m_xim.Add("buttonsleft", Xim.Button.Left);
            m_xim.Add("buttonsright", Xim.Button.Right);
            m_xim.Add("buttonsrighttrigger", Xim.Button.RightTrigger);
            m_xim.Add("buttonslefttrigger", Xim.Button.LeftTrigger);
            m_xim.Add("buttonsrightstick", Xim.Button.RightStick);
            m_xim.Add("buttonsleftstick", Xim.Button.LeftStick);
            m_xim.Add("buttonsrightbumper", Xim.Button.RightBumper);
            m_xim.Add("buttonsleftbumper", Xim.Button.LeftBumper);
            m_xim.Add("buttonsstart", Xim.Button.Start);
            m_xim.Add("buttonsguide", Xim.Button.Guide);
            m_xim.Add("buttonsback", Xim.Button.Back);
            m_xim.Add("buttonsa", Xim.Button.A);
            m_xim.Add("buttonsb", Xim.Button.B);
            m_xim.Add("buttonsx", Xim.Button.X);
            m_xim.Add("buttonsy", Xim.Button.Y);

        }

        public static ConfigManager Instance
        {
            get { return Singleton<ConfigManager>.Instance; }
        }

        private bool LoadDotXim(String file)
        {
            VarManager varManager = Singleton<VarManager>.Instance;
            CommandParser cmdParser = new CommandParser();
            m_infoTextManager.WriteLine("Loading xim config from: " + Environment.NewLine + "\t" + file + "... ");

            StreamReader sr;
            if (!OpenFile(file, out sr))
            {
                m_infoTextManager.Write("Failed!! file not found :(");
                return false;
            }

            cmdParser.ParseLine("unbindall");

            String currentSection = "";
            String altSens = "";
            bool onMouseBinding = false;

            String s;
            while ( (s = sr.ReadLine()) != null)
            {
                s = s.ToLower();
                if (s.StartsWith(";"))
                {
                    continue;
                }
                else if (s.StartsWith("["))
                {
                    // Entering a new section.
                    s = s.Substring(1, s.Length - 2);
                    currentSection = s;
                }
                else
                {
                    String[] tokens = s.Split(new char[]{ ' ','=' }, StringSplitOptions.RemoveEmptyEntries );
                    if (tokens.Length == 2)
                    {
                        if (tokens[0] == "binding")
                        {
                            onMouseBinding = tokens[1] == "mouse";
                        }
                        if (tokens[0] == "deadzone")
                        {
                            cmdParser.ParseLine("set deadzone " + tokens[1]);
                        }
                        else if (tokens[0] == "deadzonetype")
                        {
                            cmdParser.ParseLine("set deadzonecircle " + tokens[1] == "circle" ? "true" : "false");
                        } 
                        else if (tokens[0] == "yxratio")
                        {
                            cmdParser.ParseLine("set yxratio " + tokens[1]);
                        }
                        else if (tokens[0] == "translationexponent")
                        {
                            cmdParser.ParseLine("set transexponent1 " + tokens[1]);
                            cmdParser.ParseLine("set transexponent2 " + tokens[1]);
                        }
                        else  if (tokens[0] == "sensitivityprimary" && onMouseBinding )
                        {
                            cmdParser.ParseLine("set sensitivity1 " + tokens[1]);
                        }
                        else if (tokens[0] == "sensitivitytoggle" && onMouseBinding)
                        {
                            altSens = tokens[1];
                        }
                        else if (tokens[0] == "sensitivitysecondary" && onMouseBinding)
                        {
                            cmdParser.ParseLine("set sensitivity2 " + tokens[1]);
                        }
                        else if (tokens[0] == "autoanalogdisconnect")
                        {
                            cmdParser.ParseLine("set autoanalogdisconnect " + tokens[1]);
                        }
                        else if (tokens[0] == "inputupdatefrequency")
                        {
                            cmdParser.ParseLine("set rate " + tokens[1]);
                        }
                        else if (m_xim.ContainsKey(currentSection + tokens[0]))
                        {
                            // Some sort of binding.
                            Xim.Button ximButton;
                            m_xim.TryGetValue(currentSection + tokens[0], out ximButton);

                            if (m_mouse.ContainsKey(tokens[1]))
                            {
                                Mouse.Button mouseButton;
                                m_mouse.TryGetValue(tokens[1],out mouseButton);
                                cmdParser.ParseLine("bind " + mouseButton.ToString().ToLower() + " ." + ximButton.ToString().ToLower());
                            }
                            else if (m_key.ContainsKey(tokens[1]))
                            {
                                Win32Api.VirtualKeys keyButton;
                                m_key.TryGetValue(tokens[1], out keyButton);
                                cmdParser.ParseLine("bind " + keyButton.ToString().ToLower() + " ." + ximButton.ToString().ToLower());
                            }
                        }
                    }
                }
            }
            if (altSens.Length > 0)
            {
                string otherBinds = "";
                if (m_mouse.ContainsKey(altSens))
                {
                    Mouse.Button mouseButton;
                    m_mouse.TryGetValue(altSens, out mouseButton);
                    if (BindingManager.Instance.IsBound(mouseButton))
                    {
                        otherBinds = BindingManager.Instance.GetBindString(mouseButton);
                    }
                        
                    cmdParser.ParseLine("bind " + mouseButton.ToString().ToLower() +" "+ otherBinds + ".altsens");
  
                }
                else if (m_key.ContainsKey(altSens))
                {
                    Win32Api.VirtualKeys keyButton;
                    m_key.TryGetValue(altSens, out keyButton);
                    if (BindingManager.Instance.IsBound(keyButton))
                    {
                        otherBinds = BindingManager.Instance.GetBindString(keyButton);
                    }
                        
                    cmdParser.ParseLine("bind " + keyButton.ToString().ToLower() +" "+ otherBinds + ".altsens");
                } 
            }
            m_infoTextManager.Write("Success!!!");
            return true;
        }

        public bool OpenFile(String file, out StreamReader sr)
        {
            if (File.Exists(file))
            {
                sr = File.OpenText(file);
            }
            else
            {
                String fileLoc = m_x2DataFolder + "\\" + file;
                if (File.Exists(fileLoc))
                {
                    sr = File.OpenText(fileLoc);
                }
                else
                {
                    sr = null;
                    return false;
                }
            }

            return true;
        }

        public void SaveFileDlg()
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Filter = "Config Files|*.cfg|All Files|*.*";
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                String filename = saveFileDlg.FileName;
                if (SaveConfig(saveFileDlg.FileName))
                {

                }
            }
        }

        public void LoadFileDlg()
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "Config Files|*.cfg;*.xim|All Files|*.*";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                String filename = openFileDlg.FileName;
                if (filename.EndsWith(".cfg"))
                {
                    LoadConfig(openFileDlg.FileName);
                }
                else if (filename.EndsWith(".xim"))
                {
                    LoadDotXim(filename);
                }
            }
        }

        public bool LoadConfig(String file)
        {
            CommandParser cmdParser = new CommandParser();

            StreamReader SR;

            m_infoTextManager.WriteLine("Loading config from: " + Environment.NewLine + "\t" + file + "... ");

            if (OpenFile(file, out SR) && !SR.EndOfStream)
            {
                string line = SR.ReadLine();
                while (line != null)
                {
                    cmdParser.ParseLine(line);
                    line = SR.ReadLine();
                }
                SR.Close();
            }
            else
            {
                m_infoTextManager.Write("Failed!");
                return false;
            }
            m_infoTextManager.Write("Success!");
            return true;
        }

        public void SaveDefaultConfig()
        {
            SaveConfig(m_x2DataFolder + "\\default.cfg");
        }

        public void LoadDefaultConfig()
        {
            String cfgLoc = m_x2DataFolder + "\\default.cfg";
            if (!LoadConfig(cfgLoc))
            {
                if (!LoadConfig(XimDyn.Instance.ximPath + "\\default.xim"))
                {
                    m_infoTextManager.WriteLine("Unable to load default config, or default.xim, be sure to load a config!");
                }
            }
        }

        public bool SaveConfig(String file)
        {
            if (!Directory.Exists(file.Substring(0, file.LastIndexOf('\\'))))
            {
                Directory.CreateDirectory(file.Substring(0, file.LastIndexOf('\\')));
            }

            TextWriter fs = new StreamWriter(file);
            m_infoTextManager.WriteLine("Saving config to: " + file +"... ");
            if (fs != null)
            {
                VarManager varManager = Singleton<VarManager>.Instance;
                BindingManager bindManager = Singleton<BindingManager>.Instance;

                List<String> binds;
                List<String> vars;

                varManager.GetVarsStringArray(out vars);
                bindManager.GetBindStringArray(out binds);

                foreach (String s in vars)
                {
                    fs.WriteLine("set "+ s);
                    fs.Flush();
                }

                foreach (String s in binds)
                {
                    fs.WriteLine(s);
                    fs.Flush();
                }

                fs.Close();
                m_infoTextManager.Write("Success!");
                return true;
            }
            m_infoTextManager.Write("Failed!");
            return false;
        }
    }
}
