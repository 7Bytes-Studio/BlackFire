//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public static class AssetsMenu 
    {
        [MenuItem("Assets/BlackFire/EditorWindowScript",false,0)]
        public static void OnMenuItemClick()
        {
           ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
           ScriptableObject.CreateInstance<CreateEditorWindowScriptAsset>(),
           "/New EditorWindowScript.cs",
           null,
           "Assets/"+BlackFireEditor.ScriptTemplatePath+ "EditorWindowScriptTemplate.cs");
           
        }

        public static string GetSelectionAssetsPath()
        {
            Object[] arr = Selection.GetFiltered(typeof(Object), SelectionMode.TopLevel);
            return Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" + AssetDatabase.GetAssetPath(arr[0]);
        }


       

    }




}
