//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// KVS访问接口。
    /// </summary>
    public static class KVS
    {
        private static Dictionary<Type,IKeyValueStorage> s_ImplDic = new Dictionary<Type,IKeyValueStorage>();

        public static void SetValue<T>(string key,string value) where T : IKeyValueStorage
        {
            CheckImplOrReturn(typeof(T)).SetValue(key,value);
        }

        public static string GetValue<T>(string key) where T : IKeyValueStorage
        {
             return CheckImplOrReturn(typeof(T)).GetValue(key);
        }

        public static void Remove<T>(string key) where T : IKeyValueStorage
        {
            CheckImplOrReturn(typeof(T)).Remove(key);
        }

        public static void RemoveAll<T>() where T : IKeyValueStorage
        {
            CheckImplOrReturn(typeof(T)).RemoveAll();
        }

        public static void RemoveAll()
        {
            foreach (var kv in s_ImplDic)
            {
                kv.Value.RemoveAll();
            }
        }



        private static IKeyValueStorage CheckImplOrReturn(Type type)
        {
            if (!s_ImplDic.ContainsKey(type))
            {
                s_ImplDic.Add(type,Utility.Reflection.New(type) as IKeyValueStorage);
            }
            return s_ImplDic[type];
        }
    }
}
