//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public sealed class ObjectPool<T> where T : IRecyclable
    {
        private Queue<T> m_Pool = new Queue<T>();

        private Func<T> m_ObjectFactory;

        public ObjectPool(Func<T> objectFactory)
        {
            this.m_ObjectFactory = objectFactory;
        }

        public T Spawn()    
        {
            lock (m_Pool)
            {
                if (m_Pool.Count > 0)
                    return m_Pool.Dequeue();
            }
            return m_ObjectFactory.Invoke();
        }

        public void Recycle(T item)
        {
            lock (m_Pool)
                m_Pool.Enqueue(item);
        }
    }
}
