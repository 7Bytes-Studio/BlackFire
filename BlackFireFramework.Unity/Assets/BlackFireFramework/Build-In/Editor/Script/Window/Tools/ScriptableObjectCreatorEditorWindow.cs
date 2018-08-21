//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

//Scriptwriter : https://github.com/GarfieldJiang

using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public class ScriptableObjectCreatorEditorWindow : EditorWindow
    {
        private string m_ClassName = string.Empty;
        private Type m_ScriptableObjectType = null;
        private string m_AssemblyName = string.Empty;

        public static void Open()
        {
            GetWindow<ScriptableObjectCreatorEditorWindow>(true, "Create Scriptable Object");
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            {
                var newClassFullName = EditorGUILayout.DelayedTextField("Class Name", m_ClassName);
                if (newClassFullName != m_ClassName)
                {
                    UpdateClassInfo(newClassFullName);
                }

                if (m_ScriptableObjectType != null)
                {
                    //Alan
                    EditorGUILayout.HelpBox(string.Format("Class '{0}' is in assembly '{1}'.", m_ClassName, m_AssemblyName),
                        MessageType.Info);
                    //Alan
                }
                else if (!string.IsNullOrEmpty(m_ClassName))
                {
                    EditorGUILayout.HelpBox("Cannot find the class", MessageType.Warning);
                }

                EditorGUI.BeginDisabledGroup(m_ScriptableObjectType == null);
                {
                    DrawCreateButtonSection();
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawCreateButtonSection()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space();
                if (GUILayout.Button("Create"))
                {
                    CreateScriptableObjectAsset();
                    //EditorUtility.FocusProjectWindow();
                }
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void UpdateClassInfo(string newClassName)
        {
            m_ClassName = newClassName;
            m_ScriptableObjectType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.IsSubclassOf(typeof(ScriptableObject)) && !t.IsAbstract && t.Name == m_ClassName);
            if (m_ScriptableObjectType != null)
            {
                m_AssemblyName = m_ScriptableObjectType.Assembly.GetName().Name;
            }
            else
            {
                m_AssemblyName = string.Empty;
            }
        }

        private void CreateScriptableObjectAsset()
        {
            var asset = CreateInstance(m_ScriptableObjectType.Name);
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (string.IsNullOrEmpty(path))
            {
                path = "Assets";
            }
            else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);
            }

            string assetPath = AssetDatabase.GenerateUniqueAssetPath(path + "/" + m_ScriptableObjectType.Name + ".asset");
            AssetDatabase.CreateAsset(asset, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Selection.activeObject = asset;
        }
    }
}
