//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework
{
    public static partial class Organize
    {
        public abstract class GroupMember
        {
            public long Id { get; protected internal set; }
            public string Name { get; protected set; }
            public int Ability { get; protected set; }

            protected internal virtual bool HandleCommand<T>(CommandCallback<T> commandCallback) where T : ICommand
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
