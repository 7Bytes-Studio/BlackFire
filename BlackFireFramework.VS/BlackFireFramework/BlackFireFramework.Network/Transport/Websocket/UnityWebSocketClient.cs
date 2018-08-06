//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace BlackFireFramework.Network
{
    public sealed class UnityWebSocketClient : WebSocketClient
    {
        public override event EventHandler<TransportEventArgs> OnConnect;
        public override event EventHandler<TransportEventArgs> OnMessage;
        public override event EventHandler<TransportEventArgs> OnClose;
        public override event EventHandler<TransportEventArgs> OnError;

        private ActionQueue m_ActionQueue = new ActionQueue();
  
        public UnityWebSocketClient(string uri,Encoding encoding = null) : base(uri,encoding)
        {
            base.OnConnect += UnityWebSocket_OnConnect;
            base.OnMessage += UnityWebSocket_OnMessage;
            base.OnError += UnityWebSocket_OnError;
            base.OnClose += UnityWebSocket_OnClose;
        }

        private void UnityWebSocket_OnClose(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnClose)
                {
                    this.OnClose.Invoke(this, e);
                }
            });
        }

        private void UnityWebSocket_OnError(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnError)
                {
                    this.OnError.Invoke(this, e);
                }
            });
        }

        private void UnityWebSocket_OnConnect(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnConnect)
                {
                    this.OnConnect.Invoke(this, e);
                }
            });
        }

        private void UnityWebSocket_OnMessage(object sender, TransportEventArgs e)
        {
            m_ActionQueue.Enqueue(() => {
                if (null != this.OnMessage)
                {
                    this.OnMessage.Invoke(this, e);
                }
            });
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

    }
}
