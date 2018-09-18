//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class LoginWindowLogic :UguiWindowLogic,ILoginWindowLogic
    {
        [SerializeField] private Text m_TextState;
        [SerializeField] private InputField m_InputFieldAccount;
        [SerializeField] private InputField m_InputFieldPassword;
        
        public event EventHandler<OnLoginEventArgs> OnLogin;
        
        public void SetLoginState(string state)
        {
            m_TextState.text = state;
        }

        public void OnLoginEventHandler()
        {
            if (null!=OnLogin)
            {
                OnLogin.Invoke(this,new OnLoginEventArgs()
                {
                    Account = m_InputFieldAccount.text,
                    Password = m_InputFieldPassword.text
                });
            }
        }
    }
}