//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using System;
using UnityEngine;

public sealed partial class BlackFire
{
    /// <summary>
    /// 应用程序退出事件。
    /// </summary>
    public static event Action ApplicationQuit;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void ApplicationInit()
    {
        StreamingAssetsPath = Application.streamingAssetsPath;
    }


    public static string StreamingAssetsPath { get; private set; }


    private void OnApplicationQuit()
    {
        if (null!= ApplicationQuit)
        {
            ApplicationQuit.Invoke();
        }
    }

}