//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 下载任务信息类。
    /// </summary>
    public sealed class DownloadTaskInfo
    {
        public DownloadTaskInfo(string taskName, string url, string savePath, Type useDownloadImplType,long contentSize, EventHandler onDownloadSucceeded = null, EventHandler<DownloadProgressEventArgs> onDownloadProgress = null, EventHandler<DownloadFailureEventArgs> onDownloadFailure=null)
        {
            TaskName = taskName;
            Url = url;
            SavePath = savePath;
            ContentSize = contentSize;
            UseDownloadImplType = useDownloadImplType;
            OnDownloadSucceeded = onDownloadSucceeded;
            OnDownloadFailure = onDownloadFailure;
            OnDownloadProgress = onDownloadProgress;
        }

        /// <summary>
        /// 下载任务的任务名。
        /// </summary>
        public string TaskName { get; private set; }

        /// <summary>
        /// 统一资源定位符。
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 下载保存的路径。
        /// </summary>
        public string SavePath { get; private set; }

        /// <summary>
        /// 下载的目标内容大小。
        /// </summary>
        public long ContentSize { get; private set; }



        /// <summary>
        /// 下载时使用的下载器类型。
        /// </summary>
        public Type UseDownloadImplType { get; private set; }



        /// <summary>
        /// 下载器实例。
        /// </summary>
        internal DownloadBase Download { get; set; }

        /// <summary>
        /// 下载成功回调。
        /// </summary>
        public EventHandler OnDownloadSucceeded { get; private set; }
        /// <summary>
        /// 下载失败回调。
        /// </summary>
        public EventHandler<DownloadFailureEventArgs> OnDownloadFailure { get; private set; }
        /// <summary>
        /// 下载进度回调。
        /// </summary>
        public EventHandler<DownloadProgressEventArgs> OnDownloadProgress { get; private set; }

    }
}
