//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{

    /// <summary>
    /// GatewayWorker客户端管家。
    /// </summary>
	public sealed partial class GatewayWorkerManager : ManagerBase
    {
        [SerializeField] private GatewayWorkerProtocol m_Protocol;
        public GatewayWorkerProtocol Protocol { get { return m_Protocol; } }

        private TransportBase m_TransportProtocol = null;

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            m_TransportProtocol.Close();
        }


        /// <summary>
        /// 连接服务器。
        /// </summary>
        /// <param name="protocol">ex: [ws://127.0.0.1:1994 | tcp://127.0.0.1:1994 | udp://127.0.0.1:1994]</param>
        public void Connect(string protocol)
        {
            if (null != m_TransportProtocol) throw new System.Exception("It's already connected,Please do not try the connection again.");

            switch (m_Protocol)
            {
                case GatewayWorkerProtocol.Tcp:
                    break;
                case GatewayWorkerProtocol.Udp:
                    break;
                case GatewayWorkerProtocol.Websocket:
                    m_TransportProtocol = BlackFire.Network.CreateUnityWebSocket("GatewayWorkerClient", protocol);
                    m_TransportProtocol.Connect();
                    m_TransportProtocol.OnMessage += M_TransportProtocol_OnConnect;
                    break;
                default:
                    break;
            }
        }

        private void M_TransportProtocol_OnConnect(object sender, TransportEventArgs e)
        {
            Debug.Log(e.MessageString()+e.Length);
        }

        public void Send(byte[] message)
        {
            m_TransportProtocol.Send(message);
        }
        public void Send(string message)
        {
            m_TransportProtocol.Send(message);
        }




    }

}
