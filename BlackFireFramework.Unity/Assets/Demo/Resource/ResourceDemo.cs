//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Alan 
{
	public sealed class ResourceDemo : MonoBehaviour 
	{
        private AssetAgency m_AssetAgency;

        private void OnGUI()
        {
            if (GUILayout.Button("异步加载资源"))
            {
                BlackFire.Resource.LoadAsync(new ResourceAssetInfo("test",null,true),
                    e => Debug.Log((m_AssetAgency=e.AssetAgency).AssetType)
                    ,
                    e => Debug.Log(e.Process)
                    ,
                    e=>Debug.Log("加载失败。")
                    );
            }


            if (GUILayout.Button("申请使用资源"))
            {
                m_AssetAgency.AcquireAsset(this);
            }


            if (GUILayout.Button("申请归还资源"))
            {
                m_AssetAgency.RestoreAsset(this);
            }


            if (GUILayout.Button("卸载"))
            {
                m_AssetAgency.ReleaseAsset();
            }


            if (GUILayout.Button("加载AB包中的资源"))
            {
                BlackFire.Resource.LoadAsync(new AssetsBundleAssetInfo(Application.streamingAssetsPath+"/test", "test", null, true),
                    e => { Debug.Log((m_AssetAgency = e.AssetAgency).AssetType+"   "+ m_AssetAgency.GetHashCode()); gameObject.AddComponent<VideoPlayer>().clip = e.AssetAgency.AcquireAsset(this) as VideoClip; }
                    ,
                    e => Debug.Log(e.Process)
                    ,
                    e => Debug.Log("加载失败。")
                    );
                //AssetBundle.UnloadAllAssetBundles();
            }

            if (GUILayout.Button("卸载AB包中加载进来的资源"))
            {
                m_AssetAgency.RestoreAsset(this);
            }

            if (GUILayout.Button("卸载AB包"))
            {
                BlackFire.Resource.Unload(Application.streamingAssetsPath + "/test");
            }

            if (GUILayout.Button("卸载AB包和已经加载的资源"))
            {
                BlackFire.Resource.Unload(Application.streamingAssetsPath + "/test",true);
            }

            if (GUILayout.Button("卸载*包"))
            {
                BlackFire.Resource.Unload("*");
            }

            if (GUILayout.Button("卸载AB包的test"))
            {
                BlackFire.Resource.Unload("test");
            }

        }

    }









}
