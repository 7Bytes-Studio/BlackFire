//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using UnityEngine;

public sealed partial class BlackFire
{
    #region Log

    private void LogCallback(LogLevel logLevel, object message)
    {
        var logMessage = string.Empty;
        switch (logLevel)
        {
            case LogLevel.Trace:
                logMessage = string.Format("<color=#AAAAAA>{0}:</color>{1}", logLevel, message);
                Debug.Log(logMessage);
                break;
            case LogLevel.Debug:
                logMessage = string.Format("<color=white>{0}:</color>{1}", logLevel, message);
                Debug.Log(logMessage);
                break;
            case LogLevel.Info:
                logMessage = string.Format("<color=green>{0}:</color>{1}", logLevel, message);
                Debug.Log(logMessage);
                break;
            case LogLevel.Warn:
                logMessage = string.Format("<color=yellow>{0}:</color>{1}", logLevel, message);
                Debug.LogWarning(logMessage);
                break;
            case LogLevel.Error:
                logMessage = string.Format("<color=#FF3399>{0}:</color>{1}", logLevel, message);
                Debug.LogError(logMessage);
                break;
            case LogLevel.Fatal:
                logMessage = string.Format("<color=red>{0}:</color>{1}", logLevel, message);
                Debug.LogException(new System.Exception(logMessage));
                break;
            default:
                break;
        }
        Log.EnLogFileQueue(logMessage);
    }



    #endregion
}