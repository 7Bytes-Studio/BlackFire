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
        var logMessage = string.Format("{0}:{1}", logLevel, message);
        Debug.Log(logMessage);
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

