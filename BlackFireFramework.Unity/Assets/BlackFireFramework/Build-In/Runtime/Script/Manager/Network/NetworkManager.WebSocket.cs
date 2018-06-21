//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Text;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class NetworkManager
    {
        public TransportBase CreateWebSocket(string transportAlias, string uri, Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocket(uri,encoding);
            AddTransport(transportAlias, ws);
            return ws;
        }

        public TransportBase CreateWebSocket(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocket(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            return ws;
        }


        public TransportBase CreateUnityWebSocket(string transportAlias,string uri,Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new UnityWebSocket(uri,encoding);
            AddTransport(transportAlias,ws);
            StartCoroutine(ws);
            return ws;
        }

        public TransportBase CreateUnityWebSocket(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new UnityWebSocket(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            StartCoroutine(ws);
            return ws;
        }





        private void CheckTransportExistsOrThrow(string transportAlias)
        {
            if (HasTransport(transportAlias)) throw new System.Exception("The transport already exists!");
        }

    }
}
