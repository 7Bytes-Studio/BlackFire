//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    using System.Collections;
    using UnityEngine;
    public sealed partial class ResourceManager
    {
        #region Base Resource Methods.

        #region Find Object  

        public new Object[] FindObjectsOfTypeAll(Type type)
        {
            return Resources.FindObjectsOfTypeAll(type);
        }

        public T[] FindObjectsOfTypeAll<T>() where T : Object
        {
            return Resources.FindObjectsOfTypeAll<T>();
        }

        #endregion

        #region Sync Load

        public Object Load(string path, Type systemTypeInstance)
        {
            return Resources.Load(path, systemTypeInstance);
        }


        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public Object[] LoadAll(string path, Type systemTypeInstance)
        {
            return Resources.LoadAll(path, systemTypeInstance);
        }


        public T[] LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        #endregion

        #region Sync Unload

        public void UnloadAsset(Object assetToUnload)
        {
            Resources.UnloadAsset(assetToUnload);
        }

        #endregion

        #region Async Load

        public ResourceRequest LoadAsync(string path)
        {
            return Resources.LoadAsync(path);
        }

        public ResourceRequest LoadAsync(string path, Type type)
        {
            return Resources.LoadAsync(path, type);
        }

        public ResourceRequest LoadAsync<T>(string path) where T : Object
        {
            return Resources.LoadAsync<T>(path);
        }

        #endregion

        #region Async Unload

        public void UnloadUnusedAssets()
        {
            Resources.UnloadUnusedAssets();
        }

        #endregion

        #endregion



        public void LoadAsync(string path,Action<AssetObject> loadComplete)
        {
            var rr = LoadAsync(path);
            rr.completed += asset => { if (null != loadComplete) loadComplete.Invoke(new AssetObject(path,asset,typeof(Object))); };
        }

        public void LoadAsync(string path,Type type, Action<AssetObject> loadComplete)
        {
            var rr = LoadAsync(path,type);
            rr.completed += asset => { if (null != loadComplete) loadComplete.Invoke(new AssetObject(path, asset, type)); };
        }
        public void LoadAsync<T>(string path, Action<AssetObject> loadComplete) where T : Object
        {
            var rr = LoadAsync<T>(path);
            rr.completed += asset => { if (null != loadComplete) loadComplete.Invoke(new AssetObject(path, asset,typeof(T))); };
        }

    }
}
