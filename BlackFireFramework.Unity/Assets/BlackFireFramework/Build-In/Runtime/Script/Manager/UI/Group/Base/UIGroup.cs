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
        public virtual IEnumerable<UIGroupMember> GetUIGroupMembers()
        {
           return BlackFire.UI.GetUIGroupMembers(Id);
        }
    }
}