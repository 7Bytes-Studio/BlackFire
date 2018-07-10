//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// Ugui 管家。
    /// </summary>
	public sealed partial class UguiManager : ManagerBase
    {
        private UguiManagerGraphicRaycaster m_UguiManagerGraphicRaycaster = null;

        /// <summary>
        /// Ugui的事件流。
        /// </summary>
        public PointerEventData PointerEventData { get { return m_UguiManagerGraphicRaycaster.PointerEventData; } }

        /// <summary>
        /// 射线射击结果列表。
        /// </summary>
        public List<RaycastResult> RaycastResultList { get { return m_UguiManagerGraphicRaycaster.RaycastResultList; } }

        private ObjectPool.PoolBase m_UguiEntitiesPool = null;

        protected override void OnStart()
        {
            base.OnStart();
            if (null==BlackFire.Resource)
            {
                throw new System.Exception("Resource manager is required.");
            }
            m_UguiManagerGraphicRaycaster = gameObject.AddComponent<UguiManagerGraphicRaycaster>();

            m_UguiEntitiesPool = ObjectPool.CreatePool("Ugui");
            m_UguiEntitiesPool.PoolFactory.Bind(typeof(UguiEntity),() => new UguiEntity());
        }

        public delegate void AcquireComplete(UguiEntity uguiEntity);
        public delegate void AcquireFailure();



        private UguiLogicBase CloneUguiLogic(UnityEngine.Object asset,string id)
        {
            var go = Instantiate(asset) as GameObject;
            var ins = go.GetComponent<UguiLogicBase>();
            ins.Id = id;
            return ins;
        }

        public void Acquire(string assetPath,string id,AcquireComplete acquireComplete,AcquireFailure acquireFailure=null)
        {
            BlackFire.Resource.LoadAsync(new ResourceAssetInfo(assetPath),e=> {
                if (null!= acquireComplete)
                {
                    var asset = e.AssetAgency.AcquireAsset(this); // 申请UguiLogic资产

                    var assetType = (asset as GameObject).GetComponent<UguiLogicBase>().GetType();

                    var entity = m_UguiEntitiesPool.Spawn(typeof(UguiEntity),o =>
                    {
                        var ue = o as UguiEntity;
                        return null != ue.Target && ue.Target.GetType() == assetType;
                    },()=>CloneUguiLogic(asset,id));

                    acquireComplete.Invoke(entity as UguiEntity);

                    e.AssetAgency.RestoreAsset(this); // 归还UguiLogic资产
                }
            },null,e=> { if (null != acquireFailure) acquireFailure.Invoke(); });
        }

        public void Restore(UguiEntity uguiEntity)
        {
            m_UguiEntitiesPool.Recycle(uguiEntity);
        }

        public void Release(UguiEntity uguiEntity)
        {
            m_UguiEntitiesPool.Release(uguiEntity);
        }

        public void Release(string assetPath)
        {
            var aa = BlackFire.Resource[assetPath];
            if (null!=aa)
            {
                aa.ReleaseAsset();
            }
        }

    }
}
