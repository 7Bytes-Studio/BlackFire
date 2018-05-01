//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.IO;
using System.Net;

namespace BlackFireFramework.Editor
{
    public sealed class HttpDownloader
    {
        private HttpDownloadInfo m_HttpDownloadInfo;
        private long m_Position;
        private FileStream m_FileStream;
        private bool m_HasStop;

        public event EventHandler OnDownloadSuccess;
        public event EventHandler OnDownloadFailure;
        public event EventHandler<HttpDownloaderProgressEventArgs> OnDownloadProgress;

        public HttpDownloader(HttpDownloadInfo httpDownloadInfo)
        {
            m_HttpDownloadInfo = httpDownloadInfo;
            DownloadFileCheck();
        }

        public void StartDownload()
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(m_HttpDownloadInfo.Url);

                if (0L < m_Position)
                {
                    httpWebRequest.AddRange((int)m_Position);
                }

                WebResponse webResponse = httpWebRequest.GetResponse();
                Stream webResponseStream = webResponse.GetResponseStream();

                float progress = 0f;
                long currentSize = m_Position;
                long totalSize = m_Position + webResponse.ContentLength;

                byte[] btContent = new byte[m_HttpDownloadInfo.DownloadBufferUnit];
                int readSize = 0;
                while (!m_HasStop && 0 < (readSize = webResponseStream.Read(btContent, 0, m_HttpDownloadInfo.DownloadBufferUnit)))
                {
                    progress = (float)(currentSize += readSize) / totalSize;
                    if (null != OnDownloadProgress)
                    {
                        OnDownloadProgress.Invoke(this,new HttpDownloaderProgressEventArgs(progress));
                    }
                    m_FileStream.Flush();
                    m_FileStream.Write(btContent, 0, readSize);

                    System.Threading.Thread.Sleep(10);

                }
                m_FileStream.Close();
                webResponseStream.Close();

                if (!m_HasStop)
                {
                    ReNameTempFile();

                    if (null != OnDownloadSuccess)
                    {
                        OnDownloadSuccess.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                if (null != OnDownloadFailure)
                {
                    OnDownloadFailure.Invoke(this, EventArgs.Empty);
                }
                throw ex;
            }
        }


        public void StopDownload()
        {
            m_HasStop = true;
        }

        private void DownloadFileCheck()
        {
            var tmpFileName = m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension;
            if (File.Exists(tmpFileName))
            {
                m_FileStream = File.OpenWrite(tmpFileName);
                m_Position = m_FileStream.Length;
                m_FileStream.Seek(m_Position, SeekOrigin.Current);
            }
            else
            {
                m_FileStream = new FileStream(tmpFileName, FileMode.Create);
                m_Position = 0L;
            }
        }

        private void ReNameTempFile()
        {
            if (File.Exists(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension))
            {
                if (File.Exists(m_HttpDownloadInfo.SavePath))
                {
                    File.Delete(m_HttpDownloadInfo.SavePath);
                }

                FileInfo fileInfo = new FileInfo(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension);
                fileInfo.MoveTo(m_HttpDownloadInfo.SavePath);
                //File.Move(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension, m_HttpDownloadInfo.SavePath);
            }
        }

    }

}
