//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(BlackFire))]
    public sealed class BlackFireInspector : InspectorBase
    {
        private float m_MinGameSpeed = 0f;
        private float m_MaxGameSpeed = 100f;
        private bool m_FoldOutAbout = true;
        private bool m_FoldOutSetting = true;

        private SerializedProperty m_DontDestroyProperty = null;
        private SerializedProperty m_LogoProperty = null;
        private SerializedProperty m_AssemblyListProperty = null;
        private Texture m_Logo=null;


        private ReorderableList m_ReorderableList = null;

       

        public override InspectorSetting Setting { get { return new InspectorSetting(); } }

        private void OnEnable()
        {
            m_DontDestroyProperty = serializedObject.FindProperty("m_DontDestroy");
            m_LogoProperty = serializedObject.FindProperty("m_Logo");
            m_AssemblyListProperty = serializedObject.FindProperty("m_AssemblyList");
        }

        

        protected override void OnDrawInspector()
        {
            serializedObject.Update(); //更新被序列化的对象上的数据

            if ( null == m_LogoProperty.objectReferenceValue && null == m_Logo )
            {
                m_Logo = EditorGUILayout.ObjectField(m_Logo, typeof(Texture), true) as Texture;
                m_LogoProperty.objectReferenceValue = m_Logo;
            }
            else
            {
                m_Logo = m_LogoProperty.objectReferenceValue as Texture;
                BlackFireEditorGUI.DrawTexture(m_Logo,15,2048,144);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (m_FoldOutAbout = BlackFireEditorGUI.FoldOut("About", m_FoldOutAbout,"yellow"))
            {

                BlackFireEditorGUI.BoxVerticalLayout(() => {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("BlackFire Framework Version 1.1.1.180428_beta.");
                    EditorGUILayout.LabelField("Copyright © 2008-2018 BlackFire-Studio. All Rights Reserved.");
                    EditorGUILayout.Space();
                });

                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }


            if (m_FoldOutSetting = BlackFireEditorGUI.FoldOut("Setting", m_FoldOutSetting, "yellow"))
            {
                BlackFireEditorGUI.BoxVerticalLayout(() => {
                    BlackFireEditorGUI.Label("Mode", Color.green);
                    m_DontDestroyProperty.boolValue = EditorGUILayout.ToggleLeft("DontDestroy", m_DontDestroyProperty.boolValue);
                    BlackFireEditorGUI.Space(2);
                    DrawAssemblyList(); //绘制程序集列表
                });

                BlackFireEditorGUI.Space(2);
            }












            serializedObject.ApplyModifiedProperties();//应用被修改的属性
        }



        private void DrawAssemblyList()
        {
            BlackFireEditorGUI.Label("Assemblies", Color.green);
            m_ReorderableList = BlackFireEditorGUI.ReorderableList("BlackFire Framework Extended Assemblies", serializedObject,m_AssemblyListProperty);
            GUILayout.Space(2);
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Reset"))
            {
                GetFrameworkReferencedAssemblies();
            }
            GUI.backgroundColor = Color.white;
            GUI.backgroundColor = Color.cyan;
            GUILayout.Space(2);
            m_ReorderableList.DoLayoutList();

            GUI.backgroundColor = Color.white;
        }

        private void GetFrameworkReferencedAssemblies()
        {
            var fwAssemblyName = typeof(Framework).Assembly.GetName().Name;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<string> assemblyList = new List<string>();
            for (int i = 0; i < assemblies.Length; i++)
            {
                if (assemblies[i].GetName().Name.Contains("Assembly-CSharp")) continue; //过滤运行时项目程序集跟编辑器程序集。

                foreach (var assebly in assemblies[i].GetReferencedAssemblies())
                {
                    if (assebly.Name == fwAssemblyName)
                    {
                        assemblyList.Add(assemblies[i].GetName().Name);
                        break;
                    }
                }
            }

            m_AssemblyListProperty.arraySize = assemblyList.Count;
            for (int i = 0; i < assemblyList.Count; i++)
            {
                m_AssemblyListProperty.GetArrayElementAtIndex(i).stringValue = assemblyList[i];
            }

        }
    }
}
