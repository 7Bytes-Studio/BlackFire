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

        public void Connected(string protocol)
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
                    break;
                default:
                    break;
            }
        }

    }

}
