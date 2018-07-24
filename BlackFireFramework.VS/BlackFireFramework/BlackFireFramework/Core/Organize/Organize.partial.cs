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
    /// 组织。
    /// </summary>
    public static partial class Organize
    {
        /// <summary>
        /// 创建小组。
        /// </summary>
        public static T CreateGroup<T>(string groupName,int groupWeight) where T: Group
        {
            var ins = Utility.Reflection.New<T>();
            ins.Name = groupName;
            ins.Weight = groupWeight;
            Group.RecordGroup(ins);
            return ins;
        }

        public static bool Join(string groupName,GroupMember groupMember,int groupMemberWeight)
        {
            Relationship.RecordRelationship(groupMember.Name,groupName);
            var group = Group.QueryGroup(groupName);
            if (null!=group)
            {
                Permission.RecordPermission(groupName, groupMember.Name,group.Weight, groupMemberWeight);
                return group.JoinGroup(groupMember); 
            }
            return false;
        }

        public static bool Leave(string groupName,string memberName)
        {
            var group = Group.QueryGroup(groupName);
            if (null != group)
            {
                Permission.RemovePermission(groupName, memberName);
                Relationship.RemoveRelationship(memberName,groupName);
                return group.LeaveGroup(memberName);
            }
            return false;
        }

        public static Permission QueryPermission(string groupName,string memberName)
        {
            return Permission.QueryPermission(groupName,memberName);
        }

        public static Relationship QueryRelationship(string memberName)
        {
           return Relationship.QueryRelationship(memberName);
        }
    }
}
