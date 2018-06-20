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

        /// <summary>
        /// 框架内部资源路径。
        /// </summary>
        public const string AssetsPath = "BlackFireFramework/Build-In/.Assets/";
        /// <summary>
        /// 框架内部资源脚本模板路径。
        /// </summary>
        public const string ScriptTemplatePath = AssetsPath + "Data/Resources/ScriptTemplates/";
        /// <summary>
        /// 框架内部临时文件夹路径。
        /// </summary>
        public static string TempPath { get { return Application.dataPath + "/../Temp/BlackFireFramework.Temp/"; } }
        /// <summary>
        /// 框架内部临时包管理路径。
        /// </summary>
        public static string PackageTempPath { get { return TempPath+"Packages/"; } }
        /// <summary>
        /// 框架内部包管理路径。
        /// </summary>
        public static string PackagePath { get { return Application.dataPath + "/BlackFireFramework/Custom/Packages/"; } }
        /// <summary>
        /// 框架自定义二次开发资源路径。
        /// </summary>
        public static string FrameworkCustomPath { get { return Application.dataPath + "/BlackFireFramework/Custom/"; } }
        /// <summary>
        /// 框架自定义二次开发资源的相对路径。
        /// </summary>
        public static string FrameworkCustomRelativePath { get { return "Assets/BlackFireFramework/Custom/"; } }



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

        private static void MakeUserCustomFolder()
        {
            var results = AssetDatabase.FindAssets("Custom");
            if (0 == results.Length)
            {
                Unity.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework/Custom");
                Unity.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework/Custom/Packages");
                AssetDatabase.Refresh();
            }
        }
        private static void MakeUserTempFolder()
        {
            Unity.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp");
            Unity.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp/Packages");
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
