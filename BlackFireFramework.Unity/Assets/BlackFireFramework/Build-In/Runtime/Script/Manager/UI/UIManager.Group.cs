//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace BlackFireFramework.Unity
{

    /// <summary>
    /// UI管家。
    /// </summary>
    public sealed partial class UIManager
    {

		public bool CreateUIGroup<T>(long groupId, string groupName, int groupWeight) where T : UIGroup
		{
			return m_UIGroupModule.CreateUIGroup<T>(groupId,groupName,groupWeight);
		}
		
		private Dictionary<long,List<UIGroupMember>> m_UIGroupMembersDic = new Dictionary<long, List<UIGroupMember>>();
		public bool JoinUIGroup(long groupId,UIGroupMember uiGroupMember, int groupMemberWeight)
		{
			var joinResult = m_UIGroupModule.JoinUIGroup(groupId,uiGroupMember,groupMemberWeight);
			if (joinResult) //如果加入成功。
			{
				if (!m_UIGroupMembersDic.ContainsKey(groupId))
				{
					m_UIGroupMembersDic.Add(groupId,new List<UIGroupMember>());
				}
				m_UIGroupMembersDic[groupId].Add(uiGroupMember);
			}
			return joinResult;
		}

		public IEnumerable<UIGroupMember> GetUIGroupMembers(long groupId)
		{
			if (m_UIGroupMembersDic.ContainsKey(groupId))
			{
				return m_UIGroupMembersDic[groupId];
			}
			return null;
		}

		public bool LeaveUIGroup(UIGroupMember uiGroupMember)
		{
			return m_UIGroupModule.LeaveUIGroup(uiGroupMember.Window.WindowInfo.GroupId,uiGroupMember.Id);
		}

		private Dictionary<int,UIGroupMember> m_UIGroupMemberDic = new Dictionary<int, UIGroupMember>();
		private UIGroupMember CreateUIGroupMember(UIWindow window)
		{			
			var hashCode = window.GetHashCode();
			if (!m_UIGroupMemberDic.ContainsKey(hashCode))
			{
				var uiGroupMember = new UIGroupMember(window);
				m_UIGroupMemberDic.Add(hashCode,uiGroupMember);
			}
			return m_UIGroupMemberDic[hashCode];
		}

		public UIGroupMember QueryGroupMember(UIWindow window)
		{
			if (m_UIGroupMemberDic.ContainsKey(window.GetHashCode()))
				return m_UIGroupMemberDic[window.GetHashCode()];
			else
				return null;
		}

		/// <summary>
		/// 给小组下达命令。
		/// </summary>
		/// <param name="groupId">组Id。</param>
		/// <param name="callback">命令回调。</param>
		/// <typeparam name="T">命令接口类型。</typeparam>
		/// <returns>命令是否成功执行。</returns>
		public bool ExecuteCommand<T>(long groupId, UICommandCallback<T> callback) where T : Event.IEventHandler
		{
			return m_UIGroupModule.ExecuteCommand<T>(groupId, callback);
		}

		/// <summary>
		/// 通过UI小组名查询UI组Id。
		/// </summary>
		/// <param name="uiGroupName">UI小组名。</param>
		/// <returns>UI组Id。</returns>
		public long QueryUIGroupId(string uiGroupName)
		{
			return m_UIGroupModule.QueryUIGroupId(uiGroupName);
		}
		
	}
}
