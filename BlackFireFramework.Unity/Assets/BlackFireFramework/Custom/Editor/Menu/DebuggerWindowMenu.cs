//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public static class DebuggerWindowMenu
    {
        public const string TopMenuName = "BlackFire/";


        [MenuItem(TopMenuName + "Debugger")]
        private static void OnMenuItemClickConfig()
        {
            var go_Debugger = new GameObject("Debugger",typeof(DebuggerManager));
            var go_Build_In = new GameObject("Build-In");
            var go_BlackFire = new GameObject("[BlackFire]",typeof(BlackFire));

            go_Build_In.transform.SetParent(go_BlackFire.transform);
            go_Debugger.transform.SetParent(go_Build_In.transform);
        }

    }
}
