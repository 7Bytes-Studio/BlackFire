//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public interface ILoginUpdateView
    {
        void SetLoginState(string state);

        void LoginSuccess(string context);
        
        void LoginFailure(string context);
    }
}