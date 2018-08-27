//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public class GameObjectTracer : MonoBehaviour
    {
        //Id。
        public string Id;
        
        //数据结构。
        private static SortedDictionary<string,GameObject> s_GoDic = new SortedDictionary<string, GameObject>();

        public static GameObject Acqiure(string id)
        {
            if (s_GoDic.ContainsKey(id))
            {
                return s_GoDic[id];
            }
            return null;
        }

        private static void Register(string id,GameObject go)
        {
            if (!s_GoDic.ContainsKey(id))
            {
                s_GoDic.Add(id,go);
            }
        }

        private static void Remove(string id)
        {
            if (s_GoDic.ContainsKey(id))
            {
                s_GoDic.Remove(id);
            }
        }
        
        protected virtual void Awake()
        {
            Register(Id,gameObject);
        }

        protected virtual void OnDestroy()
        {
            Remove(Id);
        }
        
    }
}