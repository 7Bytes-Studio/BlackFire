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
        public class Permission
        {
            internal string PermissionOwnerName { get;set; }
            internal string PermissionOwnerGroupName { get;set; }

            public int GroupWeight { get; internal set; }

            public int Weight { get; internal set; }


            private static readonly LinkedList<Permission> s_Permissions = new LinkedList<Permission>();

            internal static bool RecordPermission(string groupName,string groupMemberName,int groupWeight,int weigh)
            {
                var current = s_Permissions.First;
                while (null!=current)
                {
                    if (current.Value.PermissionOwnerName==groupMemberName&&current.Value.PermissionOwnerGroupName==groupName)
                    {
                        return false;
                    }
                    current = current.Next;
                }
                s_Permissions.AddLast(new Permission() { PermissionOwnerName = groupMemberName, PermissionOwnerGroupName = groupName, GroupWeight = groupWeight, Weight = weigh });
                return true;
            }

            internal static Permission QueryPermission(string groupName,string groupMemberName)
            {
                var current = s_Permissions.First;
                while (null != current)
                {
                    if (current.Value.PermissionOwnerName == groupMemberName && current.Value.PermissionOwnerGroupName == groupName)
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                return null;
            }


            internal static bool RemovePermission(string groupName, string groupMemberName)
            {
                var current = s_Permissions.First;
                while (null != current)
                {
                    if (current.Value.PermissionOwnerName == groupMemberName && current.Value.PermissionOwnerGroupName == groupName)
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
