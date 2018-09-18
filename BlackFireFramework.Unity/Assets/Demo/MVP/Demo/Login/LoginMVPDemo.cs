//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class LoginMVPDemo : MonoBehaviour
    {
        
        [Header("切换数据模型")][SerializeField] private bool m_UseRemoteAuth;
        private bool m_LastState;
        private void Start()
        {
            Bind();
        }

      

        private void Update()
        {
            if (m_LastState!=m_UseRemoteAuth)
            {
                Bind();
                m_LastState = m_UseRemoteAuth;
            }
        }
        
        
        private void Bind()
        {
            if (m_UseRemoteAuth)
            {
                BlackFire.MVP.BindMVP<RemoteAuthLoginModel,LoginView,LoginPresenter>();
            }
            else
            {
                BlackFire.MVP.BindMVP<LocalAuthLoginModel,LoginView,LoginPresenter>();
            }
        }
        
    }
}