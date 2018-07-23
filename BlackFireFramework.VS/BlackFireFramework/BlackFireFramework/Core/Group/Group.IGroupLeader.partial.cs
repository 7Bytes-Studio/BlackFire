//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    public static partial class Group
    {
        /// <summary>
        /// 小组组长接口。
        /// </summary>
        public interface IGroupLeader : IGroupMember
        {
            /// <summary>
            /// 加入小组的第一个成员。
            /// </summary>
            IGroupMember FirstIntrant { get; }

            /// <summary>
            /// 加入小组的最后一个成员。
            /// </summary>
            IGroupMember LastIntrant { get; }

            /// <summary>
            /// 添加小组成员。
            /// </summary>
            /// <param name="groupMember">小组成员。</param>
            /// <returns>是否添加成功。</returns>
            bool AddGroupMember(IGroupMember groupMember);

            /// <summary>
            /// 移除小组成员。
            /// </summary>
            /// <param name="groupMemberName">小组成员名字。</param>
            /// <returns>是否移除成功。</returns>
            bool RemoveGroupMember(string groupMemberName);

            /// <summary>
            /// 获取指定名字的小组成员。
            /// </summary>
            /// <param name="groupMemberName">小组成员名字。</param>
            /// <returns>小组成员。</returns>
            IGroupMember GetGroupMember(string groupMemberName);

            /// <summary>
            /// 给指定名字成员下达命令(假设该成员具有处理该命令的能力)。
            /// </summary>
            /// <typeparam name="T">命令接口类型。</typeparam>
            /// <param name="groupMemberName">指定的小组成员名。</param>
            /// <param name="commandCallback">小组成员拥有的接口命令执行回调。</param>
            /// <returns>命令是否处理完毕。</returns>
            bool ExecuteCommand<T>(string groupMemberName,ActionCommandCallback<T> commandCallback) where T : ICommand;

            /// <summary>
            /// 给所有小组成员们依次下达命令。
            bool ExecuteCommand<T>(ActionCommandCallback<T> commandCallback) where T : ICommand;

            /// <summary>
            /// 给小组成员们依次下达命令，如果已经有小组成员处理完毕了，那么将终止往下下达命令。
            /// </summary>
            bool ExecuteCommand<T>(FuncCommandCallback<T> commandCallback) where T : ICommand;

            /// <summary>
            /// 给小组成员们责任链式下达命令，执行顺序按照小组成员能力由低到高。
            /// </summary>
            bool ExecuteChainCommand<T>(ChainCommandCallback<T> commandCallback) where T : ICommand;
        }
    }
}
