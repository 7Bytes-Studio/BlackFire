//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public sealed class UIGroupModule:IUIGroupModule
    {
        public bool CreateUIGroup<T>(long groupId, string groupName, int groupWeight) where T : UIGroup
        {
            return Organize.CreateGroup<T>(groupId,groupName,groupWeight);
        }

        public long QueryUIGroupId(string uiGroupName)
        {
            return Organize.GetGroupId(uiGroupName);
        }

        public bool JoinUIGroup(long groupId, UIGroupMember uiGroupMember, int groupMemberWeight)
        {
            return Organize.Join(groupId, uiGroupMember, groupMemberWeight);
        }

        public bool LeaveUIGroup(long groupId, long uiGroupMemberId)
        {
            return Organize.Leave(groupId, uiGroupMemberId);
        }

        public bool ExecuteCommand<T>(long groupId, UICommandCallback<T> callback) where T : Event.IEventHandler
        {
            return Organize.ExecuteCommand<T>(groupId,i=>callback.Invoke(i),false);
        }
    }
}