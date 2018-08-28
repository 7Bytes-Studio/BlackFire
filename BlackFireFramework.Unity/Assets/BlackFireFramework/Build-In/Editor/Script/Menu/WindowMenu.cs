//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;

namespace BlackFireFramework.Editor
{
    public static class WindowMenu 
	{
        public const string TopMenuName = "BlackFire/";

        public const string Window = "Window/";


        [MenuItem(TopMenuName + "Config")]
        private static void OnMenuItemClickConfig()
        {
            var window = EditorWindow.GetWindow(typeof(ConfigWindow), true, "Config") as ConfigWindow;
            window.position = new UnityEngine.Rect((1920f - 520f) / 2, (1080f - 136f) / 2, 520f, 136f);
        }

		
        [MenuItem(TopMenuName + "Package")]
        private static void OnMenuItemClick_Package()
        {
           var window = EditorWindow.GetWindow(typeof(PackageWindow), false, "Package") as PackageWindow;
           window.position = new UnityEngine.Rect((1920f-730f)/2,(1080f-650f)/2,730f,650f);
        }

		
		[MenuItem(TopMenuName + "ScriptableObject Creator &c")]
		private static void OnMenuItemClick_ScriptableObjectCreator()
		{
			var window = EditorWindow.GetWindow(typeof(ScriptableObjectCreatorEditorWindow), false, "Creator") as ScriptableObjectCreatorEditorWindow;
			window.position = new UnityEngine.Rect((1920f-730f)/2,(1080f-650f)/2,250f,100f);
		}
	    

		[MenuItem(TopMenuName + "Game Process &g")]
		static void OnMenuItemClick_GameProcess()
		{
			var window = EditorWindow.GetWindow(typeof(ProcessWindow), false, "Process") as ProcessWindow;
			window.position = new UnityEngine.Rect((1920f-730f)/2,(1080f-650f)/2,730f,650f);
		}
	    
		
		[MenuItem(TopMenuName + "Project/Open Data Path")]
		private static void OpenDataPath()
		{
			Utility.Project.OpenDataPath();
		}

		
		[MenuItem(TopMenuName + "Project/Open Persistent Data Path")]
		private static void OpenPersistentDataPath()
		{
			Utility.Project.OpenPersistentDataPath();
		}


		[MenuItem(TopMenuName + "Project/Open Streaming Assets Path")]
		private static void OpenStreamingAssetsPath()
		{
			Utility.Project.OpenStreamingAssetsPath();
		}

		
		[MenuItem(TopMenuName + "Project/Open Temporary Cache Path")]
		private static void OpenTemporaryCachePath()
		{
			Utility.Project.OpenTemporaryCachePath();
		}
		
		
		[MenuItem(TopMenuName + "Project/Development Scene &d")]
		private static void OpenDevelopmentScene()
		{
			var window = EditorWindow.GetWindow(typeof(DevelopmentSceneWindow), false, "DevelopmentScene") as DevelopmentSceneWindow;
			window.position = new UnityEngine.Rect((1920f-730f)/2,(1080f-650f)/2,300f,550f);
		}
		



    }
}
