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
    public class TcpClient : TransportBase
    {
        public override event EventHandler<TransportEventArgs> OnConnect;
        public override event EventHandler<TransportEventArgs> OnMessage;
        public override event EventHandler<TransportEventArgs> OnClose;
        public override event EventHandler<TransportEventArgs> OnError;

        private EasyClient m_Client;
        private string m_Ip;
        private int m_Port;


        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="uri">统一资源定位符。tcp://127.0.0.1:666</param>
        public TcpClient(string uri)
        {
            var s = uri.Split(':');
            m_Ip = s[1].Substring(2, s[1].Length-2);
            m_Port = int.Parse(s[2]);
        }

        public override void Connect()
        {
            if (null != m_Client) throw new Exception("This method 'Connect()' can only be called once.");
            m_Client = new EasyClient();
            m_Client.Initialize<DefaultPackageInfo>(new DefaultReceiveFilter(),r =>
            {
                if (null != OnMessage)
                {
                    var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                    eventArgs.TransportState = TransportState.ReceiveMessage;
                    if (r.Data.Length > eventArgs.Message.Length) //缓冲区不够，调整缓冲区大小。
                    {
                        eventArgs.AdjustBufferSize(r.Data.Length);
                    }
                    eventArgs.Length = r.Data.Length;
                    Buffer.BlockCopy(r.Data, 0, eventArgs.Message, 0, eventArgs.Length);
                    OnMessage.Invoke(this, eventArgs);
                }
            });
            m_Client.BeginConnect(new IPEndPoint(IPAddress.Parse(m_Ip), m_Port));
            m_Client.Connected += Client_Connected;
            m_Client.Closed += Client_Closed;
            m_Client.Error += Client_Error;
        }

        private void Client_Error(object sender, ErrorEventArgs e)
        {
            if (null != OnError)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.Error;
                OnError.Invoke(this, eventArgs);
            }
        }

        private void Client_Connected(object sender, EventArgs e)
        {
            if (null != OnConnect)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.Connect;
                OnConnect.Invoke(this, eventArgs);
            }
        }

        private void Client_Closed(object sender, EventArgs e)
        {
            if (!m_HasCloseByUser&&null != OnClose)
            {
                var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                eventArgs.TransportState = TransportState.CloseByRemote;
                OnClose.Invoke(this, eventArgs);
            }
        }

        private bool m_HasCloseByUser;
        public override void Close()
        {
            if (!m_HasCloseByUser&&null!= m_Client)
            {
                m_Client.Close();
                m_HasCloseByUser = true;
                if (null != OnClose)
                {
                    var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                    eventArgs.TransportState = TransportState.CloseByUser;
                    OnClose.Invoke(this, eventArgs);
                }
            }
        }

        public override void Send(byte[] message)
        {
            if (null != m_Client)
                m_Client.Send(message);
        }

        protected override bool KeepWaiting()
        {
            return true;
        }
    }
}
