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
	public abstract class ManagerBase : MonoBehaviour , IManager
	{
        public virtual void InitManager()
        {
            //注册进BlackFire管家管理模块。
            BlackFire.RegisterManager(this);
        }

        public virtual void UpdateManager()
        {
            
        }

        public virtual void DestroyManager()
        { 
            //注销BlackFire管家管理模块。
            BlackFire.UnRegisterManager(this);
        }

    }
}
