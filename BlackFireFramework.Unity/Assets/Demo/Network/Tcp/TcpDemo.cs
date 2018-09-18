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
using BlackFireFramework.Unity;
using BlackFireFramework;
using UnityEngine.EventSystems;
using BlackFireFramework.Network;

namespace Alan
{
    public sealed class TcpDemo : MonoBehaviour
    {
        private TransportBase tcpClient = null;

        private IEnumerator Start()
        {


























            tcpClient = BlackFire.Network.CreateUnityTcpClient("SuperSocket:::","tcp://127.0.0.1:4000");
            tcpClient.Connect();
            tcpClient.OnConnect += TcpClientt_Connected;
            tcpClient.OnMessage += TcpClient_OnMessage;
            while (true)
            {
                yield return new WaitForSeconds(1/60);
                if (m_CanSend)
                {
                    tcpClient.Send(Encoding.UTF8.GetBytes("Login {\"Account\":\"Password\":\"abc123456789\"}"));
                }
            }

        }

        private void TcpClient_OnMessage(object sender, TransportEventArgs e)
        {
            Debug.Log(e.MessageString());
        }

        private bool m_CanSend;
        private void TcpClientt_Connected(object sender, EventArgs e)
        {
            Debug.Log("Connected!!!");
            m_CanSend = true;
        }


        private void OnDestroy()
        {
            if (null!= tcpClient)
            {
                tcpClient.Close();
            }
        }
    }
}
