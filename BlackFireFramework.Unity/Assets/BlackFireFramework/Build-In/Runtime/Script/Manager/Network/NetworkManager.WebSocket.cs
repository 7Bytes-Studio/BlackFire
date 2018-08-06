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
        public TransportBase CreateWebSocketClient(string transportAlias, string uri, Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocketClient(uri,encoding);
            AddTransport(transportAlias, ws);
            return ws;
        }

        public TransportBase CreateWebSocketClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocketClient(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            return ws;
        }


        public TransportBase CreateUnityWebSocketClient(string transportAlias,string uri,Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new UnityWebSocketClient(uri,encoding);
            AddTransport(transportAlias,ws);
            StartCoroutine(ws);
            return ws;
        }


        public TransportBase CreateUnityWebSocketClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new UnityWebSocketClient(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            StartCoroutine(ws);
            return ws;
        }

    }
}
