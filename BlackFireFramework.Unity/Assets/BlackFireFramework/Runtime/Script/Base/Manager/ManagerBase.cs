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
    /// 管家抽象基类。
    /// </summary>
    [GameObjectIcon("Manager")]
	public abstract class ManagerBase : MonoBehaviour , IManager
	{
        //是否在工作状态。
        public virtual bool IsWorking
        {
            get
            {
                return enabled && gameObject.activeSelf;
            }
        }

       void IManager.StartManager()
        {
            //注册进BlackFire管家管理模块。
            BlackFire.RegisterManager(this);
        }

        protected virtual void OnStart()
        {

        }

        private void Update()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {

        }

        protected virtual void OnShutdown()
        {

        }

        void IManager.ShutdownManager()
        { 
            //注销BlackFire管家管理模块。
            BlackFire.UnRegisterManager(this);
            OnShutdown();
            DestroyImmediate(gameObject);
        }

    }
}
