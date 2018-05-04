//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// 实体树节点。
    /// </summary>
    /// <typeparam name="T">目标类型。</typeparam>
    public class EntityTreeNode : MultiwayTreeNode<UserData>
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="value">初始化目标类型的数值。</param>
        public EntityTreeNode(UserData value) : base(value)
        {

        }

        /// <summary>
        /// 已经诞生。
        /// </summary>
        private bool m_HasBorn; 

        /// <summary>
        /// 已经死亡。
        /// </summary>
        private bool m_HasDie;

        /// <summary>
        /// 是否活着。
        /// </summary>
        public bool Alive { get { return m_HasBorn && !m_HasDie; } }

        /// <summary>
        /// 诞生。
        /// </summary>
        internal void Born()
        {
            if (!m_HasBorn && !m_HasDie)
            {
                OnBorn();
                m_HasBorn = true;
            }
        }

        /// <summary>
        /// 活动。
        /// </summary>
        internal void Act()
        {
            if (m_HasBorn && !m_HasDie)
            {
                OnAct();
            }
        }

        /// <summary>
        /// 灭亡。
        /// </summary>
        internal void Die()
        {
            if (m_HasBorn && !m_HasDie)
            {
                OnDie();
                m_HasDie = true;
            }
        }


        #region 事件处理

        protected override void OnAddChildNode(MultiwayTreeNode<UserData> childNode)
        {
            if (m_HasBorn && !m_HasDie)
            {
                (childNode as EntityTreeNode).Born();
            }
        }


        protected override void OnRemoveChildNode(MultiwayTreeNode<UserData> childNode)
        {
            if (m_HasBorn && !m_HasDie)
            {
                (childNode as EntityTreeNode).Die();
            }
        }

        #endregion


        #region 事件


        /// <summary>
        /// 诞生事件。
        /// </summary>
        protected virtual void OnBorn()
        {
#if VS_EDITOR
            Log.Trace("生事件:" + Value.ToString());
#endif
        }

        /// <summary>
        /// 活动事件。
        /// </summary>
        protected virtual void OnAct()
        {
#if VS_EDITOR
            Log.Trace("活事件:" + Value.ToString());
#endif
        }

        /// <summary>
        /// 灭亡事件。
        /// </summary>
        protected virtual void OnDie()
        {
#if VS_EDITOR
            Log.Trace("死事件:" + Value.ToString());
#endif
        }


            #endregion


        }
}
