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
    public static partial class ObjectPool
    {
        public abstract class PoolBase
        {
            public PoolBase(string name,int capacity)
            {
                Name = name;
                Capacity = capacity;
                PoolFactory = new PoolFactory();
            }

            public string Name { get; private set; }
            public int Capacity { get; private set; }
            public abstract int Count { get;}
            public abstract int InCount { get;}
            public abstract int OutCount { get; }
            public PoolFactory PoolFactory { get; private set; }

            public abstract void Lock(ObjectBase @object);
            public abstract void UnLock(ObjectBase @object);
            public abstract ObjectBase Spawn(Type objectType,Predicate<ObjectBase> predicate=null,Func<object> argsCallback=null);
            public abstract void Recycle(ObjectBase @object);
            public abstract void RecycleAll();
            public abstract void Release(ObjectBase @object);
            public abstract void ReleaseAll();
            public abstract void ReleaseIn();
            public abstract void ReleaseOut();

            internal void Destroy()
            {
                OnDestroy();
            }
            protected abstract void OnDestroy();
        }


        /// <summary>
        /// 提供线程安全的对象池（框架默认对象池）。
        /// </summary>
        public class DefaultPool : PoolBase
        {

            public DefaultPool(string name, int poolCapacity):base(name,poolCapacity)
            {
              
            }





            private object m_Lock = new object();
            private LinkedList<ObjectBase> m_LinkedListObject_InPool = new LinkedList<ObjectBase>();
            private LinkedList<ObjectBase> m_LinkedListObject_OutPool = new LinkedList<ObjectBase>();
            public override int Count { get { return m_LinkedListObject_InPool.Count + m_LinkedListObject_OutPool.Count; } }
            public override int InCount { get { return m_LinkedListObject_InPool.Count; } }
            public override int OutCount { get { return m_LinkedListObject_OutPool.Count; } }




            private void SetObjectLockState(ObjectBase @object, bool lockState)
            {
                CheckObjectBaseArgsOrThrow(@object);
                var targetInNode = m_LinkedListObject_InPool.Find(@object);
                if (null != targetInNode)
                {
                    targetInNode.Value.SetLockState(lockState);
                }
                var targetOutNode = m_LinkedListObject_OutPool.Find(@object);
                if (null != targetOutNode)
                {
                    targetOutNode.Value.SetLockState(lockState);
                }
            }

            public override void Lock(ObjectBase @object)
            {
                CheckObjectBaseArgsOrThrow(@object);
                lock (m_Lock)
                {
                    SetObjectLockState(@object, true);
                }
            }

            public override void UnLock(ObjectBase @object)
            {
                CheckObjectBaseArgsOrThrow(@object);
                lock (m_Lock)
                {
                    SetObjectLockState(@object, false);
                }
            }

            public override void Recycle(ObjectBase @object)
            {
                CheckObjectLockStateOrLog(@object);

                CheckObjectBaseArgsOrThrow(@object);
                lock (m_Lock)
                {
                    if (!@object.Lock && m_LinkedListObject_OutPool.Contains(@object))
                    {
                        m_LinkedListObject_OutPool.Remove(@object);
                        m_LinkedListObject_InPool.AddLast(@object);
                        @object.Recycle();
                    }
                }
            }

            public override void RecycleAll()
            {
                lock (m_Lock)
                {
                    m_LinkedListObject_OutPool.Foreach(current=> {

                       
                        if (null!=current.Value)
                        {
                            CheckObjectLockStateOrLog(current.Value);
                            if (!current.Value.Lock)
                            {
                                current.Value.Recycle();
                                m_LinkedListObject_OutPool.Remove(current);
                                m_LinkedListObject_InPool.AddLast(current.Value);
                            }
                        }

                        

                    });                  
                }
            }

            public override void Release(ObjectBase @object)
            {
                CheckObjectLockStateOrLog(@object);

                CheckObjectBaseArgsOrThrow(@object);
                lock (m_Lock)
                {
                    if (m_LinkedListObject_InPool.Contains(@object) && !@object.Lock)
                    {
                        m_LinkedListObject_InPool.Remove(@object);
                        @object.Release();
                        return;
                    }

                    if (m_LinkedListObject_OutPool.Contains(@object) && !@object.Lock)
                    {
                        m_LinkedListObject_OutPool.Remove(@object);
                        @object.Release();
                        return;
                    }

                }
            }

            public override void ReleaseAll()
            {
                ReleaseOut();
                ReleaseIn();
            }

            public override void ReleaseIn()
            {
                lock (m_Lock)
                {
                    m_LinkedListObject_InPool.Foreach(current => {

                        if (null != current.Value )
                        {
                            CheckObjectLockStateOrLog(current.Value);
                            if (!current.Value.Lock)
                            {
                                current.Value.Release();
                            }
                        }

                    });
                    m_LinkedListObject_InPool.Clear();
                }
            }

            public override void ReleaseOut()
            {
                lock (m_Lock)
                {
                    m_LinkedListObject_OutPool.Foreach(current => {
                        if (null != current.Value)
                        {
                            CheckObjectLockStateOrLog(current.Value);
                            if (!current.Value.Lock)
                            {
                                current.Value.Release();
                            }
                        }
                    });
                    m_LinkedListObject_OutPool.Clear();
                }
            }

            public override ObjectBase Spawn(Type objectType, Predicate<ObjectBase> predicate = null,Func<object> factoryArgsCallback=null)
            {
                CheckObjectTypeOrThrow(objectType);
                var target = null != predicate? FindTypeInPool(predicate):FindTypeInPool(objectType);
                if (null != target && !target.Lock)
                {
                    lock (m_Lock)
                    {
                        m_LinkedListObject_InPool.Remove(target);
                        m_LinkedListObject_OutPool.AddLast(target);
                    }
                    target.Spawn();
                    return target;
                }
                else
                {
                    CheckCapacityOrThrow();
                    ObjectBase ins = null;
                    var callback =  PoolFactory.GetBinding(objectType);
                    if (null != callback)
                    {
                        ins = callback.Invoke();
                    }
                    else
                    {
                        //throw new Exception(string.Format("没有获取到类型'{0}'的委托绑定！",objectType));
                        ins = Utility.Reflection.New(objectType) as ObjectBase;
                    }

                    lock (m_Lock)
                    {
                        m_LinkedListObject_OutPool.AddLast(ins);
                    }
                    
                    ins.SetPoolOwnersName(Name);
                    if (null != factoryArgsCallback)
                    {
                        ins.Spawn(factoryArgsCallback.Invoke());
                    }
                    else
                    {
                        ins.Spawn();
                    }
                    return ins;
                }
            }



            private ObjectBase FindTypeInPool(Predicate<ObjectBase> predicate)
            {
                if (null == predicate) return null;

                var current = m_LinkedListObject_InPool.First;
                while (null != current)
                {
                    if (predicate.Invoke(current.Value))
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                return null;
            }

            private ObjectBase FindTypeInPool(Type objectType)
            {
                var current = m_LinkedListObject_InPool.First;
                while (null!=current)
                {
                    if (current.Value.GetType() == objectType)
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                return null;
            }

            private ObjectBase FindTypeOutPool(Type objectType)
            {
                var current = m_LinkedListObject_OutPool.First;
                while (null != current)
                {
                    if (current.Value.GetType() == objectType)
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                return null;
            }

            private void CheckCapacityOrThrow()
            {
                if (Count>=Capacity)
                {
                    throw new Exception(string.Format("对象池'{0}'内可复用对象为0，当尝试用工厂生产对象时已超过对象池的容量上限{1},请回收或释放后再操作!", Name,Capacity));
                }
            }

            private void CheckObjectTypeOrThrow(Type objectType)
            {
                if (!typeof(ObjectBase).IsAssignableFrom(objectType))
                    throw new Exception(string.Format("The {0} is not the implementation type for the ObjectBase.", objectType));
            }

            private void CheckObjectBaseArgsOrThrow(ObjectBase @object)
            {
                if (null == @object) throw new ArgumentNullException("参数@object不能为空!");
            }

            private void CheckObjectLockStateOrLog(ObjectBase @object)
            {
                if (@object.Lock)
                {
                    Log.Warn(string.Format("对象'{0}'已被加锁!",@object),true);
                    //throw new Exception(string.Format("对象'{0}'已被加锁!", @object));
                }
            }

            protected override void OnDestroy()
            {
                lock (m_Lock)
                {
                    m_LinkedListObject_InPool.Foreach(current => {

                        if (null != current.Value)
                        {
                            current.Value.Release();
                            m_LinkedListObject_InPool.Remove(current);
                        }

                    });

                    m_LinkedListObject_OutPool.Foreach(current => {

                        if (null != current.Value)
                        {
                            current.Value.Release();
                            m_LinkedListObject_OutPool.Remove(current);
                        }

                    });

                    m_LinkedListObject_InPool.Clear();
                    m_LinkedListObject_OutPool.Clear();
                }
            }
        }
    }
}
