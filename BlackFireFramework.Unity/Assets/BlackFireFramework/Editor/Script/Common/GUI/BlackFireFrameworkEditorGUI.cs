//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    /// <summary>
    /// Sparrow 的Editor GUI辅助类。
    /// </summary>
	public static class BlackFireFrameworkEditorGUI
    {
        #region Layout

        public static void Space(int spaceCount)
        {
            for (int i = 0; i < spaceCount; i++)
                EditorGUILayout.Space();

        }

        public static void Space(float spaceValue)
        {
            GUILayout.Space(spaceValue);
        }

        public static void HorizontalLayout(Action callback)
        {
            EditorGUILayout.BeginHorizontal();
            {
                if (null!= callback)
                {
                    callback.Invoke();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        public static void VerticalLayout(Action callback)
        {
            EditorGUILayout.BeginVertical();
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            EditorGUILayout.EndVertical();
        }

        public static void DisabledLayout(Action callback)
        {
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            EditorGUI.EndDisabledGroup();
        }

        public static void BoxHorizontalLayout(Action callback)
        {
            EditorGUILayout.BeginHorizontal("box");
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        public static void BoxVerticalLayout(Action callback)
        {
            EditorGUILayout.BeginVertical("box");
            {
                if (null != callback)
                {
                    callback.Invoke();
                }
            }
            EditorGUILayout.EndVertical();
        }



        #endregion

        #region Button

        public static void Button(string label, Action callback=null)
        {
            bool result = GUILayout.Button(label);

            if (null != callback && result)
            {
                callback.Invoke();
            } 
        }

        public static void Button(string label, Color color, int width, Action callback = null, bool leftAligment = false, int height = 0)
        {

            GUI.backgroundColor = color;
            GUIStyle buttonStyle = new GUIStyle("Button");

            if (leftAligment)
                buttonStyle.alignment = TextAnchor.MiddleLeft;

            if (height == 0)
            {
                if (GUILayout.Button(label, buttonStyle, GUILayout.Width(width)))
                {
                    GUI.backgroundColor = Color.white;
                    if (null!= callback)
                    {
                        callback.Invoke();
                    }
                }
            }
            else
            {
                if (GUILayout.Button(label, buttonStyle, GUILayout.Width(width), GUILayout.Height(height)))
                {
                    GUI.backgroundColor = Color.white;
                    if (null != callback)
                    {
                        callback.Invoke();
                    }
                }
            }
            GUI.backgroundColor = Color.white;
        }


        #endregion

        #region Label

        public static void Label(string label)
        {
            GUILayout.Label(label);
        }

        public static void Label(string label,Color color)
        {
            GUIStyle buttonStyle = new GUIStyle("Label");
            buttonStyle.normal.textColor = color;
            GUILayout.Label(label, buttonStyle);
        }


        #endregion

        #region TextField

        public static void InputField(ref string text, int width,bool passwordType = false,char passwordMaskChar='*')
        {
            if (passwordType)
            {
                text = GUILayout.PasswordField(text, passwordMaskChar, GUILayout.Width(width));
            }
            else
            {
                text = GUILayout.TextField(text, GUILayout.Width(width));
            }
        }


        #endregion

        #region Toggle


        public static void Toggle(string text, ref bool value, bool leftToggle = false, bool useBgColor = false)
        {

            if (useBgColor)
                GUI.backgroundColor = value ? Color.green : Color.red;

            if (leftToggle)
            {
                value = EditorGUILayout.ToggleLeft(text, value);
            }
            else
            {
                value = EditorGUILayout.Toggle(text, value);
            }
            if (useBgColor)
                GUI.backgroundColor = Color.white;

        }

        #endregion

        #region 2d effect
        public static void DrawSeparatorLine(int padding = 0)
        {

            EditorGUILayout.Space();
            DrawLine(Color.gray, padding);
            EditorGUILayout.Space();
        }

        public static void DrawLine(Color color, int padding = 0)
        {

            GUILayout.Space(10);
            Rect lastRect = GUILayoutUtility.GetLastRect();

            GUI.color = color;
            GUI.DrawTexture(new Rect(padding, lastRect.yMax - lastRect.height / 2f, Screen.width, 1f), EditorGUIUtility.whiteTexture);
            GUI.color = Color.white;
        }


        #endregion

        #region Texture

        public static void DrawTexture(Texture texture, int padding, int width, int height)
        {

            GUILayout.Space(height);
            Rect lastRect = GUILayoutUtility.GetLastRect();
            lastRect.yMin = lastRect.yMin + 7;
            lastRect.yMax = lastRect.yMax - 7;
            lastRect.width = Screen.width;

            GUI.DrawTexture(new Rect(padding, lastRect.yMin + 1, width, lastRect.yMax - lastRect.yMin), texture);
        }

        #endregion

        #region FoldOut



        public static bool FoldOut(string text, bool foldOut,string color = "white", bool endSpace = true)
        {
            text = "<b><size=11><color="+color+">" + text + "</color></size></b>";
            if (foldOut)
            {
                text = "\u25BC " + text;
            }
            else
            {
                text = "\u25BA " + text;
            }

            if (!GUILayout.Toggle(true, text, "dragtab"))
            {
                foldOut = !foldOut;
            }

            if (!foldOut && endSpace) GUILayout.Space(5f);

            return foldOut;
        }

        public static void FoldOut(string text,ref bool foldOut, bool endSpace = true)
        {
            FoldOut(text,ref foldOut,endSpace);
        }


        #endregion

        #region Popup

        public static Enum EnumPopup(string text,Enum @enum) 
        {
           return EditorGUILayout.EnumPopup(text,@enum);
        }

        public static void ArrayPopup(string text,ref int selectedIndex,string[] displayedOptions)
        {
            selectedIndex = EditorGUILayout.Popup(text, selectedIndex, displayedOptions);
        }




        #endregion

        #region Window


        #endregion
    }
}
