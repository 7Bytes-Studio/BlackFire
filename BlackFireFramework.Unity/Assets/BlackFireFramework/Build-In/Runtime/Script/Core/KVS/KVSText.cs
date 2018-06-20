//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public class KVSText : IKeyValueStorage
    {
        private string m_Path;

        private SortedDictionary<string,string> m_KVDic = new SortedDictionary<string,string>();



        public KVSText()
        {
            m_Path = BlackFire.StreamingAssetsPath + "/kvs.txt";

            if (!File.Exists(m_Path))
            {
                using (File.Create(m_Path)) { }
            }
            else
            {
                StringReader sr = new StringReader(File.ReadAllText(m_Path));
                string line;
                string key;
                string value;
                while (null!=(line=sr.ReadLine()))
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i]=='=')
                        {
                            key = line.Substring(0,i);
                            value = line.Substring(i+1,line.Length - i-1); 
                            m_KVDic.Add(key,value);
                            break;
                        }
                    }
                }
                sr.Close();
            }

            BlackFire.ApplicationQuit += BlackFire_ApplicationQuit;

        }

        ~KVSText()
        {
            SaveAtApplicationQuit();
        }




        private void BlackFire_ApplicationQuit()
        {
            SaveAtApplicationQuit();
            BlackFire.ApplicationQuit -= BlackFire_ApplicationQuit;
        }

        private bool m_HasSave = false;
        private void SaveAtApplicationQuit()
        {
            if (m_HasSave) return;
            using (FileStream fs = new FileStream(m_Path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var kv in m_KVDic)
                    {
                        sw.WriteLine(string.Format("{0}={1}", kv.Key, kv.Value));
                    }
                    sw.Flush();
                    sw.Close();
                }
                fs.Close();
            }
            m_HasSave = true;
        }



        public void Del(string key)
        {
            if (m_KVDic.ContainsKey(key))
            {
                m_KVDic.Remove(key);
            }
        }

        public void DelAll()
        {
            m_KVDic.Clear();
        }

        public string GetValue(string key)
        {
            if (m_KVDic.ContainsKey(key))
            {
               return m_KVDic[key];
            }
            return string.Empty;
        }

        public bool HasKey(string key)
        {
            return m_KVDic.ContainsKey(key);
        }

        public void SetValue(string key, string value)
        {
            if (!m_KVDic.ContainsKey(key))
            {
                m_KVDic.Add(key,string.Empty);
            }
            m_KVDic[key] = value;
        }
    }
}
