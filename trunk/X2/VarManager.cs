using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace X2
{
    public class VarManager
    {
        public class Var
        {
            public String varName;
            public Type varType;
            public Object value;
            public String info;
        };

        private Dictionary<String, Var> m_vars;

        private VarManager()
        {
            m_vars = new Dictionary<string, Var>();

            InitVar("sensitivity1", typeof(double), (double)6000,"Primary sensitivity as defined by XIM api");
            InitVar("sensitivity2", typeof(int), (int)8500,"Alternate sensitivity as defined by XIM api");
            InitVar("transexponent1", typeof(double), (double)0.35,"Translation Exponent as defined by XIM api");
            InitVar("diagonaldampen", typeof(double), (double)0, "Diagonal Dampen as defined by XIM api");
            InitVar("deadzone", typeof(int), (int)3000, "Deadzone as defined by XIM api");
            InitVar("yxratio", typeof(double), (double)2.0,"YXRatio as defined by XIM api");
            InitVar("clearsmoothonstop", typeof(bool), (bool)true, "Ignore for now");
            InitVar("rate", typeof(double), (double)60, "Rate to process input");
            InitVar("textmode", typeof(bool), (bool)false, "Set to true to start textmode");
            InitVar("textmoderate", typeof(double), (double)20, "Rate to process keystrokes when in Text Mode");
            InitVar("smoothness", typeof(double), (double)0, "Smoothness as defined by XIM api");
            InitVar("autoanalogdisconnect", typeof(bool), (bool)false, "'true' = use autoanalogdisconnect, 'false' = don't");
            InitVar("circulardeadzone", typeof(bool), (bool)true, "Defines deadzone type: 'true' = circular deadzone, 'false' = square deadzone");
            InitVar("useximapimousemath", typeof(bool), (bool)true, "'true' = use the xim API mouse translation, 'false' = don't");
            InitVar("mousemoves", typeof(int), (int)1, "'0' = None, '1' = Rightstick, '2' = Leftstick, '3' = Both ( lol )");
            InitVar("altsens", typeof(bool), (bool)false, "'false' = use sensitivity1 and transexp1, 'true' = use sensitivity2");
        }

        private void InitVar(String varName, Type varType, Object value, String info)
        {
            Var var = new Var();
            var.varName = varName;
            var.varType = varType;
            var.value = value;
            var.info = info;

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
                return v.value.ToString().ToLower();;
            }
            return "";
        }

        public String GetVarInfo(String key)
        {
            Var v;
            if (GetVar(key, out v))
            {
                return v.info.ToString().ToLower(); ;
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

            if (v.varType != typeof(T))
                return false;

            v.value = val;
            return true;
        }

        public bool SetVar(String key, String val)
        {
            Var v;
            if (GetVar(key, out v))
            {
                if (v.varType == typeof(bool))
                {
                    bool b;
                    if (bool.TryParse(val, out b))
                    {
                        v.value = b;
                    }
                }
                else if (v.varType == typeof(double))
                {
                    double d;
                    if (double.TryParse(val, out d))
                    {
                        v.value = d;
                        return true;
                    }
                }
                else if (v.varType == typeof(int))
                {
                    int i;
                    if (int.TryParse(val, out i))
                    {
                        v.value = i;
                        return true;
                    }
                }

            }
            return false;
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
            if (v.varType != typeof(T))
            {
                val = NewT<T>();
                return false;
            }

            val = (T)v.value;
            return true;
        }

        public void GetVarsStringArray(out List<String> varStrings)
        {
            varStrings = new List<String>();

            foreach (Var v in m_vars.Values)
            {
                varStrings.Add(v.varName.ToString().ToLower() + " " + v.value.ToString().ToLower());
            }
        }
    }
}
