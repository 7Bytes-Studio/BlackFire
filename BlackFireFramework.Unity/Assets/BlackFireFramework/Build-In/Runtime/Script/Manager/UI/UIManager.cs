//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <inheritdoc />
    /// <summary>
    /// UI管家。
    /// </summary>
    public sealed class UIManager : ManagerBase 
	{
        [SerializeField] private string m_IUIEventDataHelperTypeFullName = string.Empty;
        private IUIEventDataHelper m_UIEventDataHelper = null;
        public IUIEventDataHelper UIEventDataHelper { get; private set; }

        protected override void OnStart()
        {
            base.OnStart();
            UIEventDataHelper = (IUIEventDataHelper)gameObject.AddComponent( Type.GetType(m_IUIEventDataHelperTypeFullName) );
        }

        public UIWindow CreateWindow(UIWindow window,WindowInfo windowInfo)
        {
            window.OnCreate(windowInfo);
            return window;
        }
	
	}
}
