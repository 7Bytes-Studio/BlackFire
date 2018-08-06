//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireFramework.Network
{
    public class UnityTcpClient : TcpClient
    {
        public override event EventHandler<TransportEventArgs> OnConnect;
        public override event EventHandler<TransportEventArgs> OnMessage;
        public override event EventHandler<TransportEventArgs> OnClose;
        public override event EventHandler<TransportEventArgs> OnError;

        private ActionQueue m_ActionQueue = new ActionQueue();

        public UnityTcpClient(string uri) : base(uri)
        {
            base.OnConnect += UnityTcpClient_OnConnect;
            base.OnMessage += UnityTcpClient_OnMessage;
            base.OnError +=   UnityTcpClient_OnError;
            base.OnClose += UnityTcpClient_OnClose;
        }

        protected override bool KeepWaiting()
        {
            base.KeepWaiting();
            while (0 < m_ActionQueue.Count)
            {
                m_ActionQueue.Dequeue().Invoke();
            }
            return true;
        }

        private void UnityTcpClient_OnClose(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnClose)
                {
                    this.OnClose.Invoke(this, e);
                }
            });
        }

        private void UnityTcpClient_OnError(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnError)
                {
                    this.OnError.Invoke(this, e);
                }
            });
        }

        private void UnityTcpClient_OnMessage(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnMessage)
                {
                    this.OnMessage.Invoke(this, e);
                }
            });
        }

        private void UnityTcpClient_OnConnect(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnConnect)
                {
                    this.OnConnect.Invoke(this, e);
                }
            });
        }


    }
}
