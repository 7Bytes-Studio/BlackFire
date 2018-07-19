//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(DoubleClickButton), true)]
    [CanEditMultipleObjects]
    public sealed class DoubleClickButtonEditor : ButtonEditor
    {
        private SerializedProperty m_OnDoubleClickProperty; 
        private SerializedProperty m_DoubleClickIntervelProperty; 

        protected override void OnEnable()
        {
            base.OnEnable();
            m_OnDoubleClickProperty = serializedObject.FindProperty("m_OnDoubleClick");
            m_DoubleClickIntervelProperty = serializedObject.FindProperty("m_DoubleClickIntervel");
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.PropertyField(m_DoubleClickIntervelProperty);
            EditorGUILayout.PropertyField(m_OnDoubleClickProperty);

            serializedObject.ApplyModifiedProperties();
        }

    }
}
