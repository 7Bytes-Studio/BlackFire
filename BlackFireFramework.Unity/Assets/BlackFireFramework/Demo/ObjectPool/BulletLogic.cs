//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework
{
    /// <summary>
    /// 子弹逻辑类。
    /// </summary>
	public sealed class BulletLogic : MonoBehaviour 
	{
        [SerializeField] private float m_SurvivalTime=5f;
        [SerializeField] private float m_BulletSpeed=20f;

        public bool LockState { get; internal set; }
        public ObjectPool.ObjectBase ObjectOwner { get; internal set; }



        private float m_AccumulationTime = 0f;

        private void OnEnable()
        {
            m_AccumulationTime = 0f;
        }

        private void Update()
        {
            if (!LockState)
            {
                m_AccumulationTime += Time.deltaTime;
                if (m_AccumulationTime>=m_SurvivalTime)
                {
                    Log.Info("BulletTimetoRecycle");
                    Event.Fire("Topic://TestBullet/BulletTimetoRecycle", this, EventArgs.Empty);
                    m_AccumulationTime = 0f;
                    return;
                }
                transform.position = Vector3.MoveTowards(transform.position, transform.position+Vector3.left,Time.deltaTime * m_BulletSpeed); 
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            Log.Info("Bullet Hit "+other.gameObject.name,true);
            Event.Fire("Topic://TestBullet/BulletHit",this,EventArgs.Empty);
        }



    }
}
