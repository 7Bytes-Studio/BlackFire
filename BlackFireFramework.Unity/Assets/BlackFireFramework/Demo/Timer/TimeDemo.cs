
//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class TimeDemo : MonoBehaviour 
	{

        private void Start()
        {
            Timer.Delay(1f).On(()=> {

                Log.Info("Delay Hello world!");

            });

            Timer.DelayFrame(1).On(() => {

                Log.Info("DelayFrame Hello world!");

            });

            Timer.RealDelay(1f).On(() => {

                Log.Info("RealDelay Hello world!");

            });

            Timer.Interval(1f).On(() => {

                Log.Info("Interval Hello world!");

            });

        }

    }
}
