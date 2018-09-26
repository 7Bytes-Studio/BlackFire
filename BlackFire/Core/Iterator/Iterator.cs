/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BlackFire
{
    
    /// <summary>
    /// 框架迭代程序管理静态类。
    /// </summary>
    public static partial class Iterator
    {

        private static IteratorStartCallback s_IteratorStartCallback;
        private static IteratorCancelCallback s_IteratorCancelCallback;

        /// <summary>
        /// 所有的迭代器名字集合。
        /// </summary>
        public static IEnumerable<string> AllIteratorNames
        {
            get { return s_Dic.Keys; }
        }

        /// <summary>
        /// 迭代器启动回调。
        /// </summary>
        public static IteratorStartCallback IteratorStartCallback
        {
            get { return s_IteratorStartCallback; }
            set { s_IteratorStartCallback = value; }
        }

        /// <summary>
        /// 迭代器取消回调。
        /// </summary>
        public static IteratorCancelCallback IteratorCancelCallback
        {
            get { return s_IteratorCancelCallback; }
            set { s_IteratorCancelCallback = value; }
        }

        private static Dictionary<string,IEnumerator> s_Dic = new Dictionary<string, IEnumerator>();

        
        /// <summary>
        /// 是否存在迭代器>
        /// </summary>
        /// <param name="name">迭代器名字。</param>
        /// <returns>是否存在。</returns>
        public static bool HasIterator(string name)
        {
            return s_Dic.ContainsKey(name);
        }


        /// <summary>
        /// 启动迭代器。
        /// </summary>
        /// <param name="name">迭代器名字。</param>
        /// <param name="enumerator">迭代器接口。</param>
        /// <returns>是否已经启动了此迭代器。</returns>
        public static bool Start(string name, IEnumerator enumerator)
        {
            if (!s_Dic.ContainsKey(name))
            {
                s_Dic.Add(name,enumerator);
                s_IteratorStartCallback.Invoke(name,enumerator);
                return true;
            }
            return false;
        }

        
        /// <summary>
        /// 取消迭代器。
        /// </summary>
        /// <param name="name">迭代器名字。</param>
        public static void Cancel(string name)
        {
            if (s_Dic.ContainsKey(name))
            {
                var enumerator = s_Dic[name];
                s_Dic.Remove(name);
                s_IteratorCancelCallback.Invoke(name,enumerator);
            }
        }
    }
}