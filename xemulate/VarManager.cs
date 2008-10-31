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
            public static string Sensitivity = "sensitivity";
            public static string Accel = "accel";
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
            public static string MouseStick = "mousestick";
            public static string AltSens = "altsens";
            public static string AutoAnalogDisconnect = "autoanalogdisconnect";
            public static string TextMode = "textmode";
            public static string CurrentGame = "currentgame";
            public static string InvertY = "invertyaxis";
        };

        public enum Sticks
        {
            None = 0,
            Left,
            Right,
            Both,
        }

        public class Var
        {
            public Var()
            {
                this.Updated = false;
            }
            private Object value;

            public bool Updated { get; set; }
            public String VarName { get; set; }
            public Type VarType { get; set; }
            public String Info { get; set; }
            public Enum VarValues { get; set; }

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

            InitVar(Names.Sensitivity, typeof(double), (double)5, "Sensitivity for Game Specific Algorithm", null);
            InitVar(Names.Accel, typeof(double), (double)0, "Mouse acceleration for Game Specific Algorithm", null);
            InitVar(Names.Sensitivity1, typeof(double), (double)6000, "Primary sensitivity as defined by XIM api", null);
            InitVar(Names.Sensitivity2, typeof(double), (double)8500, "Alternate sensitivity as defined by XIM api", null);
            InitVar(Names.TransExponent1, typeof(double), (double)0.35, "Translation Exponent as defined by XIM api", null);
            InitVar(Names.DiagonalDampen, typeof(double), (double)0, "Diagonal Dampen as defined by XIM api", null);
            InitVar(Names.Deadzone, typeof(int), (int)3000, "Deadzone as defined by XIM api", null);
            InitVar(Names.YXRatio, typeof(double), (double)2.0, "YXRatio as defined by XIM api", null);
            InitVar(Names.Rate, typeof(double), (double)60, "Rate to process input", null);
            InitVar(Names.TextMode, typeof(bool), (bool)false, "Set to true to start textmode", null);
            InitVar(Names.TextModeRate, typeof(double), (double)20, "Rate to process keystrokes when in Text Mode", null);
            InitVar(Names.Smoothness, typeof(double), (double)0, "Smoothness as defined by XIM api", null);
            InitVar(Names.AutoAnalogDisconnect, typeof(bool), (bool)false, "'true' = use autoanalogdisconnect, 'false' = don't", null);
            InitVar(Names.CircularDeadzone, typeof(bool), (bool)true, "Defines deadzone type: 'true' = circular deadzone, 'false' = square deadzone", null);
            InitVar(Names.UseXimApiMouseMath, typeof(bool), (bool)true, "'true' = use the xim API mouse translation, 'false' = don't", null);
            InitVar(Names.MouseStick, typeof(Sticks), (Sticks)Sticks.Right, "None, Rightstick, Leftstick, Both ( lol )", null);
            InitVar(Names.AltSens, typeof(bool), (bool)false, "'false' = use sensitivity1 and transexp1, 'true' = use sensitivity2", null);
            InitVar(Names.CurrentGame, typeof(GamesManager.Games), (GamesManager.Games)GamesManager.Games.Ut3, "", null);
            InitVar(Names.InvertY, typeof(bool), (bool)false, "'true' = Invert Y axis during mouse translations", null);
        }

        private void InitVar(String varName, Type varType, Object value, String info, Enum validValues)
        {
            Var var = new Var();
            var.VarName = varName;
            var.VarType = varType;
            var.Value = value;
            var.Info = info;
            var.VarValues = validValues;

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
                return v.Info.ToString().ToLower(); ;
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
                varStrings.Add(v.VarName.ToString().ToLower() + " " + v.Value.ToString().ToLower());
            }
        }
    }
}
