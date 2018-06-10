//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 下载模块。
    /// </summary>
    internal sealed class DownloadModule : ModuleBase, IDownloadModule
    {

        private LinkedList<DownloadTaskInfo> m_DownloadTaskInfoLinkedList = new LinkedList<DownloadTaskInfo>();

        public void StopDownloadTask(string taskName)
        {
            var dti = GetDownloadTask(taskName);
            if (null != dti)
            {
                dti.Download.Stop();
            }
            else
            {
                throw new System.Exception(string.Format("Can't find the target task {0}.",taskName));
            }
        }


        public DownloadTaskInfo GetDownloadTask(string taskName)
        {
            var current =m_DownloadTaskInfoLinkedList.First;
            while (null!=current)
            {
                if (current.Value.TaskName==taskName)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }


        public void StartDownloadTask(DownloadTaskInfo downloadTaskInfo)
        {
            var passCondition = null != downloadTaskInfo && 0<downloadTaskInfo.ContentSize && null != downloadTaskInfo.UseDownloadImplType && !string.IsNullOrEmpty(downloadTaskInfo.TaskName) && !string.IsNullOrEmpty(downloadTaskInfo.Url) && !string.IsNullOrEmpty(downloadTaskInfo.SavePath);
            if (!passCondition)
            {
                throw new System.Exception("Please check the 'downloadTaskInfo' parameter's validity.");
            }
            if (!Utility.Reflection.IsImplType(typeof(DownloadBase), downloadTaskInfo.UseDownloadImplType))
            {
                throw new System.Exception(string.Format("'{0}' not's the implementation class of the 'DownloadBase' class.", downloadTaskInfo.UseDownloadImplType));
            }

            var dti =GetDownloadTask(downloadTaskInfo.TaskName);

            if (null != dti)
            {
                dti.Download.Start(downloadTaskInfo.Url, downloadTaskInfo.SavePath, downloadTaskInfo.ContentSize);
            }
            else
            {
                downloadTaskInfo.Download = Utility.Reflection.New(downloadTaskInfo.UseDownloadImplType) as DownloadBase;
                downloadTaskInfo.Download.OnDownloadSucceeded += downloadTaskInfo.OnDownloadSucceeded;
                downloadTaskInfo.Download.OnDownloadProgress += downloadTaskInfo.OnDownloadProgress;
                downloadTaskInfo.Download.OnDownloadFailure += downloadTaskInfo.OnDownloadFailure;
                downloadTaskInfo.Download.Start(downloadTaskInfo.Url, downloadTaskInfo.SavePath, downloadTaskInfo.ContentSize);

                m_DownloadTaskInfoLinkedList.AddLast(downloadTaskInfo);

                AddChildNode(downloadTaskInfo.Download); //挂载任务器。
            }

 
        }


        public bool HasTaskDone(string taskName)
        {
            var dti = GetDownloadTask(taskName);
            if (null != dti)
            {
                return dti.Download.IsDone;
            }
            else
            {
                throw new System.Exception(string.Format("Can't find the target task {0}.", taskName));
            }
        }
    }
}
