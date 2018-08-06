//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Net;
using UnityEngine;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public sealed class UdpDemo : MonoBehaviour
    {
        private UdpClient udp;
        private UdpClient listener;
        
        private void Start()
        {
//            Debug.Log(IPAddress.Broadcast.ToString());
//            Debug.Log(BlackFireFramework.Utility.IP.GetPublicIP());
//            Debug.Log("192.168.1.66".LastIndexOf(".255"));
//            Debug.Log("192.168.1.0".LastIndexOf(".0"));
//            Debug.Log(IPAddress.Any.ToString()=="0.0.0.0");
            
            udp =new UdpClient("udp://255.255.255.255:9527");
            //  listener =new UdpClient("udp://0.0.0.0:9527"); //异步报错。
            listener =new SyncUdpClient("udp://0.0.0.0:9527"); //使用同步。
            StartCoroutine(listener);
            listener.OnConnect += (s,e) => { Debug.Log("listener::Connect."); };
            listener.OnMessage += (s,e) => 
            { 
                Debug.Log("listener::Message."+e.Message[0]+" "+GetComponent<Transform>().name);
            };
            listener.OnClose += (s,e) => { Debug.Log("listener::Close."); };
            
            udp.OnConnect += (s,e) => { Debug.Log("udp::Connect."); };
            udp.OnMessage += (s,e) => { Debug.Log("udp::Message."); };
            udp.OnClose += (s,e) => { Debug.Log("udp::Close."); };
            
            udp.Connect();
            listener.Connect();
        }

        private void LateUpdate()
        {
            udp.Send(new byte[]{0x69,0x68,0x67});
        }

        private void OnDestroy()
        {
            udp.Close();
            listener.Close();
        }
    }
}