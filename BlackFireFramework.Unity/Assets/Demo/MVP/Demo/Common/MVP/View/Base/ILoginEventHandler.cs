//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Pattern;

namespace BlackFireFramework.Unity
{
    public interface ILoginEventHandler : IViewEventHandler
    {
        void Login(string account,string password);
    }
}