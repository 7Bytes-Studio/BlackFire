//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using BlackFireFramework.Game;
using BlackFireFramework.Unity;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFireFramework.Editor
{
    public sealed class ProcessWindow : EditorWindowBase<ProcessWindow>
    {
        private const string c_GameWindowTitle = "Game";
        private const int c_GameWindowId = 1111;
        private const float c_GameWindowTopSpace = 20f;        
        private const float c_GameWindowWidth = 200f;        
        private const float c_GameWindowHeight = 100f;        
        private const float c_ProcessWindowLeftSpace = 20f;
        private const float c_ProcessesDefaultTopSpace = 200f;
        
        private const float c_MaxWindowWidth = 160f;
        private const float c_MaxWindowHeight = 90f;

        private Color ShadowColor = new Color(1f,0f,0f,0.0618f);

        private Color HighlightColor = new Color(0f,1f,0f,0.0618f);
        
        private Dictionary<string,WindowInfo> m_WindowInfoDic = new Dictionary<string, WindowInfo>();

        private int MaxRowProcessWindowCount
        {
            get { return (int)(720f>this.position.width?720f:this.position.width / c_MaxWindowWidth); }
        }

        private bool m_InitOnce;
        private void Init()
        {
            if(m_InitOnce)return;
            
            InitGameWindow();
            GetWindowKVSPosition();
            CheckOrInitGameManagerProcess(); //初始化游戏管家流程。
            m_InitOnce = true;
        }

        private void OnEnable()
        {

        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            SetWindowKVS();
            SetProcessWindowKVSPosition();
        }


        protected override void OnDrawWindow()
        {
            BeginWindows();
            
            Init();
            
            if (EditorApplication.isPlaying) //运行时。
            {
                DrawGameWindow();
                DrawProcessWindows();
            }
            else
            {
                EditorGUILayout.HelpBox("Only drawing when playing.", MessageType.Info);
                m_WindowInfoDic.Clear();
                m_InitOnce = false;
            }
            
            EndWindows();

        }


        private void DrawGameWindow(int id)
        {
            GUI.DragWindow();

            if (EditorApplication.isPlaying) //运行时。
            {
                if (null!=BlackFire.Game)
                {
                    GUILayout.Label(string.Format("ProcessCount : {0}",m_WindowInfoDic.Count-1));
                    GUILayout.Label(string.Format("CurrentProcess : {0}",BlackFire.Game.CurrentProcess.Name));
                    GUILayout.Label(string.Format("LastProcess : {0}",null!=BlackFire.Game.LastProcess?BlackFire.Game.LastProcess.Name:"Null"));
                    GUILayout.Label(string.Format("ModuleWorkingTime : {0:0.00} s",BlackFire.Game.ProcessModuleWorkingTime));
                }
                else
                {
                    GUILayout.Label("        The GameManager must \n        be instantiated.");
                }
            }
            

        }
               
        private void DrawProcessWindow(int id)
        {
            GUI.DragWindow();
            var info = GetWindowInfoById(id);
            GUILayout.Label(string.Format("WorkingTime : {0:0.00} s",info.Process.WorkingTime));
            GUILayout.Label(string.Format("ActivityTime : {0:0.00} s",info.Process.ActivityTime));
            GUILayout.Label(string.Format("LastEnterDate : {0}",info.Process.LastEnterDate.ToShortTimeString()));
            GUILayout.Label(string.Format("LastExitDate : {0}",info.Process.LastExitDate.ToShortTimeString()));
        }

        private WindowInfo GetWindowInfoById(int id)
        {
            foreach (var v in m_WindowInfoDic.Values)
            {
                if (v.Id==id)
                {
                    return v;
                }
            }
            return null;
        }

        private void DrawNodeCurve(Rect start, Rect end,Color? shadowColor=null)
        {
            Vector3 startPos = new Vector3(start.x + start.width/2, start.y + start.height, 0);
            Vector3 endPos = new Vector3(end.x + end.width/2, end.y, 0);
            Vector3 startTan = startPos + Vector3.up * 50;
            Vector3 endTan = endPos - Vector3.up * 50;
            Color shadowCol = shadowColor??new Color(0f,0f,0f,0.0618f);;
            for (int i = 0; i < 3; i++) // Draw a shadow
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
        }
     
        private void AddProcessWindow(ProcessBase process)
        {
            var title = string.IsNullOrEmpty(process.Name)?process.GetType().Name:process.Name;
            if (!m_WindowInfoDic.ContainsKey(title))
            {
                var id = c_GameWindowId + m_WindowInfoDic.Count;
                var pCount = Mathf.Clamp(m_WindowInfoDic.Count - 1,0,int.MaxValue);

                var modCount = pCount % MaxRowProcessWindowCount;
                var yCount = (int)(pCount / MaxRowProcessWindowCount);
//                Debug.LogWarning(pCount+"  "+yCount);
                var x = c_ProcessWindowLeftSpace + modCount * (c_MaxWindowWidth + c_ProcessWindowLeftSpace);
                var y = c_ProcessesDefaultTopSpace+ yCount*(c_MaxWindowHeight+36f);
                
                var rect = new Rect(x,y,c_MaxWindowWidth,c_MaxWindowHeight);
                m_WindowInfoDic.Add(title,new WindowInfo(process,id,title,rect));
            }
        }

        private void GetProcessWindowKVS()
        {
            foreach (var v in m_WindowInfoDic.Values)
            {
                var x = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/x");
                var y = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/y");
                float xv = 0f;
                if (float.TryParse(x,out xv))
                {
                    float yv = 0f;
                    if (float.TryParse(y,out yv))
                    {
                        v.Rect = new Rect(xv,yv,v.Rect.width,v.Rect.height);
                    }
                }
            }
        }

        private bool m_SetPositionOnce = false;
        private void GetWindowKVSPosition()
        {
            if(m_SetPositionOnce) return;
            m_SetPositionOnce = true;
            var x = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/x");
            var y = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/y");
            var w = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/width");
            var h = KVS.GetValue<KVSPlayerPrefs>("ProcessWindow/height");
            float xv = 0f;
            if (float.TryParse(x,out xv))
            {
                float yv = 0f;
                if (float.TryParse(y,out yv))
                {
                    float wv = 0f;
                    if (float.TryParse(w,out wv))
                    {
                        float hv = 0f;
                        if (float.TryParse(h,out hv))
                        {
                            this.position = new Rect(xv,yv,wv,hv);
                            return;
                        }
                    }
                }
            }
            //this.position = new Rect(this.position.x,this.position.y,720f,650f);
        }
        private void SetWindowKVS()
        {
            KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/x",this.position.x.ToString());
            KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/y",this.position.y.ToString());
            KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/width",this.position.width.ToString());
            KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/height",this.position.height.ToString());
            m_SetPositionOnce = false;
        }

        private void SetProcessWindowKVSPosition()
        {
            foreach (var v in m_WindowInfoDic.Values)
            {
                KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/x",v.Rect.x.ToString());
                KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/y",v.Rect.y.ToString());
            }
        }


        private void CheckOrInitGameManagerProcess()
        {
            if (EditorApplication.isPlaying) //运行时。
            {
                if (null!=BlackFire.Game)
                {
                    var processes = BlackFire.Game.GetProcesses();
                    for (int i = 0; i < processes.Length; i++)
                    {
//                    Log.Warn(processes[i].Name);
                        AddProcessWindow(processes[i]);
                    }
                    GetProcessWindowKVS();
                }
            }
        }

        private void InitGameWindow()
        {
            if (!m_WindowInfoDic.ContainsKey(c_GameWindowTitle))
            {
                var x = this.position.width / 2 - c_MaxWindowWidth / 2;
                var y = c_GameWindowTopSpace;
                m_WindowInfoDic.Add(c_GameWindowTitle,new WindowInfo(null,c_GameWindowId,c_GameWindowTitle,new Rect(x,y, c_GameWindowWidth, c_GameWindowHeight)) );
            }
        }


        private void DrawGameWindow()
        {
            if (!m_WindowInfoDic.ContainsKey(c_GameWindowTitle))
            {
                return;
            }
            
            var x = this.position.width / 2 - c_MaxWindowWidth / 2;
            var y = c_GameWindowTopSpace;
            var gameWindowInfo = m_WindowInfoDic[c_GameWindowTitle];
            gameWindowInfo.Rect = GUI.Window(gameWindowInfo.Id,gameWindowInfo.Rect, DrawGameWindow,gameWindowInfo.Title);  
            gameWindowInfo.Rect = new Rect(x,y,gameWindowInfo.Rect.width,gameWindowInfo.Rect.height);
        }


        
        private void DrawProcessWindows()
        {
            foreach (var v in m_WindowInfoDic.Values)
            {
                //Debug.LogWarning(m_WindowInfoDic.Count+"  "+v.Title);
                if (v.Id==c_GameWindowId)
                {
                    continue;
                }
                v.Rect = GUI.Window(v.Id,v.Rect,DrawProcessWindow,v.Title); 
                DrawNodeCurve(m_WindowInfoDic[c_GameWindowTitle].Rect,v.Rect,v.Process.IsWorking?HighlightColor:ShadowColor);
            }
        }
        
      
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private sealed class WindowInfo
        {
            public WindowInfo(ProcessBase process,int id,string title,Rect rect)
            {
                this.Process = process;
                this.Id = id;
                this.Title = title;
                this.Rect = rect;
            }
            
            public int Id;
            public string Title;
            public Rect Rect;

            #region Process

            public ProcessBase Process;
            
            #endregion
            
        }




    }
}
