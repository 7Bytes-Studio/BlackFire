//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public sealed class WebSocketDemo : MonoBehaviour 
	{
        private TransportBase m_WebSocket = null;

        private void Awake()
        {
            m_WebSocket = BlackFire.Network.CreateUnityWebSocketClient("GatewayWorker::WebSocket::Client", "ws://127.0.0.1:2018?token=wxqdaf487542");
            m_WebSocket.OnConnect += WebSocket_OnConnect;
            m_WebSocket.OnMessage += WebSocket_OnConnect;
            m_WebSocket.OnClose += WebSocket_OnConnect;
            m_WebSocket.OnError += WebSocket_OnConnect;
            m_WebSocket.Connect();

            //Json Test

            string json = "{\"type\":666,\"rooms\":[\"room1\",\"room2\",\"room3\",123,{\"hello\":\"kitty\"}]}";

            var jo = new JObject();
            jo.Add("uid", "wxid12346579");
            jo.Add("password", "987654321");
            jo.Add("group_list",new JArray() {});
            var str = jo.ToString(Formatting.None);

            Debug.Log(str);

            var o = JObject.Parse(json);

            Debug.Log(o["type"]);

            Debug.Log(o["rooms"]);
            var jarray = o["rooms"] as JArray;
            foreach (var item in jarray)
            {
                Debug.Log(item.ToString());
            }
            
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
            Debug.Log("id:"+System.Threading.Thread.CurrentThread.ManagedThreadId+"   " + e.GetHashCode() + "   "  + e.TransportState+"  "+e.Length +"  "+System.Text.Encoding.UTF8.GetString(e.Message,0,e.Length) );
            TransportEventArgs.Recycle(e);
        }
    }
}
