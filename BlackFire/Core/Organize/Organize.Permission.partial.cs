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
        public class Permission
        {
            internal long PermissionOwnerId { get;set; }
            internal long PermissionOwnerGroupId { get;set; }

            public int GroupWeight { get; internal set; }

            public int Weight { get; internal set; }


            private static readonly LinkedList<Permission> s_Permissions = new LinkedList<Permission>();

            internal static bool RecordPermission(long groupId,long groupMemberId,int groupWeight,int weigh)
            {
                var current = s_Permissions.First;
                while (null!=current)
                {
                    if (current.Value.PermissionOwnerId == groupMemberId && current.Value.PermissionOwnerGroupId== groupId)
                    {
                        return false;
                    }
                    current = current.Next;
                }
                s_Permissions.AddLast(new Permission() { PermissionOwnerId = groupMemberId, PermissionOwnerGroupId = groupId, GroupWeight = groupWeight, Weight = weigh });
                return true;
            }

            internal static Permission QueryPermission(long groupId, long groupMemberId)
            {
                var current = s_Permissions.First;
                while (null != current)
                {
                    if (current.Value.PermissionOwnerId == groupMemberId && current.Value.PermissionOwnerGroupId == groupId)
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                return null;
            }


            internal static bool RemovePermission(long groupId, long groupMemberId)
            {
                var current = s_Permissions.First;
                while (null != current)
                {
                    if (current.Value.PermissionOwnerId == groupMemberId && current.Value.PermissionOwnerGroupId == groupId)
                    {
                        s_Permissions.Remove(current);
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
        }
    }

}
