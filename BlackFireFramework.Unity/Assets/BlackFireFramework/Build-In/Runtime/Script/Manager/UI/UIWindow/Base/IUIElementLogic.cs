//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public delegate void WindowHandleCallback<T>(T i) where T : IUIEventHandler;

    /// <summary>
    /// 窗口的UI元素的逻辑接口类。
    /// </summary>
    public interface IUIElementLogic : ILogic
    {
        /// <summary>
        /// 冒泡事件。
        /// </summary>
        void BubblingEvent<T>(WindowHandleCallback<T> handleCallback) where T : IUIEventHandler;
    }
}
