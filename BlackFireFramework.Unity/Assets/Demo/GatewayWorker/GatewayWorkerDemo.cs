//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
	public sealed class GatewayWorkerDemo : MonoBehaviour 
	{
        private void Start()
        {
            BlackFire.GatewayWorker.RegisterEntity(typeof(Player));
            BlackFire.GatewayWorker.Connect("ws://127.0.0.1:2018");
        }

        private string uid="Alan";
        private void OnGUI()
        {
            uid = GUILayout.TextField(uid);

            if (GUILayout.Button("Login"))
            {
                Player.Login(uid, "123456");
            }

            if (GUILayout.Button("MatchPlayer"))
            {
                Player.MatchPlayer();
            }

            if (GUILayout.Button("MatchedPlayerLeave"))
            {
                Player.MatchedPlayerLeave();
            }

        }



    }
}
