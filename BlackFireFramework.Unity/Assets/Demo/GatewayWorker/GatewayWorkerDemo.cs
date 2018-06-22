//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
	public sealed class GatewayWorkerDemo : MonoBehaviour 
	{
        private void Start()
        {
            BlackFire.GatewayWorker.Connect("ws://127.0.0.1:2018");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Send"))
            {
                BlackFire.GatewayWorker.Send("{\"type\":\"rpc\",\"entity\":\"Player\",\"method\":\"Login\",\"args\":[\"666\",\"777\"]}");
            }
        }

    }
}
