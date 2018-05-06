//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// 框架时间类。
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
