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
	public static class BlackFireGUI 
	{
        private static Dictionary<int,Rect> s_WindowRectDic = new Dictionary<int, Rect>();
        private static Dictionary<int,Vector2> s_ScrollViewVector2Dic = new Dictionary<int, Vector2>();


        #region ScrollView

        public static void ScrollView(int scrollId, Action<int> drawCallback,params GUILayoutOption[] gUILayoutOptions)
        {
            if (!s_ScrollViewVector2Dic.ContainsKey(scrollId))
            {
                s_ScrollViewVector2Dic.Add(scrollId,Vector2.zero);
            }

            s_ScrollViewVector2Dic[scrollId] = GUILayout.BeginScrollView(s_ScrollViewVector2Dic[scrollId],gUILayoutOptions);
            {
                if (null!= drawCallback)
                {
                    drawCallback.Invoke(scrollId);
                }
            }
            GUILayout.EndScrollView();
        }


        #endregion


        #region Window

        public static void Window(int windowId,string title,float x,float y,float width,float height,Action<int> drawWindowCallbak,float dragHeight=15f,Texture texture=null)
        {
            if (!s_WindowRectDic.ContainsKey(windowId))
            {
                s_WindowRectDic.Add(windowId, new Rect(x,y,width,height));
            }

            s_WindowRectDic[windowId] = new Rect(s_WindowRectDic[windowId].x, s_WindowRectDic[windowId].y, width,height);

            s_WindowRectDic[windowId] = null == texture 
            
            ? GUILayout.Window(windowId, s_WindowRectDic[windowId], id =>
            {

                GUI.DragWindow(new Rect(0, 0, s_WindowRectDic[windowId].width, dragHeight));
                if (null != drawWindowCallbak)
                {
                    drawWindowCallbak.Invoke(id);
                }

            }, title)
            : GUILayout.Window(windowId, s_WindowRectDic[windowId], id =>
            {

                GUI.DragWindow(new Rect(0, 0, s_WindowRectDic[windowId].width, dragHeight));
                if (null != drawWindowCallbak)
                {
                    drawWindowCallbak.Invoke(id);
                }

            },texture, title); 


        }

        #endregion

        #region Layout

        public static void BackgroundColor(Color color,Action callback)
        {
            GUI.backgroundColor = color;
            if (null!= callback)
            {
                callback.Invoke();
            }
            GUI.backgroundColor = Color.white;
        }

        public static void HorizontalLayout(Action callback,params GUILayoutOption[] gUILayoutOptions)
        {
            GUILayout.BeginHorizontal(gUILayoutOptions);
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            GUILayout.EndHorizontal();
        }

        public static void VerticalLayout(Action callback, params GUILayoutOption[] gUILayoutOptions)
        {
            GUILayout.BeginVertical(gUILayoutOptions);
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            GUILayout.EndVertical();
        }


        public static void BoxHorizontalLayout(Action callback, params GUILayoutOption[] gUILayoutOptions)
        {
            GUILayout.BeginHorizontal("box", gUILayoutOptions);
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            GUILayout.EndHorizontal();
        }

        public static void BoxVerticalLayout(Action callback, params GUILayoutOption[] gUILayoutOptions)
        {
            GUILayout.BeginVertical("box", gUILayoutOptions);
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            GUILayout.EndVertical();
        }



        #endregion

    }
}
