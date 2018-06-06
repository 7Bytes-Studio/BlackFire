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
using BlackFireFramework.Game;


namespace BlackFireFramework 
{
	public sealed class ProcessDemo : MonoBehaviour 
	{

        private void Start()
        {
            BlackFire.ModuleManager.Register<IProcessModule>();
            var processModule = BlackFire.ModuleManager.GetModule<IProcessModule>();
            Log.Info(processModule.IsWorking);
            var one = new ProcessOne("One");
            var two = new ProcessTwo("Two");
            processModule.AddProcess(one);
            processModule.AddProcess(two);
            processModule.StartFirstProcess();
        }

    }
}
