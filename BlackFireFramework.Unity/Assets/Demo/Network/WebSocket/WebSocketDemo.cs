//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class WebSocketDemo : MonoBehaviour 
	{
        private WebSocket m_WebSocket = null;

        private void Awake()
        {
            m_WebSocket = new WebSocket("ws://127.0.0.1:8282?token=wxqdaf487542");
            m_WebSocket.OnConnect += WebSocket_OnConnect;
            m_WebSocket.OnMessage += WebSocket_OnConnect;
            m_WebSocket.OnClose += WebSocket_OnConnect;
            m_WebSocket.OnError += WebSocket_OnConnect;
            m_WebSocket.Connect();
        }



        private void OnDestroy()
        {
            m_WebSocket.Close();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Send"))
            {
                m_WebSocket.Send("中国队，加油！！！");
            }
        }


        private void WebSocket_OnConnect(object sender, TransportEventArgs e)
        {
            Debug.Log(e.TransportState+"  "+e.Length +"  "+System.Text.Encoding.UTF8.GetString(e.Message,0,e.Length) +"   "+ e.GetHashCode());
            TransportEventArgs.Recycle(e);
        }
    }
}
