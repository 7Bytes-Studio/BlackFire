//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// LoopComponent扩展类。
    /// </summary>
    public static class ILoopManagerExtension
	{
        public static void Register(this ILoopManager loop, Action callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType,name);
        }

        #region 测试
        //Not often used ... 

        public static void Register(this ILoopManager loop, Action<int> callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType, name);
        }

        public static void Register(this ILoopManager loop, Action<int, int> callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType, name);
        }

        //Not often used ...
        #endregion

    }
}
