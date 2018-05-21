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
	public interface IDebuggerPackUp
    {
        /// <summary>
        /// 事件接口排序的优先级。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 事件回调接口。
        /// </summary>
        /// <param name="debuggerManager">调试器管家实例。</param>
        /// <returns>PackUp条件结果。</returns>
        bool PackUp(DebuggerManager debuggerManager);

    }
}
