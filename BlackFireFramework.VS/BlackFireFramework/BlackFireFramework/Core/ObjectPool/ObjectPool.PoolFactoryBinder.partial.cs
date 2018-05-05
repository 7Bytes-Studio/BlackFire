//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class ObjectPool
    {
        /// <summary>
        /// 工厂方法绑定者（负责给对象池工厂绑定实例化回调委托）。
        /// </summary>
        public class PoolFactoryBinder
        {
            private Dictionary<Type, PoolFactoryCallback> m_BindDic = new Dictionary<Type, PoolFactoryCallback>();

            /// <summary>
            /// 添加绑定条目。
            /// </summary>
            /// <param name="objectType">对象类型。</param>
            /// <param name="poolFactoryCallback">对象池工厂委托。</param>
            public void AddBinding(Type objectType,PoolFactoryCallback poolFactoryCallback)
            {
                if (!m_BindDic.ContainsKey(objectType))
                {
                    m_BindDic.Add(objectType,poolFactoryCallback);
                    return;
                }
                throw new System.Exception(string.Format("类型'{0}'已经绑定过了!请务重新绑定!",objectType));
            }

            /// <summary>
            /// 获取绑定的条目。
            /// </summary>
            /// <param name="objectType">对象类型。</param>
            /// <returns>对象池工厂委托。</returns>
            public PoolFactoryCallback GetBinding(Type objectType)
            {
                if (m_BindDic.ContainsKey(objectType))
                {
                    return m_BindDic[objectType];
                }
                return null;
            }
        }
    }
}
