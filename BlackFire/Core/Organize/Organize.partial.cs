/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    /// <summary>
    /// 组织。
    /// </summary>
    public static partial class Organize
    {

        /// <summary>
        /// 遍历小组。
        /// </summary>
        public static void Foreach(Action<Group> callback)
        {
            Group.Foreach(callback);
        }

        /// <summary>
        /// 获取小组Id。
        /// </summary>
        public static long GetGroupId(string groupName)
        {
            return Group.QueryGroupId(groupName);
        }

        /// <summary>
        /// 创建小组。
        /// </summary>
        public static bool CreateGroup(Type groupType,long groupId,string groupName,int groupWeight) 
        {
            try
            {
                Group ins = (Group)Utility.Reflection.New(groupType);
                ins.Id = groupId;
                ins.Name = groupName;
                ins.Weight = groupWeight;
                Group.RecordGroup(ins);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
          
        /// <summary>
        /// 创建小组。
        /// </summary>
        public static bool CreateGroup<T>(long groupId,string groupName,int groupWeight) where T: Group
        {
            try
            {
                var ins = Utility.Reflection.New<T>();
                ins.Id = groupId;
                ins.Name = groupName;
                ins.Weight = groupWeight;
                Group.RecordGroup(ins);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 创建成员。
        /// </summary>
        public static bool CreateMember(Type memberType , long groupMemberId , int ability , string name)
        {
            try
            {
                var ins = (GroupMember)Utility.Reflection.New(memberType);
                ins.Id = groupMemberId;
                ins.Name = name;
                ins.Ability = ability;
                GroupMember.RecordGroupMember(ins);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        /// <summary>
        /// 创建成员。
        /// </summary>
        public static bool CreateMember<T>(long groupMemberId , int ability , string name) where T: GroupMember
        {
            try
            {
                var ins = (GroupMember)Utility.Reflection.New(typeof(T));
                ins.Id = groupMemberId;
                ins.Name = name;
                ins.Ability = ability;
                GroupMember.RecordGroupMember(ins);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取小组成员实例。
        /// </summary>
        public static GroupMember GetGroupMember(long groupMemberId)
        {
            return GroupMember.QueryGroupMember(groupMemberId);
        }
        
        /// <summary>
        /// 获取小组成员实例。
        /// </summary>
        public static T GetGroupMember<T>(long groupMemberId)where T: GroupMember
        {
            return GroupMember.QueryGroupMember(groupMemberId) as T;
        }


        /// <summary>
        /// 成员加入小组。
        /// </summary>
        public static bool Join(long groupId,GroupMember groupMember,int groupMemberWeight)
        {
            Relationship.RecordRelationship(groupMember.Id,groupId);
            var group = Group.QueryGroup(groupId);
            if (null!=group)
            {
                Permission.RecordPermission(groupId, groupMember.Id,group.Weight, groupMemberWeight);
                return group.JoinGroup(groupMember); 
            }
            return false;
        }
      
        /// <summary>
        /// 成员离开小组。
        /// </summary>
        public static bool Leave(long groupId,long memberId)
        {
            var group = Group.QueryGroup(groupId);
            if (null != group)
            {
                Permission.RemovePermission(groupId, memberId);
                Relationship.RemoveRelationship(memberId,groupId);
                return group.LeaveGroup(memberId);
            }
            return false;
        }

        /// <summary>
        /// 查询成员的权限。
        /// </summary>
        public static Permission QueryPermission(long groupId,long memberId)
        {
            return Permission.QueryPermission(groupId, memberId);
        }

        /// <summary>
        /// 查询成员与小组的关系。
        /// </summary>
        public static Relationship QueryRelationship(long memberId)
        {
           return Relationship.QueryRelationship(memberId);
        }

        /// <summary>
        /// 设置命令接口权限。
        /// </summary>
        public static void SetCommandPermission<T>(int permission) where T : Event.IEventHandler
        {
            Command.SetCommandPermission<T>(permission);
        }

        /// <summary>
        /// 执行成员命令。
        /// </summary>
        public static bool ExecuteCommand<T>(long groupId,long memberId ,CommandCallback<T> callback, bool usePermission = true) where T:Event.IEventHandler 
        {
            var permission = Permission.QueryPermission(groupId,memberId);
            if (null!= permission)
            {
                var groupMember = GroupMember.QueryGroupMember(memberId);
                if (null != groupMember)
                {
                    if (usePermission)
                    {
                        var maxPermission = permission.GroupWeight + permission.Weight;
                        if (maxPermission>=Command.GetCommandPermission<T>()) //权限足够
                        {
                            return groupMember.HandleCommand<T>(callback);
                        }
                    }
                    else
                    {
                        return groupMember.HandleCommand<T>(callback);
                    }
                   
                }
            }
            return false;
        }

        /// <summary>
        /// 执行成员命令。
        /// </summary>
        public static bool ExecuteCommand<T>(long groupId,CommandCallback<T> callback,bool orderGroupMembers, bool usePermission = true) where T:Event.IEventHandler 
        {
            var group = Group.QueryGroup(groupId);
            var members = group.AcquirAllGroupMembers();
            foreach (var member in members)
            {
                var permission = Permission.QueryPermission(group.Id,member.Id);
                if (null!= permission)
                {
                    if (null != member)
                    {
                        if (usePermission)
                        {
                            var maxPermission = permission.GroupWeight + permission.Weight;
                            if (maxPermission>=Command.GetCommandPermission<T>()) //权限足够
                            {
                                return member.HandleCommand<T>(callback);
                            }
                        }
                        else
                        {
                            return member.HandleCommand<T>(callback);
                        }
                    }
                }
            }
            return false;
        }
                 
        /// <summary>
        /// 执行组命令。
        /// </summary>
        public static bool ExecuteCommand<T>(long groupId, CommandCallback<T> callback, bool usePermission = true) where T : Event.IEventHandler
        {
            var group = Group.QueryGroup(groupId);
            if (null != group)
            {
                if (usePermission)
                {
                    var maxPermission = group.Weight;
                    if (maxPermission >= Command.GetCommandPermission<T>()) //权限足够
                    {
                        return group.HandleCommand<T>(callback);
                    }
                }
                else
                {
                    return group.HandleCommand<T>(callback);
                }
            }
            return false;
        }

    }
}
