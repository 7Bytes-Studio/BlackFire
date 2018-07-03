//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Threading;

namespace BlackFireFramework
{
    /// <summary>
    /// 框架信息。
    /// </summary>
    public static partial class Framework
    {
        private static void Init_Info()
        {
            Info = new FrameworkInfo("1.1.0_beta",Thread.CurrentThread.ManagedThreadId,s_Who);
        }


        public static FrameworkInfo Info { get; private set; }

        public sealed class FrameworkInfo
        {
            /// <summary>
            /// 构造方法。
            /// </summary>
            public FrameworkInfo(string version,int threadId,object creator)
            {
                Version = version;
                ThreadId = threadId;
                Creator = creator;
            }

            /// <summary>
            /// 框架版本。
            /// </summary>
            public string Version { get; private set; }

            /// <summary>
            /// 框架线程Id;
            /// </summary>
            public int ThreadId { get; private set; }

            /// <summary>
            /// 框架创建者。
            /// </summary>
            public object Creator { get; private set; }
        }
    }
}
