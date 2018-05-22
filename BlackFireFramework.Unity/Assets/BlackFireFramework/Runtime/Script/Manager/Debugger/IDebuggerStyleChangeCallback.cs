//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    /// <summary>
    /// Debugger 由Full模式收起到Mini模式的事件接口。
    /// </summary>
	public interface IDebuggerStyleChangeCallback
    {
        /// <summary>
        /// 事件接口排序的优先级。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 事件回调接口。
        /// </summary>
        /// <param name="debuggerManager">调试器管家实例。</param>
        /// <returns>FullStyl PackUp条件结果。</returns>
        bool FullStylePredicate(DebuggerManager debuggerManager);

        /// <summary>
        /// 事件回调接口。
        /// </summary>
        /// <param name="debuggerManager">调试器管家实例。</param>
        /// <returns>MiniStyle PackUp条件结果。</returns>
        bool MiniStylePredicate(DebuggerManager debuggerManager);

        /// <summary>
        /// 事件回调接口。
        /// </summary>
        /// <param name="debuggerManager">调试器管家实例。</param>
        /// <returns>HiddenStyle PackUp条件结果。</returns>
        bool HiddenStylePredicate(DebuggerManager debuggerManager);

    }
}
