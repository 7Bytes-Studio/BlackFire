//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public sealed class LocalAuthLoginModel:Model,ILoginModel
    {
        void ILoginModel.Login(LoginInfo info)
        {
            if (info.Account=="Alan" && info.Password=="123")
            {
                if (null!=info.LoginSucceeded)
                {
                    info.LoginSucceeded.Invoke("本地验证，登陆成功。");
                }
            }
            else
            {
                if (null!=info.LoginFailure)
                {
                    info.LoginFailure.Invoke("本地验证，登陆失败。");
                }
            }
        }
    }
}