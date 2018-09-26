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
    /// <summary>
    /// 框架状态。
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
