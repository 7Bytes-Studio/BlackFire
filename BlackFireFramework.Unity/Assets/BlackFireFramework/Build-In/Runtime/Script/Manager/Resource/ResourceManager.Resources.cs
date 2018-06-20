//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    using System.Collections;
    using System.Collections.Generic;
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

        public Object Load(string path)
        {
            return Resources.Load(path);
        }

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
            if (null == assetToUnload) throw new NullReferenceException("Parameters 'assetToUnload' cannot be null.");
            bool isIndividualAssets = assetToUnload is Mesh || assetToUnload is Texture || assetToUnload is Material || assetToUnload is Shader;
            if (isIndividualAssets)
            {
                Resources.UnloadAsset(assetToUnload);
            }
            else
            {
                var ao = HasAsset(assetToUnload);
                if (null!= ao)
                {
                    m_AssetObjectLinkList.Remove(ao);
                    ao = null;
                    UnloadUnusedAssets();
                }
            }
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

        private LinkedList<AssetObject> m_AssetObjectLinkList = new LinkedList<AssetObject>();

        private AssetObject HasAsset(string assetName)
        {
            var current = m_AssetObjectLinkList.First;
            while (null!=current)
            {
                if (current.Value.AssetPath==assetName)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        private AssetObject HasAsset(Object asset)
        {
            var current = m_AssetObjectLinkList.First;
            while (null != current)
            {
                if (current.Value.Asset.Equals(asset))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        public void LoadAsync(string path,Action<AssetObject> loadComplete)
        {
            var assetObject = HasAsset(path);
            if (null == assetObject)
            {
                var rr = LoadAsync(path);
                rr.completed += ao => { if (null != loadComplete) loadComplete.Invoke( m_AssetObjectLinkList.AddLast(new AssetObject(path, rr.asset, typeof(Object))).Value ); };
            }
            else
            {
                if (null != loadComplete) loadComplete.Invoke(assetObject);
            }
        }

        public void LoadAsync(string path,Type type, Action<AssetObject> loadComplete)
        {
            var assetObject = HasAsset(path);
            if (null == assetObject)
            {
                var rr = LoadAsync(path, type);
                rr.completed += ao => { if (null != loadComplete) loadComplete.Invoke(m_AssetObjectLinkList.AddLast(new AssetObject(path, rr.asset, type)).Value); };
            }
            else
            {
                if (null != loadComplete) loadComplete.Invoke(assetObject);
            }
        }

        public void LoadAsync<T>(string path, Action<AssetObject> loadComplete) where T : Object
        {
            var assetObject = HasAsset(path);
            if (null == assetObject)
            {
                var rr = LoadAsync<T>(path);
                rr.completed += ao => { if (null != loadComplete) loadComplete.Invoke(m_AssetObjectLinkList.AddLast(new AssetObject(path, rr.asset, typeof(T))).Value); };
            }
            else
            {
                if (null != loadComplete) loadComplete.Invoke(assetObject);
            }
        }




    }
}
