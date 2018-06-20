//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------




namespace BlackFireFramework.Unity
{
    /// <summary>
    /// Debugger模块的GUI渲染接口。
    /// </summary>
    public interface IDebuggerModuleGUI
    {
        /// <summary>
        /// 在调试器上被绘制的优先级。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Debugger模块的名字。
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Debugger模块初始化事件。
        /// </summary>
        /// <param name="debuggerManager"></param>
        void OnInit(DebuggerManager debuggerManager);

        /// <summary>
        /// Debugger模块的GUI被绘制事件。
        /// </summary>
        /// <param name="debuggerManager">调试器管家。</param>
        void OnModuleGUI();

        /// <summary>
        /// Debugger模块被销毁事件。
        /// </summary>
        void OnDestroy();

    }




}
