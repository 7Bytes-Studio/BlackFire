//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 基于PlayerPrefs的KVS存储。
    /// </summary>
    public sealed class KVSPlayerPrefs : IKeyValueStorage
    {
        public KVSPlayerPrefs()
        {
            InitRegisterList();
        }


        public string GetValue(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public void Del(string key)
        {
            PlayerPrefs.DeleteKey(key);
            RemoveRegister(key);
        }

        public void DelAll()
        {
            var keys = GetAllKeys();
            for (int i = 0; i < keys.Length; i++)
            {
                if (PlayerPrefs.HasKey(keys[i]))
                {
                    PlayerPrefs.DeleteKey(keys[i]);
                }
            }
            RemoveAllRegister();
        }

        public void SetValue(string key, string value)
        {
            PlayerPrefs.SetString(key,value);
            AddRegister(key);
        }



        #region KVSRegister





        private KVSRegister m_KVSRegister = null;

        private void InitRegisterList()
        {
            if (PlayerPrefs.HasKey("KVSRegister"))
            {
                var value = PlayerPrefs.GetString("KVSRegister");
                m_KVSRegister = JsonUtility.FromJson<KVSRegister>(value);
            }
            else
            {
                m_KVSRegister = new KVSRegister();
                PlayerPrefs.SetString("KVSRegister",JsonUtility.ToJson(m_KVSRegister));
            }
        }

        private void AddRegister(string newKey)
        {
            if (!m_KVSRegister.keys.Contains(newKey))
            {
                m_KVSRegister.keys.Add(newKey);
            }
        }

        private void RemoveRegister(string key)
        {
            if (m_KVSRegister.keys.Contains(key))
            {
                m_KVSRegister.keys.Remove(key);
            }
        }

        private void RemoveAllRegister()
        {
            m_KVSRegister.keys.Clear();
        }

        private string[] GetAllKeys()
        {
            return m_KVSRegister.keys.ToArray();
        }



        [System.Serializable]
        private sealed class KVSRegister
        {
            public List<string> keys = new List<string>();
        }

        #endregion

    }
}
