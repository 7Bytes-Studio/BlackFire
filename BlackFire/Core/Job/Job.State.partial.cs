/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    public static partial class Job
    {
        /// <summary>
        /// Job的状态类。
        /// </summary>
        public sealed class JobState
        {
            /// <summary>
            /// 异步状态量。
            /// </summary>
            public object State { get; internal set; }

            /// <summary>
            /// Job运行的Token，用于代表线程信号量。
            /// </summary>
            public Token Token { get; internal set; }

            /// <summary>
            /// 同步状态量。
            /// </summary>
            public object SyncState { get; set; }
        }
    }
}
