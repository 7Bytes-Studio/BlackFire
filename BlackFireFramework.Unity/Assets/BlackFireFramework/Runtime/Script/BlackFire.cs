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
        Log.SetLogCallback(LogCallback);
        Framework.Born(this,Time.unscaledDeltaTime,Time.deltaTime);
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

   

    



}

