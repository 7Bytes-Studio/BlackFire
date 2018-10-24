/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;

namespace BlackFire
{
    public static partial class Organize
    {
        public abstract class GroupMember
        {
            /// <summary>
            /// 成员Id。
            /// </summary>
            public long Id { get; protected internal set; }
            /// <summary>
            /// 成员名字。
            /// </summary>
            public string Name { get; protected internal set; }
            /// <summary>
            /// 成员能力值。（这个数值决定了处理任务的优先级）
            /// </summary>
            public int Ability { get; protected internal set; }

            /// <summary>
            /// 处理命令。
            /// </summary>
            protected internal virtual bool HandleCommand<T>(CommandCallback<T> commandCallback) where T : Event.IEventHandler
            {
                if (this is T)
                {
                    commandCallback.Invoke((T)((object)this));
                    return true;
                }
                return false;
            }


            private static readonly Dictionary<long, GroupMember> s_GroupMembers = new Dictionary<long, GroupMember>();

            internal static void RecordGroupMember(GroupMember groupMember)
            {
                if (!s_GroupMembers.ContainsKey(groupMember.Id))
                {
                    s_GroupMembers.Add(groupMember.Id,groupMember);
                    return;
                }
                throw new System.Exception(string.Format("An instance with Id {0} already exists.", groupMember.Id));
            }

            internal static GroupMember QueryGroupMember(long groupMemberId)
            {
                if (s_GroupMembers.ContainsKey(groupMemberId))
                {
                    return s_GroupMembers[groupMemberId];
                }
                return null;
            }
        }
    }
}
