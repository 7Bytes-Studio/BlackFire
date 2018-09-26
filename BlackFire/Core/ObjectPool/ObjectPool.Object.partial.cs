/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    public static partial class ObjectPool
    {
        /// <summary>
        /// 被对象池管理的对象抽象基类。
        /// </summary>
        public abstract class ObjectBase
        {
            #region State

            /// <summary>
            /// 是否有被锁住。
            /// </summary>
            public bool Lock { get; private set; }

            /// <summary>
            /// 对象所属对象池名字。
            /// </summary>
            public string PoolName { get; private set; }

            #endregion

            internal void SetLockState(bool lockState)
            {
                Lock = lockState;
                if (Lock)
                {
                    OnLock();
                }
                else
                {
                    OnUnlock();
                }
            }
            internal void SetPoolOwnersName(string poolName)
            {
                PoolName = poolName;
            }

            internal virtual void Spawn(object args = null)
            {
                OnSpawn(args);
            }

            internal void Recycle()
            {
                OnRecycle();
            }

            internal void Release()
            {
                OnRelease();
            }



            #region Event


            protected virtual void OnLock() { }
            protected virtual void OnUnlock() { }
            protected virtual void OnSpawn(object args=null) { }
            protected virtual void OnRecycle() { }
            protected virtual void OnRelease() { }


            #endregion

        }
    }
}
