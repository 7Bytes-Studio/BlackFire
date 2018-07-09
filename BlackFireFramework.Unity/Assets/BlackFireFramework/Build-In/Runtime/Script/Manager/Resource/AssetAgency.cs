//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------



using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 资产对象。
    /// </summary>
    public class AssetAgency
    {

        /// <summary>
        /// 构造方法。
        /// </summary>
        public AssetAgency(string assetPath,Object asset,bool isShortdatedAsset =false)
        {
            IsShortdatedAsset = isShortdatedAsset;
            AssetPath = assetPath;
            Asset = asset;
            ReferenceCounter = new DefaultReferenceCounter();
            ReferenceCounter.OnRefCountIsZero += OnRefCountIsZero;
        }

        #region Event

        protected virtual void OnRefCountIsZero()
        {
            if (IsShortdatedAsset)
            {
                ReleaseAsset();
            }
        }

        #endregion

        #region Property


        /// <summary>
        /// 引用计数器。
        /// </summary>
        private IReferenceCounter ReferenceCounter { get; set; }

        /// <summary>
        /// 资源引用计数。
        /// </summary>
        public int RefCount { get { return ReferenceCounter.RefCount; } }

        /// <summary>
        /// 资源路径。
        /// </summary>
        public string AssetPath { get; private set; }

        /// <summary>
        /// 资源对象内存引用。
        /// </summary>
        private Object Asset { get; set; }

        /// <summary>
        /// 资源对象的类型。
        /// </summary>
        public System.Type AssetType { get { return Asset.GetType(); } }

        /// <summary>
        /// 是否是短期资源。
        /// </summary>

        public bool IsShortdatedAsset { get; private set; }


        #endregion

        #region API

        /// <summary>
        /// 向资源代理请示获取资源对象。
        /// </summary>
        /// <param name="who">谁获取。</param>
        /// <returns>资源对象。</returns>
        public Object AcquireAsset(object who)
        {
            ReferenceCounter.Cumulative(who);
            return Asset;
        }

        /// <summary>
        /// 向资源代理请示归还资源对象。
        /// </summary>
        /// <param name="who">谁归还。</param>
        public void RestoreAsset(object who)
        {
            ReferenceCounter.Regressive(who);
        }

        /// <summary>
        /// 向资源代理请示释放资源对象。
        /// </summary>
        public void ReleaseAsset()
        {
            bool isIndividualAssets = Asset is Mesh || Asset is Texture || Asset is Material || Asset is Shader;
            if (isIndividualAssets)
            {
                ResourceManager.Base_UnloadAsset(Asset);
                Asset = null;
            }
            else
            {
                Asset = null;//理论非托管资源引用计数彻底为零。
                ResourceManager.Base_UnloadUnusedAssets();
            }
        }

        #endregion

        #region override


        public override bool Equals(object obj)
        {
            return null != Asset? Asset.Equals(obj) : null==obj;
        }

        public override int GetHashCode()
        {
            return null != Asset ? Asset.GetHashCode() :-1;
        }

        #endregion
    }
}