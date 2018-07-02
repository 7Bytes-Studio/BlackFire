//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperSocket.ClientEngine;
using System.Net;
using System;
using System.Text;

namespace Alan 
{
    public sealed class SuperSocketDemo : MonoBehaviour
    {
        private EasyClient m_Client;
        private void Start()
        {
            m_Client = new EasyClient();
            m_Client.Initialize<BlackFireServerPackageInfo>(new BlackFireServerReceiveFilter(), r =>
            {
                Debug.Log(r.Key);
                Debug.Log(r.Json);
            });

            m_Client.Connected += Client_Connected;
            m_Client.BeginConnect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4000));
        }

        private bool m_CanSend;
        private void Client_Connected(object sender, EventArgs e)
        {
            Debug.Log("Connected!!!");
            m_CanSend = true;
        }

        private void Update()
        {
            if (m_CanSend)
            {
                m_Client.Send(Encoding.UTF8.GetBytes("Login {\"Account\":\"Password\":\"abc123456789\"}"));
            }
        }

        private void OnDestroy()
        {
            m_Client.Close();
        }
    }
}
