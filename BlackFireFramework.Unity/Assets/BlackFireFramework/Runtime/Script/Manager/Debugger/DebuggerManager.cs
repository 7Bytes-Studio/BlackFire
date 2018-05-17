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
        public float WindowScale { get { return m_WindowScale; } set { m_WindowScale = value; } }

        private bool m_Minimize = true;

        private string m_SelectedModuleName = string.Empty;

        private Dictionary<string, Action> m_DrawModuleCallbackDic = new Dictionary<string, Action>();

        private List<IDebuggerModuleGUI> m_DebuggerModuleGUIList = new List<IDebuggerModuleGUI>();





        private void Awake()
        {
            InitDebuggerModuleGUI();

            #region Test



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



            //RegisterModuleGUI("Framework", () => {

            //    GUILayout.Label("Version:1.0.0");

            //});

            //RegisterModuleGUI("About", () => {

            //    GUILayout.Label("BlackFire-Studio");

            //});

            #endregion

        }


        private void OnGUI()
        {
            if (m_Minimize)
            {
                DrawMiniDebugger("<b>DEBUGGER</b>", "<color=green>FPS:100</color>");
            }
            else
            {
                DrawFullDebugger("<b>BLACKFIRE FRAMEWORK DEBUGGER</b>", 640f * m_WindowScale, 360f * m_WindowScale);
            }
        }


        private void OnDestroy()
        {
            DestroyDebuggerModuleGUI();
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
                                            m_DrawModuleCallbackDic[m_SelectedModuleName].Invoke();
                                        }

                                    });

                                });
                            });

                        });



                    });

                });

            });
        }

        private void InitDebuggerModuleGUI()
        {
            var types = Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(IDebuggerModuleGUI));

            for (int i = 0; i < types.Length; i++)
            {
                IDebuggerModuleGUI ins = (IDebuggerModuleGUI)Utility.Reflection.New(types[i]);
                m_DebuggerModuleGUIList.Add(ins);
            }

            m_DebuggerModuleGUIList.Sort((x,y)=>x.Priority-y.Priority);

            for (int i = 0; i < m_DebuggerModuleGUIList.Count; i++)
            {
                if (null != m_DebuggerModuleGUIList[i])
                {
                    m_DebuggerModuleGUIList[i].OnInit(this);
                    RegisterModuleGUI(m_DebuggerModuleGUIList[i]);
                }
            }
        }

        private void DestroyDebuggerModuleGUI()
        {
            for (int i = 0; i < m_DebuggerModuleGUIList.Count; i++)
            {
                m_DebuggerModuleGUIList[i].OnDestroy();
            }
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
