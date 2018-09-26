/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire
{
    /// <summary>
    /// 框架全局数据。
    /// </summary>
    public static partial class Framework
    {

        internal static FrameworkGlobalData s_GlobalData = new FrameworkGlobalData();

        /// <summary>
        /// 框架内部的全局数据。
        /// </summary>
        internal static FrameworkGlobalData GlobalData { get { return s_GlobalData; } }


        /// <summary>
        /// 时间类。
        /// </summary>
        public sealed class FrameworkGlobalData
        {

            private Dictionary<string, object> m_DictionaryGlobalData = new Dictionary<string, object>();

            public object this[string key]
            {
                get
                {
                    if (m_DictionaryGlobalData.ContainsKey(key))
                    {
                        return m_DictionaryGlobalData[key];
                    }
                    return null;
                }

                set
                {
                    if (!m_DictionaryGlobalData.ContainsKey(key))
                    {
                        m_DictionaryGlobalData.Add(key, value);
                    }
                    else
                    {
                        m_DictionaryGlobalData[key] = value;
                    }
                }
            }

        }
    }
}
