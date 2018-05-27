//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan 
{
	public sealed class EventDemo_UIHandler : MonoBehaviour 
	{
        private void Start()
        {
            BlackFireFramework.Event.On(EventTopic.BossDropOfBlood, this, (sender, args) => {

                var cargs = args as BossDropOfBloodEventArgs;
                Log.Info(string.Format("UI界面减血{0}。  Sender : {1}   Args : {2}", cargs.Blood, sender,  cargs.ToString()));
            });
        }

        private void OnDestroy()
        {
            BlackFireFramework.Event.Off(EventTopic.BossDropOfBlood, this);
        }
    }
}
