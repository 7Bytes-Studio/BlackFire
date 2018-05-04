//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 框架时间类。
    /// </summary>
    public static partial class Framework
    {
        /// <summary>
        /// 时间类。
        /// </summary>
        public static partial class Time
        {
            #region 属性


            public static float RealElapsedDeltaTime { get; internal set; }
            public static float VirsulElapsedDeltaTime { get; internal set; }
            public static float RealElapsedTime { get; internal set; }
            public static float VirsulElapsedTime { get; internal set; }


            public static DateTime OriginDateTime { get; private set; }

            public static DateTime CurrentDateTime { get { return DateTime.Now; } }

            public static DateTime EndDateTime { get; private set; }

            #endregion

            #region 事件

            internal static event Action OnOriginTime;
            internal static event Action OnActTime;
            internal static event Action OnEndTime;

            #endregion

            #region 时间轴


            internal static void SetOriginTime(float realElapsedDeltaTime, float virsulElapsedDeltaTime)
            {
#if VS_EDITOR
                Log.Trace("SetOriginTime...");
#endif

                CheckTwiceSetOriginTimeOrThrow();
                OriginDateTime = DateTime.Now;
                RealElapsedTime += RealElapsedDeltaTime = realElapsedDeltaTime;
                VirsulElapsedTime += VirsulElapsedDeltaTime = virsulElapsedDeltaTime;
                if (null != OnOriginTime)
                {
                    OnOriginTime.Invoke();
                }
                s_HasSetOriginTime = true;
            }

            internal static void SetActTime(float realElapsedDeltaTime, float virsulElapsedDeltaTime)
            {
                RealElapsedTime += RealElapsedDeltaTime = realElapsedDeltaTime;
                VirsulElapsedTime += VirsulElapsedDeltaTime = virsulElapsedDeltaTime;
                if (null != OnActTime)
                {
                    OnActTime.Invoke();
                }
            }

            internal static void SetEndTime(float realElapsedDeltaTime, float virsulElapsedDeltaTime)
            {
                CheckTwiceSetEndTimeOrThrow();
                RealElapsedTime += RealElapsedDeltaTime = realElapsedDeltaTime;
                VirsulElapsedTime += VirsulElapsedDeltaTime = virsulElapsedDeltaTime;
                EndDateTime = DateTime.Now;
                if (null != OnEndTime)
                {
                    OnEndTime.Invoke();
                }
                s_HasSetEndTime = true;
            }


            #endregion

            #region 异常检查

            private static bool s_HasSetOriginTime;
            private static void CheckTwiceSetOriginTimeOrThrow()
            {
                if (s_HasSetOriginTime)
                {
                    throw new System.Exception("禁止再次设置起点时间。");
                }
            }
            private static bool s_HasSetEndTime;
            private static void CheckTwiceSetEndTimeOrThrow()
            {
                if (s_HasSetEndTime)
                {
                    throw new System.Exception("禁止再次设置终点时间。");
                }
            }

            #endregion

        }
    }
}
