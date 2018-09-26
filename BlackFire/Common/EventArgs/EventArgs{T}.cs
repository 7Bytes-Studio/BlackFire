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
    /// 只带传递一个参数的事件参数。
    /// </summary>
    /// <typeparam name="T">目标参数类型。</typeparam>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T arg)
        {
            Arg = arg;
        }

        /// <summary>
        /// 参数。
        /// </summary>
        public T Arg { get; private set; }

    }
}
