//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class ResourceManager 
	{

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

    }
}
