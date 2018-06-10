//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 下载任务模块。
    /// </summary>
    public interface IDownloadModule : IModule
    {
        /// <summary>
        /// 任务是否已经完成。
        /// </summary>
        /// <param name="taskName">任务名字。</param>
        /// <returns>是否完成。</returns>
        bool HasTaskDone(string taskName);

        /// <summary>
        /// 启动一个下载任务。
        /// </summary>
        /// <param name="downloadTaskInfo">下载任务的信息。</param>
        void StartDownloadTask(DownloadTaskInfo downloadTaskInfo);

        /// <summary>
        /// 关闭目标下载任务。
        /// </summary>
        /// <param name="taskName">任务名字。</param>
        void StopDownloadTask(string taskName);

        /// <summary>
        /// 获取目标任务信息。
        /// </summary>
        /// <param name="taskName">任务名字。</param>
        DownloadTaskInfo GetDownloadTask(string taskName);
    }
}