/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;

namespace BlackFire
{
    /// <summary>
    /// 多叉树节点。
    /// </summary>
    public class MultiwayTreeNode<T>:IEnumerable<MultiwayTreeNode<T>>
    {
        public MultiwayTreeNode(T value)
        {
            Value = value;
        }

        public MultiwayTreeNode<T> Parrent { get; internal set; }
        public T Value { get; protected set; }

        public int ChildCount { get { return m_Childs.Count;  } }

        private LinkedList<MultiwayTreeNode<T>> m_Childs = new LinkedList<MultiwayTreeNode<T>>();


        #region IEnumerable<MultiwayTreeNode<T>> 接口的实现。
        public IEnumerator<MultiwayTreeNode<T>> GetEnumerator()
        {
            LinkedListNode<MultiwayTreeNode<T>> current = m_Childs.First;
            while (null != current)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion


        /// <summary>
        /// 添加孩子节点。
        /// </summary>
        /// <param name="childNode"></param>
        public void AddChildNode(MultiwayTreeNode<T> childNode)
        {
            if (!m_Childs.Contains(childNode))
            {
                m_Childs.AddLast(childNode);
                childNode.Parrent = this;
                OnAddChildNode(childNode);
            }
        }

        /// <summary>
        /// 移除孩子节点。
        /// </summary>
        /// <param name="childNode"></param>
        public void RemoveChildNode(MultiwayTreeNode<T> childNode)
        {
            if (m_Childs.Contains(childNode))
            {
                m_Childs.Remove(childNode);
                childNode.Parrent = null;
                OnRemoveChildNode(childNode);
            }
        }


        #region 事件

        protected virtual void OnAddChildNode(MultiwayTreeNode<T> childNode)
        {

        }

        protected virtual void OnRemoveChildNode(MultiwayTreeNode<T> childNode)
        {

        }

        #endregion


    }
}
