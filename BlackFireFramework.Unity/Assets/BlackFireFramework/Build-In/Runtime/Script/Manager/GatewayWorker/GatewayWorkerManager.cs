//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// GatewayWorker客户端管家。
    /// </summary>
	public sealed partial class GatewayWorkerManager : ManagerBase
    {
        [SerializeField] private GatewayWorkerProtocol m_Protocol;
        public GatewayWorkerProtocol Protocol { get { return m_Protocol; } }

        [SerializeField] private GatewayWorkerState m_GatewayWorkerState;
        [SerializeField] private TransportState m_TransportState;

        private TransportBase m_TransportProtocol = null;

        /// <summary>
        /// 客户端ID。
        /// </summary>
        public string ClientId { get; private set; }

        #region Module Events

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            if (null!=m_TransportProtocol)
            {
                m_TransportProtocol.Close();
            }
        }

        #endregion


        #region API

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
                    m_TransportProtocol = BlackFire.Network.CreateUnityWebSocketClient("GatewayWorkerClient", protocol);
                    m_TransportProtocol.OnConnect += TransportProtocol_OnConnect;
                    m_TransportProtocol.OnMessage += TransportProtocol_OnMessage;
                    m_TransportProtocol.OnClose += TransportProtocol_OnClose;
                    m_TransportProtocol.OnError += TransportProtocol_OnError;
                    m_TransportProtocol.Connect();
                    break;
                default:
                    break;
            }
        }



        public void Send(byte[] message)
        {
            m_TransportProtocol.Send(message);
        }
        public void Send(string message)
        {
            m_TransportProtocol.Send(message);
        }


        #endregion


        #region Private


        private void TransportProtocol_OnMessage(object sender, TransportEventArgs e)
        {
            m_TransportState = e.TransportState;
            try
            {
                Log.Info(e.MessageString());
                ServerMessageHandler(JObject.Parse(e.MessageString()));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
            
        }

        private void ServerMessageHandler(JObject jo)
        {
            if (null != jo["type"])
            {
                var type = jo["type"].ToString();

                if ("connect" == type)
                {
                    if (null != jo["client_id"])
                    {
                        ClientId = jo["client_id"].ToString();
                    }
                }
                else if ("rpc" == type)
                {
                    if (null != jo["entity"] && null != jo["method"])
                    {
                        var entity = jo["entity"].ToString();
                        var method = jo["method"].ToString();
                        object[] pars = null;
                        if (null != jo["args"])
                        {
                            var jarray = jo["args"] as JArray;
                            pars = new object[jarray.Count];
                            int i = 0;
                            foreach (var item in jarray)
                            {
                                pars[i++] = item.ToString();
                            }
                        }
                        Invoke(entity,method, pars);
                    }
                    
                }
            }
        }


        private void TransportProtocol_OnConnect(object sender, TransportEventArgs e)
        {
            m_GatewayWorkerState = GatewayWorkerState.Online;
            m_TransportState = e.TransportState;
        }

        private void TransportProtocol_OnClose(object sender, TransportEventArgs e)
        {
            m_GatewayWorkerState = GatewayWorkerState.Offline;
            m_TransportState = e.TransportState;
        }
        private void TransportProtocol_OnError(object sender, TransportEventArgs e)
        {
            m_TransportState = e.TransportState;
        }
        #endregion


        #region Entity


        private void Invoke(string entityName,string methodName,params object[] pars)
        {
            var list = GetEntities(entityName);
            for (int i = 0; i < list.Count; i++)
            {
                BlackFireFramework.Utility.Reflection.Invoke(list[i],methodName,pars);
            }
        }


        private LinkedList<Type> m_Entity = new LinkedList<Type>();
        private List<Type> GetEntities(string entityType)
        {
            List<Type> entityTypes = new List<Type>();
            var current = m_Entity.First;
            while (null!=current)
            {
                if (entityType==current.Value.Name)
                {
                    entityTypes.Add(current.Value);
                }
                current = current.Next;
            }
            return entityTypes;
        }


        public void RegisterEntity(Type entityType)
        {
            if (!m_Entity.Contains(entityType))
            {
                m_Entity.AddLast(entityType);
            }
        }

        public void RemoveEntity(Type entityType)
        {
            if (m_Entity.Contains(entityType))
            {
                m_Entity.Remove(entityType);
            }
        }


        #endregion

    }

}
