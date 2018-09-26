/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    /// <summary>
    /// Magic Utilities.
    /// </summary>
    public static partial class Utility
    {
        /// <summary>
        /// 枚举助手。
        /// </summary>
        public static class Enum
        {
            /// <summary>
            /// 遍历枚举。
            /// </summary>
            /// <typeparam name="T">枚举类型。</typeparam>
            /// <param name="foreachCallback">遍历枚举回调。</param>
            public static void Foreach<T>(Action<T> foreachCallback) where T : struct, IComparable, IFormattable, IConvertible
            {
                var arr =  System.Enum.GetValues(typeof(T));
                foreach (T item in arr)
                {
                    if (null != foreachCallback)
                    {
                        foreachCallback.Invoke(item);
                    }
                }
            }

        }

    }
}

