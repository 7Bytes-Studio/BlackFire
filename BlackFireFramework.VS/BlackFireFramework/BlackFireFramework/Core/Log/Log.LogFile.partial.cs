//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackFireFramework
{
    /// <summary>
    /// 日志类。
    /// </summary>
    public static partial class Log
    {

        public static void SetLogFileMode(string logFilePath,int writePeriod)
        {
            s_LogFilePath = logFilePath;
            if (!string.IsNullOrEmpty(s_LogFilePath))
            {
                if (!File.Exists(s_LogFilePath))
                {
                    File.Create(s_LogFilePath);
                }            
            }
            else
            {
                return;
            }

            s_WritePeriod = writePeriod;
            if (0 >= s_WritePeriod)
            {
                throw new System.ArgumentException("'writePeriod'不能小于0。推荐数值为5000（即5s）");
            }

            s_LogFileMode = true;
            CuttingLine();
            s_Timer = new System.Threading.Timer(TimerCallback, null, 0, s_WritePeriod);

        }

        private static bool s_LogFileMode = false;

        private static string s_LogFilePath = string.Empty;

        private static int s_WritePeriod = 5000;

        private static System.Threading.Timer s_Timer = null;

        private static Queue<string> s_QueueLogToFileString = new Queue<string>();

        private static void CuttingLine()
        {
            string logMessage = string.Format(":::::::::::::::::::::::::::::::::[ {0} ]:::::::::::::::::::::::::::::::\r\n", System.DateTime.Now.ToLongDateString());
            EnLogFileQueue(logMessage);
            WritelogQueueToLogFile();

        }

        private static void TimerCallback(object state)
        {
            WritelogQueueToLogFile();
        }

        /// <summary>
        /// 把日志消息排入日志文件代写队列（如果未设置日志文件模式则无效）。
        /// </summary>
        /// <param name="logMessage">日志消息。</param>
        public static void EnLogFileQueue(string logMessage)
        {
            if (s_LogFileMode)
            {
                s_QueueLogToFileString.Enqueue(logMessage);
            }
        }

        private static void WritelogQueueToLogFile()
        {
            var logMessage = string.Empty;
            while (0<s_QueueLogToFileString.Count)
            {
                logMessage += s_QueueLogToFileString.Dequeue()+"\r\n";
            }

            using (FileStream fileStream = new FileStream(s_LogFilePath, FileMode.Append))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(logMessage);
                fileStream.BeginWrite(buffer, 0, buffer.Length, a => {

                    var fs = a.AsyncState as FileStream;
                    fs.EndWrite(a);

                }, fileStream);
            }

        }

    }
}
