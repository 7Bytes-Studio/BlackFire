//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
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
