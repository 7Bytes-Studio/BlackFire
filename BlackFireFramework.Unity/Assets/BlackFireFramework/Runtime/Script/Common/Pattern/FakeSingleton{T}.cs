//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 仿冒单例抽象类
    /// </summary>
    /// <typeparam name="T">实现类的类型</typeparam>
	public abstract class FakeSingleton<T> : MonoBehaviour where T : FakeSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {

            if (null == Instance)
            {
                Instance = this as T;
            }
            else if (!Instance.Equals(this))
            {
                DestroyImmediate(this);
            }

        }

        protected virtual void Update()
        {

        }


        protected virtual void OnDestroy()
        {
            if (Instance.Equals(this))
            {
                Instance = null;
            }
        }

    }
}
