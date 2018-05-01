//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



using System.IO;
using UnityEditor;
using UnityEngine;

namespace BlackFireFramework.Editor
{
    public static class BlackFireEditor
	{
        #region Path


        public const string AssetsPath = "BlackFireFramework/.Assets/";

        public const string ScriptTemplatePath = AssetsPath + "Data/Resources/ScriptTemplates/";

        public static string TempPath { get { return Application.dataPath + "/../Temp/BlackFireFramework.Temp/"; } }

        public static string PackageTempPath { get { return TempPath+"Packages/"; } }

        public static string PackagePath { get { return Application.dataPath + "/BlackFireFramework.Custom/Packages/"; } }

      

        #endregion

        [InitializeOnLoadMethod]
        private static void Init()
        {       
            InitFolders();
        }


        private static void InitFolders()
        {
            MakeUserCustomFolder();
            MakeUserTempFolder();
        }


        private static void ExistsOrCreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private static void MakeUserCustomFolder()
        {
            var results = AssetDatabase.FindAssets("BlackFireFramework.Custom");
            if (0 == results.Length)
            {
                ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework.Custom");
                ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework.Custom/Packages");
                AssetDatabase.Refresh();
            }
        }
        private static void MakeUserTempFolder()
        {
            ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp");
            ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp/Packages");
        }




        #region FrameworkAssetsPath


        public static string FrameworkAssetsPath { get { return DepthMatchingFrameworkAssetsPath(); } }

        private static string DepthMatchingFrameworkAssetsPath()
        {

            var results = AssetDatabase.FindAssets("FrameworkInfo");
            foreach (var guid in results)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.Contains("BlackFireFramework") && path.Contains("Runtime") && path.Contains("Script")) //匹配第一个
                {
                    return path.Replace("/Runtime/Script/FrameworkInfo.cs", string.Empty);
                }
            }
            return string.Empty;

        }


        #endregion


    }
}
