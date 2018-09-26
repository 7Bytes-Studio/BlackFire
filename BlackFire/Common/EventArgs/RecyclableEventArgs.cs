/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;

namespace BlackFire
{

    /// <summary>
    /// 可被对象队列回收的事件参数类型。
    /// </summary>
    public abstract partial class RecyclableEventArgs : EventArgs
    {

        /// <summary>
        /// 事件参数实例被产出事件。
        /// </summary>
        protected abstract void OnSpawn();

        /// <summary>
        /// 事件参数实例被回收事件。
        /// </summary>
        protected abstract void OnRecycle();


        #region Static

        private static readonly LinkedList<RecyclableEventArgs> s_Pool = new LinkedList<RecyclableEventArgs>();

        private static object s_Lock = new object();


        /// <summary>
        /// 回收事件参数。
        /// </summary>
        /// <param name="instance">时间参数实例。</param>
        public static void Recycle(RecyclableEventArgs instance)
        {
            lock (s_Lock)
            {
                s_Pool.AddLast(instance);
            }
            instance.OnRecycle();
        }


        /// <summary>
        /// 产出事件参数。
        /// </summary>
        /// <returns>事件参数产出实例。</returns>
        public static RecyclableEventArgs Spawn(Type implEventArgsType)
        {
            if (!typeof(RecyclableEventArgs).IsAssignableFrom(implEventArgsType))
                throw new Exception(string.Format("The {0} is not the implementation type for the RecyclableEventArgs.", implEventArgsType));

            RecyclableEventArgs instance = null;
            if (0<s_Pool.Count)
            {
                lock (s_Lock)
                {
                    var current = s_Pool.First;
                    while (null!=current)
                    {
                        if (current.Value.GetType() == implEventArgsType)
                        {
                            s_Pool.Remove(current.Value);
                            instance = current.Value;
                            break;
                        }
                        current = current.Next;
                    }
                }
                    
            }

            if (null == instance)
            {
                instance = Utility.Reflection.New(implEventArgsType) as RecyclableEventArgs;

            }

            instance.OnSpawn();
            return instance;
        }

        /// <summary>
        /// 产出事件参数。
        /// </summary>
        /// <typeparam name="T">时间参数类型。</typeparam>
        /// <returns>事件参数产出实例。</returns>
        public static T Spawn<T>() where T : RecyclableEventArgs
        {
            return Spawn(typeof(T)) as T;
        }

        #endregion

    }
}
