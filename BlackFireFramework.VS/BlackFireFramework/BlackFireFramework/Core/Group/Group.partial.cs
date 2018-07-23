//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    /// <summary>
    /// 组管理类。
    /// </summary>
    public static partial class Group
    {
        private static readonly LinkedList<IGroup> s_GroupLinkedList = new LinkedList<IGroup>();

        public static void Foreach(Action<IGroup> callback)
        {
            var current = s_GroupLinkedList.First;
            while (null != current)
            {
                callback?.Invoke(current.Value);
                current = current.Next;
            }
        }

        public static bool RegisterGroup(IGroup group)
        {
            if (!s_GroupLinkedList.Contains(group))
            {
                s_GroupLinkedList.AddLast(group);
                return true;
            }
            return false;
        }

        public static bool UnRegisterGroup(string groupName)
        {
            var current = s_GroupLinkedList.First;
            while (null!= current)
            {
                if (current.Value.Name == groupName)
                {
                    s_GroupLinkedList.Remove(current);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public static IGroup AcquireGroup(string groupName)
        {
            var current = s_GroupLinkedList.First;
            while (null != current)
            {
                if (current.Value.Name == groupName)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
