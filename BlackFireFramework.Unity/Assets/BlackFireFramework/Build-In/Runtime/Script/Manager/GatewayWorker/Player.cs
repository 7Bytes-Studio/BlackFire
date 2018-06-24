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
	public static class Player 
	{
        public static string Uid { get; private set; }

        public static bool LoginSucceed{ get { return !string.IsNullOrEmpty(Uid); } }

        public static string MatchedPlayer { get; private set; }

        #region API
        public static void Login(string uid,string password)
        {
            BlackFire.GatewayWorker.Send("{\"type\":\"rpc\",\"uid\":\""+uid+"\",\"entity\":\"Player\",\"method\":\"Login\",\"args\":[\"" + uid + "\",\""+ password + "\"]}");
        }

        public static void MatchPlayer()
        {
            if (!LoginSucceed) return;
            BlackFire.GatewayWorker.Send("{\"type\":\"rpc\",\"uid\":\"" + Uid + "\",\"entity\":\"Player\",\"method\":\"MatchPlayer\",\"args\":[]}");
        }

        public static void SendToMatchedPlayer(string message) //组名 等价于 目标用户名
        {
            if (!LoginSucceed || string.IsNullOrEmpty(MatchedPlayer)) return;
            BlackFire.GatewayWorker.Send("{\"type\":\"rpc\",\"uid\":\"" + Uid + "\",\"entity\":\"Player\",\"method\":\"SendToMatchedPlayer\",\"args\":[\"" + MatchedPlayer + "\",\"" + message + "\"]}");
        }


        #endregion

        #region Events

        private static void OnLogin(string uid,string loginResult,string loginMessage)
        {
            if (loginResult=="true")
            {
                Uid = uid;
                Log.Info(uid);
                Log.Info(loginResult);
                Log.Info(loginMessage);
            }
        }

        private static void OnMatchPlayer(string who)
        {
            MatchedPlayer = who;
            Log.Info(who);
        }


        private static void OnMatchedPlayerLeave(string who)
        {
            MatchedPlayer = null;
            Log.Info(who);
        }

        private static void OnMatchedPlayerMessage(string fromUid,string message)
        {
            Log.Info(message);
        }

        #endregion


    }
}
