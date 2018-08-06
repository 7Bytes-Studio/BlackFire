//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public sealed partial class NetworkManager
    {
        
        public TransportBase CreateUdpClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var udp = new UdpClient(uri);
            AddTransport(transportAlias,udp);
            return udp;
        }

        public TransportBase CreateUnityUdpClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var udp = new SyncUdpClient(uri);
            AddTransport(transportAlias, udp);
            StartCoroutine(udp);
            return udp;
        }
        
    }
}
