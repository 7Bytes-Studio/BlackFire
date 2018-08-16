using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public interface IUIManager:IManager
    {
        bool CreateUIGroup<T>(long groupId, string groupName, int groupWeight) where T : UIGroup;
        IEnumerable<UIGroupMember> GetUIGroupMembers(long groupId);
        bool LeaveUIGroup(UIGroupMember uiGroupMember);
        UIGroupMember QueryGroupMember(UIWindow window);

        /// <summary>
        /// 给小组下达命令。
        /// </summary>
        /// <param name="groupId">组Id。</param>
        /// <param name="callback">命令回调。</param>
        /// <typeparam name="T">命令接口类型。</typeparam>
        /// <returns>命令是否成功执行。</returns>
        bool ExecuteCommand<T>(long groupId, UICommandCallback<T> callback) where T : Event.IEventHandler;

        /// <summary>
        /// 通过UI小组名查询UI组Id。
        /// </summary>
        /// <param name="uiGroupName">UI小组名。</param>
        /// <returns>UI组Id。</returns>
        long QueryUIGroupId(string uiGroupName);

        IUIEventDataHelper UIEventDataHelper { get; }

        /// <summary>
        /// 创建窗口。
        /// </summary>
        /// <param name="windowTpl">窗口模板（资源加载的预制件实例的内存引用）。</param>
        /// <param name="windowInfo">窗体信息。</param>
        /// <returns>创建出来的窗体实例。</returns>
        /// <exception cref="ArgumentException">参数不能为空异常。</exception>
        UIWindow CreateWindow(UIWindow windowTpl,WindowInfo windowInfo);

        /// <summary>
        /// 获取窗体。
        /// </summary>
        /// <param name="id">UI窗体的实例Id。</param>
        /// <returns>目标窗体引用。</returns>
        UIWindow AcquireUIWindow(long id);

        /// <summary>
        /// 销毁窗体
        /// </summary>
        /// <param name="id">UI窗体的实例Id。</param>
        void DestroyUIWindow(long id);
        
        /// <summary>
        /// 加入UI组。
        /// </summary>
        /// <param name="groupId">UI组Id。</param>
        /// <param name="uiGroupMember">UI组成员Id。</param>
        /// <param name="groupMemberWeight">UI组成员权重。</param>
        /// <returns>是否成功加入UI组。</returns>
        bool JoinUIGroup(long groupId,UIGroupMember uiGroupMember, int groupMemberWeight);
    }
}
