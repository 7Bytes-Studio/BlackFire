//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using BlackFireFramework.Unity;
using UnityEngine;

/// <summary>
/// BlackFireFramework主要程序入口类。
/// </summary>
public sealed partial class BlackFire : FakeSingleton<BlackFire>
{
    #region LifeCircle

    protected override void Awake()
    {
        base.Awake();
        Log.SetLogFileMode("D://BlackFireLog.txt",1000);
        Log.SetLogCallback(LogCallback);
        Framework.Born(this,Time.unscaledDeltaTime,Time.deltaTime);
        ExportedAssemblyInit();
        ModuleManageInit();
    }

    protected override void Update()
    {
        Framework.Act(this, Time.unscaledDeltaTime, Time.deltaTime);
    }

    protected override void OnDestroy()
    {
        ExportedAssemblyDestroy();
        Framework.Die(this, Time.unscaledDeltaTime, Time.deltaTime);
    }

    #endregion

    #region Log



    private void LogCallback(LogLevel logLevel,object message)
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

    #region ExportedAssembly

    private string[] m_ExtendedAssemblies = new string[] { "BlackFireFramework.Unity" };
    private IExportedAssemblyManager m_ExportedAssemblyManager = null;

    private void ExportedAssemblyInit()
    {
        m_ExportedAssemblyManager = (IExportedAssemblyManager)EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
        for (int i = 0; i < m_ExtendedAssemblies.Length; i++)
        {
            m_ExportedAssemblyManager.LoadExportedAssembly(m_ExtendedAssemblies[i]);
        }
    }

    private void ExportedAssemblyDestroy()
    {
        for (int i = 0; i < m_ExtendedAssemblies.Length; i++)
        {
            m_ExportedAssemblyManager.UnLoadExportAssembly(m_ExtendedAssemblies[i]);
        }
    }


    #endregion

    #region Module

    private IModuleManager m_ModuleManager = null;

    public static IModuleManager ModuleManager { get { return Instance.m_ModuleManager; } }

    private void ModuleManageInit()
    {
        m_ModuleManager = (IModuleManager)EntityTree.GetEntityInChildren(typeof(IModuleManager));
    }

    #endregion

}

