//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using BlackFireFramework.Unity;
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
        private const float c_ProcessWindowLeftSpace = 20f;
        private const float c_ProcessesDefaultTopSpace = 200f;
        
        private const float c_MaxWindowWidth = 160f;
        private const float c_MaxWindowHeight = 90f;


        private Dictionary<string,WindowInfo> m_WindowInfoDic = new Dictionary<string, WindowInfo>();
        

        private void OnEnable()
        {
            InitGameWindow();
            AddProcessWindow("GameStart");
            AddProcessWindow("GameHotUpdate");
            AddProcessWindow("GameMainMenu");
            AddProcessWindow("GameContest");
            AddProcessWindow("GameEnd");
            GetKVS();
        }

        private void OnDestroy()
        {
            SetKVS();
        }


        protected override void OnDrawWindow()
        {
            BeginWindows();
            DrawGameWindow();
            DrawProcessWindows();
            EndWindows();
        }
        
        
        
        private void DrawGameWindow(int id)
        {
            GUI.DragWindow();

        }
        
        

        private void DrawProcessWindow(int id)
        {
            GUI.DragWindow();
            GUILayout.Label("TotalTime:");
            GUILayout.Label("EnterTime:");
            GUILayout.Label("ExitTime:");
            GUILayout.Label("CurrentTime:");
        }
        

        private void DrawNodeCurve(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(start.x + start.width/2, start.y + start.height, 0);
            Vector3 endPos = new Vector3(end.x + end.width/2, end.y, 0);
            Vector3 startTan = startPos + Vector3.up * 50;
            Vector3 endTan = endPos - Vector3.up * 50;
            Color shadowCol = new Color(0, 0, 0, 0.06f);
            for (int i = 0; i < 3; i++) // Draw a shadow
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
        }

            
        //让窗口高亮。
        private void HighlightWindow(string windowName)
        {
            
        }

        
        private void AddProcessWindow(string title)
        {
            if (!m_WindowInfoDic.ContainsKey(title))
            {
                var id = c_GameWindowId + m_WindowInfoDic.Count-1;
                var pCount = Mathf.Clamp(m_WindowInfoDic.Count - 2,0,int.MaxValue);
                var rect = new Rect(c_ProcessWindowLeftSpace+pCount*(c_MaxWindowWidth+c_ProcessWindowLeftSpace),c_ProcessesDefaultTopSpace,c_MaxWindowWidth,c_MaxWindowHeight);
                m_WindowInfoDic.Add(title,new WindowInfo(id,title,rect));
            }
        }

        private void GetKVS()
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

        private void SetKVS()
        {
            foreach (var v in m_WindowInfoDic.Values)
            {
                KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/x",v.Rect.x.ToString());
                KVS.SetValue<KVSPlayerPrefs>("ProcessWindow/"+v.Title+"/y",v.Rect.y.ToString());
            }
        }

        private void InitGameWindow()
        {
            var x = this.position.width / 2 - c_MaxWindowWidth / 2;
            var y = c_GameWindowTopSpace;
            m_WindowInfoDic.Add(c_GameWindowTitle,new WindowInfo(c_GameWindowId,c_GameWindowTitle,new Rect(x,y, c_MaxWindowWidth, c_MaxWindowHeight)) );
        }


        private void DrawGameWindow()
        {
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
                if (v.Id==c_GameWindowId)
                {
                    continue;
                }
                v.Rect = GUI.Window(v.Id,v.Rect,DrawProcessWindow,v.Title); 
                DrawNodeCurve(m_WindowInfoDic[c_GameWindowTitle].Rect,v.Rect);
            }
        }
        
        private sealed class WindowInfo
        {
            public WindowInfo(int id,string title,Rect rect)
            {
                this.Title = title;
                this.Id = id;
                this.Rect = rect;
            }
            
            public int Id;
            public string Title;
            public Rect Rect;
        }




    }
}
