//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public sealed class SimpleGroupLeader : Group.IGroupLeader
    {

        public SimpleGroupLeader(string name,int ability)
        {
            Name = name;
            Ability = ability;
        }

        public Group.IGroupMember FirstIntrant { get; private set; }

        public Group.IGroupMember LastIntrant { get; private set; }

        public string Name { get; private set; }

        public int Ability { get; private set; }



        private LinkedList<Group.IGroupMember> m_GroupMemberLinkedList = new LinkedList<Group.IGroupMember>();
        public bool AddGroupMember(Group.IGroupMember groupMember)
        {
            if (!m_GroupMemberLinkedList.Contains(groupMember))
            {
                m_GroupMemberLinkedList.AddLast(groupMember);
                if (null == FirstIntrant)
                {
                    FirstIntrant = groupMember;
                }
                LastIntrant = groupMember;
                return true;
            }
            return false;
        }

        public Group.IGroupMember GetGroupMember(string groupMemberName)
        {
            var current = m_GroupMemberLinkedList.First;
            while (null != current)
            {
                if (current.Value.Name == groupMemberName)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        public bool RemoveGroupMember(string groupMemberName)
        {
            var current = m_GroupMemberLinkedList.First;
            while (null!= current)
            {
                if (current.Value.Name == groupMemberName)
                {
                    m_GroupMemberLinkedList.Remove(current.Value);
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int CompareTo(Group.IGroupMember other)
        {
            return other.Ability - this.Ability;
        }

        public bool ExecuteCommand<T>(string groupMemberName, Group.ActionCommandCallback<T> commandCallback) where T : Group.ICommand
        {
            var current = m_GroupMemberLinkedList.First;
            while (null != current)
            {
                if (current.Value.Name == groupMemberName)
                {
                    if (current.Value is T)
                    {
                        if (null != commandCallback)
                        {
                            commandCallback.Invoke((T)current.Value);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                current = current.Next;
            }
            return false;
        }

        public bool ExecuteCommand<T>(Group.ActionCommandCallback<T> commandCallback) where T : Group.ICommand
        {
            bool hasHandler = false;
            var current = m_GroupMemberLinkedList.First;
            while (null != current)
            {
                if (current.Value is T)
                {
                    if (null != commandCallback)
                    {
                        commandCallback.Invoke((T)current.Value);
                    }
                    hasHandler = true;
                }
                current = current.Next;
            }
            return hasHandler;
        }

        public bool ExecuteCommand<T>(Group.FuncCommandCallback<T> commandCallback) where T : Group.ICommand
        {
            var current = m_GroupMemberLinkedList.First;
            while (null != current)
            {
                if (current.Value is T)
                {
                    if (null != commandCallback)
                    {
                        var ret = commandCallback.Invoke((T)current.Value);
                        if (ret)
                        {
                            return true;
                        }
                    }
                }
                current = current.Next;
            }
            return false;
        }

        public bool ExecuteChainCommand<T>(Group.ChainCommandCallback<T> commandCallback) where T : Group.ICommand
        {
            List<Group.IGroupMember> list = new List<Group.IGroupMember>();
            var current = m_GroupMemberLinkedList.First;
            while (null != current)
            {
                if (current.Value is T)
                {
                    list.Add(current.Value);
                }
                current = current.Next;
            }

            list.Sort((x,y)=>x.Ability-y.Ability);
            object lastRet = null;
            bool hasHandler = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (null != commandCallback)
                {
                    lastRet = commandCallback.Invoke((T)list[i], lastRet);
                    hasHandler = true;
                }
            }
            return hasHandler;
        }

    }
}
