using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using XimApi;
using Common;
using DxI = Microsoft.DirectX.DirectInput;

namespace xEmulate
{
    class ConfigManager
    {
        InfoTextManager m_infoTextManager;
        Dictionary<String, DxI.Key> m_key;
        Dictionary<String, Mouse.Button> m_mouse;
        Dictionary<String, Xim.Button> m_xim;

        String m_x2DataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\xEmulate";
        String m_x2MyDocs = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Xim Configs";
                
        private ConfigManager()
        {
            m_infoTextManager = InfoTextManager.Instance;
            m_key = new Dictionary<string, DxI.Key>();
            m_mouse = new Dictionary<string, Mouse.Button>();
            m_xim = new Dictionary<string, Xim.Button>();

            m_key.Add("key0", DxI.Key.D0);
            m_key.Add("key1", DxI.Key.D1);
            m_key.Add("key2", DxI.Key.D2);
            m_key.Add("key3", DxI.Key.D3);
            m_key.Add("key4", DxI.Key.D4);
            m_key.Add("key5", DxI.Key.D5);
            m_key.Add("key6", DxI.Key.D6);
            m_key.Add("key7", DxI.Key.D7);
            m_key.Add("key8", DxI.Key.D8);
            m_key.Add("key9", DxI.Key.D9);
            m_key.Add("keya", DxI.Key.A);
            m_key.Add("keyadd", DxI.Key.Add);
            m_key.Add("keyapostrophe", DxI.Key.Apostrophe);
            m_key.Add("keyapplications", DxI.Key.Apps);
            //m_key.Add("keyat", DxI.Key.At);
            m_key.Add("keyb", DxI.Key.B);
            m_key.Add("keybackslash", DxI.Key.BackSlash);
            m_key.Add("keybackspace", DxI.Key.Back);
            m_key.Add("keyc", DxI.Key.C);
            m_key.Add("keycalculator", DxI.Key.Calculator);
            m_key.Add("keycaptial", DxI.Key.Capital);
            m_key.Add("keycolon", DxI.Key.Colon);
            m_key.Add("keycomma", DxI.Key.Comma);
            m_key.Add("keyconvert", DxI.Key.Convert);
            m_key.Add("keyd", DxI.Key.D);
            m_key.Add("keydecimal", DxI.Key.Decimal);
            m_key.Add("keydelete", DxI.Key.Delete);
            m_key.Add("keydivide", DxI.Key.Divide);
            m_key.Add("keydown", DxI.Key.Down);
            m_key.Add("keye", DxI.Key.E);
            m_key.Add("keyend", DxI.Key.End);
            m_key.Add("keyenter", DxI.Key.Return);
            m_key.Add("keyequals", DxI.Key.Equals);
            m_key.Add("keyescape", DxI.Key.Escape);
            m_key.Add("keyf", DxI.Key.F);
            m_key.Add("keyf1", DxI.Key.F1);
            m_key.Add("keyf10", DxI.Key.F10);
            m_key.Add("keyf11", DxI.Key.F11);
            m_key.Add("keyf12", DxI.Key.F12);
            m_key.Add("keyf13", DxI.Key.F13);
            m_key.Add("keyf14", DxI.Key.F14);
            m_key.Add("keyf15", DxI.Key.F15);
            m_key.Add("keyf2", DxI.Key.F2);
            m_key.Add("keyf3", DxI.Key.F3);
            m_key.Add("keyf4", DxI.Key.F4);
            m_key.Add("keyf5", DxI.Key.F5);
            m_key.Add("keyf6", DxI.Key.F6);
            m_key.Add("keyf7", DxI.Key.F7);
            m_key.Add("keyf8", DxI.Key.F8);
            m_key.Add("keyf9", DxI.Key.F9);
            m_key.Add("keyg", DxI.Key.G);
            m_key.Add("keyh", DxI.Key.H);
            m_key.Add("keyhome", DxI.Key.Home);
            m_key.Add("keyi", DxI.Key.I);
            m_key.Add("keyinsert", DxI.Key.Insert);
            m_key.Add("keyj", DxI.Key.J);
            m_key.Add("keyk", DxI.Key.K);
            m_key.Add("keykana", DxI.Key.Kana);
            m_key.Add("keykanji", DxI.Key.Kanji);
            m_key.Add("keyl", DxI.Key.L);
            m_key.Add("keyleft", DxI.Key.Left);
            m_key.Add("keyleftalt", DxI.Key.LeftAlt);
            m_key.Add("keyleftbracket", DxI.Key.LeftBracket);
            m_key.Add("keyleftcontrol", DxI.Key.LeftControl);
            m_key.Add("keyleftshift", DxI.Key.LeftShift);
            m_key.Add("keyleftwindows", DxI.Key.LeftWindows);
            m_key.Add("keym", DxI.Key.M);
            m_key.Add("keymail", DxI.Key.Mail);
            m_key.Add("keymediaselect", DxI.Key.MediaSelect);
            m_key.Add("keymediastop", DxI.Key.MediaStop);
            m_key.Add("keyminus", DxI.Key.Minus);
            m_key.Add("keymultiply", DxI.Key.Multiply);
            m_key.Add("keymute", DxI.Key.Mute);
            //m_key.Add("keymycomputer", DxI.Key.media);
            m_key.Add("keyn", DxI.Key.N);
            m_key.Add("keynexttrack", DxI.Key.NextTrack);
            //m_key.Add("keynoconvert", DxI.Key.NoConvert);
            m_key.Add("keynumlock",  DxI.Key.Numlock);
            m_key.Add("keynumpad0",  DxI.Key.NumPad0);
            m_key.Add("keynumpad1",  DxI.Key.NumPad1);
            m_key.Add("keynumpad2",  DxI.Key.NumPad2);
            m_key.Add("keynumpad3",  DxI.Key.NumPad3);
            m_key.Add("keynumpad4",  DxI.Key.NumPad4);
            m_key.Add("keynumpad5",  DxI.Key.NumPad5);
            m_key.Add("keynumpad6",  DxI.Key.NumPad6);
            m_key.Add("keynumpad7",  DxI.Key.NumPad7);
            m_key.Add("keynumpad8",  DxI.Key.NumPad8);
            m_key.Add("keynumpad9",  DxI.Key.NumPad9);
            m_key.Add("keynumpadcomma", DxI.Key.NumPadComma);
            m_key.Add("keynumpadenter", DxI.Key.Return);
            m_key.Add("keynumpadequals", DxI.Key.NumPadEquals);
            m_key.Add("keyo", DxI.Key.O);
            m_key.Add("keyp", DxI.Key.P);
            m_key.Add("keypagedown", DxI.Key.Next);
            m_key.Add("keypageup", DxI.Key.Prior);
            m_key.Add("keypause", DxI.Key.Pause);
            m_key.Add("keyperiod", DxI.Key.Period);
            m_key.Add("keyplaypause", DxI.Key.PlayPause);
            //m_key.Add("keypower", DxI.Key.Power);
            m_key.Add("keyprevioustrack", DxI.Key.PrevTrack);
            m_key.Add("keyq", DxI.Key.Q);
            m_key.Add("keyr", DxI.Key.R);
            m_key.Add("keyright", DxI.Key.Right);
            m_key.Add("keyrightalt", DxI.Key.RightAlt);
            m_key.Add("keyrightcontrol", DxI.Key.RightControl);
            m_key.Add("keyrightshift", DxI.Key.RightShift);
            m_key.Add("keyrightwindows", DxI.Key.RightWindows);
            m_key.Add("keyrrightbracket", DxI.Key.RightBracket);
            m_key.Add("keys",  DxI.Key.S);
            m_key.Add("keyscroll", DxI.Key.Scroll);
            m_key.Add("keysemicolon", DxI.Key.SemiColon);
            m_key.Add("keyslash", DxI.Key.Slash);
            m_key.Add("keysleep", DxI.Key.Sleep);
            m_key.Add("keyspace", DxI.Key.Space);
            m_key.Add("keystop", DxI.Key.Stop);
            m_key.Add("keysubtract", DxI.Key.Subtract);
            m_key.Add("keyprint", DxI.Key.SysRq);
            m_key.Add("keyt", DxI.Key.T);
            m_key.Add("keytab", DxI.Key.Tab);
            m_key.Add("keytilde", DxI.Key.Grave);
            m_key.Add("keyu", DxI.Key.U);
            m_key.Add("keyunderline", DxI.Key.Minus);
            m_key.Add("keyunlabeled", DxI.Key.Unlabeled);
            m_key.Add("keyup", DxI.Key.Up);
            m_key.Add("keyv", DxI.Key.V);
            m_key.Add("keyvolumedown", DxI.Key.VolumeDown);
            m_key.Add("keyvolumeup", DxI.Key.VolumeUp);
            m_key.Add("keyw", DxI.Key.W);
            m_key.Add("keywake", DxI.Key.Wake);
            m_key.Add("keywebback", DxI.Key.WebBack);
            m_key.Add("keywebfavorites", DxI.Key.WebFavorites);
            m_key.Add("keywebforward", DxI.Key.WebForward);
            m_key.Add("keywebhome", DxI.Key.WebHome);
            m_key.Add("keywebrefresh", DxI.Key.WebRefresh);
            m_key.Add("keywebsearch", DxI.Key.WebSearch);
            m_key.Add("keywebstop", DxI.Key.WebStop);
            m_key.Add("keyx", DxI.Key.X);
            m_key.Add("keyy", DxI.Key.Y);
            m_key.Add("keyyen", DxI.Key.Yen);
            m_key.Add("keyz", DxI.Key.Z);

            m_mouse.Add("mouseleft",Mouse.Button.MouseLeft );
            m_mouse.Add("mouseright",Mouse.Button.MouseRight );
            m_mouse.Add("mousemiddle",Mouse.Button.MouseMiddle );
            m_mouse.Add("mouseback",Mouse.Button.Mouse4 );
            m_mouse.Add("mouseforward",Mouse.Button.Mouse5 );
            m_mouse.Add("mouseaux1",Mouse.Button.Mouse6 );
            m_mouse.Add("mouseaux2",Mouse.Button.Mouse7 );
            m_mouse.Add("mouseaux3",Mouse.Button.Mouse8 );
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
                        else if (tokens[0] == "smoothness")
                        {
                            cmdParser.ParseLine("set smoothness " + tokens[1]);
                        }
                        else if (tokens[0] == "diagonaldampen")
                        {
                            cmdParser.ParseLine("set diagonaldampen " + tokens[1]);
                        }
                        else if (tokens[0] == "translationexponent")
                        {
                            cmdParser.ParseLine("set transexponent1 " + tokens[1]);
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
                                DxI.Key keyButton;
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
                    InputKey<Mouse.Button> mouseKey = new InputKey<Mouse.Button>(mouseButton);
                    if (BindingManager.Instance.IsBound(mouseKey))
                    {
                        otherBinds = BindingManager.Instance.GetBindString(mouseKey);
                    }
                        
                    cmdParser.ParseLine("bind " + mouseButton.ToString().ToLower() +" "+ otherBinds + ".altsens");
  
                }
                else if (m_key.ContainsKey(altSens))
                {
                    DxI.Key keyButton;
                    
                    m_key.TryGetValue(altSens, out keyButton);
                    InputKey<DxI.Key> key = new InputKey<Microsoft.DirectX.DirectInput.Key>(keyButton);
                    if (BindingManager.Instance.IsBound(key))
                    {
                        otherBinds = BindingManager.Instance.GetBindString(key);
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
            saveFileDlg.RestoreDirectory = true;
            saveFileDlg.InitialDirectory = m_x2MyDocs;
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
            openFileDlg.RestoreDirectory = true;
            openFileDlg.InitialDirectory = m_x2MyDocs;
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
