using System;
using System.Text;
using System.Net;
using System.IO;

namespace BlackFireFramework
{
    public static partial class Utility
    {
        /// <summary>
        /// Http连接操作帮助类。
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
                return httpDownloader;
            }

            #region HttpDownloader

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

            #endregion



            public static HttpServer CreateHttpServer(HttpServerInfo httpServerInfo)
            {
                var httpServer = new HttpServer(httpServerInfo);
                return httpServer;
            }


            #region HTTP Server

            public class HttpServerInfo
            {
                public string Ip;
                public int Port;

                public string[] Prefixes;

                public EventHandler OnStartSucceed;
                public EventHandler<StartFailureEventArgs> OnStartFailure;

                public Func<HttpListenerRequest,byte[]> GetHandler;
                public Func<HttpListenerRequest,byte[]> PostHandler;
                public Func<HttpListenerRequest, byte[]> DefaultHandler;

                public Action<HttpListenerResponse> OnBeforeResponse;
            }

            public sealed class StartFailureEventArgs : EventArgs
            {
                public StartFailureEventArgs(Exception exception)
                {
                    Exception = exception;
                }

                public Exception Exception { get; private set; }

            }

            public class LazyHttpServerInfo : HttpServerInfo
            {

                public LazyHttpServerInfo(Func<string, string> getLazyHandler, Func<string, string> postLazyHandler, Func<string, string> defaultLazyHandler)
                {


                    GetLazyHandler = getLazyHandler;
                    PostLazyHandler = postLazyHandler;
                    DefaultLazyHandler = defaultLazyHandler;


                    GetHandler = request => {
                        var handlerContent = string.Empty;
                        if (null!= GetLazyHandler)
                        {
                            handlerContent = GetLazyHandler.Invoke(request.RawUrl);
                        }
                        return Encoding.UTF8.GetBytes(handlerContent);
                    };

                    PostHandler = request => {
                        var handlerContent = string.Empty;
                        if (null != PostLazyHandler)
                        {
                            using (StreamReader getPostParam = new StreamReader(request.InputStream, true))
                            {
                                var postData = getPostParam.ReadToEnd();
                                handlerContent = PostLazyHandler.Invoke(postData);
                            }
                        }
                        return Encoding.UTF8.GetBytes(handlerContent);
                    };

                    DefaultHandler = request => {
                        var handlerContent = string.Empty;
                        if (null != DefaultLazyHandler)
                        {
                            handlerContent = DefaultLazyHandler.Invoke(request.RawUrl);
                        }
                        return Encoding.UTF8.GetBytes(handlerContent);
                    };




                }

                public Func<string,string> GetLazyHandler;
                public Func<string,string> PostLazyHandler;
                public Func<string, string> DefaultLazyHandler;
            }



            public class HttpServer
            {
                private HttpServerInfo m_HttpServerInfo = null;

                public bool IsWorking { get; private set; }

                public string Ip { get; private set; }
                public int Port { get; private set; }

                public string Address { get; private set; }



                public string[] Prefixes { get; private set; }


                /// <summary>
                /// 监听器
                /// </summary>
                private HttpListener m_HttpListener;


                public HttpServer(HttpServerInfo httpServerInfo)
                {
                    if (null== httpServerInfo)
                    {
                        throw new ArgumentNullException(string.Format("构造方法的参数:{0}不能为空。", "httpServerInfo"));
                    }
                    m_HttpServerInfo = httpServerInfo;
                    Ip = httpServerInfo.Ip;
                    Port = httpServerInfo.Port;
                    Address = string.Format("{0}:{1}", @"http://"+ Ip, Port);
                    Prefixes = httpServerInfo.Prefixes;
                }


                public void Start()
                {
                    if (IsWorking) return;

                    try
                    {
                        m_HttpListener = new HttpListener();
                        //监听的路径
                        m_HttpListener.Prefixes.Add(Address + "/");
                        for (int i = 0; i < Prefixes.Length; i++)
                        {
                            m_HttpListener.Prefixes.Add(Prefixes[i]);
                        }
                        //设置匿名访问
                        m_HttpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                        m_HttpListener.Start();

                        if (null != m_HttpServerInfo.OnStartSucceed)
                        {
                            m_HttpServerInfo.OnStartSucceed.Invoke(this, EventArgs.Empty);
                        }

                        IsWorking = true;



                        while (IsWorking)
                        {
                            var context = m_HttpListener.GetContext();
                            HttpListenerRequest request = context.Request;
                            HttpListenerResponse response = context.Response;
                            response.ContentEncoding = Encoding.UTF8;
                            response.AddHeader("Access-Control-Allow-Origin", "*"); //允许跨域请求。

                            byte[] handleContent = null;
                            if (request.HttpMethod == "GET")
                            {
                                if (null != m_HttpServerInfo.GetHandler)
                                {
                                    handleContent = m_HttpServerInfo.GetHandler.Invoke(request);
                                }

                            }
                            else if (request.HttpMethod == "POST")
                            {
                                if (null != m_HttpServerInfo.PostHandler)
                                {
                                    handleContent = m_HttpServerInfo.PostHandler.Invoke(request);
                                }
                            }
                            else
                            {
                                if (null != m_HttpServerInfo.DefaultHandler)
                                {
                                    handleContent = m_HttpServerInfo.DefaultHandler.Invoke(request);
                                }
                            }

                            if (null!= m_HttpServerInfo.OnBeforeResponse)
                            {
                                m_HttpServerInfo.OnBeforeResponse.Invoke(response);
                            }

                            response.ContentLength64 = handleContent.Length;
                            Stream output = response.OutputStream;
                            output.Write(handleContent, 0, handleContent.Length);
                            output.Close();
                        }

                        m_HttpListener.Close();
                        m_HttpListener.Abort();
                    }
                    catch (Exception ex)
                    {
                        IsWorking = false;
                        if (null != m_HttpServerInfo.OnStartFailure)
                        {
                            m_HttpServerInfo.OnStartFailure.Invoke(this,new StartFailureEventArgs(ex));
                        }
                    }








                }

                public void Close()
                {
                    IsWorking = false;
                }

            }


            #endregion



        }

    }
}