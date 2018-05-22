//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;

public sealed partial class BlackFire
{
    #region Module

    private static IModuleManager s_ModuleManager = null;

    public static IModuleManager ModuleManager { get { return s_ModuleManager; } }

    [UnityEngine.RuntimeInitializeOnLoadMethod]
    private static void ModuleManageInit()
    {
        if (null != Instance)
        {
            s_ModuleManager = (IModuleManager)EntityTree.GetEntityInChildren(typeof(IModuleManager));
        }
    }

    #endregion
}