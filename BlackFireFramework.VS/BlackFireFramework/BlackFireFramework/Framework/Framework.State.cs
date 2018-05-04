//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// 框架。
    /// </summary>
    public static partial class Framework
    {

        private static void Init_State()
        {
            State = new FrameworkState();         
        }

        public static FrameworkState State { get; private set; }

        public sealed class FrameworkState
        {
            public bool Working { get; internal set; }
        }
    }
}
