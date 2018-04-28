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
    public static partial class Config 
	{

        public static partial class MenuBar
        {

            public const string Name = "BlackFire";

            #region Window


            #region Package
            public const string PackageWindow = Name + "/Package";
            public const string PackageWindowTile = "Package";
            public const bool PackageWindowType = false;
            #endregion
             #region Hello
            public const string Hello = Name + "/Hello";
            public const string HelloTile = "Hello";
            public const bool HelloType = false;
            #endregion

            
            #region Lalala
            public const string Lalala = Name + "/Lalala";
            public const string LalalaTile = "Lalala";
            public const bool LalalaType = false;
            #endregion

            #endregion Window



            public static void MakeWindowConfig(string className)
            {
                var results = AssetDatabase.FindAssets("Config.MenuBar", new string[] { BlackFire.FrameworkInfo.FrameworkAssetsPath });
                if (0 < results.Length)
                {
                    var template = string.Format(ReplaceFormatString , className, className, className, className, className, className);
                    var currentScriptPath = AssetDatabase.GUIDToAssetPath(results[0]);
                    var str = File.ReadAllText(currentScriptPath);
                    var re = str.Replace(ReplaceSourceString, template);
                    File.Delete(currentScriptPath);
                    using (var ws = File.CreateText(currentScriptPath))
                    {
                        ws.Write(re);
                    }
                }
            }


        }

    }
}
