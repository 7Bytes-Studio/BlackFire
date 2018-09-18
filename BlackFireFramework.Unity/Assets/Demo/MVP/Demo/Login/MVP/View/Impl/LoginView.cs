//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public sealed class LoginView : View , ILoginUpdateView
    {
        private UIWindow m_LoginWindowTpl;
        private UIWindow m_LoginWindow;
        private ILoginWindowLogic m_Logic;
        
        protected override void OnInit()
        {
            m_LoginWindowTpl = UnityEngine.Resources.Load<UIWindow>("UI/LoginWindow");
            m_LoginWindow = BlackFire.UI.CreateWindow(m_LoginWindowTpl,666,"LoginWindow","Default");
            m_LoginWindow.Layer = 1;
            m_LoginWindow.Open();
            m_Logic = m_LoginWindow.Logic as ILoginWindowLogic;
            m_Logic.OnLogin += _OnLogin;
        }

        protected override void OnDestroy()
        {
            m_Logic.OnLogin -= _OnLogin;
            if (null!=m_LoginWindow)
            {
                UnityEngine.Object.DestroyImmediate(m_LoginWindow.gameObject);
            }

            m_LoginWindow = null;
            m_LoginWindowTpl = null;
        }

        private void _OnLogin(object sender,OnLoginEventArgs args)
        {
            Fire<ILoginEventHandler>(i=>i.Login(args.Account,args.Password));
        }

        void ILoginUpdateView.SetLoginState(string state)
        {
            m_Logic.SetLoginState(state);
        }

        void ILoginUpdateView.LoginSuccess(string context)
        {
            Log.Info(":::LoginSuccess:::"+context);
        }

        void ILoginUpdateView.LoginFailure(string context)
        {
            Log.Info(":::LoginFailure:::"+context);
        }
    }
}