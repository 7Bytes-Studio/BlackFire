//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Network;
using System;
using UnityEngine.Networking;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 使用HTTP协议的大文件下载器（支持断点续传）。
    /// </summary>
    public sealed class DownloadHttpBigFile : DownloadBase
    {
        public override event EventHandler OnDownloadSucceeded;
        public override event EventHandler<DownloadFailureEventArgs> OnDownloadFailure;
        public override event EventHandler<DownloadProgressEventArgs> OnDownloadProgress;


        private DownloadHandlerBigFile m_DownloadHandlerBigFile = null;
        private UnityWebRequestAsyncOperation m_UnityWebRequestAsyncOperation = null;


        public override float DownloadProgress
        {
            get
            {
                return null== m_DownloadHandlerBigFile ? 0: m_DownloadHandlerBigFile.Progress;
            }
        }

        public override long DownloadRealSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.CurrentPosition;
            }
        }

        public override long DownloadContentSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.ContentLength;
            }
        }

        public override long DownloadPosition
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.Position;
            }
        }

        public override long DownloadRealContentSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.RealContentLength;
            }
        }

        public override bool IsDone
        {
            get
            {
                return null!=m_UnityWebRequestAsyncOperation ? m_UnityWebRequestAsyncOperation.webRequest.isDone:false;
            }
        }

        protected override void OnAct()
        {
            base.OnAct();

            //轮询检测错误通知。
            if (!m_HasStop && null != m_UnityWebRequestAsyncOperation && !m_UnityWebRequestAsyncOperation.isDone && m_UnityWebRequestAsyncOperation.webRequest.isNetworkError)
            {
                FireDownloadFailureEvent(DownloadErrorCode.ServerResponse, m_UnityWebRequestAsyncOperation.webRequest.error);
            }

            if (!m_HasStop && m_UnityWebRequestAsyncOperation.isDone) //轮询检测下载完毕事件。
            {
                if (null != OnDownloadSucceeded)
                {
                    OnDownloadSucceeded.Invoke(this, EventArgs.Empty);
                }
                Stop();
            }

            if (null != m_UnityWebRequestAsyncOperation && !m_UnityWebRequestAsyncOperation.isDone)//轮询通知下载进度。
            {
                if (null != OnDownloadProgress)
                {
                    OnDownloadProgress.Invoke(this, new DownloadProgressEventArgs(DownloadPosition, DownloadRealContentSize, DownloadRealSize, DownloadContentSize, DownloadProgress));
                }
            }

        }

        protected override void OnDie()
        {
            base.OnDie();
            Stop();
        }

        public override void Start(string url,string localPath,long contentSize)
        {
            if (!m_HasStop)
            {
                throw new Exception("Do not start again before closing.");
            }
            else
            {
                try
                {
                    m_DownloadHandlerBigFile = new DownloadHandlerBigFile(localPath,contentSize);
                }
                catch (Exception ex)
                {
                    FireDownloadFailureEvent(DownloadErrorCode.FileIOException, ex.Message);
                    throw ex;
                }

                //Log.Info("文件已经下载好了   "+m_DownloadHandlerBigFile.HasDownloadComplete);

                if (m_DownloadHandlerBigFile.HasDownloadComplete) //文件已经下载好了。
                {
                    if (null != OnDownloadProgress)
                    {
                        OnDownloadProgress.Invoke(this, new DownloadProgressEventArgs(DownloadPosition, DownloadRealContentSize, DownloadRealSize, DownloadContentSize, DownloadProgress));
                    }
                    if (null != OnDownloadSucceeded)
                    {
                        OnDownloadSucceeded.Invoke(this, EventArgs.Empty);
                    }
                    return;
                }

                var uwr = new UnityWebRequest(url);
                uwr.method = UnityWebRequest.kHttpVerbGET;
                uwr.downloadHandler = m_DownloadHandlerBigFile;
                uwr.disposeDownloadHandlerOnDispose = true;
                uwr.SetRequestHeader("range", "bytes=" + m_DownloadHandlerBigFile.Position + "-");
                m_UnityWebRequestAsyncOperation = uwr.SendWebRequest();

                m_HasStop = false;
            }


        }

        private bool m_HasStop=true;
        public override void Stop()
        {
            if (m_HasStop)
            {
                return;
            }
            else
            {
                m_DownloadHandlerBigFile.Close();
                m_DownloadHandlerBigFile = null;

                if (!m_UnityWebRequestAsyncOperation.webRequest.isDone && !m_UnityWebRequestAsyncOperation.webRequest.isNetworkError)
                    FireDownloadFailureEvent(DownloadErrorCode.Stopped);

                m_UnityWebRequestAsyncOperation.webRequest.Dispose();
                m_UnityWebRequestAsyncOperation = null;

                m_HasStop = true;
            }
        }

        private void FireDownloadFailureEvent(DownloadErrorCode downloadErrorCode,string errorMessage=null)
        {
            if (null != OnDownloadFailure)
            {
                OnDownloadFailure.Invoke(this, new DownloadFailureEventArgs(downloadErrorCode, errorMessage));
            }
        }

    }
}
