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


namespace BlackFireFramework 
{
	public sealed class ObjectPoolDemo : MonoBehaviour 
	{
        [SerializeField] private BulletLogic m_BulletTemplate;
        private ObjectPool.PoolBase m_TestPool = null;

        private void Start()
        {
            //监听事件。
            //子弹达到存活时间事件。
            Event.On("Topic://TestBullet/BulletTimetoRecycle",this,(sender,args)=> {

                m_TestPool.Recycle((sender as BulletLogic).ObjectOwner);

            });
            //子弹打到物体事件。
            Event.On("Topic://TestBullet/BulletHit", this, (sender, args) => {

                m_TestPool.Recycle((sender as BulletLogic).ObjectOwner);

            });
            //对象池弹性增长的，这里设置池的容量为300。
            m_TestPool = ObjectPool.CreatePool("TestPool",300);
            //对象池设计可以存放不同子类类型对象，只要是继承自ObjectPool.Object。
            //下面是给对象池的工厂绑定实例化回调。
            m_TestPool.PoolFactory.Bind(typeof(BulletObject),()=>new BulletObject(GameObject.Instantiate<BulletLogic>(m_BulletTemplate)));
        }

        //界面UI点击FireBullet事件。
        public void OnFireBullet()
        {
            if (m_TestPool.Count<m_TestPool.Capacity)
            {
                var bulletObject = m_TestPool.Spawn(typeof(BulletObject));
            }
        }

    }



}
