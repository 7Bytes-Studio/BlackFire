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
