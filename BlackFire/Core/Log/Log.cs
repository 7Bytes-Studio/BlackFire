/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackFire
{
    /// <summary>
    /// 日志类。
    /// </summary>
    public static partial class Log
    {

        private static LogCallback s_LogCallback = null;

        #region SyncLog

        private struct SyncLog
        {
            public LogLevel LogLevel;
            public object Message;
        }

        private static Queue<SyncLog> s_SyncLogQueue = new Queue<SyncLog>();

        private static void EnSyncQueue(LogLevel logLevel,object message)
        {
            s_SyncLogQueue.Enqueue(new SyncLog() { LogLevel = logLevel, Message = message });
        }

        internal static void DeSyncQueue()
        {
            while (0<s_SyncLogQueue.Count)
            {
                var syncLog = s_SyncLogQueue.Dequeue();
                s_LogCallback.Invoke(syncLog.LogLevel, syncLog.Message);
            }
        }

        #endregion

        public static void SetLogCallback(LogCallback logCallback)
        {
            s_LogCallback = logCallback;
        }

        public static void Trace(object message,bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug,message);
                return;
            }
            s_LogCallback.Invoke( LogLevel.Trace,message);
        }

        public static void Debug(object message, bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug, message);
                return;
            }
            s_LogCallback.Invoke(LogLevel.Debug, message);
        }

        public static void Info(object message, bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug, message);
                return;
            }
            s_LogCallback.Invoke(LogLevel.Info, message);
        }

        public static void Warn(object message, bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug, message);
                return;
            }
            s_LogCallback.Invoke(LogLevel.Warn, message);
        }

        public static void Error(object message, bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug, message);
                return;
            }
            s_LogCallback.Invoke(LogLevel.Error, message);
        }

        public static void Fatal(object message, bool sync = false)
        {
            if (sync)
            {
                EnSyncQueue(LogLevel.Debug, message);
                return;
            }
            s_LogCallback.Invoke(LogLevel.Fatal, message);
        }




    }
}
