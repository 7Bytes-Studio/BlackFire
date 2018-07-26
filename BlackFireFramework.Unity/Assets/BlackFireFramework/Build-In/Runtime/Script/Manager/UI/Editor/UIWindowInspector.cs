//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Game;

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(UIWindow))]
    [DisallowMultipleComponent]
    public sealed class UIWindowInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
                return new InspectorSetting();
            }
        }


        private void OnEnable()
        {

        }

        //private bool m_WindowInfoFoldOut = true;
        protected override void OnDrawInspector()
        {
            var uiWindow = target as UIWindow;
            GUILayout.Space(15);
            BlackFireEditorGUI.BoxVerticalLayout(() => {
                if (null != uiWindow.WindowInfo)
                {
                    BlackFireEditorGUI.HorizontalLayout(() => {
                        BlackFireEditorGUI.Label("WindowInfo:");
                    });
                    BlackFireEditorGUI.HorizontalLayout(() => {
                        if (null != uiWindow.WindowInfo)
                        {
                            BlackFireEditorGUI.Label(uiWindow.WindowInfo.ToString());
                        }
                    });
                }
                else
                {
                    BlackFireEditorGUI.HorizontalLayout(() => {
                        BlackFireEditorGUI.Label("WindowInfo : Empty");
                    });
                }

            });



            //m_WindowInfoFoldOut = BlackFireEditorGUI.FoldOut("WindowInfo", m_WindowInfoFoldOut);
            //if (m_WindowInfoFoldOut)
            //{
            //    BlackFireEditorGUI.Label(uiWindow.ToString());
            //}
        }

    }
}
