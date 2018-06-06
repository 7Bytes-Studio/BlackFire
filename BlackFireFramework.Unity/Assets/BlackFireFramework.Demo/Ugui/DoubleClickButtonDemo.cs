//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class DoubleClickButtonDemo : MonoBehaviour 
	{

        public void OnDoubleClickTest(object sender, EventArgs args)
        {
            Debug.Log(sender);
            Debug.Log(args);

            Debug.Log((args as DoubleClickButtonEventArgs).ClickDeltaTime);
        }

        //private void Awake()
        //{
        //    Debug.Log("Awake");
        //}

        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        //private static void TestInitAfterSceneLoad()
        //{
        //    Debug.Log("TestInitAfterSceneLoad");
        //}

        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        //private static void TestInitBeforeSceneLoad()
        //{
        //    Debug.Log("TestInitBeforeSceneLoad");
        //}

    }
}
