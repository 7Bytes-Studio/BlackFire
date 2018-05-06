//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BlackFireFramework
{
    /// <summary>
    /// 对象池。
    /// </summary>
    public static partial class ObjectPool
    {

        private static LinkedList<PoolBase> s_LinkedListPoolBase = new LinkedList<PoolBase>();



        /// <summary>
        /// 创建对象池。
        /// </summary>
        /// <param name="poolName">对象池的名字。</param>
        /// <param name="poolCapacity">对象之的容量。</param>
        /// <param name="poolCustomImpl">自定义对象池的实现。</param>
        public static PoolBase CreatePool(string poolName,int poolCapacity=int.MaxValue,Type poolCustomImpl = null)
        {
            PoolBase pool = null;
            if (null != poolCustomImpl)
            {
                CheckPoolImplOrThrow(poolCustomImpl);
                pool = Utility.Reflection.New(poolCustomImpl,poolName,poolCapacity) as PoolBase;
            }
            else
            {
                pool = new DefaultPool(poolName,poolCapacity);
            }

            if (!s_LinkedListPoolBase.Contains(pool))
            {
                s_LinkedListPoolBase.AddLast(pool);
            }
            return pool;
        }

        /// <summary>
        /// 获取对象池。
        /// </summary>
        /// <param name="poolName">对象池名字。</param>
        /// <returns>对象池实例。</returns>
        public static PoolBase GetPool(string poolName)
        {
            var current = s_LinkedListPoolBase.First;
            while (null != current)
            {
                if (current.Value.Name == poolName)
                {
                    return current.Value;
                }

                current = current.Next;
            }
            return null;
        }

        /// <summary>
        /// 销毁对象池。
        /// </summary>
        /// <param name="poolName">对象池名字。</param>
        /// <returns>是否销毁成功。</returns>
        public static bool DestroyPool(string poolName)
        {
            var current = s_LinkedListPoolBase.First;
            while (null!=current)
            {
                if (current.Value.Name==poolName)
                {
                    s_LinkedListPoolBase.Remove(current);
                    current.Value.Destroy();
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// 检查对象池的实现类型如果有异常则抛出。
        /// </summary>
        /// <param name="poolType">对象池的实现类型。</param>
        private static void CheckPoolImplOrThrow(Type poolType)
        {
            if (!typeof(PoolBase).IsAssignableFrom(poolType))
                throw new Exception(string.Format("The {0} is not the implementation type for the PoolBase.", poolType));
        }


    }
}
