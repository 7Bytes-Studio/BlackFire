//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 支持大文件断点续传的下载处理器。
    /// </summary>
    public class DownloadHandlerBigFile : DownloadHandlerScript
    {
        protected FileStream m_FileStream = null;
        private long m_Position;
        private long m_ContentLength;
        private long m_Addition;

        /// <summary>
        /// 下载断点续传起始点。
        /// </summary>
        public long Position { get { return m_Position; } }

        /// <summary>
        /// 本次真实下载总内容长度。
        /// </summary>
        public long RealContentLength { get { return m_ContentLength - m_Position; } }

        /// <summary>
        /// 下载总内容长度。
        /// </summary>
        public long ContentLength { get { return m_ContentLength; } }

        /// <summary>
        /// 当前的传输点。
        /// </summary>
        public long CurrentPosition { get { return m_Position + m_Addition; } }


        /// <summary>
        /// 进度。
        /// </summary>
        public float Progress { get { return (float)CurrentPosition / ContentLength; } }

        /// <summary>
        /// 是否已经是下载完毕了的。
        /// </summary>
        public bool HasDownloadComplete { get; private set; }


        /// <summary>
        /// 构造方法。
        /// </summary>
        public DownloadHandlerBigFile(string localPath,long contentSize)
        {
            m_ContentLength = contentSize;
            DownloadFileCheck(localPath);
        }

        protected override void CompleteContent()
        {
            m_FileStream.Close();
        }

        protected override bool ReceiveData(byte[] data, int dataLength)
        {
            if (!HasDownloadComplete)
            {
                m_FileStream.Flush();
                m_FileStream.Write(data, 0, dataLength);
                m_Addition += dataLength;
            }

            return base.ReceiveData(data, dataLength);
        }


        private bool m_HasClose = false;
        public virtual void Close()
        {
            if (!m_HasClose)
            {
                m_FileStream.Close();
                m_HasClose = true;
            }
        }

        #region Private

        private void DownloadFileCheck(string path)
        {
            if (File.Exists(path))
            {
                m_FileStream = File.OpenWrite(path);
                m_Position = m_FileStream.Length;
                m_FileStream.Seek(m_Position, SeekOrigin.Current);
                HasDownloadComplete = m_Position == m_ContentLength;
                // Debug.Log(m_Position+ "  " + m_ContentLength + "  "+ HasDownloadComplete);
                if (HasDownloadComplete)
                {
                    m_FileStream.Close();
                }
            }
            else
            {
                m_FileStream = new FileStream(path, FileMode.Create);
                m_Position = 0L;
            }
        }

        #endregion

    }
}
