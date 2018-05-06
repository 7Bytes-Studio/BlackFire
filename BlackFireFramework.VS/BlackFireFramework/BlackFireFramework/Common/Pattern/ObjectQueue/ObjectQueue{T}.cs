//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// 线程安全的对象池队列。
    /// </summary>
    /// <typeparam name="T">池对象类型。</typeparam>
    public class ObjectQueue<T>
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        public ObjectQueue()
        {
            m_ObjectQueueFactoryCallback = ()=>Utility.Reflection.New<T>();
        }
  
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="objectQueueFactoryCallback">设置构建对象时的回调。</param>
        public ObjectQueue(ObjectQueueFactoryCallback  objectQueueFactoryCallback)
        {
            m_ObjectQueueFactoryCallback = objectQueueFactoryCallback;
        }

        public delegate T ObjectQueueFactoryCallback();

        private ObjectQueueFactoryCallback m_ObjectQueueFactoryCallback;

        private static Queue<T> m_ObjectQueue = new Queue<T>();

        private static object s_Lock = new object();

        /// <summary>
        /// 能否产出。
        /// </summary>
        public bool CanSpawn { get { return 0 < m_ObjectQueue.Count; } }

        /// <summary>
        /// 从池子或者设置的回调产出对象。
        /// </summary>
        /// <returns></returns>
        public T Spawn()
        {
            lock (s_Lock)
            {
                if (0 < m_ObjectQueue.Count)
                    return m_ObjectQueue.Dequeue();
                else
                    return m_ObjectQueueFactoryCallback.Invoke();
            }
        }

        /// <summary>
        /// 回收对象。
        /// </summary>
        /// <param name="@object">对象引用。</param>
        public void Recycle(T @object)
        {
            lock (s_Lock)
            {
                m_ObjectQueue.Enqueue(@object);
            }  
        }

    }
}
