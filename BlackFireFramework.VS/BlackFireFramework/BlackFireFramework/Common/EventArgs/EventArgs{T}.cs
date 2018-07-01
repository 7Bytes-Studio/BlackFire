using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackFireFramework
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
        public T Arg { get; }

    }
}
