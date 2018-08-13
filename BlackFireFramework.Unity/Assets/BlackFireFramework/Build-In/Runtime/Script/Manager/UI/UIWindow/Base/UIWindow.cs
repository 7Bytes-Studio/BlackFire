//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 窗口的抽象。
    /// </summary>
    public class UIWindow : UIBehaviour<IUIWindowLogic>
	{

        #region 对外接口

        private IUIWindowLogic m_Logic = null;
        public override IUIWindowLogic Logic { get { return m_Logic??(m_Logic=GetComponent<IUIWindowLogic>()); } }

        public WindowInfo WindowInfo { get; internal set; }

	    public int Layer
	    {
	        get { return Logic.Layer; }
	        set { Logic.Layer = value; }
	    }

	    public bool IsShowing { get; private set; }

        public void Open()
        {
            OnOpen();
        }

        public void Close()
        {
            OnClose();
        }

	    public void Destroy()
	    {
	        OnDestroyed();
	    }

	    #region Unity LifeCircle

		private void Update()
		{
			OnUpdate();
		}

		#endregion
	    
	    
	    #endregion


        #region 生命周期


        internal void OnCreate(WindowInfo windowInfo)
        {
            WindowInfo = windowInfo;
            Logic.OnCreate(this);
        }

        private void OnOpen()
        {
            IsShowing = true;
            Logic.OnOpen();
        }

        internal void OnUpdate()
        {
            Logic.OnUpdate();
        }

        private void OnClose()
        {
            IsShowing = false;
            Logic.OnClose();
        }

        internal void OnDestroyed()
        {
            Logic.OnDestroyed();
        }

        #endregion


        #region 事件


        #endregion

    }
}


