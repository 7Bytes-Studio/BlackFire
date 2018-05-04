using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackFireFramework
{
    public static partial class Log
    {
        /// <summary>
        /// Log静态类被使用。
        /// </summary>
        static Log()
        {
            Framework.Time.OnOriginTime += Born;
            Framework.Time.OnActTime += Act;
            Framework.Time.OnEndTime += Die;
        }


        /// <summary>
        /// 诞生。
        /// </summary>
        internal static void Born()
        {
           
        }

        /// <summary>
        /// 活动。
        /// </summary>
        internal static void Act()
        {
            Log.DeSyncQueue(); //轮询出日志队列。
        }

        /// <summary>
        /// 灭亡。
        /// </summary>
        internal static void Die()
        {
           
        }
    }
}
