//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    using UnityEngine;

    public sealed partial class ResourceManager 
	{

        #region Find Object  

        public static Object[] Base_FindObjectsOfTypeAll(Type type)
        {
            return Resources.FindObjectsOfTypeAll(type);
        }

        public static T[] Base_FindObjectsOfTypeAll<T>() where T : Object
        {
            return Resources.FindObjectsOfTypeAll<T>();
        }

        #endregion

        #region Sync Load

        public static Object Base_Load(string path)
        {
            return Resources.Load(path);
        }

        public static Object Base_Load(string path, Type systemTypeInstance)
        {
            return Resources.Load(path, systemTypeInstance);
        }


        public static T Base_Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public static Object[] Base_LoadAll(string path, Type systemTypeInstance)
        {
            return Resources.LoadAll(path, systemTypeInstance);
        }


        public static T[] Base_LoadAll<T>(string path) where T : Object
        {
            return Resources.LoadAll<T>(path);
        }

        #endregion

        #region Sync Unload

        public static void Base_UnloadAsset(Object assetToUnload)
        {
            Resources.UnloadAsset(assetToUnload);
        }

        public static void Base_UnloadUnusedAssets()
        {
            Resources.UnloadUnusedAssets();
        }



        #endregion

        #region Async Load

        public static ResourceRequest Base_LoadAsync(string path)
        {
            return Resources.LoadAsync(path);
        }

        public static ResourceRequest Base_LoadAsync(string path, Type type)
        {
            return Resources.LoadAsync(path, type);
        }

        public static ResourceRequest Base_LoadAsync<T>(string path) where T : Object
        {
            return Resources.LoadAsync<T>(path);
        }

        #endregion


        #region AssetsBundle




        public static AssetBundle Base_LoadFromFile(string path)
        {
           return AssetBundle.LoadFromFile(path);
        }

        public static AssetBundle Base_LoadFromFile(string path, uint crc)
        {
            return AssetBundle.LoadFromFile(path, crc);
        }

        public static AssetBundle Base_LoadFromFile(string path, uint crc, ulong offset)
        {
            return AssetBundle.LoadFromFile(path, crc, offset);
        }









        public static AssetBundleCreateRequest Base_LoadFromFileAsync(string path)
        {
            return AssetBundle.LoadFromFileAsync(path);
        }

        public static AssetBundleCreateRequest Base_LoadFromFileAsync(string path, uint crc)
        {
            return AssetBundle.LoadFromFileAsync(path, crc);
        }

        public static AssetBundleCreateRequest Base_LoadFromFileAsync(string path, uint crc, ulong offset)
        {
            return AssetBundle.LoadFromFileAsync(path, crc, offset);
        }





        #endregion


    }
}
