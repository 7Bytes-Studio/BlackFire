//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;


namespace BlackFireFramework.Unity
{
    public abstract class AssetInfoBase
    {
        public AssetInfoBase(string assetPath, Type assetType, bool shortdatedAsset)
        {
            AssetType = assetType;
            ShortdatedAsset = shortdatedAsset;
            AssetPath = assetPath;
        }

        public string AssetPath { get; protected set; }
        public Type AssetType { get; protected set; }
        public bool ShortdatedAsset { get; protected set; }

    }


    public sealed class ResourceAssetInfo : AssetInfoBase
    {
        public ResourceAssetInfo(string assetPath, Type assetType, bool shortdatedAsset) : base( assetPath, assetType, shortdatedAsset)
        {

        }
    }


    public sealed class AssetsBundleAssetInfo : AssetInfoBase
    {
        public AssetsBundleAssetInfo(string assetsBundlePath, string assetPath, Type assetType, bool shortdatedAsset) : base( assetPath, assetType, shortdatedAsset)
        {
            AssetsBundlePath = assetsBundlePath;
        }

        public string AssetsBundlePath { get; private set; }
    }

}
