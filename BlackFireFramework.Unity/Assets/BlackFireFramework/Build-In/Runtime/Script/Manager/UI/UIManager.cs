//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace BlackFireFramework.Unity
{

    /// <summary>
    /// UI管家。
    /// </summary>
    public sealed partial class UIManager : ManagerBase 
	{
        [SerializeField] private string m_IUIEventDataHelperTypeFullName = string.Empty;

		private IUIGroupModule m_UIGroupModule = new UIGroupModule();
		private IUIEventModule m_UIEventModule = new UIEventModule();

		public IUIEventDataHelper UIEventDataHelper
		{
			get
			{
				return m_UIEventModule.UIEventDataHelper;
			}
		}

		protected override void OnStart()
        {
            base.OnStart();
	        m_UIEventModule.UIEventDataHelper = (IUIEventDataHelper)gameObject.AddComponent( Type.GetType(m_IUIEventDataHelperTypeFullName) );
	        CreateUIGroup<UIDefaultGroup>(100L,"Default",100);
        }

	}
}
