//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    [InitializeOnLoad]
    public static class GameObjectIconHierachy 
	{
        #region Constructor
        static GameObjectIconHierachy()
        {
            s_HiearchyItemCallback = new EditorApplication.HierarchyWindowItemCallback(DrawHierarchyIcon);
            InitHierachyCallBack();

            var implTyps = BlackFireFramework.Utility.Reflection.GetImplTypes("Assembly-CSharp",typeof(Component));

            for (int i = 0; i < implTyps.Length; i++)
            {
                var attrs = implTyps[i].GetCustomAttributes(typeof(GameObjectIconAttribute),true);
                if (0<attrs.Length)
                {
                    s_ResourcesPathDic.Add(implTyps[i], (attrs[0] as GameObjectIconAttribute).IconPath);
                }

            }

        }

        #endregion

        #region Icon


        private static Dictionary<Type, string> s_ResourcesPathDic = new Dictionary<Type, string>();
        private static Dictionary<Type, Texture2D> s_IconDic = new Dictionary<Type, Texture2D>();

        private static Texture2D GetIcon(Type type)
        {
            if (s_ResourcesPathDic.ContainsKey(type))
            {
                if (!s_IconDic.ContainsKey(type))
                {
                    s_IconDic.Add(type, (Texture2D)Resources.Load(s_ResourcesPathDic[type]));
                }
                return s_IconDic[type];
            }

            return null;
        }

        #endregion

        #region Callback
        private static readonly EditorApplication.HierarchyWindowItemCallback s_HiearchyItemCallback;
        private static void InitHierachyCallBack()
        {
            EditorApplication.hierarchyWindowItemOnGUI = (EditorApplication.HierarchyWindowItemCallback)Delegate.Combine(EditorApplication.hierarchyWindowItemOnGUI, s_HiearchyItemCallback);
        }
        #endregion

        #region Draw
        private static void DrawHierarchyIcon(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null)
            {
                Rect rect = new Rect(selectionRect.x + selectionRect.width - 16f, selectionRect.y, 16f, 16f);

                foreach (var kv in s_ResourcesPathDic)
                {
                    if (gameObject.GetComponent(kv.Key) != null)
                    {
                        GUI.DrawTexture(rect,GetIcon(kv.Key));
                    }
                }
            }
        }

        #endregion

    }
}