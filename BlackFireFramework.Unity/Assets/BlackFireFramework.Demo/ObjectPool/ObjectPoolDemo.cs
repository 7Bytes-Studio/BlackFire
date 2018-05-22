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
	public sealed class ObjectPoolDemo : MonoBehaviour 
	{
        private ObjectPool.PoolBase m_TestPool = null;

        private void Start()
        {
            m_TestPool = ObjectPool.CreatePool("TestPool0");

            m_TestPool.PoolFactoryBinder.AddBinding(typeof(TestObject),()=>new TestObject(new GameObject("Unlock  /  Spawn From Test Pool  "+System.DateTime.Now.ToLongTimeString())));

           ObjectPool.CreatePool("TestPool2",100);
           ObjectPool.CreatePool("TestPool3");
           ObjectPool.CreatePool("TestPool4");
           ObjectPool.CreatePool("TestPool5");
           ObjectPool.CreatePool("TestPool6");
           ObjectPool.CreatePool("TestPool7");
           ObjectPool.CreatePool("TestPool8");
           ObjectPool.CreatePool("TestPool9");
           ObjectPool.CreatePool("TestPool10");
           ObjectPool.CreatePool("TestPool11");
           ObjectPool.CreatePool("TestPool12");



        }

        private TestObject m_FirstSpawnObj;

        private void OnGUI()
        {
            if (GUILayout.Button("产出对象"))
            {
                var obj = m_TestPool.Spawn(typeof(TestObject)) as TestObject;
                m_FirstSpawnObj = m_FirstSpawnObj??obj;
            }

            if (GUILayout.Button("回收对象"))
            {
                m_TestPool.Recycle(m_FirstSpawnObj);
            }

            if (GUILayout.Button("加锁对象"))
            {
                m_TestPool.Lock(m_FirstSpawnObj);
            }

            if (GUILayout.Button("解锁对象"))
            {
                m_TestPool.UnLock(m_FirstSpawnObj);
            }

            if (GUILayout.Button("释放对象"))
            {
                m_TestPool.Release(m_FirstSpawnObj);
            }
        }
    }

    public sealed class TestObject : UnityObject<GameObject>
    {
        public TestObject(GameObject target) : base(target) { }


        protected override void OnSpawn()
        {
            base.OnSpawn();
            Target.SetActive(true);
        }

        protected override void OnRecycle()
        {
            base.OnRecycle();
            Target.SetActive(false);
        }

        protected override void OnLock()
        {
            base.OnLock();
            Target.name = Target.name.Replace("0:|Lock  ");
        }

        protected override void OnUnlock()
        {
            base.OnUnlock();
            Target.name = Target.name.Replace("0:|Unlock");
        }

    }


}
