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
    public sealed partial class UIManager : ManagerBase 
	{

		private LinkedList<UIWindow> m_UIWindows = new LinkedList<UIWindow>();
		
		/// <summary>
		/// 创建窗口。
		/// </summary>
		/// <param name="windowTpl">窗口模板（资源加载的预制件实例的内存引用）。</param>
		/// <param name="windowInfo">窗体信息。</param>
		/// <returns>创建出来的窗体实例。</returns>
		/// <exception cref="ArgumentException">参数不能为空异常。</exception>
		public UIWindow CreateWindow(UIWindow windowTpl,WindowInfo windowInfo)
		{
			if(null==windowTpl || null==windowInfo) throw new ArgumentException("The 'windowTpl' & 'windowInfo' can not be null or empty.");
			var window = Instantiate<UIWindow>(windowTpl);
			window.WindowInfo = windowInfo;
			var uiGroupMember = CreateUIGroupMember(window); //创建UI组成员。
			
			if (!m_UIWindows.Contains(window))
			{
				m_UIWindows.AddLast(window);
			}
			
			JoinUIGroup(window.WindowInfo.GroupId,uiGroupMember,window.WindowInfo.GroupMemberWeight);
			window.OnCreate(windowInfo);
			return window;
		}
		
		/// <summary>
		/// 获取窗体。
		/// </summary>
		/// <param name="id">UI窗体的实例Id。</param>
		/// <returns>目标窗体引用。</returns>
		public UIWindow AcquireUIWindow(long id)
		{
			return m_UIWindows.Find(v => v.WindowInfo.Id == id);
		}

		/// <summary>
		/// 销毁窗体
		/// </summary>
		/// <param name="id">UI窗体的实例Id。</param>
		public void DestroyUIWindow(long id)
		{
			var target = m_UIWindows.Find(v => v.WindowInfo.Id == id);
			m_UIWindows.Remove(target);
		    target.OnDestroyed();
		}
		
	}
}
