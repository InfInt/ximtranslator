using System;
using System.Collections.Generic;
using System.Text;
using Common;
using XimApi;
using DxI = Microsoft.DirectX.DirectInput;
using Xna = Microsoft.Xna.Framework;

namespace xEmulate
{
    class BindingManager
    {
        private Dictionary<IKey, List<InputEvent>> m_bindings = new Dictionary<IKey, List<InputEvent>>(40);
        private KeysManager keysManager;
        
        private BindingManager()
        {
            this.keysManager = KeysManager.Instance;
        }

        public static BindingManager Instance
        {
            get { return Singleton<BindingManager>.Instance; }
        }

        public bool IsKey(String keyName)
        {
            return this.keysManager.IsKey(keyName);
        }

        public bool IsAnalogKey(String keyName)
        {
            return this.keysManager.IsAnalogKey(keyName);
        }

        public bool IsLinkKey(String keyName)
        {
            return this.keysManager.IsLinkKey(keyName);
        }

        public void SetKeyBind(String key, List<InputEvent> events)
        {
            IKey iKey;
            if (this.keysManager.GetKey(key, out iKey))
            {
                SetKeyBind(iKey,events);
            }
        }

        private void SetKeyBind<KeyType>(KeyType key, List<InputEvent> val) where KeyType : IKey
        {
            m_bindings[key] = val;
        }

        public bool GetKeyBind<KeyType>(KeyType key, out List<InputEvent> val) where KeyType : IKey
        {
            return m_bindings.TryGetValue(key, out val);
        }

        public bool IsBound<KeyType>(KeyType key) where KeyType : IKey
        {
            return m_bindings.ContainsKey(key);
        }

        public String GetBindString(String key)
        {
            IKey iKey;
            if (this.keysManager.GetKey(key, out iKey))
            {
                return GetBindString(iKey);
            }
            return "Key '" + key +"' is not a valid key";
        }

        public String GetBindString(IKey iKey)
        {
            String s;
            List<InputEvent> events;
            if (m_bindings.TryGetValue(iKey, out events))
            {
                GetEventAsString(events, out s);
            }
            else
                s = "Key \"" + iKey.ToString().ToLower() + "\" not bound/linked to anything";
            return s;
        }

        public void Unbind(String key)
        {
            IKey iKey;
            if (this.keysManager.GetKey(key, out iKey))
            {
                Unbind(iKey);
            }
        }

        private void Unbind(IKey iKey)
        {
            if( m_bindings.ContainsKey(iKey) )
            {
                m_bindings.Remove(iKey);
            }
        }

        public Dictionary<IKey, List<InputEvent>> GetAnalogBinds()
        {
            Dictionary<IKey, List<InputEvent>> analogBinds = new Dictionary<IKey, List<InputEvent>>();
            foreach (KeyValuePair<IKey, List<InputEvent>> pair in m_bindings)
            {
                if (pair.Key.IsAnalog)
                    analogBinds.Add(pair.Key, pair.Value);
            }
            return analogBinds;
        }

        public void GetBindStringArray(out List<String> binds)
        {
            binds = new List<String>();
            foreach (KeyValuePair<IKey, List<InputEvent>> pair in m_bindings)
            {
                String strBind;
                GetEventAsString(pair.Value, out strBind);
                if(pair.Key.IsLink)
                    binds.Add("link " + pair.Key.ToString().ToLower() + " " + strBind);
                else
                    binds.Add("bind " + pair.Key.ToString().ToLower() + " " + strBind);
            }
        }

        private void GetEventAsString(List<InputEvent> events, out String strBind)
        {
            StringBuilder s = new StringBuilder();
            foreach( InputEvent inputEvent in events )
            {
                s.Append(inputEvent.ToString() + ";");
            }
            strBind = s.ToString();
        }

        public void UnbindAll()
        {
            m_bindings.Clear();
        }
    }
}
