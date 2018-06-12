//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class ResourceDemo : MonoBehaviour 
	{
        private object m_Asset;
        private void OnGUI()
        {
            if (GUILayout.Button("异步加载"))
            {
                BlackFire.Resource.LoadAsync("GameObject", ao => Debug.Log(ao.Asset.GetHashCode() + "   " + (m_Asset=ao.Asset) +"   "+ ao.AssetPath+"   "+ao.AssetType));
            }

            if (GUILayout.Button("卸载"))
            {
                BlackFire.Resource.UnloadAsset((Object)m_Asset);
            }

            if (GUILayout.Button("测试"))
            {
                Debug.Log(m_Asset);
            }
        }

    }
}
