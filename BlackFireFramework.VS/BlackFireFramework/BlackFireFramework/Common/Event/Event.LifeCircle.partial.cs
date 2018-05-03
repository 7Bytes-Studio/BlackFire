//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    /// <summary>
    /// 事件模块生命周期。
    /// </summary>
    public static partial class Event
    {
        /// <summary>
        /// Event静态类被使用。
        /// </summary>
        static Event()
        {
            Framework.Time.OnOriginTime += Born;
            Framework.Time.OnActTime    += Act;
            Framework.Time.OnEndTime    += Die;
        }


        /// <summary>
        /// 诞生。
        /// </summary>
        internal static void Born()
        {
            DeSyncQueue();
        }

        /// <summary>
        /// 活动。
        /// </summary>
        internal static void Act()
        {
            DeSyncQueue();
        }

        /// <summary>
        /// 灭亡。
        /// </summary>
        internal static void Die()
        {
            DeSyncQueue();
        }

    }
}
