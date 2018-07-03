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
    /// <summary>
    /// 假装这个是怪物的脚部绑定的触发器。
    /// </summary>
	public sealed class BeShotTrigger : MonoBehaviour 
	{

        private void OnGUI()
        {
            if (GUILayout.Button("冒泡事件:::怪物的脚被子弹打中"))
            {
                BlackFireFramework.Event.Fire<IBeShotHandler>(this,x => x.BeShot(100));
            }
        }

    }
}
