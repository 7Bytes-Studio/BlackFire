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
    public sealed class DebuggerLogGUI : IDebuggerModuleGUI
    {
        public string ModuleName
        {
            get
            {
               return "Log";
            }
        }

        public void OnModuleGUI(DebuggerManager debuggerManager)
        {

            BlackFireGUI.BoxHorizontalLayout(() =>
            {

                GUILayout.Toggle(true, LogLevel.Trace.ToString());
                GUILayout.Toggle(true, LogLevel.Debug.ToString());
                GUILayout.Toggle(true, LogLevel.Info.ToString());
                GUILayout.Toggle(true, LogLevel.Warn.ToString());
                GUILayout.Toggle(true, LogLevel.Error.ToString());
                GUILayout.Toggle(true, LogLevel.Fatal.ToString());

            });

            BlackFireGUI.BoxHorizontalLayout(() =>
            {
                BlackFireGUI.ScrollView(101, id =>
                {

                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
                    GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");

                });

            });

            BlackFireGUI.BoxHorizontalLayout(() =>
            {

                BlackFireGUI.ScrollView(102, id =>
                {

                    GUILayout.Label("11111111111111111111111111112222222222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222222222222222222222222222222222222");
                    GUILayout.Label("11111111111111111111111111112222222222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222222222222222222222222222222222222");

                }, GUILayout.MinHeight(50));

            });

        }
    }
}
