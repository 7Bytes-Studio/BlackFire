//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;


namespace BlackFireFramework.Unity
{
    public class AssetInfo
    {
        public AssetInfo(string assetPath, Type assetType=null,bool shortdatedAsset=false)
        {
            AssetPath = assetPath;
            AssetType = assetType;
            ShortdatedAsset = shortdatedAsset;
        }

        public string AssetPath { get; private set; }
        public Type AssetType { get; private set; }
        public bool ShortdatedAsset { get; internal set; }
    }
}
