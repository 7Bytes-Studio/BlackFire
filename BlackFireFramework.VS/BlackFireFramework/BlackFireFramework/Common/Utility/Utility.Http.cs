using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Linq;
using System.Net.Cache;

namespace BlackFireFramework
{
    public static partial class Utility
    {
        /// <summary>
        /// Http连接操作帮助类
        /// </summary>
        public static class Http
        {
            /// <summary>
            /// HTTP协议的POST方法。
            /// </summary>
            /// <param name="Url">POST的目标地址。</param>
            /// <param name="postDataStr">提交的POST数据。</param>
            /// <param name="cookieContainer">Cookie容器。</param>
            /// <returns>同步返回的服务器响应字符串。</returns>
            public static string Post(string Url, string postDataStr, CookieContainer cookieContainer = null)
            {
                cookieContainer = cookieContainer ?? new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                request.CookieContainer = cookieContainer;
                Stream myRequestStream = request.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }

            /// <summary>
            /// HTTP协议的GET方法。
            /// </summary>
            /// <param name="Url">GET的目标地址</param>
            /// <param name="gettDataStr">提交的GET数据。</param>
            /// <returns>同步返回的服务器响应字符串。</returns>
            public static string Get(string Url, string gettDataStr)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (gettDataStr == "" ? "" : "?") + gettDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }

            /// <summary>
            /// HTTP协议支持断点续传的文件下载。
            /// </summary>
            /// <param name="httpDownloadInfo">下载器必需的参数。</param>
            /// <returns>HTTP下载器。</returns>
            public static HttpDownloader DownLoad(HttpDownloadInfo httpDownloadInfo)
            {
                var httpDownloader = new HttpDownloader(httpDownloadInfo);
                httpDownloader.StartDownload();
                return httpDownloader;
            }


            /// <summary>
            /// HTTP协议支持断点续传的文件下载器。
            /// </summary>
            public sealed class HttpDownloader
            {
                private HttpDownloadInfo m_HttpDownloadInfo;
                private long m_Position;
                private FileStream m_FileStream;
                private bool m_HasStop;

                public event EventHandler OnDownloadSuccess;
                public event EventHandler<HttpDownloaderFailureEventArgs> OnDownloadFailure;
                public event EventHandler<HttpDownloaderProgressEventArgs> OnDownloadProgress;

                /// <summary>
                /// 构造方法。
                /// </summary>
                /// <param name="httpDownloadInfo">HTTP下载信息。</param>
                internal HttpDownloader(HttpDownloadInfo httpDownloadInfo)
                {
                    m_HttpDownloadInfo = httpDownloadInfo;
                    DownloadFileCheck();
                }

                /// <summary>
                /// 开启下载。
                /// </summary>
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
                                OnDownloadProgress.Invoke(this, new HttpDownloaderProgressEventArgs(progress));
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
                            OnDownloadFailure.Invoke(this,new HttpDownloaderFailureEventArgs(ex));
                        }
                        throw ex;
                    }
                }

                /// <summary>
                /// 停止下载。
                /// </summary>
                public void StopDownload()
                {
                    m_HasStop = true;
                }

                private void DownloadFileCheck()
                {
                    var tmpFileName = m_HttpDownloadInfo.SavePath +"."+ m_HttpDownloadInfo.TempFileExtension;
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
                    if (File.Exists(m_HttpDownloadInfo.SavePath + "." + m_HttpDownloadInfo.TempFileExtension))
                    {
                        if (File.Exists(m_HttpDownloadInfo.SavePath))
                        {
                            File.Delete(m_HttpDownloadInfo.SavePath);
                        }

                        FileInfo fileInfo = new FileInfo(m_HttpDownloadInfo.SavePath + "." + m_HttpDownloadInfo.TempFileExtension);
                        fileInfo.MoveTo(m_HttpDownloadInfo.SavePath);
                        //File.Move(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension, m_HttpDownloadInfo.SavePath);
                    }
                }

            }

            /// <summary>
            /// HTTP下载信息。
            /// </summary>
            public class HttpDownloadInfo
            {
                /// <summary>
                /// 构造方法。
                /// </summary>
                /// <param name="url">下载地址。</param>
                /// <param name="savePath">下载下来的文件保存的路径。</param>
                /// <param name="tempFileExtension">下载过程中临时保存的文件扩展名。</param>
                /// <param name="downloadBufferUnit">下载处理的缓冲区，一般与带宽有关。</param>
                /// <param name="onDownloadSuccess">下载成功的回调。</param>
                /// <param name="onDownloadFailure">下载失败的回调。</param>
                /// <param name="onDownloadProgress">下载过程的回调。</param>
                public HttpDownloadInfo(string url, string savePath, string tempFileExtension, int downloadBufferUnit, EventHandler onDownloadSuccess, EventHandler<HttpDownloaderFailureEventArgs> onDownloadFailure, EventHandler<HttpDownloaderProgressEventArgs> onDownloadProgress)
                {
                    Url = url;
                    SavePath = savePath;
                    TempFileExtension = tempFileExtension;
                    DownloadBufferUnit = downloadBufferUnit;
                    OnDownloadSuccess = onDownloadSuccess;
                    OnDownloadFailure = onDownloadFailure;
                    OnDownloadProgress = onDownloadProgress;
                }


                internal string Url;
                internal string SavePath;
                internal string TempFileExtension;
                internal int DownloadBufferUnit = 512;
                internal EventHandler OnDownloadSuccess;
                internal EventHandler<HttpDownloaderFailureEventArgs> OnDownloadFailure;
                internal EventHandler<HttpDownloaderProgressEventArgs> OnDownloadProgress;
            }

            /// <summary>
            /// HTTP下载器的Progress事件参数。
            /// </summary>
            public sealed class HttpDownloaderProgressEventArgs : EventArgs
            {
                public HttpDownloaderProgressEventArgs(float progress)
                {
                    DownloadProgress = progress;
                }

                public float DownloadProgress { get; private set; }
            }

            /// <summary>
            /// HTTP下载器的Failure事件参数。
            /// </summary>
            public sealed class HttpDownloaderFailureEventArgs : EventArgs
            {
                public HttpDownloaderFailureEventArgs(Exception ex)
                {
                    Exception = ex;
                }

                public Exception Exception { get; private set; }
            }

        }

    }
}