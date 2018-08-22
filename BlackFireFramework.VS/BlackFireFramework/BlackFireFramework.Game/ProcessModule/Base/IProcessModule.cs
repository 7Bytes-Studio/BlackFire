//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Game
{
    public interface IProcessModule:IModule
    {

        /// <summary>
        /// 第一个启动流程。
        /// </summary>
        ProcessBase BootProcess { get; }

        /// <summary>
        /// 当前的活动流程。
        /// </summary>
        ProcessBase CurrentProcess { get; }

        /// <summary>
        /// 上一个活动流程。
        /// </summary>
        ProcessBase LastProcess { get; }
        
        /// <summary>
        /// 添加流程。
        /// </summary>
        /// <param name="process">流程实例。</param>
        void AddProcess(ProcessBase process);

        /// <summary>
        /// 启动第一个流程。
        /// </summary>
        void StartFirstProcess();

        /// <summary>
        /// 获取所有的流程实例。
        /// </summary>
        /// <returns>流程实例数组。</returns>
        ProcessBase[] GetProcesses();
    }
}