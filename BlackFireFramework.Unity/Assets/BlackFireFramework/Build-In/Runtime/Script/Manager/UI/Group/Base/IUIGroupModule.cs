//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    
    public delegate void UICommandCallback<T>(T i) where T:Event.IEventHandler;
    
    /// <summary>
    /// UI Group模块接口。
    /// </summary>
    public interface IUIGroupModule
    {
        
        /// <summary>
        /// 创建UI组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="groupName">组名。</param>
        /// <param name="groupWeight">组权重。</param>
        /// <typeparam name="T">组类型。</typeparam>
        /// <returns>是否创建成功。</returns>
        bool CreateUIGroup<T>(long groupId,string groupName,int groupWeight) where T : UIGroup;

        /// <summary>
        /// 查询UI小组Id。
        /// </summary>
        /// <param name="uiGroupName">UI小组名。</param>
        /// <returns>小组Id。</returns>
        long QueryUIGroupId(string uiGroupName);
        
        /// <summary>
        /// 加入组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="uiGroupMember">组成员。</param>
        /// <param name="groupMemberWeight">组成员权重。</param>
        /// <returns>是否加入成功。</returns>
        bool JoinUIGroup(long groupId,UIGroupMember uiGroupMember, int groupMemberWeight);

//        /// <summary>
//        /// 获取UI组成员。
//        /// </summary>
//        /// <param name="groupId">组Id。</param>
//        /// <param name="groupMemberId">组Id。</param>
//        /// <returns>UI组成员。</returns>
//        UIGroupMember GetGroupMember(long groupId,long groupMemberId);
//
//
//        /// <summary>
//        /// 获取组的所有成员。
//        /// </summary>
//        /// <param name="groupId">组Id。</param>
//        /// <returns>小组成员集合。</returns>
//        IEnumerable<UIGroupMember> GetGroupMembers(long groupId);
        
        /// <summary>
        /// 离开组。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="uiGroupMember">组成员。</param>
        /// <returns>是否离开成功。</returns>
        bool LeaveUIGroup(long groupId,long uiGroupMemberId);

        /// <summary>
        /// 下达命令。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="callback">命令会调。</param>
        /// <typeparam name="T">命令类型。</typeparam>
        /// <returns>命令是否执行成功。</returns>
        bool ExecuteCommand<T>(long groupId, UICommandCallback<T> callback) where T : Event.IEventHandler;

    }
}