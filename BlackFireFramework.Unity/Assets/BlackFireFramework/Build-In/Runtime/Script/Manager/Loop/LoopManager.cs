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

    /// <summary>
    /// 游戏轮询委托管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Loop")]
    public sealed class LoopManager : ManagerBase, ILoopManager
    {
        #region Editor
#if UNITY_EDITOR

        /// <summary>
        /// 获取所有被物理帧轮训条目的信息
        /// </summary>
        /// <returns>条目的信息</returns>
        public string[] GetFixedUpdateInfos()
        {
            var items = FindAll(item => item.m_LoopType == LoopType.FixedUpdate ||
            item.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
            item.m_LoopType == LoopType.Update_FixedUpdate ||
            item.m_LoopType == LoopType.All);

            string[] infos = new string[items.Length];

            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = items[i].ToString();
            }

            return infos;
        }

        /// <summary>
        /// 获取所有被逻辑帧轮训条目的信息
        /// </summary>
        /// <returns>条目的信息</returns>
        public string[] GetUpdateInfos()
        {
            var items = FindAll(item => item.m_LoopType == LoopType.Update ||
                        item.m_LoopType == LoopType.Update_FixedUpdate ||
                        item.m_LoopType == LoopType.Update_LateUpdate ||
                        item.m_LoopType == LoopType.All);

            string[] infos = new string[items.Length];

            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = items[i].ToString();
            }

            return infos;

        }

        /// <summary>
        /// 获取所有被逻辑帧后轮训条目的信息
        /// </summary>
        /// <returns>条目的信息</returns>
        public string[] GetLateUpdateInfos()
        {
            var items = FindAll(item=> item.m_LoopType == LoopType.LateUpdate ||
                        item.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
                        item.m_LoopType == LoopType.Update_LateUpdate ||
                        item.m_LoopType == LoopType.All);

            string[] infos = new string[items.Length];

            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = items[i].ToString();
            }

            return infos;
        }

        /// <summary>
        /// 获取所有被相机场景渲染完成后轮训条目的信息
        /// </summary>
        /// <returns>条目的信息</returns>
        public string[] GetOnRenderObjectInfos()
        {
            var items = FindAll(item => item.m_LoopType == LoopType.OnRenderObject);

            string[] infos = new string[items.Length];

            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = items[i].ToString();
            }

            return infos;
        }

