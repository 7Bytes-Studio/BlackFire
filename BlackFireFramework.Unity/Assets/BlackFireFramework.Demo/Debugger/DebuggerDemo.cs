//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackFireFramework.Unity;
using BlackFireFramework;

namespace Alan 
{
	public sealed class DebuggerDemo : MonoBehaviour 
	{
        private void Update()
        {
            Log.Trace("Trace");
            Log.Debug("Debug");
            Log.Info("Info");
            Log.Warn("Warn");
            Log.Error("Error");
            Log.Fatal("Fatal");


            Debug.Log("Info:".HexColor("green")+ 66666666666);
            Debug.Log(66666666666);
            Debug.LogWarning("66666666666");
            Debug.LogAssertion("66666666666");
            Debug.LogError("66666666666");
            Debug.LogException(new System.Exception("66666666666"));
        }

    }
}
