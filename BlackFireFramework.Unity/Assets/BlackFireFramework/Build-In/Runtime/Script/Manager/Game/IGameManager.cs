using BlackFireFramework.Game;

namespace BlackFireFramework.Unity
{
    public interface IGameManager:IManager
    {
        /// <summary>
        /// 获取或设置是否禁止休眠。
        /// </summary>
        bool NeverSleep { get; set; }

        /// <summary>
        /// 设置游戏运行速度。
        /// </summary>
        float GameSpeed { get; set; }

        /// <summary>
        /// 设置游戏以指定的帧率运行(ps:这个设定会受垂直同步影响，如果设置了垂直同步，那么就会抛弃这个设定而根据屏幕硬件的刷新速度来运行)。
        /// </summary>
        int Fps { get; set; }

        bool RunInBackground { get; set; }

        /// <summary>
        /// 游戏启动的第一个流程。
        /// </summary>
        string FirstProcess { get; }

        /// <summary>
        /// 有效的游戏流程类型全名字符串数组。
        /// </summary>
        string[] AvailableProcesses { get; }

        /// <summary>
        /// 全部的游戏流程类型全名字符串数组。
        /// </summary>
        string[] AllProcesses { get; }

        bool StartFirstProcessWhenInitialized { get; set; }

        /// <summary>
        /// 添加游戏流程。
        /// </summary>
        /// <param name="process">流程。</param>
        void AddProcess(ProcessBase process);

        /// <summary>
        /// 启动第一个游戏流程。
        /// </summary>
        void StartFirstProcess();

        /// <summary>
        /// 获取所有的流程实例。
        /// </summary>
        /// <returns>所有流程实例数组。</returns>
        ProcessBase[] GetProcesses();
    }
}