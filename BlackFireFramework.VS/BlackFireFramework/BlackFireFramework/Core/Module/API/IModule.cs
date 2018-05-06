//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// 模块接口。(天梯式用法)
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 模块是否在工作状态。
        /// </summary>
        bool IsWorking { get; }

        /// <summary>
        /// 唤醒模块。
        /// </summary>
        void Resume();

        /// <summary>
        /// 挂起模块。
        /// </summary>
        void Suspend();
    }
}
