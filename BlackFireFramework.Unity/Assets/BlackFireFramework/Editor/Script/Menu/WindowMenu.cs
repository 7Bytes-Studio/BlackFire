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

        [MenuItem(TopMenuName+Window+"Package")]
        private static void OnMenuItemClick_Package()
        {
            EditorWindow.GetWindow(typeof(PackageWindow), false, "Package");
        }

    }
}
