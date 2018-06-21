//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan
{
    public sealed class EventDemo : MonoBehaviour
    {
        private void OnGUI()
        {
            if (GUILayout.Button("这里假装在你的单机游戏里面操作玩家角色砍了一刀Boss"))
            {
                BlackFireFramework.Event.Fire(EventTopic.BossDropOfBlood, this, new BossDropOfBloodEventArgs(100));
            }
        }
    }


    /// <summary>
    /// 多个开发人员可以分开来写。
    /// </summary>
    public sealed partial class EventTopic
    {
        public const string BossDropOfBlood = "主题:Boss掉血";
    }


    /// <summary>
    /// 掉血事件主题需要传递的参数。
    /// </summary>
    public sealed class BossDropOfBloodEventArgs : System.EventArgs
    {
        public BossDropOfBloodEventArgs(int blood)
        {
            Blood = blood;
        }

        public int Blood { get; private set; }

        public override string ToString()
        {
            return string.Format("Blood:{0}",Blood);
        }
    }

}
