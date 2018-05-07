//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// TestAssembly 的导出类。
    /// </summary>
    public sealed class ExportedAssembly : ExportedAssemblyBase
    {
        /// <summary>
        /// 导出接口事件(该事件会被BlackFire核心程序集反射执行)。
        /// </summary>
        /// <param name="ioc">BlackFireFramework内部的IOC容器。</param>
        protected override void OnExport(ISparrowIoC ioc)
        {
            ioc.RegisterType<ProcessModule>().As<IProcessModule>();
#if VS_EDITOR
            Log.Info("ExportedAssembly::OnExport");
#endif

        }



        #region 程序集生命周期



        protected override void OnBorn()
        {
#if VS_EDITOR
          Log.Info("ExportedAssembly::OnBorn");
#endif
        }

        protected override void OnAct()
        {
#if VS_EDITOR
          Log.Info("ExportedAssembly::OnAct");
#endif
        }

        protected override void OnDie()
        {
#if VS_EDITOR
          Log.Info("ExportedAssembly::OnDie");
#endif
        }



        #endregion

    }
}
