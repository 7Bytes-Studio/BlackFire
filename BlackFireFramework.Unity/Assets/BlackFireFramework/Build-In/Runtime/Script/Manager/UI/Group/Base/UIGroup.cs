//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Unity
{
    public class UIGroup : Organize.Group
    {
        protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
        {
            if (typeof(IUIGroupCommand).IsAssignableFrom(typeof(T))) //组命令。
            {
                return base.HandleCommand<T>(commandCallback);
            }
            else if (typeof(IUIGroupMemberCommand).IsAssignableFrom(typeof(T))) //成员命令。
            {
                var members = AcquirAllGroupMembers();
                foreach (var member in members)
                {
                    var result = Organize.ExecuteCommand(this.Id, member.Id, commandCallback, false);
                    if (result)
                    {
                        return true;
                    }
                }
            }
            else if (typeof(IUIGroupMembersCommand).IsAssignableFrom(typeof(T))) //成员命令。
            {
                var members = AcquirAllGroupMembers();
                bool hasHandler = false;
                foreach (var member in members)
                {
                    var result = Organize.ExecuteCommand(this.Id, member.Id, commandCallback, false);
                    if (result)
                    {
                        hasHandler = true;
                    }
                }
                return hasHandler;
            }
            return false;
        }
    }
}