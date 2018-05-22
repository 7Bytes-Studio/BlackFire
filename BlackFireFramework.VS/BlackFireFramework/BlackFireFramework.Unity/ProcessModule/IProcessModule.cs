namespace BlackFireFramework.Unity
{
    public interface IProcessModule:IModule
    {
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