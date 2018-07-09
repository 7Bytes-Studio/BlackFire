//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class ResourceManager
	{

        private Action m_UpdateAssetsBundle_Delegate;

        private Dictionary<string,AssetBundle>  m_AssetBundleDic = new Dictionary<string, AssetBundle>();


        private void Init_AssetsBundle()
        {

        }

        private void Update_AssetsBundle()
        {
            if (null != m_UpdateAssetsBundle_Delegate)
            {
                m_UpdateAssetsBundle_Delegate.Invoke();
            }
        }

        private void Destroy_AssetsBundle()
        {

        }



        private void LoadAssetsBundleAsync(AssetsBundleAssetInfo assetsBundleAssetInfo, LoadAssetComplete loadAssetComplete, LoadAssetProgress loadAssetProgress = null, LoadAssetFailure loadAssetFailure = null)
        {

            var assetObject = HasAsset(assetsBundleAssetInfo.AssetPath);

            if (null == assetObject)
            {

                if (m_AssetBundleDic.ContainsKey(assetsBundleAssetInfo.AssetsBundlePath)) //如果已经加载过此AB。
                {

                    var asset = m_AssetBundleDic[assetsBundleAssetInfo.AssetsBundlePath].LoadAsset(assetsBundleAssetInfo.AssetPath);

                    if (null == asset)
                    {
                        if (null != loadAssetFailure)
                        {
                            loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetsBundleAssetInfo.AssetPath));
                        }
                        return;
                    }

                    AssetAgency assetAgency = m_AssetObjectLinkList.AddLast(new AssetAgency(assetsBundleAssetInfo.AssetPath, asset, assetsBundleAssetInfo.ShortdatedAsset)).Value;
                    if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetsBundleAssetInfo.AssetPath, 1f));
                    if (null != loadAssetComplete)
                        loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetsBundleAssetInfo.AssetPath, assetAgency));

                }
                else//如果没有加载过此AB。
                {
                    AssetBundleCreateRequest assetBundleCreateRequest = Base_LoadFromFileAsync(assetsBundleAssetInfo.AssetsBundlePath);
                    Action action = () => { if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetsBundleAssetInfo.AssetPath, assetBundleCreateRequest.progress)); };
                    m_UpdateAssetsBundle_Delegate += action;
                    assetBundleCreateRequest.completed += ao =>
                    {

                        m_UpdateAssetsBundle_Delegate -= action;

                        if (null == assetBundleCreateRequest.assetBundle)
                        {
                            if (null != loadAssetFailure)
                            {
                                loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetsBundleAssetInfo.AssetPath));
                            }
                        }
                        else
                        {
                            m_AssetBundleDic.Add(assetsBundleAssetInfo.AssetsBundlePath, assetBundleCreateRequest.assetBundle);//加入AB字典集合。

                            var asset = assetBundleCreateRequest.assetBundle.LoadAsset(assetsBundleAssetInfo.AssetPath);

                            if (null == asset)
                            {
                                if (null != loadAssetFailure)
                                {
                                    loadAssetFailure.Invoke(new LoadAssetFailureEventArgs(assetsBundleAssetInfo.AssetPath));
                                }
                                return;
                            }

                            AssetAgency assetAgency = m_AssetObjectLinkList.AddLast(new AssetAgency(assetsBundleAssetInfo.AssetPath, asset, assetsBundleAssetInfo.ShortdatedAsset)).Value;
                            if (null != loadAssetComplete)
                                loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetsBundleAssetInfo.AssetPath, assetAgency));
                        }

                    };
                }

            }
            else
            {
                if (null != loadAssetProgress) loadAssetProgress.Invoke(new LoadAssetProgressEventArgs(assetsBundleAssetInfo.AssetPath, 1f));
                if (null != loadAssetComplete) loadAssetComplete.Invoke(new LoadAssetCompleteEventArgs(assetObject.AssetPath, assetObject));
            }

        }

        /// <summary>
        /// 卸载AssetsBundle实例。
        /// </summary>
        /// <param name="assetsBundlePath">AssetsBundle文件路径。</param>
        /// <param name="unloadAllLoadedObjects">是否下载该AssetsBundle包所有的已经加载过的对象。</param>
        public void Unload(string wildcardPath, bool unloadAllLoadedObjects=false)
        {
            if ("*" == wildcardPath) //清除全部。
            {
                foreach (var kv in m_AssetBundleDic)
                {
                    kv.Value.Unload(unloadAllLoadedObjects);
                }
                m_AssetBundleDic.Clear();
            }
            else if (m_AssetBundleDic.ContainsKey(wildcardPath)) //清除指定的目标。
            {
                m_AssetBundleDic[wildcardPath].Unload(unloadAllLoadedObjects);
                m_AssetBundleDic.Remove(wildcardPath);
            }
            else
            {
                var aa = HasAsset(wildcardPath);
                if (null != aa)
                {
                    aa.ReleaseAsset();
                }
            }

        }




    }
}
