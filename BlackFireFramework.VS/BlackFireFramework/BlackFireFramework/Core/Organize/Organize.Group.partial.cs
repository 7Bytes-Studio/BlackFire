//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class Organize
    {
        public abstract partial class Group
        {
            public long Id { get; internal set; }
            public string Name { get; internal set; }

            public int Weight { get; internal set; }

            public virtual int Ability { get {

                    int ability = 0;
                    foreach (var v in m_GroupMemberDic.Values)
                    {
                        ability += v.Ability;
                    }
                    return ability;
                } }

            protected internal virtual bool HandleCommand<T>(CommandCallback<T> commandCallback) where T : ICommand
            {
                if (this is T)
                {
                    commandCallback.Invoke((T)((object)this));
                    return true;
                }
                return false;
            }









            private Dictionary<long,GroupMember> m_GroupMemberDic = new Dictionary<long, GroupMember>();


            internal bool JoinGroup(GroupMember groupMember)
            {
                if (!m_GroupMemberDic.ContainsKey(groupMember.Id))
                {
                    m_GroupMemberDic.Add(groupMember.Id,groupMember);
                    return true;
                }
                return false;
            }

            internal bool LeaveGroup(long groupMemberId)
            {
                if (m_GroupMemberDic.ContainsKey(groupMemberId))
                {
                    m_GroupMemberDic.Remove(groupMemberId);
                    return true;
                }
                return false;
            }


            private static readonly Dictionary<long, Group> s_GroupMDic = new Dictionary<long, Group>();

            internal static void Foreach(Action<Group> callback)
            {
                if(null==callback)return;
                foreach (var v in s_GroupMDic.Values)
                {
                    callback.Invoke(v);
                }
            }

            internal static void RecordGroup(Group group)
            {
                if (!s_GroupMDic.ContainsKey(group.Id))
                {
                    s_GroupMDic.Add(group.Id, group);
                }
            }

            internal static Group QueryGroup(long groupId)
            {
                if (s_GroupMDic.ContainsKey(groupId))
                {
                    return s_GroupMDic[groupId];
                }
                return null;
            }

        }
    }
}
