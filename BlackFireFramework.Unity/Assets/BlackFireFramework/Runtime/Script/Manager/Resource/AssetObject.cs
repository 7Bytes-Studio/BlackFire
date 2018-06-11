//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 资产对象。
    /// </summary>
    public sealed class AssetObject
	{
        
        /// <summary>
        /// 构造方法。
        /// </summary>
        public AssetObject(string assetPath, Object asset,Type assetType)
        {
            AssetPath = assetPath;
            Asset = asset;
            AssetType = assetType;
        }

        /// <summary>
        /// 资源路径。
        /// </summary>
        public string AssetPath { get; private set; }
        
        /// <summary>
        /// 资源对象内存引用。
        /// </summary>
        public Object Asset { get; private set; }

        /// <summary>
        /// 资源对象的类型。
        /// </summary>
        public Type AssetType { get; private set; }

    }
}