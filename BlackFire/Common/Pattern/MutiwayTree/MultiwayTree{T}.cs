/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;


namespace BlackFire
{
    /// <summary>
    /// 多叉树。
    /// </summary>
    public class MultiwayTree<T> : IEnumerable<MultiwayTreeNode<T>>
    {

        /// <summary>
        /// 魔法树的根节点。
        /// </summary>
        public MultiwayTreeNode<T> Root { get; protected set; }




        /// <summary>
        /// 挂载节点。
        /// </summary>
        /// <param name="parrent">父亲节点。</param>
        /// <param name="currentNode">当前节点。</param>
        public void Mount(MultiwayTreeNode<T> parrent, MultiwayTreeNode<T> currentNode)
        {
            if (null != parrent && null != currentNode)
            {
                parrent.AddChildNode(currentNode);
                m_HasUpdateTree = true;
            }
        }
        /// <summary>
        /// 卸载节点。
        /// </summary>
        /// <param name="currentNode">当前节点。</param>
        /// <param name="traversaType">遍历类型。</param>
        public void UnMount(MultiwayTreeNode<T> currentNode)
        {
            if (null != currentNode.Parrent)
            {
                currentNode.Parrent.RemoveChildNode(currentNode);
                m_HasUpdateTree = true;
            }
        }





        #region 遍历


        /// <summary>
        /// 设置遍历的类型。
        /// </summary>
        public TraversaType TraversaType { get; set; }

        /// <summary>
        /// 遍历。
        /// </summary>
        /// <param name="traversaCallback">遍历节点时的回调。</param>
        public void Traverse(Action<MultiwayTreeNode<T>> traversaCallback)
        {
            if (null!= traversaCallback)
            switch (TraversaType)
            {
                case TraversaType.DepthFirst:
                    DepthFirstTraversa(traversaCallback);
                    break;
                case TraversaType.BreadthFirst:
                    BreadthFirstTraverse(traversaCallback);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 深度优先遍历。
        /// </summary>
        /// <param name="traversaCallback">广度优先遍历回调。</param>
        private void DepthFirstTraversa(Action<MultiwayTreeNode<T>> traversaCallback)
        {
            if (null != Root)
            {
                _DepthFirstTraversa(Root, traversaCallback);
            }
        }
        private void _DepthFirstTraversa(MultiwayTreeNode<T> currentNode, Action<MultiwayTreeNode<T>> traversaCallback)
        {
            if (null != traversaCallback)
            {
                traversaCallback.Invoke(currentNode);
            }

            foreach (var child in currentNode)
            {
                _DepthFirstTraversa(child, traversaCallback);
            }

            return;
        }

        /// <summary>
        /// 广度优先遍历。
        /// </summary>
        /// <param name="breadthFirstTraverse">广度优先遍历回调。</param>
        private void BreadthFirstTraverse(Action<MultiwayTreeNode<T>> breadthFirstTraverse)
        {
            if (null != Root)
            {
                if (null != breadthFirstTraverse)
                {
                    breadthFirstTraverse.Invoke(Root);
                }
                _BreadthFirstTraverse(Root, breadthFirstTraverse);
            }
        }

        private void _BreadthFirstTraverse(MultiwayTreeNode<T> currentNode, Action<MultiwayTreeNode<T>> breadthFirstTraverse)
        {
            Queue<MultiwayTreeNode<T>> childQueue = new Queue<MultiwayTreeNode<T>>();

            foreach (var child in currentNode)
            {
                if (null != breadthFirstTraverse)
                {
                    breadthFirstTraverse.Invoke(child);
                }
                childQueue.Enqueue(child);
            }

            while (0 < childQueue.Count)
            {
                var node = childQueue.Dequeue();
                _BreadthFirstTraverse(node, breadthFirstTraverse);
            }

            return;
        }
        private LinkedList<MultiwayTreeNode<T>> m_NodeLinkedList = new LinkedList<MultiwayTreeNode<T>>();
        private bool m_HasUpdateTree;

        #region IEnumerable<MultiwayTreeNode<T>> 的实现。


        public IEnumerator<MultiwayTreeNode<T>> GetEnumerator()
        {
            if (m_HasUpdateTree)
            {
                m_NodeLinkedList.Clear();
                switch (TraversaType)
                {
                    case TraversaType.DepthFirst:
                        DepthFirstTraversa(node => { m_NodeLinkedList.AddLast(node); });
                        break;
                    case TraversaType.BreadthFirst:
                        BreadthFirstTraverse(node => { m_NodeLinkedList.AddLast(node); });
                        break;
                    default:
                        break;
                }
                m_HasUpdateTree = false;
            }

            LinkedListNode<MultiwayTreeNode<T>> current = m_NodeLinkedList.First;
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

        #endregion



    }
}
