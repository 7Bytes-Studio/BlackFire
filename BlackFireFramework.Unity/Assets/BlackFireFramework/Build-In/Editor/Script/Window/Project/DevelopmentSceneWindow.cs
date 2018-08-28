//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

// ScriptMainLogicWriter : https://github.com/Yawpp

using BlackFireFramework.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public sealed class DevelopmentSceneWindow : EditorWindowBase<DevelopmentSceneWindow>
    {
        private static DevelopmentScene s_EditorScene;

        private void OnEnable()
        {
            if (null==s_EditorScene)
            {
                s_EditorScene = Resources.Load<DevelopmentScene>("DevelopmentScene");
            }
        }

        protected override void OnDrawWindow()
        {
            if (null!=s_EditorScene)
            {
                foreach (var item in s_EditorScene.Scenes)
                {
                    if (GUILayout.Button(item.name))
                    {
                        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(item));
                    }
                }
            }
        }
    }
}