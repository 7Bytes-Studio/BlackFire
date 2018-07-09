//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework.Unity
{

    using UnityEngine;

    public sealed partial class ResourceManager
    {
        private Action m_UpdateResource_Delegate;

        private void Init_Resource()
        {

        }

        private void Update_Resource()
        {
            if (null!= m_UpdateResource_Delegate)
            {
                m_UpdateResource_Delegate.Invoke();
            }
        }

        private void Destroy_Resource()
        {

        }




        public void LoadAsync(AssetInfoBase assetInfo, LoadAssetComplete loadResourceComplete, LoadAssetProgress loadResourceProgress = null, LoadAssetFailure loadResourceFailure = null)
        {
            if ( assetInfo is ResourceAssetInfo )
            {
                LoadResourceAsync(assetInfo as ResourceAssetInfo, loadResourceComplete, loadResourceProgress, loadResourceFailure);
            }
            else if (assetInfo is AssetsBundleAssetInfo)
            {
                LoadAssetsBundleAsync(assetInfo as AssetsBundleAssetInfo, loadResourceComplete, loadResourceProgress, loadResourceFailure);
            }
        }



        private void LoadResourceAsync(ResourceAssetInfo assetInfo,LoadAssetComplete loadAssetComplete,LoadAssetProgress loadAssetProgress = null, LoadAssetFailure loadAssetFailure=null)
        {
            var assetObject = HasAsset(assetInfo.AssetPath);

            if (null == assetObject)
            {
                var rr = null!=assetInfo.AssetType?Base_LoadAsync(assetInfo.AssetPath,assetInfo.AssetType):Base_LoadAsync(assetInfo.AssetPath);
                Action action = () => { if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetInfo.AssetPath, rr.progress));  };
                m_UpdateResource_Delegate += action;
                rr.completed += ao =>
                {
                    m_UpdateResource_Delegate -= action;
                    if (null == rr.asset)
                    {
                        if (null != loadAssetFailure)
                        {
                            loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetInfo.AssetPath));
                        }
                    }
                    else
                    {
                        AssetAgency assetAgency = m_AssetObjectLinkList.AddLast(new AssetAgency(assetInfo.AssetPath, rr.asset, assetInfo.ShortdatedAsset)).Value;
                        if (null != loadAssetComplete)
                            loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetInfo.AssetPath,assetAgency));
                    }
                };
            }
            else
            {
                if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetInfo.AssetPath,1f));
                if (null != loadAssetComplete) loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetObject.AssetPath,assetObject));

            }
        }


        /// <summary>
        /// 遍历资源代理。
        /// </summary>
        /// <param name="callback">遍历资源代理时的回调。</param>
        public void ForeachAssetAgency(Action<LinkedListNode<AssetAgency>> callback)
        {
            m_AssetObjectLinkList.Foreach(callback);
        } 

        /// <summary>
        /// 资源代理数目。
        /// </summary>
        public int AssetAgencyCount { get { return m_AssetObjectLinkList.Count; } }

        #region 数据结构

        private LinkedList<AssetAgency> m_AssetObjectLinkList = new LinkedList<AssetAgency>();

        private AssetAgency HasAsset(string assetName)
        {
            var current = m_AssetObjectLinkList.First;
            while (null != current)
            {
                if (current.Value.AssetPath == assetName)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        private AssetAgency HasAsset(Object asset)
        {
            var current = m_AssetObjectLinkList.First;
            while (null != current)
            {
                if (current.Value.Equals(asset))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }


        #endregion


    }
}
