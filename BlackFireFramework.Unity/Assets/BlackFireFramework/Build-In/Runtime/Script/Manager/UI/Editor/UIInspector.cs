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
    [CustomEditor(typeof(UIManager))]
    [DisallowMultipleComponent]
    public sealed class UIInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
                return new InspectorSetting();
            }
        }

        //private UIManager m_UIManager = null;

        private SerializedProperty m_SP_IUIEventDataHelperTypeFullName = null;
  


        private Type[] m_ImplTypes = null;
        private int m_PopupIndex = 0;

        private void OnEnable()
        {
            //m_UIManager = target as UIManager;
            m_SP_IUIEventDataHelperTypeFullName = serializedObject.FindProperty("m_IUIEventDataHelperTypeFullName");
            m_ImplTypes = BlackFireFramework.Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(IUIEventDataHelper));
        }

        protected override void OnDrawInspector()
        {
            GUILayout.Space(15);
            DrawHelperPopup(m_ImplTypes);
        }

        private void DrawHelperPopup(Type[] implTypes)
        {
            string[] array = new string[implTypes.Length];
            for (int i = 0; i < m_ImplTypes.Length; i++)
            {
                array[i] = m_ImplTypes[i].FullName;
            }
            BlackFireEditorGUI.ArrayPopup("UIEventDataHelper", ref m_PopupIndex, array);
            m_SP_IUIEventDataHelperTypeFullName.stringValue = array[m_PopupIndex];
        }

    }
}
