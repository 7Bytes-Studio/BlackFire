//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public abstract class EntityBase<T> : ObjectPool.ObjectBase 
    {

        protected static readonly Dictionary<T, EntityBase<T>> s_EntityMap = new Dictionary<T, EntityBase<T>>();

        public static TEntity GetEntity<TEntity>(T instance) where TEntity : EntityBase<T>
        {
            if (s_EntityMap.ContainsKey(instance))
            {
                return s_EntityMap[instance] as TEntity;
            }
            return null;
        }

        private T m_Target = default(T);
        public virtual T Target {
            get { return m_Target; }
            protected set {
                if (null != value)
                {
                    if (!s_EntityMap.ContainsKey(value))
                    {
                        s_EntityMap.Add(value,this);
                    }
                }
                else
                {
                    if (s_EntityMap.ContainsKey(m_Target))
                    {
                        s_EntityMap.Remove(m_Target);
                    }
                }
                m_Target = value;
            }
        }

        public override string ToString()
        {
            return Target.ToString();
        }

        protected override void OnLock()
        {
            base.OnLock();
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
        }

        protected override void OnRelease()
        {
            base.OnRelease();
        }

        protected override void OnSpawn(object args)
        {
            base.OnSpawn(args);
        }

        protected override void OnUnlock()
        {
            base.OnUnlock();
        }
    }
}
