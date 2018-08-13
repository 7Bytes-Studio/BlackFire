//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{

    /// <summary>
    /// UI管家扩展类。
    /// </summary>
    public static class UIManagerExtension
	{

		public static UIWindow CreateWindow(this UIManager uiManager,UIWindow windowTpl,long id, string name, long groupId)
		{
			return uiManager.CreateWindow(windowTpl,new WindowInfo(id,name,groupId));
		}

		public static UIWindow CreateWindow(this UIManager uiManager,UIWindow windowTpl,long id, string name, string groupName)
		{
			var groupId = uiManager.QueryUIGroupId( groupName );
			return uiManager.CreateWindow(windowTpl,new WindowInfo( id, name, groupId ));
		}
		
		public static bool ExecuteCommand<T>(this UIManager uiManager,UIWindow window, UICommandCallback<T> callback) where T : Event.IEventHandler
		{
			return uiManager.ExecuteCommand<T>(window.WindowInfo.GroupId, callback);
		}
		
	}
}
