//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {
        /// <summary>
        /// 解决唯一性类问题的帮助类。
        /// </summary>
        public static class Unique
        {
            #region String <=> Id


            private static Dictionary<string, int> s_IdDic = new Dictionary<string, int>();

            private static readonly object s_Lock = new object();

            private static int s_CurrentId = 999;

            public static int GetId(string text)
            {
                if (!s_IdDic.ContainsKey(text))
                {
                    lock (s_Lock)
                    {
                        s_IdDic.Add(text, s_CurrentId++);
                    }
                }
                return s_IdDic[text];
            }

            public static string GetText(int id)
            {
                foreach (var kv in s_IdDic)
                {
                    if (kv.Value==id)
                    {
                        return kv.Key;
                    }
                }
                return string.Empty;
            }

            #endregion

        }

    }
}
