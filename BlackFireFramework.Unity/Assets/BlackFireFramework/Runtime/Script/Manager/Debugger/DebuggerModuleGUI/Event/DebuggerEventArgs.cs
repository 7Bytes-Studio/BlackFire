//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 调试器参数。
    /// </summary>
    public sealed class DebuggerEventArgs : EventArgs 
	{
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="args"></param>
        public DebuggerEventArgs(params object[] args)
        {
            Args = args;
        }

        /// <summary>
        /// 传递给内部方法的多个参数。
        /// </summary>
        public object[] Args { get; private set; }

	}
}
