//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
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
        #region Public

        public float WindowScale { get { return m_WindowScale; } set { m_WindowScale = value; } }

        public DebuggerStyle DebuggerStyle { get { return m_DebuggerStyle; } set { m_DebuggerStyle = value; } }


        public void RegisterModuleGUI(IDebuggerModuleGUI moduleGUIImpl)
        {
            if (null != moduleGUIImpl && !m_DrawModuleCallbackDic.ContainsKey(moduleGUIImpl.ModuleName))
            {
                m_DrawModuleCallbackDic.Add(moduleGUIImpl.ModuleName, moduleGUIImpl.OnModuleGUI);
                if (string.IsNullOrEmpty(m_SelectedModuleName))
                {
                    m_SelectedModuleName = moduleGUIImpl.ModuleName;
                }
            }
        }


        #endregion


        [SerializeField] private DebuggerStyle m_DebuggerStyle = DebuggerStyle.Hidden;
        [SerializeField][Range(1f,3f)] private float m_WindowScale=1f;

        private string m_SelectedModuleName = string.Empty;

        private Dictionary<string, Action> m_DrawModuleCallbackDic = new Dictionary<string, Action>();

        private List<IDebuggerModuleGUI> m_DebuggerModuleGUIList = new List<IDebuggerModuleGUI>();

        private string m_MiniDebuggerHexColor = "white";
        private bool HasErrorOrException = false;

        private Func<DebuggerManager, bool> m_PackUpCallback = null;



        private void Awake()
        {
            CheckErrorOrException();
            InitDebuggerModuleGUI();
            InitDebuggerPackUp();
        }

        private void OnGUI()
        {
            switch (m_DebuggerStyle)
            {
                case DebuggerStyle.Hidden:
                    //Todo...
                    break;
                case DebuggerStyle.Mini:
                    DrawMiniDebugger("<b>DEBUGGER</b>");
                    break;
                case DebuggerStyle.Full:
                    DrawFullDebugger("<b>BLACKFIRE FRAMEWORK DEBUGGER</b>", 640f * m_WindowScale, 360f * m_WindowScale);
                    break;
                default:
                    break;
            }

            if (null!= m_PackUpCallback && m_PackUpCallback.Invoke(this))
            {
                m_DebuggerStyle = DebuggerStyle.Mini;
            }
        }

        private void OnDestroy()
        {
            DestroyDebuggerModuleGUI();
        }

        private void DrawMiniDebugger(string title)
        {
            var fps = Unity.Utility.Game.Fps();
            if (HasErrorOrException)
            {
                SetMiniDebuggerColor("#CC0000");
            }
            else if (60f <= fps)
            {
                SetMiniDebuggerColor("#009900");
            }
            else if (60f > fps)
            {
                SetMiniDebuggerColor("#00CCFF");
            }
            else if (50f > fps)
            {
                SetMiniDebuggerColor("#FFFFCC");
            }
            else if (40f > fps)
            {
                SetMiniDebuggerColor("#FFFF99");
            }
            else if (30f > fps)
            {
                SetMiniDebuggerColor("#FFFF66");
            }
            else if (20f > fps)
            {
                SetMiniDebuggerColor("#FFFF33");
            }
            else if (10f > fps)
            {
                SetMiniDebuggerColor("#FFFF00");
            }

            var fpsStr = string.Format("FPS : {0:00.00}", fps).HexColor(m_MiniDebuggerHexColor);

            Rect rect = BlackFireGUI.GetWindowRect(1);
            float x, y;
            if (rect != Rect.zero)
            {
                x = rect.x;
                y = rect.y;
            }
            else
            {
                x = 10;
                y = 10;
            }

            GUI.backgroundColor = Color.black;
            BlackFireGUI.Window(0, title , x, y, 100, 50, id => {
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                {

                    GUI.backgroundColor = Color.black;
                    if (GUILayout.Button(fpsStr, new GUIStyle("Button") { fontSize = 14, fixedHeight = 30 }))
                    {
                        m_DebuggerStyle =  DebuggerStyle.Full;
                    }
                    
                    GUI.backgroundColor = Color.black;

                }
                GUILayout.EndHorizontal();

            });
            GUI.backgroundColor = Color.black;
        }

        private void DrawFullDebugger(string title,float width,float height)
        {
            Rect rect = BlackFireGUI.GetWindowRect(0);
            float x, y;
            if (rect != Rect.zero)
            {
                x = rect.x;
                y = rect.y;
            }
            else
            {
                x = 10;
                y = 10;
            }

            BlackFireGUI.BackgroundColor(Color.black, () =>
            {

                BlackFireGUI.Window(1, title, x, y, width, height, id => {

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

        private void InitDebuggerPackUp()
        {
            var types = Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(IDebuggerPackUp));
            List<IDebuggerPackUp> list = new List<IDebuggerPackUp>();
            for (int i = 0; i < types.Length; i++)
            {
                IDebuggerPackUp ins = (IDebuggerPackUp)Utility.Reflection.New(types[i]);
                list.Add(ins);
            }

            list.Sort((x, y) => x.Priority - y.Priority);

            if (0<list.Count)
            {
                m_PackUpCallback = new Func<DebuggerManager, bool>(list[0].PackUp);
            }
        }

        private void CheckErrorOrException()
        {
            Application.logMessageReceived += (msg, st, tp) =>
            {
                if (!HasErrorOrException)
                {
                    if (tp == LogType.Error || tp == LogType.Exception)
                    {
                        HasErrorOrException = true;
                    }
                }
            };

        }

        private void DestroyDebuggerModuleGUI()
        {
            for (int i = 0; i < m_DebuggerModuleGUIList.Count; i++)
            {
                m_DebuggerModuleGUIList[i].OnDestroy();
            }
        }

        private void SetMiniDebuggerColor(string hexColor)
        {
            m_MiniDebuggerHexColor = hexColor;
        }








    }
}
