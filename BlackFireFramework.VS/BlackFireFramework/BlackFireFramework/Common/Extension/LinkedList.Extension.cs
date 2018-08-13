//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public static class LinkedListExtension
    {

        public static void PredicateForeach<T>(this LinkedList<T> linkedList, Predicate<LinkedListNode<T>> callback, Action<LinkedList<T>> endCallback = null)
        {
            if (null == callback) return;

            var currentLinkedNode = linkedList.First;
            while (null != currentLinkedNode)
            {
                if (callback.Invoke(currentLinkedNode))
                {
                    break;
                }
                currentLinkedNode = currentLinkedNode.Next;
            }

            if (null != endCallback)
            {
                endCallback.Invoke(linkedList);
            }
        }

        public static void Foreach<T>(this LinkedList<T> linkedList,Action<LinkedListNode<T>> callback, Action<LinkedList<T>> endCallback=null)
        {
            if (null == callback) return;

            var currentLinkedNode = linkedList.First;
            while (null != currentLinkedNode)
            {
                callback.Invoke(currentLinkedNode);
                currentLinkedNode = currentLinkedNode.Next;
            }

            if (null!= endCallback)
            {
                endCallback.Invoke(linkedList);
            }
        }

        public static T[] ToArray<T>(this LinkedList<T> linkedList)
        {
            T[] array = new T[linkedList.Count];
            int i = 0;
            var currentLinkedNode = linkedList.First;
            while (null != currentLinkedNode)
            {
                array[i++] = currentLinkedNode.Value;
                currentLinkedNode = currentLinkedNode.Next;
            }
            return array;
        }


        public static bool Contains<T>(this LinkedList<T> linkedList,Predicate<T> predicate)
        {
            var current = linkedList.First;
            while (null!=current)
            {
                if (predicate.Invoke(current.Value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public static T Find<T>(this LinkedList<T> linkedList,Predicate<T> predicate)
        {
            var current = linkedList.First;
            while (null!=current)
            {
                if (predicate.Invoke(current.Value))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return default(T);
        }
        
        
    }
}

