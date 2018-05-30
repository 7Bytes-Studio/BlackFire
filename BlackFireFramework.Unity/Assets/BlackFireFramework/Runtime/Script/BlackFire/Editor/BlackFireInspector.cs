//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(BlackFire))]
    internal sealed class BlackFireInspector : InspectorBase
    {
        private float m_MinGameSpeed = 0f;
        private float m_MaxGameSpeed = 100f;

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
            InitAssemblyList(); //初始化程序集可排序列表。
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

        private bool m_FoldOutAbout= true;
        private bool m_FoldOutSetting = true;

        private void InitAssemblyList()
        {
            m_ReorderableList = new ReorderableList(serializedObject, m_AssemblyListProperty);
            //提示内容
            m_ReorderableList.drawHeaderCallback = (Rect rect) =>
            {
                GUI.Label(rect, "BlackFire Framework Extended Assemblies");
            };

            //绘制文本框
            m_ReorderableList.drawElementCallback = (rect, index, isActive, isFocused) => {
                SerializedProperty itemData = m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                rect.height = EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(rect, itemData, GUIContent.none);
            };
        }

        private void DrawAssemblyList()
        {
            BlackFireEditorGUI.Label("Assemblies", Color.green);
            m_ReorderableList.DoLayoutList();
        }


        private int m_AssemblyListIndex = 0;
        private void DrawAssemblyPop()
        {
            BlackFireFramework.Utility.Reflection.GetImplTypes(typeof(IExportedAssembly));

            BlackFireEditorGUI.ArrayPopup("AssemblyList",ref m_AssemblyListIndex,);
        }
    }
}
