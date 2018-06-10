//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public sealed partial class NetworkManager
    {
        public DownloadTaskInfo GetDownloadTask(string taskName)
        {
           return m_DownloadModule.GetDownloadTask(taskName);
        }

        public bool HasTaskDone(string taskName)
        {
            return m_DownloadModule.HasTaskDone(taskName);
        }


        public void StartDownloadTask(DownloadTaskInfo downloadTaskInfo)
        {
            m_DownloadModule.StartDownloadTask(downloadTaskInfo);
        }

        public void StopDownloadTask(string taskName)
        {
            m_DownloadModule.StopDownloadTask(taskName);
        }
    }
}
