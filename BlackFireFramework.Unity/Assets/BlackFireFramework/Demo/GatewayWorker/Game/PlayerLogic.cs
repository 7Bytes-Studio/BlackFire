//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class PlayerLogic : UguiLogicBase 
	{
        [SerializeField] private bool m_IsLocalPlayer;
        public bool IsLocalPlayer { get { return m_IsLocalPlayer; } set { m_IsLocalPlayer = value; } }
        private Vector2 m_InputPosition;
        [SerializeField] private float m_MoveSpeed=10f;
        [SerializeField] private int m_Fps;
        private Text m_NameText;

        public int Fps { get { return m_Fps; } set { m_Fps = value; m_EventFireIntervel = 1 / value; } }
        private float m_EventFireIntervel;
        protected override void Start()
        {
            base.Start();
            Debug.Log(IsLocalPlayer);
            var img = GetComponent<Image>();
            m_NameText = GetComponentInChildren<Text>();
            if (!IsLocalPlayer) //如果是网络玩家。
            {
                Event.On("Player/OnSyncPlayerState", this, (sender, args) =>
                {
                    var cargs = args as PlayerStateEventArgs;
                    m_InputPosition = new Vector2(cargs.px, cargs.py);
                    PlayerStateEventArgs.Recycle(cargs);
                });
                img.sprite = Instantiate<Sprite>(UnityEngine.Resources.Load<Sprite>("RemotePlayer"));
                m_NameText.text = Player.MatchedPlayer;
            }
            else
            {
                m_EventFireIntervel = 1f/m_Fps;
                img.sprite = Instantiate<Sprite>(UnityEngine.Resources.Load<Sprite>("LocalPlayer"));
                m_NameText.text = Player.Uid;
                StartCoroutine(SyncPlayerState());
            }
        }

        private IEnumerator SyncPlayerState() //同步本地玩家的状态给服务端。
        {
            while (true)
            {
                yield return new WaitForSeconds(m_EventFireIntervel);
                Player.SyncPlayerState(CachedRectTransform.anchoredPosition.x.ToString(), CachedRectTransform.anchoredPosition.y.ToString());
            }
        }

        protected override void Update()
        {
            base.Update();

            if (IsLocalPlayer) //如果是本地玩家。
            {
                m_InputPosition = LocalPlayerInput();
                CachedRectTransform.anchoredPosition = Vector2.Lerp(CachedRectTransform.anchoredPosition, CachedRectTransform.anchoredPosition + m_InputPosition, Time.deltaTime * m_MoveSpeed);
            }
            else
            {
                CachedRectTransform.anchoredPosition = Vector2.Lerp(CachedRectTransform.anchoredPosition,m_InputPosition, Time.deltaTime * m_MoveSpeed);
            }

        }

        private Vector2 LocalPlayerInput()
        {
            if (Input.GetKey(KeyCode.W)) //上
            {
               return new Vector2(m_InputPosition.x, m_InputPosition.y + 1);
            }
            else if (Input.GetKey(KeyCode.S)) //下
            {
                return  new Vector2(m_InputPosition.x, m_InputPosition.y - 1);
            }
            else if (Input.GetKey(KeyCode.A)) //左
            {
                return new Vector2(m_InputPosition.x - 1, m_InputPosition.y);
            }
            else if (Input.GetKey(KeyCode.D)) //右
            {
                return new Vector2(m_InputPosition.x + 1, m_InputPosition.y);
            }
            return Vector2.zero;
        }

    }
}
