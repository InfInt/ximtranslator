using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace xEmulate
{
    public class VarManager
    {
        public static class Names
        {
            public static string Speed = "speed";
            public static string Speed2 = "speed2";
            public static string Speed3 = "speed3";
            public static string Speed4 = "speed4";
            public static string Accel = "accel";
            public static string Accel2 = "accel2";
            public static string Accel3 = "accel3";
            public static string Accel4 = "accel4";
            public static string Sensitivity1 = "sensitivity1";
            public static string Sensitivity2 = "sensitivity2";
            public static string TransExponent1 = "transexponent1";
            public static string DiagonalDampen = "diagonaldampen";
            public static string Deadzone = "deadzone";
            public static string YXRatio = "yxratio";
            public static string Rate = "rate";
            public static string TextModeRate = "textmoderate";
            public static string TextRate = "textrate";
            public static string Smoothness = "smoothness";
            public static string CircularDeadzone = "circulardeadzone";
            public static string UseXimApiMouseMath = "useximapimousemath";
            public static string MouseStickX = "mousestickx";
            public static string MouseStickY = "mousesticky";
            public static string AltSens = "altsens";
            public static string AltSens2 = "altsens2";
            public static string AltSens3 = "altsens3";
            public static string AutoAnalogDisconnect = "autoanalogdisconnect";
            public static string TextMode = "textmode";
            public static string CurrentGame = "currentgame";
            public static string InvertY = "inverty";
            public static string MouseDPI = "mousedpi";
            public static string ButtonDownTime = "buttondowntime";
            public static string DrivingMode = "drivingmode";
        };

        public enum Sticks
        {
            None = 0,
            Left,
            Right
        }

        public class Var
        {
            public Var()
            {
                this.Updated = false;
            }
            private Object value;

            public Object Default { get; set; }
            public bool Updated { get; set; }
            public String VarName { get; set; }
            public Type VarType { get; set; }
            public String Info { get; set; }
            public Enum VarValues { get; set; }
            public bool Internal { get; set; }

            public Object Value
            {
                get { return this.value; }
                set { this.Updated = true; this.value = value; }
            }

            public bool SetVar<T>(T val)
            {
                if (this.VarType != typeof(T))
                    return false;

                this.Value = val;
                return true;
            }

            public bool CanSetValue(String val, out Object valAsObject)
            {
                if (this.VarType == typeof(double))
                {
                    double value;
                    if (double.TryParse(val, out value))
                    {
                        valAsObject = value;
                        return true;
                    }
                }
                else if (this.VarType == typeof(int))
                {
                    int value;
                    if (int.TryParse(val, out value))
                    {
                        valAsObject = value;
                        return true;
                    }
                }
                else if (this.VarType == typeof(bool))
                {
                    bool value;
                    if (bool.TryParse(val, out value))
                    {
                        valAsObject = value;
                        return true;
                    }
                }
                else if (this.VarType == typeof(string))
                {
                    valAsObject = val;
                    return true;
                }
                else if (this.VarType.IsEnum)
                {
                    try
                    {
                        valAsObject = Enum.Parse(this.VarType, val, true);
                        return true;
                    }
                    catch { }
                    valAsObject = null;
                    return false;
                }

                valAsObject = null;
                return false;
            }
        };

        private Dictionary<String, Var> m_vars;

        private VarManager()
        {
            m_vars = new Dictionary<string, Var>();

            InitVar(Names.Speed, typeof(double), (double)5, false,"Sensitivity for Game Specific Algorithm", null);
            InitVar(Names.Speed2, typeof(double), (double)5, false, "Sensitivity2 for Game Specific Algorithm", null);
            InitVar(Names.Speed3, typeof(double), (double)5, false, "Sensitivity3 for Game Specific Algorithm", null);
            InitVar(Names.Speed4, typeof(double), (double)5, false, "Sensitivity4 for Game Specific Algorithm", null);
            InitVar(Names.Accel, typeof(double), (double)0, false, "Mouse acceleration for Game Specific Algorithm", null);
            InitVar(Names.Accel2, typeof(double), (double)0, false, "Mouse2 acceleration for Game Specific Algorithm", null);
            InitVar(Names.Accel3, typeof(double), (double)0, false, "Mouse3 acceleration for Game Specific Algorithm", null);
            InitVar(Names.Accel4, typeof(double), (double)0, false, "Mouse4 acceleration for Game Specific Algorithm", null);
            InitVar(Names.Sensitivity1, typeof(double), (double)6000, false, "Primary sensitivity as defined by XIM api", null);
            InitVar(Names.Sensitivity2, typeof(double), (double)8500, false, "Alternate sensitivity as defined by XIM api", null);
            InitVar(Names.TransExponent1, typeof(double), (double)0.35, false, "Translation Exponent as defined by XIM api", null);
            InitVar(Names.DiagonalDampen, typeof(double), (double)0, false, "Diagonal Dampen as defined by XIM api", null);
            InitVar(Names.Deadzone, typeof(int), (int)3000, false, "Deadzone as defined by XIM api", null);
            InitVar(Names.YXRatio, typeof(double), (double)2.0, false, "YXRatio as defined by XIM api", null);
            InitVar(Names.Rate, typeof(double), (double)60, false, "Rate to process input", null);
            InitVar(Names.TextMode, typeof(bool), (bool)false, false, "Set to true to start textmode", null);
            InitVar(Names.TextModeRate, typeof(double), (double)12, false, "Rate to process keystrokes when in Text Mode", null);
            InitVar(Names.Smoothness, typeof(double), (double)0, false, "Smoothness as defined by XIM api", null);
            InitVar(Names.AutoAnalogDisconnect, typeof(bool), (bool)false, false, "'true' = use autoanalogdisconnect, 'false' = don't", null);
            InitVar(Names.CircularDeadzone, typeof(bool), (bool)true, false, "Defines deadzone type: 'true' = circular deadzone, 'false' = square deadzone", null);
            InitVar(Names.UseXimApiMouseMath, typeof(bool), (bool)true, false, "'true' = use the xim API mouse translation, 'false' = don't", null);
            InitVar(Names.MouseStickX, typeof(Sticks), (Sticks)Sticks.Right, false, "None, Rightstick, Leftstick", null);
            InitVar(Names.MouseStickY, typeof(Sticks), (Sticks)Sticks.Right, false, "None, Rightstick, Leftstick", null);
            InitVar(Names.AltSens, typeof(bool), (bool)false, true, "'false' = use sensitivity1 and transexp1, 'true' = use sensitivity2", null);
            InitVar(Names.AltSens2, typeof(bool), (bool)false, true, "'false' = use sensitivity1 and transexp1, 'true' = use sensitivity2", null);
            InitVar(Names.AltSens3, typeof(bool), (bool)false, true, "'false' = use sensitivity1 and transexp1, 'true' = use sensitivity2", null);
            InitVar(Names.CurrentGame, typeof(GamesManager.Games), (GamesManager.Games)GamesManager.Games.Halo3, false, "Game you are currently playing when using the game specific mouse algorithm", null);
            InitVar(Names.InvertY, typeof(bool), (bool)false, false, "'true' = Invert Y axis during mouse translations", null);
            InitVar(Names.MouseDPI, typeof(int), (int)800, false, "Your mouse DPI", null);
            InitVar(Names.ButtonDownTime, typeof(int), (int)30, false, "Minimum time to hold a button down", null);
            InitVar(Names.DrivingMode, typeof(bool), (bool)false, false, "Driving Mode, useful for driving with a mouse", null);
        }

        private void InitVar(String varName, Type varType, Object value, bool intern, String info, Enum validValues)
        {
            Var var = new Var();
            var.VarName = varName;
            var.VarType = varType;
            var.Value = value;
            var.Default = value;
            var.Info = info;
            var.VarValues = validValues;
            var.Internal = intern;

            m_vars[varName] = var;
        }

        public static VarManager Instance
        {
            get { return Singleton<VarManager>.Instance; }
        }

        public bool IsVar(String key)
        {
            return m_vars.ContainsKey(key);
        }

        public bool GetVar(String key, out Var v)
        {
            return m_vars.TryGetValue(key, out v);
        }

        public String GetVarStr(String key)
        {
            Var v;
            if (GetVar(key, out v))
            {
                return v.Value.ToString().ToLower(); ;
            }
            return "";
        }

        public String GetVarInfo(String key)
        {
            Var v;
            if (GetVar(key, out v))
            {
                return v.Info.ToString();
            }
            return "";
        }

        private static T NewT<T>()
        {
            return (T)typeof(T).GetConstructor(new System.Type[] { }).Invoke(new object[] { });
        }

        public bool SetVar<T>(String key, T val)
        {
            Var v;
            if (!m_vars.TryGetValue(key,out v))
                return false;

            return v.SetVar(val);
        }

        public bool SetVar(String key, String val)
        {
            Var v;
            if (GetVar(key, out v))
            {
                if (v.VarType == typeof(bool))
                {
                    bool b;
                    if (bool.TryParse(val, out b))
                    {
                        v.Value = b;
                    }
                }
                else if (v.VarType == typeof(double))
                {
                    double d;
                    if (double.TryParse(val, out d))
                    {
                        v.Value = d;
                        return true;
                    }
                }
                else if (v.VarType == typeof(int))
                {
                    int i;
                    if (int.TryParse(val, out i))
                    {
                        v.Value = i;
                        return true;
                    }
                }

            }
            return false;
        }

        public T GetVar<T>(String key)
        {
            Var v;
            if (!m_vars.TryGetValue(key, out v))
            {
                return NewT<T>();
            }
            return (T)v.Value;
        }

        public bool GetVar<T>(String key, out T val)
        {
            Var v;
            if (!m_vars.TryGetValue(key, out v))
            {
                val = NewT<T>();
                return false;
            }

            return GetVarValue<T>(v, out val);
        }

        public static bool GetVarValue<T>(Var v, out T val) 
        {
            if (v.VarType != typeof(T))
            {
                val = NewT<T>();
                return false;
            }

            val = (T)v.Value;
            return true;
        }

        public void GetVarsStringArray(out List<String> varStrings)
        {
            varStrings = new List<String>();

            foreach (Var v in m_vars.Values)
            {
                if (v.Internal)
                    continue;
                varStrings.Add(v.VarName.ToString().ToLower() + " " + v.Value.ToString().ToLower());
            }
        }

        public void ListVars()
        {
            InfoTextManager.Instance.WriteLine("|| Setting Name || Default Value || Description ||");
            foreach (Var v in m_vars.Values)
            {
                InfoTextManager.Instance.WriteLine("|| "+ v.VarName +" || " + v.Default +" || " + v.Info +" ||");
            }
        }
    }
}
