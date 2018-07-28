//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
{

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
	        CreateUIGroup<UIDefaultGroup>(100L,"Default",100);
        }


		public bool CreateUIGroup<T>(long groupId, string groupName, int groupWeight) where T : UIGroup
		{
			return Organize.CreateGroup<T>(groupId,groupName,groupWeight);
		}

		private bool Join(string groupName, UIGroupMember uiGroupMember, int groupMemberWeight)
		{
		 	var groupId = Organize.GetGroupId(groupName);
			return Organize.Join(groupId,uiGroupMember,groupMemberWeight);
		}


		private static bool Leave(UIGroupMember uiGroupMember)
		{
			return Organize.Leave(uiGroupMember.Window.WindowInfo.GroupId,uiGroupMember.Id);
		}
		

		public UIWindow CreateWindow(UIWindow window,WindowInfo windowInfo)
		{
			if(null==windowInfo) throw new ArgumentException("The 'windowInfo' can not be null or empty.");
			window.WindowInfo = windowInfo;
			var uiGroupMember = new UIGroupMember(window);
			Join(windowInfo.GroupName,uiGroupMember,0);
            window.OnCreate(windowInfo);
            return window;
        }
		
		
		
		
		
		
		
		
		
		
		
		
	
	}
}
