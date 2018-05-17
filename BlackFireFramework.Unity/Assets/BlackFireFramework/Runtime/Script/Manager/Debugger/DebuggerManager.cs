//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
    /// <summary>
    /// 调试器管家。
    /// </summary>
	public sealed partial class DebuggerManager : MonoBehaviour 
	{

        [SerializeField][Range(1f,3f)] private float m_WindowScale=1f;

        private bool m_Minimize = true;

        private string m_SelectedModuleName = string.Empty;

        private Dictionary<string, Action<DebuggerManager>> m_DrawModuleCallbackDic = new Dictionary<string, Action<DebuggerManager>>();


        private void ReflectModuleGUIImpl()
        {
            var types = Utility.Reflection.GetImplTypes("Assembly-CSharp",typeof(IDebuggerModuleGUI));

            for (int i = 0; i < types.Length; i++)
            {
                var ins = Utility.Reflection.New(types[i]);
                if (null!=ins)
                {
                    RegisterModuleGUI(ins as IDebuggerModuleGUI);
                }
            }

        }



        private void Start()
        {
            ReflectModuleGUIImpl();

            //RegisterModuleGUI("Log",()=> {

            //    BlackFireGUI.BoxHorizontalLayout(()=> {

            //        GUILayout.Toggle(true, LogLevel.Trace.ToString());
            //        GUILayout.Toggle(true, LogLevel.Debug.ToString());
            //        GUILayout.Toggle(true, LogLevel.Info.ToString());
            //        GUILayout.Toggle(true, LogLevel.Warn.ToString());
            //        GUILayout.Toggle(true, LogLevel.Error.ToString());
            //        GUILayout.Toggle(true, LogLevel.Fatal.ToString());

            //    });

            //    BlackFireGUI.BoxHorizontalLayout(() => {
            //        BlackFireGUI.ScrollView(101, id => {

            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");
            //            GUILayout.Toggle(false, " Info:这里是一些调试信息 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx。");

            //        });

            //    });

            //    BlackFireGUI.BoxHorizontalLayout(() => {

            //        BlackFireGUI.ScrollView(102, id => {

            //            GUILayout.Label("11111111111111111111111111112222222222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222222222222222222222222222222222222");
            //            GUILayout.Label("11111111111111111111111111112222222222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222221111111111111111111222222222222222222222222222222222222222");

            //        }, GUILayout.MinHeight(50));

            //    });

            //});

            //RegisterModuleGUI("Process", () => {



            //});

            //RegisterModuleGUI("Event", () => {



            //});

            //RegisterModuleGUI("ObjectPool", () => {



            //});

            //RegisterModuleGUI("Network", () => {



            //});

            //RegisterModuleGUI("Job", () => {



            //});

            //RegisterModuleGUI("Process", () => {



            //});

            //RegisterModuleGUI("Info", () => {



            //});

            //RegisterModuleGUI("Monitor", () => {



            //});

            //string settingText = string.Empty;
            //RegisterModuleGUI("Setting", () => {

            //    BlackFireGUI.HorizontalLayout(() => {

            //        BlackFireGUI.BoxHorizontalLayout(()=> {

            //            GUILayout.Label("Window Scale",GUILayout.Width(100));

            //            settingText = GUILayout.TextField(settingText);
            //            float scale = 1f;
            //            if (float.TryParse(settingText,out scale))
            //            {
            //                if (3f >= scale && 1f <= scale)
            //                {
            //                    m_WindowScale = scale;
            //                }
            //            }

            //            if (GUILayout.Button("-"))
            //            {
            //                m_WindowScale -= 0.1f;
            //            }

            //            if (GUILayout.Button("+"))
            //            {
            //                m_WindowScale += 0.1f;
            //            }

            //        });

            //    });

            //});

            //RegisterModuleGUI("Framework", () => {

            //    GUILayout.Label("Version:1.0.0");

            //});

            //RegisterModuleGUI("About", () => {

            //    GUILayout.Label("BlackFire-Studio");

            //});

        }


        private void OnGUI()
        {
            if (m_Minimize)
            {
                DrawMiniDebugger("DEBUGGER", "<color=green>FPS:100</color>");
            }
            else
            {
                DrawFullDebugger("BLACKFIRE FRAMEWORK DEBUGGER", 640f * m_WindowScale, 360f * m_WindowScale);
            }
        }



        private void DrawMiniDebugger(string title,string content)
        {
            GUI.backgroundColor = Color.black;
            BlackFireGUI.Window(0, title , 10, 10, 100, 50, id => {
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                {

                    GUI.backgroundColor = Color.black;
                    if (GUILayout.Button(content, new GUIStyle("Button") { fontSize = 14, fixedHeight = 30 }))
                    {
                        m_Minimize = false;
                    }
                    
                    GUI.backgroundColor = Color.black;

                }
                GUILayout.EndHorizontal();

            });
            GUI.backgroundColor = Color.black;
        }

        private void DrawFullDebugger(string title,float width,float height)
        {
            BlackFireGUI.BackgroundColor(Color.black, () =>
            {

                BlackFireGUI.Window(1, title, 10, 10, width, height, id => {

                    GUILayout.Space(10);

                    BlackFireGUI.HorizontalLayout(() => {

                        //左侧导航栏
                        BlackFireGUI.BoxVerticalLayout(()=> {

                            BlackFireGUI.ScrollView(0, sid => {

                            GUILayout.BeginVertical();
                            {
                                foreach (var k in m_DrawModuleCallbackDic.Keys)
                                {
                                    if (GUILayout.Button(k, new GUIStyle("Button") { fontSize = 14, fixedHeight = 25 }))
                                    {
                                        m_SelectedModuleName = k;
                                    }
                                }

                            }
                            GUILayout.EndVertical();

                        }, GUILayout.Width(130));

                        },GUILayout.Width(130));

                        //右侧内容栏
                        BlackFireGUI.VerticalLayout(()=> {

                            BlackFireGUI.BoxHorizontalLayout(()=> {

                                GUILayout.Label(m_SelectedModuleName, new GUIStyle("Label") { padding=new RectOffset(0,0,0,0),alignment = TextAnchor.MiddleCenter,fontStyle = FontStyle.Bold});

                            });

                            BlackFireGUI.HorizontalLayout(() => {

                                BlackFireGUI.ScrollView(1, sid => {

                                    BlackFireGUI.VerticalLayout(() => {

                                        if (!string.IsNullOrEmpty(m_SelectedModuleName))
                                        {
                                            m_DrawModuleCallbackDic[m_SelectedModuleName].Invoke(this);
                                        }

                                    });

                                });
                            });

                        });



                    });

                });

            });
        }

        public void RegisterModuleGUI(IDebuggerModuleGUI moduleGUIImpl)
        {
            if (null!= moduleGUIImpl && !m_DrawModuleCallbackDic.ContainsKey(moduleGUIImpl.ModuleName))
            {
                m_DrawModuleCallbackDic.Add(moduleGUIImpl.ModuleName,moduleGUIImpl.OnModuleGUI);
                if (string.IsNullOrEmpty(m_SelectedModuleName))
                {
                    m_SelectedModuleName = moduleGUIImpl.ModuleName;
                }
            }
        }








    }
}
