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
            public string Name { get; internal set; }

            public int Weight { get; internal set; }

            public virtual int Ability { get {

                    int ability = 0;
                    foreach (var kv in m_GroupMemberDic)
                    {
                        ability += kv.Value.Ability;
                    }
                    return ability;
                } }


            private Dictionary<string,GroupMember> m_GroupMemberDic = new Dictionary<string, GroupMember>();

            internal bool JoinGroup(GroupMember groupMember)
            {
                if (!m_GroupMemberDic.ContainsKey(groupMember.Name))
                {
                    m_GroupMemberDic.Add(groupMember.Name,groupMember);
                    return true;
                }
                return false;
            }

            internal bool LeaveGroup(string groupMemberName)
            {
                if (m_GroupMemberDic.ContainsKey(groupMemberName))
                {
                    m_GroupMemberDic.Remove(groupMemberName);
                    return true;
                }
                return false;
            }


            private static readonly Dictionary<string, Group> s_GroupMDic = new Dictionary<string, Group>();


            internal static void RecordGroup(Group group)
            {
                if (!s_GroupMDic.ContainsKey(group.Name))
                {
                    s_GroupMDic.Add(group.Name, group);
                }
            }

            internal static Group QueryGroup(string groupName)
            {
                if (s_GroupMDic.ContainsKey(groupName))
                {
                    return s_GroupMDic[groupName];
                }
                return null;
            }

        }
    }
}
