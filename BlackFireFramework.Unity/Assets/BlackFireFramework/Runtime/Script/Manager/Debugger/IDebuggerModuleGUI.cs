//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



namespace BlackFireFramework
{
    /// <summary>
    /// 模块的GUI渲染接口。
    /// </summary>
    public interface IDebuggerModuleGUI 
	{
          
        /// <summary>
        /// 模块的名字。
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// 模块的GUI被绘制事件。
        /// </summary>
        /// <param name="debuggerManager">调试器管家。</param>
        void OnModuleGUI(DebuggerManager debuggerManager);

	}
}
