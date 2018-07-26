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
	public sealed class GameWindowLogic : UguiWindowLogic 
	{
        [SerializeField] private PlayerLogic m_PlayerLogicTpl = null;
        [SerializeField] private int m_Fps;
        private PlayerLogic m_LocalPlayer;
        private PlayerLogic m_RemotePlayer;

        protected override void Start()
        {
            base.Start();

            BlackFire.GatewayWorker.RegisterEntity(typeof(Player));
            BlackFire.GatewayWorker.Connect("ws://127.0.0.1:2018");

            Event.On("Player/OnLogin", this, (sender, args) =>
            {
                if (null== m_LocalPlayer)
                {
                    m_LocalPlayer = Instantiate<PlayerLogic>(m_PlayerLogicTpl,transform);
                    m_LocalPlayer.IsLocalPlayer = true;
                    m_LocalPlayer.Fps = m_Fps;
                    m_LocalPlayer.gameObject.SetActive(true);
                }
            });

            Event.On("Player/OnMatchPlayer", this, (sender, args) =>
            {
                if (null == m_RemotePlayer)
                {
                    m_RemotePlayer = Instantiate<PlayerLogic>(m_PlayerLogicTpl, transform);
                    m_RemotePlayer.IsLocalPlayer = false;
                    m_LocalPlayer.Fps = m_Fps;
                    m_RemotePlayer.gameObject.SetActive(true);
                }
            });

            Event.On("Player/OnMatchedPlayerLeave", this, (sender, args) =>
            {
                if (null != m_RemotePlayer)
                {
                    DestroyImmediate(m_RemotePlayer);
                    m_RemotePlayer = null;
                }
            });

        }


        private string uid = "Alan";
        private string fps = "60";
        private void OnGUI()
        {
            uid = GUILayout.TextField(uid);
            fps = GUILayout.TextField(fps);

            if (GUILayout.Button("Set Fps"))
            {
                if (null!= m_LocalPlayer)
                {
                    m_LocalPlayer.Fps = fps.To<int>();
                }
            }

            if (GUILayout.Button("Login"))
            {
                Player.Login(uid,"123456");
            }

            if (GUILayout.Button("MatchPlayer"))
            {
                Player.MatchPlayer();
            }

            if (GUILayout.Button("Leave"))
            {
                Player.MatchedPlayerLeave();
            }

        }


    }
}
