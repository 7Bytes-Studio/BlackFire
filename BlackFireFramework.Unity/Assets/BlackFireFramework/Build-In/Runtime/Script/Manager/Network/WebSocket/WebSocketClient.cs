//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.IO;
using System.Text;
using System.Threading;
using WebSocket4Net;

namespace BlackFireFramework.Unity
{
    public class WebSocketClient : TransportBase
    {
        public override event EventHandler<TransportEventArgs> OnConnect;
        public override event EventHandler<TransportEventArgs> OnMessage;
        public override event EventHandler<TransportEventArgs> OnClose;
        public override event EventHandler<TransportEventArgs> OnError;

        private WebSocket4Net.WebSocket m_WebSocket;
        private Encoding m_Encoding = Encoding.UTF8;

        public WebSocketClient(string uri,Encoding encoding=null)
        {
            if (null != encoding) m_Encoding = encoding;//设置编码。

            InitWebSocket(uri);

        }


        private void InitWebSocket(string uri)
        {
            m_WebSocket = new WebSocket4Net.WebSocket(uri);
            m_WebSocket.Opened += WebSocket_Opened;
            m_WebSocket.MessageReceived += WebSocket_MessageReceived;
            m_WebSocket.Error += WebSocket_Error;
            m_WebSocket.Closed += WebSocket_Closed;
        }


        #region WebSocket4Net EventHandler


        private void WebSocket_Opened(object sender, EventArgs e)
        {

#if BLACKFIRE
            UnityEngine.Debug.Log("WebSocket_Opened");
#endif
            if (null!=OnConnect)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.Connect;
                OnConnect.Invoke(this, eventArgs);
            }

        }

        private bool m_CloseByRemoteFlag = false;
        private void WebSocket_Closed(object sender, EventArgs e)
        {

#if BLACKFIRE
            UnityEngine.Debug.Log("WebSocket_Closed");
#endif
            if (!m_CloseByUserFlag)
            {
                m_CloseByRemoteFlag = true;

                if (null != OnClose)
                {
                    var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                    eventArgs.TransportState = TransportState.CloseByRemote;
                    OnClose.Invoke(this, eventArgs);
                }
            }

        }

        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {

#if BLACKFIRE
            UnityEngine.Debug.Log("WebSocket_MessageReceived   "+e.Message);
#endif

            if (null != OnMessage)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.ReceiveMessage;
                var bytes = System.Text.Encoding.UTF8.GetBytes(e.Message);
                if (bytes.Length>eventArgs.Message.Length) //缓冲区不够，调整缓冲区大小。
                {
                    eventArgs.AdjustBufferSize(bytes.Length);
                }
                eventArgs.Length = bytes.Length;
                Buffer.BlockCopy(bytes, 0, eventArgs.Message, 0, eventArgs.Length);
                OnMessage.Invoke(this, eventArgs);
            }

        }

        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {

#if BLACKFIRE
            UnityEngine.Debug.Log("WebSocket_Error");
#endif

            if (null != OnError)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.Error;
                OnError.Invoke(this, eventArgs);
            }

        }


        #endregion

        #region API

        private bool m_CloseByUserFlag = false;
        public override void Close()
        {
            m_CloseByUserFlag = true;

            m_WebSocket.Close();

            if (!m_CloseByRemoteFlag && null != OnClose)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.CloseByUser;
                OnClose.Invoke(this, eventArgs);
            }
           
        }

        public override void Send(byte[] message)
        {
            m_WebSocket.Send(m_Encoding.GetString(message,0, message.Length));
        }

        private bool m_HasCallConnectFlag = false;
        private bool m_HasWaitCallConnectFlag = false;
        public override void Connect()
        {
            if (m_HasCallConnectFlag) throw new Exception("This method 'Connect()' can only be called once.");
            if (null != m_WebSocket)
            {
                m_WebSocket.Open();
                m_HasWaitCallConnectFlag = true;
            }
            m_HasCallConnectFlag = true;
        }

        protected override bool KeepWaiting()
        {
            if (!m_HasWaitCallConnectFlag && m_HasCallConnectFlag && null!=m_WebSocket)
            {
                m_WebSocket.Open();
                m_HasWaitCallConnectFlag = true;
            }
            return true;
        }


        #endregion

    }
}
