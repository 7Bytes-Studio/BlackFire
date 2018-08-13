//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// UI Group模块接口。
    /// </summary>
    public interface IUIGroupModule
    {
        
        /// <summary>
        /// 创建UI组。
        /// </summary>
        /// <param name="groupName">组名。</param>
        /// <param name="groupWeight">组权重。</param>
        /// <typeparam name="T">组类型。</typeparam>
        /// <returns>是否创建成功。</returns>
        bool CreateUIGroup<T>(string groupName,int groupWeight) where T : UIGroup;


        /// <summary>
        /// 加入组。
        /// </summary>
        /// <param name="groupName">组名。</param>
        /// <param name="uiGroupMember">组成员。</param>
        /// <param name="groupMemberWeight">组成员权重。</param>
        /// <returns>是否加入成功。</returns>
        bool Join(string groupName, UIGroupMember uiGroupMember, int groupMemberWeight);


        /// <summary>
        /// 离开组。
        /// </summary>
        /// <param name="groupName">组名。</param>
        /// <param name="uiGroupMember">组成员。</param>
        /// <returns>是否离开成功。</returns>
        bool Leave(string groupName,UIGroupMember uiGroupMember);

    }
}