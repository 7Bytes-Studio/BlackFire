//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace BlackFireFramework
{
    public sealed class FrameworkInfo
    {
        public string Version { get{ return "1.0.0"; } }

        public string FrameworkAssetsPath { get { return DepthMatchingFrameworkAssetsPath(); } }


        private string DepthMatchingFrameworkAssetsPath()
        {
#if UNITY_EDITOR

            var results = AssetDatabase.FindAssets("FrameworkInfo");
            foreach (var guid in results)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.Contains("BlackFireFramework") && path.Contains("Runtime") && path.Contains("Script")) //匹配第一个
                { 
                    return path.Replace("/Runtime/Script/FrameworkInfo.cs", string.Empty);
                }
            }
#endif
            return string.Empty;

        }

    }
}