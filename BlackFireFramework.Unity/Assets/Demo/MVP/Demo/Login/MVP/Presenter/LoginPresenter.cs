//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public sealed class LoginPresenter : Presenter ,ILoginEventHandler
    {
        void ILoginEventHandler.Login(string account, string password)
        {
            var loginUpdateView = ViewInterface as ILoginUpdateView;
            loginUpdateView.SetLoginState("登陆中...");
            
            var loginModel = ModelInterface as ILoginModel;
            loginModel.Login(new LoginInfo()
            {
                Account = account,
                Password = password,
                LoginSucceeded =_LoginSucceeded,
                LoginFailure = _LoginFailure
            });
        }

        //登陆成功。
        private void _LoginSucceeded(string context)
        {
            var loginUpdateView = ViewInterface as ILoginUpdateView;
            loginUpdateView.SetLoginState("登陆成功！");
            loginUpdateView.LoginSuccess(context);
        }
        
        //登陆失败。
        private void _LoginFailure(string context)
        {            
            var loginUpdateView = ViewInterface as ILoginUpdateView;
            loginUpdateView.SetLoginState("登陆失败！");
            loginUpdateView.LoginFailure(context);
        }

    }
}