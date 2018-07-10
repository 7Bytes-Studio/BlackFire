//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class ResourceManager
    {
        /// <summary>
        /// 获取已经存在资源代理。
        /// </summary>
        /// <param name="key">资源代理索引。</param>
        /// <returns></returns>
        public AssetAgency this[ string key]{ get{return HasAsset(key);} }

        private void Init_Agency()
        {
            Application.lowMemory += Application_lowMemory;
        }

        private void Application_lowMemory() //当内存使用率过低时。
        {
            var current = m_AssetObjectLinkList.First;
            while (null != current)
            {
                if (0==current.Value.RefCount) //资源引用计数为0。
                {
                    current.Value.ReleaseAsset(); //尝试释放资源。
                    m_AssetObjectLinkList.Remove(current);//移除节点。
                }
                current = current.Next;
            }
        }

        private void Update_Agency()
        {
            CheckOrReleaseNode();
        }

        private void Destroy_Agency()
        {

        }


        private void CheckOrReleaseNode()
        {
            var current = m_AssetObjectLinkList.First;
            while (null!=current)
            {
                if ( current.Value.Equals(null) ) //内部资源引用已经为空。
                {
                    m_AssetObjectLinkList.Remove(current);
                }
                current = current.Next;
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

        private AssetAgency HasAsset(UnityEngine.Object asset)
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




    }
}
