//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using BlackFireFramework.Unity;
using Boo.Lang;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(BlackFire))]
    public sealed class BlackFireInspector : InspectorBase
    {

        private SerializedProperty m_SP_DontDestroy = null;
        private SerializedProperty m_SP_Logo = null;
        private SerializedProperty m_SP_AssemblyList = null;
        private SerializedProperty m_SP_IoCRegisters = null;
        private SerializedProperty m_SP_AvailableIoCRegisters = null;
        
        private SerializedProperty m_SP_FoldOutAbout = null;
        private SerializedProperty m_SP_FoldOutSetting = null;
        private SerializedProperty m_SP_FoldOutIoC = null;
        
        
        
        private Texture m_Logo=null;
        private Texture m_LogoRes = null;

        private ReorderableList m_ReorderableList = null;

        public override InspectorSetting Setting { get { return new InspectorSetting(); } }

        private void OnEnable()
        {
            m_SP_DontDestroy = serializedObject.FindProperty("m_DontDestroy");
            m_SP_Logo = serializedObject.FindProperty("m_Logo");
            m_SP_AssemblyList = serializedObject.FindProperty("m_AssemblyList");
            m_SP_IoCRegisters = serializedObject.FindProperty("m_IoCRegisters");
            m_SP_AvailableIoCRegisters = serializedObject.FindProperty("m_AvailableIoCRegisters");
            m_SP_FoldOutAbout = serializedObject.FindProperty("m_FoldOutAbout");
            m_SP_FoldOutSetting = serializedObject.FindProperty("m_FoldOutSetting");
            m_SP_FoldOutIoC = serializedObject.FindProperty("m_FoldOutIoC");
           
            if(null==m_LogoRes)
                m_LogoRes = BlackFireEditor.Load<Texture>("BlackFire.Logo.png");
            m_ReorderableList = BlackFireEditorGUI.ReorderableList("BlackFire Framework Extended Assemblies", serializedObject, m_SP_AssemblyList);
            ReflectIoCRegisterTypesInfo();
        }

 

        protected override void OnDrawInspector()
        {
            serializedObject.Update(); //更新被序列化的对象上的数据
            EditorGUILayout.Space();
            DrawLogo();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (m_SP_FoldOutAbout.boolValue = BlackFireEditorGUI.FoldOut("About", m_SP_FoldOutAbout.boolValue,"yellow"))
            {

                BlackFireEditorGUI.BoxVerticalLayout(() => {
                    EditorGUILayout.Space();
                EditorGUILayout.LabelField(string.Format("BlackFire Framework Version {0}.",Framework.Info.Version));
                    EditorGUILayout.LabelField("Copyright © 2008-2018 BlackFire-Studio. All Rights Reserved.");
                    EditorGUILayout.Space();
                });

                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }


            if (m_SP_FoldOutSetting.boolValue = BlackFireEditorGUI.FoldOut("Setting", m_SP_FoldOutSetting.boolValue, "yellow"))
            {
                BlackFireEditorGUI.BoxVerticalLayout(() => {
                    BlackFireEditorGUI.Label("Mode", Color.green);
                    m_SP_DontDestroy.boolValue = EditorGUILayout.ToggleLeft("DontDestroy", m_SP_DontDestroy.boolValue);
                    BlackFireEditorGUI.Space(2);
                    DrawAssemblyList(); //绘制程序集列表
                });

                BlackFireEditorGUI.Space(2);
            }
            
            
            if (m_SP_FoldOutIoC.boolValue = BlackFireEditorGUI.FoldOut("IoC", m_SP_FoldOutIoC.boolValue, "yellow"))
            {
                BlackFireEditorGUI.BoxVerticalLayout(() => {
                    BlackFireEditorGUI.Label("Registers", Color.green);
                    DrawIoCList();
                    BlackFireEditorGUI.Space(2);
                });


            }

            










            serializedObject.ApplyModifiedProperties();//应用被修改的属性
        }




        private void DrawLogo()
        {
            if (null == m_LogoRes)
            {
                if (null == m_Logo)
                {
                    m_Logo = EditorGUILayout.ObjectField(m_SP_Logo.objectReferenceValue, typeof(Texture), true) as Texture;
                }
                else
                {
                    m_SP_Logo.objectReferenceValue = m_Logo;
                    BlackFireEditorGUI.DrawTexture(m_Logo, 15, 2048, 144);
                }
            }
            else
            {
                m_Logo = Instantiate<Texture>(m_LogoRes);
                BlackFireEditorGUI.DrawTexture(m_Logo, 15, 2048, 144);
            }
        }
        

        private void DrawAssemblyList()
        {
            BlackFireEditorGUI.Label("Assemblies", Color.green);
            GUILayout.Space(2);
            //GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Update"))
            {
                GetFrameworkReferencedAssemblies();
            }
//            GUI.backgroundColor = Color.white;
//            GUI.backgroundColor = Color.cyan;
            GUILayout.Space(2);
            m_ReorderableList.DoLayoutList();

           // GUI.backgroundColor = Color.white;
        }
        
        private Dictionary<string, bool> m_ImplTypeDic = new Dictionary<string, bool>();
        private System.Collections.Generic.List<string> m_SelectedIoCRegisters = new System.Collections.Generic.List<string>();
        
        private void DrawIoCList()
        {
            BlackFireGUI.ScrollView("BlackFireInspector/IoCView",id=> {

                BlackFireGUI.BoxVerticalLayout(()=> {
                    for (int i = 0; i < m_SP_IoCRegisters.arraySize; i++)
                    {
                        var element = m_SP_IoCRegisters.GetArrayElementAtIndex(i).stringValue;
                        var selected = m_ImplTypeDic[element];
                        if (selected) //如果被选择了
                        {                            
                            if (!m_SelectedIoCRegisters.Contains(element))
                            {
                                m_SelectedIoCRegisters.Add(element);
                            }
                            
                            GUI.backgroundColor = Color.green;
                            m_ImplTypeDic[element] = EditorGUILayout.ToggleLeft(element, selected);
                            GUI.backgroundColor = Color.white;
                        }
                        else
                        {
                            if (m_SelectedIoCRegisters.Contains(element))
                            {
                                m_SelectedIoCRegisters.Remove(element);
                            }
                            m_ImplTypeDic[element] = EditorGUILayout.ToggleLeft(element, selected);
                        }
                    }

                    m_SP_AvailableIoCRegisters.arraySize = m_SelectedIoCRegisters.Count; //设置可用IoC注册数组。
                    for (int j = 0; j < m_SelectedIoCRegisters.Count; j++)
                    {
                        m_SP_AvailableIoCRegisters.GetArrayElementAtIndex(j).stringValue = m_SelectedIoCRegisters[j];
                    }
                    
                });

            }, GUILayout.ExpandHeight(false));
        }
        
        private Type[] m_ImplTypes = null;
        private void ReflectIoCRegisterTypesInfo()
        {
            m_ImplTypes = BlackFireFramework.Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(IIoCRegister));
            m_SP_IoCRegisters.arraySize = m_ImplTypes.Length;

            for (int i = 0; i < m_ImplTypes.Length; i++)
            {
                m_SP_IoCRegisters.GetArrayElementAtIndex(i).stringValue = m_ImplTypes[i].FullName;
                m_ImplTypeDic.Add(m_ImplTypes[i].FullName, false);
            }

            for (int i = 0; i < m_SP_AvailableIoCRegisters.arraySize; i++)
            {
                m_ImplTypeDic[m_SP_AvailableIoCRegisters.GetArrayElementAtIndex(i).stringValue] = true;
            }
            serializedObject.ApplyModifiedProperties();
        }
        
        
        
        
        private void GetFrameworkReferencedAssemblies()
        {
            var fwAssemblyName = typeof(Framework).Assembly.GetName().Name;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            System.Collections.Generic.List<string> assemblyList = new System.Collections.Generic.List<string>();
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

            m_SP_AssemblyList.arraySize = assemblyList.Count;
            for (int i = 0; i < assemblyList.Count; i++)
            {
                m_SP_AssemblyList.GetArrayElementAtIndex(i).stringValue = assemblyList[i];
            }

        }
    }
}
