//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public class UIGroupMember : Organize.GroupMember
    {
        public UIGroupMember(UIWindow window)
        {
            Window = window;
            Id = window.WindowInfo.Id;
            Name = window.WindowInfo.Name;
        }
        
        
        
        public UIWindow Window { get; private set; }


        
        protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
        {
            if (null!=Window && null!=Window.Logic && Window.Logic is T)
            {
                commandCallback.Invoke((T)(object) Window.Logic);
                return true;
            }
            return false;
        }
    }
}