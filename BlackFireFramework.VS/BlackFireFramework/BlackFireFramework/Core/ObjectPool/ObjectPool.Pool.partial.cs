//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class ObjectPool
    {
        public abstract class PoolBase
        {
            public PoolBase()
            {
                PoolFactoryBinder = new PoolFactoryBinder();
            }

            public PoolFactoryBinder PoolFactoryBinder { get; protected set; }

            public abstract void Lock(ObjectBase @object);
            public abstract void UnLock(ObjectBase @object);
            public abstract ObjectBase Spawn(Type objectType);
            public abstract void Recycle(ObjectBase @object);
            public abstract void RecycleAll();
            public abstract void Release(ObjectBase @object);
            public abstract void ReleaseAll();
            public abstract void ReleaseIn();
            public abstract void ReleaseOut();

        }


        /// <summary>
        /// 提供线程安全的对象池（框架默认对象池）。
        /// </summary>
        public class DefaultPool : PoolBase
        {
            private object m_Lock = new object();

            private LinkedList<ObjectBase> m_LinkedListObject_InPool = new LinkedList<ObjectBase>();
            private LinkedList<ObjectBase> m_LinkedListObject_OutPool = new LinkedList<ObjectBase>();

            private void SetObjectLockState(ObjectBase @object, bool lockState)
            {
                var targetNode = m_LinkedListObject_InPool.Find(@object);
                if (null != targetNode)
                {
                    targetNode.Value.SetLockState(lockState);
                }
            }



            public override void Lock(ObjectBase @object)
            {
                lock (m_Lock)
                {
                    SetObjectLockState(@object, true);
                }
            }

            public override void UnLock(ObjectBase @object)
            {
                lock (m_Lock)
                {
                    SetObjectLockState(@object, false);
                }
            }

            public override void Recycle(ObjectBase @object)
            {
                lock (m_Lock)
                {
                    if (m_LinkedListObject_OutPool.Contains(@object))
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
                            current.Value.Recycle();
                        }
                        m_LinkedListObject_InPool.AddLast(current.Value);

                    });
                    m_LinkedListObject_OutPool.Clear();
                }
            }


            public override void Release(ObjectBase @object)
            {
                lock (m_Lock)
                {
                    if (m_LinkedListObject_InPool.Contains(@object))
                    {
                        m_LinkedListObject_InPool.Remove(@object);
                        @object.Release();
                        return;
                    }

                    if (m_LinkedListObject_OutPool.Contains(@object))
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

                        if (null != current.Value)
                        {
                            current.Value.Release();
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
                            current.Value.Release();
                        }

                    });

                    m_LinkedListObject_OutPool.Clear();

                }
            }

            public override ObjectBase Spawn(Type objectType)
            {
                var target = FindTypeInPool(objectType);
                if (null != target)
                {
                    return target;
                }
                else
                {
                    var callback =  PoolFactoryBinder.GetBinding(objectType);
                    if (null != callback)
                    {
                        var ins = callback.Invoke();
                        m_LinkedListObject_OutPool.AddLast(ins);
                        ins.SetPoolOwner(this);
                        return ins;
                    }
                    else
                    {
                        throw new Exception(string.Format("没有获取到类型'{0}'的委托绑定！",objectType));
                    }
                }
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


        }
    }
}
