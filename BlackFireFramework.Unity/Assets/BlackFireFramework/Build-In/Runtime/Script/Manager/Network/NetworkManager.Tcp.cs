//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Text;
using UnityEngine;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public sealed partial class NetworkManager
    {
        public TransportBase CreateTcpClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var tcp = new TcpClient(uri);
            AddTransport(transportAlias,tcp);
            return tcp;
        }

        public TransportBase CreateUnityTcpClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var tcp = new UnityTcpClient(uri);
            AddTransport(transportAlias, tcp);
            StartCoroutine(tcp);
            return tcp;
        }

    }
}
