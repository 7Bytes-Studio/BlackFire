//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
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
