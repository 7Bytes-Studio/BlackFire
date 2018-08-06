//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.CodeDom;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using WebSocket4Net;

namespace BlackFireFramework.Network
{
    public class UdpClient:TransportBase
    {
        public override event EventHandler<TransportEventArgs> OnConnect;
        public override event EventHandler<TransportEventArgs> OnMessage;
        public override event EventHandler<TransportEventArgs> OnClose;
        public override event EventHandler<TransportEventArgs> OnError;

        private Socket m_Socket = null;
        private string m_IP;
        private int m_Port;
        private IPEndPoint m_IPEndPoint;
        private bool m_HasConnect;
        private Thread m_Thread;
        private int m_BufferSize = 1024;
        private byte[] m_Buffer = null;
        private EndPoint m_RecEndPoint;
        
        
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="uri">统一资源定位符。udp://127.0.0.1:666</param>
        public UdpClient(string uri)
        {
            var s = uri.Split(':');
            this.m_IP = s[1].Substring(2, s[1].Length-2);
            this.m_Port = int.Parse(s[2]);
            this.m_Buffer = new byte[this.m_BufferSize];
            this.m_IPEndPoint = new IPEndPoint(IPAddress.Parse(this.m_IP), this.m_Port);
            this.m_RecEndPoint = this.m_IPEndPoint as EndPoint;
        }
        
        public override void Connect()
        {   
            m_Thread = new Thread(state =>
            {
                m_Socket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
                if (IPAddress.Any.ToString()==m_IP) //监听广播
                {
                    m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                    m_Socket.Bind(new IPEndPoint(IPAddress.Any, m_Port));
                    m_HasConnect = true;
                    if (null != OnConnect)
                    {
                        var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                        eventArgs.TransportState = TransportState.Connect;
                        OnConnect.Invoke(this, eventArgs);
                    }
                    Rev();
                }
                else if (-1!=m_IP.LastIndexOf(".255")) //广播
                {
                    m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                    m_HasConnect = true;
                    if (null != OnConnect)
                    {
                        var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                        eventArgs.TransportState = TransportState.Connect;
                        OnConnect.Invoke(this, eventArgs);
                    }
                }
            });
            m_Thread.Start();
        }

        //接收数据。
        private void Rev()
        {
            while (m_HasConnect)
            {
                var len = m_Socket.ReceiveFrom(m_Buffer,ref m_RecEndPoint);
                var tmpBuffer = new byte[len];
                Buffer.BlockCopy(m_Buffer,0,tmpBuffer,0,len);
                //接受到数据通知。
                if (null != OnMessage)
                {
                    var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                    eventArgs.TransportState = TransportState.ReceiveMessage;
                    if (len > eventArgs.Message.Length) //缓冲区不够，调整缓冲区大小。
                    {
                        eventArgs.AdjustBufferSize(len);
                    }
                    eventArgs.Length = len;
                    Buffer.BlockCopy(m_Buffer, 0, eventArgs.Message, 0, eventArgs.Length);
                    OnMessage.Invoke(this, eventArgs);
                }
            }
        }


        public override void Send(byte[] message)
        {
            if (m_HasConnect)
            {
                m_Socket.SendTo(message, m_IPEndPoint);
            }
        }

        public override void Close()
        {
            if (m_HasConnect)
            {
                m_Socket.Close();
                if (null != OnClose)
                {
                    var eventArgs = TransportEventArgs.Spawn<TransportEventArgs>();
                    eventArgs.TransportState = TransportState.CloseByUser;
                    OnClose.Invoke(this, eventArgs);
                }
                m_Thread.Abort();
                m_HasConnect = false;
            }
        }

        protected override bool KeepWaiting()
        {
            return true;
        }
        
    }
}