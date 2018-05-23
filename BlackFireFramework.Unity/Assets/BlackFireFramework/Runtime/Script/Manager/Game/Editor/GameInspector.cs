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

namespace BlackFireFramework.Editor
{
    [CustomEditor(typeof(GameManager))]
    [DisallowMultipleComponent]
    public sealed class GameInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
                return new InspectorSetting();
            }
        }

        private GameManager m_GameManager = null;

        private SerializedProperty m_SP_GameSpeed = null;
        private SerializedProperty m_SP_Fps = null;
        private SerializedProperty m_SP_AllProcesses = null;
        private SerializedProperty m_SP_AvailableProcesses = null;
        private SerializedProperty m_SP_FirstProcess = null;
        private SerializedProperty m_SP_ProcessScrowFoldOut = null;
        private SerializedProperty m_SP_ApplyGameSpeedWhenInitialized = null;
        private SerializedProperty m_SP_ApplyFpsWhenInitialized = null;
        
            
        private Type[] m_ImplTypes = null;
        private int m_ProcessPopupIndex = 0;
        private Dictionary<string, bool> m_ImplTypeDic = new Dictionary<string, bool>();

        private void OnEnable()
        {
            m_GameManager = target as GameManager;
            m_SP_GameSpeed = serializedObject.FindProperty("m_GameSpeed");
            m_SP_Fps = serializedObject.FindProperty("m_Fps");
            m_SP_FirstProcess = serializedObject.FindProperty("m_FirstProcess");
            m_SP_AllProcesses = serializedObject.FindProperty("m_AllProcesses");
            m_SP_AvailableProcesses = serializedObject.FindProperty("m_AvailableProcesses");
            m_SP_ProcessScrowFoldOut = serializedObject.FindProperty("m_ProcessScrowFoldOut");
            m_SP_ApplyGameSpeedWhenInitialized = serializedObject.FindProperty("m_ApplyGameSpeedWhenInitialized");
            m_SP_ApplyFpsWhenInitialized = serializedObject.FindProperty("m_ApplyFpsWhenInitialized");

            ReflectProcessTypesInfo();
        }


        private void ReflectProcessTypesInfo()
        {
            m_ImplTypes = BlackFireFramework.Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(ProcessBase));
            m_SP_AllProcesses.arraySize = m_ImplTypes.Length;

            for (int i = 0; i < m_ImplTypes.Length; i++)
            {
                m_SP_AllProcesses.GetArrayElementAtIndex(i).stringValue = m_ImplTypes[i].FullName;
                m_ImplTypeDic.Add(m_ImplTypes[i].FullName, false);
            }

            for (int i = 0; i < m_SP_AvailableProcesses.arraySize; i++)
            {
                m_ImplTypeDic[m_SP_AvailableProcesses.GetArrayElementAtIndex(i).stringValue] = true;
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawProcessScrollView()
        {
            BlackFireGUI.ScrollView("GameInspector/ProcessScrollView",id=> {

                BlackFireGUI.BoxVerticalLayout(()=> {
                    for (int i = 0; i < m_SP_AllProcesses.arraySize; i++)
                    {
                        var element = m_SP_AllProcesses.GetArrayElementAtIndex(i).stringValue;
                        var selected = m_ImplTypeDic[element];
                        if (selected)
                        {
                            GUI.backgroundColor = Color.green;
                            m_ImplTypeDic[element] = EditorGUILayout.ToggleLeft(element, selected);
                            GUI.backgroundColor = Color.white;
                        }
                        else
                        {
                            m_ImplTypeDic[element] = EditorGUILayout.ToggleLeft(element, selected);
                        }
                    }

                });

            }, GUILayout.ExpandHeight(false));


        }

        private void DrawFirstProcessPopup()
        {
            List<string> selectedProcessList = new List<string>(); 
            foreach (var kv in m_ImplTypeDic)
            {
                if (kv.Value)
                {
                    selectedProcessList.Add(kv.Key);
                }
            }
            if (0 == selectedProcessList.Count)
            {
                EditorGUILayout.HelpBox("You must select the available process!", MessageType.Error);
                return;
            }
            m_SP_AvailableProcesses.arraySize = selectedProcessList.Count;
            for (int i = 0; i < m_SP_AvailableProcesses.arraySize; i++)
            {
                m_SP_AvailableProcesses.GetArrayElementAtIndex(i).stringValue = selectedProcessList[i];
            }
            BlackFireEditorGUI.ArrayPopup("First Process", ref m_ProcessPopupIndex, selectedProcessList.ToArray());
            m_SP_FirstProcess.stringValue = selectedProcessList[m_ProcessPopupIndex = m_ProcessPopupIndex >= selectedProcessList.Count ? selectedProcessList.Count - 1 : m_ProcessPopupIndex];
        }

        protected override void OnDrawInspector()
        {

            GUILayout.Space(15);

            BlackFireEditorGUI.BoxVerticalLayout(()=> {

                EditorGUILayout.PropertyField(m_SP_GameSpeed);
                m_SP_ApplyGameSpeedWhenInitialized.boolValue = EditorGUILayout.ToggleLeft("ApplyGameSpeed", m_SP_ApplyGameSpeedWhenInitialized.boolValue);

            });

            GUILayout.Space(5);

            BlackFireEditorGUI.BoxVerticalLayout(() => {

                EditorGUILayout.PropertyField(m_SP_Fps);
                m_SP_ApplyFpsWhenInitialized.boolValue = EditorGUILayout.ToggleLeft("ApplyFps", m_SP_ApplyFpsWhenInitialized.boolValue);

            });

            GUILayout.Space(5);

            BlackFireEditorGUI.BoxVerticalLayout(() => {
                DrawFirstProcessPopup();
                m_GameManager.StartFirstProcessWhenInitialized = EditorGUILayout.ToggleLeft("StartFirstProcess", m_GameManager.StartFirstProcessWhenInitialized);
                GUILayout.Space(5);
                if (m_SP_ProcessScrowFoldOut.boolValue = BlackFireEditorGUI.FoldOut("Process", m_SP_ProcessScrowFoldOut.boolValue, "#3399CC"))
                {
                    DrawProcessScrollView();
                }
                GUILayout.Space(10);
            });


        }
    }
}
