//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 资源管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Resource")]
    public sealed partial class ResourceManager : ManagerBase ,IResourceManager
	{
        protected override void OnStart()
        {
            base.OnStart();
            Init_Resource();
            Init_AssetsBundle();
            Init_Scene();
            Init_Agency();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Update_Resource();
            Update_AssetsBundle();
            Update_Scene();
            Update_Agency();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            Destroy_Resource();
            Destroy_AssetsBundle();
            Destroy_Scene();
            Destroy_Agency();
        }
    }
}
