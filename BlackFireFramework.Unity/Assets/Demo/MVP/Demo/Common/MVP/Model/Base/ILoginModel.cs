//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    
    public interface ILoginModel
    {
        void Login(LoginInfo info);
    }

    
    public sealed class LoginInfo
    {
        public string Account;

        public string Password;

        public Action<string> LoginSucceeded;

        public Action<string> LoginFailure;
    }

}