//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework
{
	public sealed class GameDemo : MonoBehaviour 
	{
        private void Start()
        {
            var one = new ProcessOne("One");
            var two = new ProcessTwo("Two");
            BlackFire.Game.AddProcess(one);
            BlackFire.Game.AddProcess(two);
            BlackFire.Game.StartFirstProcess();
        }
    }
}
