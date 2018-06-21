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
        [SerializeField] private bool m_FireLog;


        private void Start()
        {
            BlackFireFramework.Event.On("DebuggerTest",this,(sender,args)=> {
                var cargs = args as DebuggerEventArgs;
                Log.Info(cargs.Args.Length);
                for (int i = 0; i < cargs.Args.Length; i++)
                {
                    Log.Info(cargs.Args[i]);
                }
            });
        }



        private void Update()
        {
            if (m_FireLog)
            {
                Log.Trace("Trace");
                Log.Debug("Debug");
                Log.Info("Info");
                Log.Warn("Warn");
                Log.Error("Error");
                Log.Fatal("Fatal");


                Debug.Log("Info:".HexColor("green") + 66666666666);
                Debug.Log(66666666666);
                Debug.LogWarning("66666666666");
                Debug.LogAssertion("66666666666");
                Debug.LogError("66666666666");
                Debug.LogException(new System.Exception("66666666666"));
            }

        }




    }
}
