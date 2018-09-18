//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework
{
    /// <summary>
    /// 子弹对象。
    /// </summary>
	public sealed class BulletObject : ObjectPool.ObjectBase
    {
        public BulletObject(BulletLogic target)
        {
            Target = target;
            target.ObjectOwner = this;
        }

        public BulletLogic Target { get; private set; }

        protected override void OnSpawn(object args)
        {
            base.OnSpawn();
            Target.transform.position = Vector3.zero;
            Target.gameObject.SetActive(true);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            Target.gameObject.SetActive(false);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            GameObject.DestroyImmediate(Target);
            Target = null;
        }

        protected override void OnLock()
        {
            base.OnLock();
            Target.LockState = true;
        }

        protected override void OnUnlock()
        {
            base.OnUnlock();
            Target.LockState = false;
        }
    }
}
