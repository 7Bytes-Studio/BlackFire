//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public sealed class RemoteAuthLoginModel:Model,ILoginModel
    {
        void ILoginModel.Login(LoginInfo info)
        {
            //模拟服务器3s后响应客户端。
            Timer.Delay(3f).On(() => 
            {
                
                if (info.Account=="Alan" && info.Password=="123")
                {
                    if (null!=info.LoginSucceeded)
                    {
                        info.LoginSucceeded.Invoke("远程验证，登陆成功。");
                    }
                }
                else
                {
                    if (null!=info.LoginFailure)
                    {
                        info.LoginFailure.Invoke("远程验证，登陆失败。");
                    }
                }
                
                
            });
            
           
        }
    }
}