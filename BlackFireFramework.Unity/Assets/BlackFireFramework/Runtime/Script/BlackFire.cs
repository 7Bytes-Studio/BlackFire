//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using UnityEngine;

/// <summary>
/// BlackFireFramework主要程序入口类。
/// </summary>
public sealed partial class BlackFire : MonoBehaviour 
{

    private void Awake()
    {
        Log.SetLogFileMode("D://BlackFireLog.txt",1000);
        Log.SetLogCallback(LogCallback);
        Framework.Born(this,Time.unscaledDeltaTime,Time.deltaTime);
    }

    private void Update()
    {
        Framework.Act(this, Time.unscaledDeltaTime, Time.deltaTime);
    }

    private void OnDestroy()
    {
        Framework.Die(this, Time.unscaledDeltaTime, Time.deltaTime);
    }



    private void LogCallback(LogLevel logLevel,object message)
    {
        var logMessage = string.Format("{0}:{1}", logLevel, message);
        Debug.Log(logMessage);
        Log.EnLogFileQueue(logMessage);
    }


}

