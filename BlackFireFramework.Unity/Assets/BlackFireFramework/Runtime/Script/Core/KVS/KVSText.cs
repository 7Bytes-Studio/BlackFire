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
    public sealed class KVSText : IKeyValueStorage
    {
        private string Path { get { return Application.streamingAssetsPath + "/kvs.txt"; } }

        public KVSText()
        {
            if (!File.Exists(Application.streamingAssetsPath + "/kvs.txt"))
            {
                File.CreateText(Path);
            }
            else
            {

            }
        }


        public void Del(string key)
        {
            
        }

        public void DelAll()
        {
            
        }

        public string GetValue(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool HasKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public void SetValue(string key, string value)
        {
           
        }
    }
}
