//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 框架生命周期。
    /// </summary>
    public static partial class Framework
    {
        /// <summary>
        /// 框架活动主体。
        /// </summary>
        private static object s_Who = null;


        /// <summary>
        /// 检查框架活动主体或者抛出异常。
        /// </summary>
        /// <param name="who">框架活动主体。</param>
        private static void CheckWhoOrThrow(object who)
        {
            if (s_Who!=null && !s_Who.Equals(who))
            {
                throw new NullReferenceException("框架活动主体有且只能有一个。");
            }
        }





        /// <summary>
        /// Framework静态类被使用。
        /// </summary>
        static Framework()
        {
           Init_Info();
           Init_State();
        }

        /// <summary>
        /// 诞生框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Born(object who,float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            State.Working = true;
            CheckWhoOrThrow(who);
            s_Who = who;
            Time.SetOriginTime(realElapsedDeltaTime,virsulElapsedDeltaTime); //设置时间轴的起点时间。
        }

        /// <summary>
        /// 活动框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Act(object who, float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            CheckWhoOrThrow(who);
            Time.SetActTime(realElapsedDeltaTime, virsulElapsedDeltaTime); //设置时间轴的活动时间。
        }

        /// <summary>
        /// 销毁框架。
        /// </summary>
        /// <param name="who">让框架诞生者(也指使用框架这件事情的活动主体是谁)。</param>
        /// <param name="realElapsedDeltaTime">真实世界流逝的时间。</param>
        /// <param name="virsulElapsedDeltaTime">虚拟世界流逝的时间。</param>
        public static void Die(object who, float realElapsedDeltaTime, float virsulElapsedDeltaTime)
        {
            CheckWhoOrThrow(who);
            Time.SetEndTime(realElapsedDeltaTime, virsulElapsedDeltaTime); //设置时间轴的终点时间。
            State.Working = false;
        }

    }
}