#endif
        #endregion

        /// <summary>
        /// 委托条目类。
        /// </summary>
        private class DelegateEntry
        {
            /// <summary>
            /// 轮询类型。
            /// </summary>
            public LoopType m_LoopType;

            /// <summary>
            /// 委托变量。
            /// </summary>
            public Delegate m_Delegate;

            /// <summary>
            /// 名字变量。
            /// </summary>
            public string m_Name;

            /// <summary>
            /// 是否是静态绑定。
            /// </summary>
            public bool IsStatic;

            /// <summary>
            /// 清除原先的数据。
            /// </summary>
            public void Clear()
            {
                m_Delegate = null;
                m_LoopType = LoopType.None;
                m_Name = string.Empty;
            }

            public override string ToString()
            {
                return string.Format("Name: {0}  Target: {1}", m_Name, !IsStatic? m_Delegate.Target.ToString():"Static");
            }

        }

        /// <summary>
        /// 函数地址项列表。
        /// </summary>
        private readonly LinkedList<DelegateEntry> m_DelegateEntryLinkedList = new LinkedList<DelegateEntry>();

        /// <summary>
        /// 链表操作的当前节点缓存变量。
        /// </summary>
        private LinkedListNode<DelegateEntry> m_CacheCurrentNode = null;

        /// <summary>
        /// 是否允许FixedUpdate轮训回调。
        /// </summary>
        public bool IsAllowFixedUpdate;
        /// <summary>
        /// 是否允许Update轮训回调。
        /// </summary>
        public bool IsAllowUpdate;
        /// <summary>
        /// 是否允许LateUpdate轮训回调。
        /// </summary>
        public bool IsAllowLateUpdate;
        /// <summary>
        /// 是否允许OnRenderObject轮训回调。
        /// </summary>
        public bool IsAllowOnRenderObject;



        /// <summary>
        /// 注册的委托数量。
        /// </summary>
        public int DelegateCount { get { return m_DelegateEntryLinkedList.Count; } }

        /// <summary>
        /// 注册的被物理帧轮训的委托数量。
        /// </summary>
        public int FixedUpdateDelegateCount { get { return GetFixedUpdateDelegateCount(); } }

        /// <summary>
        /// 注册的被逻辑帧轮训的委托数量。
        /// </summary>
        public int UpdateDelegateCount { get { return GetUpdateDelegateCount(); } }

        /// <summary>
        /// 注册的被逻辑帧后轮训的委托数量。
        /// </summary>
        public int LateUpdateCount { get { return GetLateUpdateDelegateCount(); } }

        /// <summary>
        /// 获取所有被相机场景渲染完成后轮训条目的数量。
        /// </summary>
        public int OnRenderObjectCount { get { return GetLateUpdateDelegateCount(); } }

        /// <summary>
        /// 获取所有被轮训条目的信息。
        /// </summary>
        /// <returns>委托命名数组。</returns>
        public string[] GetNames()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            string[] names = new string[m_DelegateEntryLinkedList.Count];
            int index = 0;
            while (null != m_CacheCurrentNode)
            {
                names[index++] = m_CacheCurrentNode.Value.m_Name;
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return names;
        }

        /// <summary>
        /// 获取所有被物理帧轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        public string[] GetFixedUpdateNames()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            List<string> infoList = new List<string>();
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    infoList.Add(m_CacheCurrentNode.Value.m_Name);
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return infoList.ToArray();
        }

        /// <summary>
        /// 获取所有被逻辑帧轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        public string[] GetUpdateNames()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            List<string> infoList = new List<string>();
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.Update ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    infoList.Add(m_CacheCurrentNode.Value.m_Name);
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return infoList.ToArray();
        }

        /// <summary>
        /// 获取所有被逻辑帧后轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        public string[] GetLateUpdateNames()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            List<string> infoList = new List<string>();
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    infoList.Add(m_CacheCurrentNode.Value.m_Name);
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return infoList.ToArray();
        }

        /// <summary>
        /// 是否已经注册了委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        /// <returns>结果。</returns>
        public bool HasRegisted(Delegate @delegate)
        {
           return null != Find(item=>null!=item.m_Delegate && item.m_Delegate.Equals(@delegate));
        }

        /// <summary>
        /// 是否已经注册了委托。
        /// </summary>
        /// <param name="delegate">给委托的命名。</param>
        /// <returns>结果。</returns>
        public bool HasRegisted(string name)
        {
            return null != Find(item => !string.IsNullOrEmpty(item.m_Name) && item.m_Name == name);
        }

        /// <summary>
        /// 注册委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        public void Register(Delegate @delegate,LoopType loopType,string name=null)
        {
            DelegateEntry nullDelegateEntry= null;
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            while (null != m_CacheCurrentNode)
            {
                if (null == m_CacheCurrentNode.Value.m_Delegate && null == nullDelegateEntry) //存储委托已经为空的节点值，用于重复利用。
                    nullDelegateEntry = m_CacheCurrentNode.Value;
                else
                {
                    if (m_CacheCurrentNode.Value.m_Delegate.Equals(@delegate)) //已经注册过了。
                    {
                        return;
                    }
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }

            if (null != nullDelegateEntry)
            {
                nullDelegateEntry.m_Delegate = @delegate;
                nullDelegateEntry.m_LoopType = loopType;
                nullDelegateEntry.m_Name = name??string.Format("<Nil:{0}>", @delegate.GetHashCode());
                nullDelegateEntry.IsStatic = @delegate.Target == null;
            }
            else
            {
                m_DelegateEntryLinkedList.AddLast(new LinkedListNode<DelegateEntry>(new DelegateEntry() { m_Delegate = @delegate, m_LoopType = loopType, m_Name = name ?? string.Format("<Nil:{0}>", @delegate.GetHashCode()), IsStatic = @delegate.Target == null }));
            }

        }

        /// <summary>
        /// 注销委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        public void UnRegister(Delegate @delegate)
        {
            var result = Find(item => null != item.m_Delegate && item.m_Delegate.Equals(@delegate));
            if (null!=result)
            {
                result.Clear();
            }
        }

        /// <summary>
        /// 注销委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        public void UnRegister(string name)
        {
            var result = Find(item => !string.IsNullOrEmpty(item.m_Name) && item.m_Name == name);
            if (null != result)
            {
                result.Clear();
            }
        }






        /// <summary>
        /// 使用预条件判断回调来查找结点。
        /// </summary>
        /// <param name="callback">回调。</param>
        /// <returns>返回符合条件的当前节点。</returns>
        private DelegateEntry Find(Predicate<DelegateEntry> callback)
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            while (null != m_CacheCurrentNode)
            {
                if (callback(m_CacheCurrentNode.Value))
                {
                    return m_CacheCurrentNode.Value;
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return null;
        }
        /// <summary>
        /// 使用预条件判断回调来查找所有的结点。
        /// </summary>
        /// <param name="callback">回调。</param>
        /// <returns>返回符合条件的当前节点。</returns>
        private DelegateEntry[] FindAll(Predicate<DelegateEntry> callback)
        {
            List<DelegateEntry> delegateEntryList = new List<DelegateEntry>();
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            while (null != m_CacheCurrentNode)
            {
                if (callback(m_CacheCurrentNode.Value))
                {
                    delegateEntryList.Add(m_CacheCurrentNode.Value);
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return delegateEntryList.ToArray();
        }


        /// <summary>
        /// 获取所有被物理帧轮训条目的数量。
        /// </summary>
        /// <returns>条目的信息。</returns>
        private int GetFixedUpdateDelegateCount()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            int index = 0;
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    index++;
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return index;
        }

        /// <summary>
        /// 获取所有被逻辑帧轮训条目的数量。
        /// </summary>
        /// <returns>条目的信息。</returns>
        private int GetUpdateDelegateCount()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            int index = 0;
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.Update ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    index++;
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return index;
        }

        /// <summary>
        /// 获取所有被逻辑帧后轮训条目的数量。
        /// </summary>
        /// <returns>条目的信息。</returns>
        private int GetLateUpdateDelegateCount()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            int index = 0;
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.Update_LateUpdate ||
                    m_CacheCurrentNode.Value.m_LoopType == LoopType.All
                     )
                {
                    index++;
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return index;
        }

        /// <summary>
        /// 获取所有被相机场景渲染完成后轮训条目的数量。
        /// </summary>
        /// <returns>条目的信息。</returns>
        private int GetOnRenderObjectDelegateCount()
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            int index = 0;
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.OnRenderObject)
                {
                    index++;
                }
                m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
            return index;
        }

        /// <summary>
        /// 调用回调符合条件的委托。
        /// </summary>
        /// <param name="callback">条件回调。</param>
        private void Call(Predicate<DelegateEntry> callback)
        {
            m_CacheCurrentNode = m_DelegateEntryLinkedList.First;
            while (null != m_CacheCurrentNode)
            {
                if (m_CacheCurrentNode.Value.m_LoopType == LoopType.None) goto MoveNext;

                if (callback(m_CacheCurrentNode.Value))
                {
                    //检查动态绑定的宿主
                    if (null != m_CacheCurrentNode.Value.m_Delegate.Target && (m_CacheCurrentNode.Value.m_Delegate.Target.Equals(null) ) != m_CacheCurrentNode.Value.IsStatic)
                    {
                        m_CacheCurrentNode.Value.Clear();
                        goto MoveNext;
                    }

                    if (null != m_CacheCurrentNode.Value.m_Delegate)
                    {
                        var parameterLength = m_CacheCurrentNode.Value.m_Delegate.Method.GetParameters().Length;
                        if (0 == parameterLength)
                            m_CacheCurrentNode.Value.m_Delegate.DynamicInvoke();
                        else
                            m_CacheCurrentNode.Value.m_Delegate.DynamicInvoke(new object[parameterLength]);
                    }
                }

                MoveNext: m_CacheCurrentNode = m_CacheCurrentNode.Next;
            }
        }

        /// <summary>
        /// 游戏物理帧被轮询事件。
        /// </summary>
        private void FixedUpdate()
        {
            if(IsAllowFixedUpdate)
            Call(item=>
            item.m_LoopType == LoopType.FixedUpdate ||
            item.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
            item.m_LoopType == LoopType.Update_FixedUpdate ||
            item.m_LoopType == LoopType.All
            );
        }

        /// <summary>
        /// 游戏被轮询事件。
        /// </summary>
        private void Update()
        {
            if (IsAllowUpdate)
            Call(item =>
            item.m_LoopType == LoopType.Update ||
            item.m_LoopType == LoopType.Update_FixedUpdate ||
            item.m_LoopType == LoopType.Update_LateUpdate ||
            item.m_LoopType == LoopType.All
            );
        }

        /// <summary>
        /// 游戏被轮询后再次被轮询事件。
        /// </summary>
        private void LateUpdate()
        {
            if (IsAllowLateUpdate)
            Call(item =>
            item.m_LoopType == LoopType.LateUpdate ||
            item.m_LoopType == LoopType.LateUpdate_FixedUpdate ||
            item.m_LoopType == LoopType.Update_LateUpdate ||
            item.m_LoopType == LoopType.All
            );
        }

        /// <summary>
        /// 相机场景渲染完成后被调用事件。
        /// </summary>
        private void OnRenderObject()
        {
            if (IsAllowOnRenderObject)
            Call(item=>item.m_LoopType == LoopType.OnRenderObject);
        }


    }

    /// <summary>
    /// 轮询类型。
    /// </summary>
    public enum LoopType : byte
    {
        None,
        All,
        Update,
        LateUpdate,
        FixedUpdate,
        Update_LateUpdate,
        Update_FixedUpdate,
        LateUpdate_FixedUpdate,
        OnRenderObject
    }

}
