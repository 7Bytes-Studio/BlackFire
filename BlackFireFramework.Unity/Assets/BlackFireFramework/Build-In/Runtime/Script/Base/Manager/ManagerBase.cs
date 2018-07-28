//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 管家抽象基类。
    /// </summary>
    [GameObjectIcon("Manager")]
    public abstract class ManagerBase : MonoBehaviour, IManager
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
            OnStart();
        }
        private void Update()
        {
            OnUpdate();
        }
        void IManager.ShutdownManager()
        {
            //注销BlackFire管家管理模块。
            BlackFire.UnRegisterManager(this);
            OnShutdown();
            DestroyImmediate(gameObject);
        }


        protected T GetModule<T>() where T : IModule
        {
            return BlackFire.ModuleManager.GetModule<T>();
        }

        protected void RegisterModule<T>() where T : IModule
        {
            BlackFire.ModuleManager.Register<T>();
        }

        protected void UnRegisterModule<T>() where T : IModule
        {
            BlackFire.ModuleManager.UnRegister<T>();
        }

        /// <summary>
        /// 模块被启动事件。
        /// </summary>
        protected virtual void OnStart()
        {

        }
        
        /// <summary>
        /// 模块被轮询事件。
        /// </summary>
        protected virtual void OnUpdate()
        {

        }
        
        /// <summary>
        /// 模块被关闭事件。
        /// </summary>
        protected virtual void OnShutdown()
        {

        }

    }
}
