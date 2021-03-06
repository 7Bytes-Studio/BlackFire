﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackFire
{
    public static partial class Log
    {


        /// <summary>
        /// Log静态类被使用。
        /// </summary>
        static Log()
        {
            Framework.LifeCircle.OnBorn += Born;
            Framework.LifeCircle.OnAct += Act;
            Framework.LifeCircle.OnDie += Die;
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
