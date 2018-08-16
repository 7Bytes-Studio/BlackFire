//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlackFireFramework.Unity
{
    public interface IResourceManager:IManager
    {
        /// <summary>
        /// 当前场景数量。
        /// </summary>
        int SceneCount { get; }

        /// <summary>
        /// 活动场景。
        /// </summary>
        string ActiveScene { get; set; }

        /// <summary>
        /// 资源代理数目。
        /// </summary>
        int AssetAgencyCount { get; }

        /// <summary>
        /// 加载场景。
        /// </summary>
        /// <param name="sceneName">场景名字。</param>
        void LoadSceneAsync(SceneInfo sceneInfo,ResourceManager.LoadSceneComplete loadSceneComplete=null,ResourceManager.LoadSceneProgress loadSceneProgress=null,ResourceManager.LoadSceneFailure loadSceneFailure=null);

        /// <summary>
        /// 卸载场景。
        /// </summary>
        void UnloadSceneAsync(string sceneName,ResourceManager.UnloadSceneComplete UnloadSceneComplete = null, ResourceManager.UnloadSceneProgress UnloadSceneProgress = null, ResourceManager.UnloadSceneFailure UnloadSceneFailure = null);

        /// <summary>
        /// 移动场景。
        /// </summary>
        void MoveToScene(List<GameObject> gameObjectList,string sceneName,ResourceManager.MoveToSceneComplete moveToSceneComplete = null, ResourceManager.MoveToSceneProgress moveToSceneProgress = null, ResourceManager.MoveToSceneFailure moveToSceneFailure = null);

        /// <summary>
        /// 将原始场景合并到目标场景。
        /// </summary>
        /// <param name="fromSceneName">原始场景。</param>
        /// <param name="toSceneName">目标场景。</param>
        void MergeScene(string fromSceneName, string toSceneName);

        void LoadAsync(AssetInfoBase assetInfo, ResourceManager.LoadAssetComplete loadResourceComplete, ResourceManager.LoadAssetProgress loadResourceProgress = null, ResourceManager.LoadAssetFailure loadResourceFailure = null);

        /// <summary>
        /// 卸载AssetsBundle实例。
        /// </summary>
        /// <param name="assetsBundlePath">AssetsBundle文件路径。</param>
        /// <param name="unloadAllLoadedObjects">是否下载该AssetsBundle包所有的已经加载过的对象。</param>
        void Unload(string wildcardPath, bool unloadAllLoadedObjects=false);

        /// <summary>
        /// 遍历资源代理。
        /// </summary>
        /// <param name="callback">遍历资源代理时的回调。</param>
        void ForeachAssetAgency(Action<LinkedListNode<AssetAgency>> callback);
    }
}