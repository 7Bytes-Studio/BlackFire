//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;

public sealed partial class BlackFire
{
    #region ExportedAssembly

    private static string[] m_ExtendedAssemblies = new string[] { "BlackFireFramework.Unity" };
    private static IExportedAssemblyManager m_ExportedAssemblyManager = null;

    private static void StartAssemblyManager(BlackFire instance)
    {
        m_ExportedAssemblyManager = (IExportedAssemblyManager)EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
        for (int i = 0; i < m_ExtendedAssemblies.Length; i++)
        {
            m_ExportedAssemblyManager.LoadExportedAssembly(m_ExtendedAssemblies[i]);
        }
    }

    private static void ShutdownAssemblyManager()
    {
        for (int i = 0; i < m_ExtendedAssemblies.Length; i++)
        {
            m_ExportedAssemblyManager.UnLoadExportAssembly(m_ExtendedAssemblies[i]);
        }
    }

    #endregion

}