//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;


namespace BlackFireFramework.Network
{
    /// <summary>
    /// 下载器抽象基类。
    /// </summary>
	public abstract class DownloadBase : EntityTreeNode
	{
        public DownloadBase() : base(new UserData(string.Empty))
        {

        }

        /// <summary>
        /// 下载成功事件。
        /// </summary>
        public abstract event EventHandler OnDownloadSucceeded;
        /// <summary>
        /// 下载失败事件。
        /// </summary>
        public abstract event EventHandler<DownloadFailureEventArgs> OnDownloadFailure;
        /// <summary>
        /// 下载进度事件。
        /// </summary>
        public abstract event EventHandler<DownloadProgressEventArgs> OnDownloadProgress;


        /// <summary>
        /// 是否下载完毕。
        /// </summary>
        public abstract bool IsDone { get; }

        /// <summary>
        /// 下载进度。
        /// </summary>
        public abstract float DownloadProgress { get; }
       
        /// <summary>
        /// 下载的真实文件大小。
        /// </summary>
        public abstract long DownloadRealSize{ get; }

        /// <summary>
        /// 本次请求下载的真实文件内容的大小。
        /// </summary>
        public abstract long DownloadRealContentSize { get; }

        /// <summary>
        /// 下载的文件内容的大小。
        /// </summary>
        public abstract long DownloadContentSize { get; }

        /// <summary>
        /// 下载文件时端点续传的起始点。
        /// </summary>
        public abstract long DownloadPosition { get; }


        /// <summary>
        /// 开启下载。
        /// </summary>
        /// <param name="url">统一资源定位符。</param>
        /// <param name="savePath">本地保存的路径。</param>
        /// <param name="contentSize">下载内容大小。</param>
        public abstract void Start(string url,string savePath,long contentSize);

        /// <summary>
        /// 关闭下载。
        /// </summary>
        public abstract void Stop();

    }
}
