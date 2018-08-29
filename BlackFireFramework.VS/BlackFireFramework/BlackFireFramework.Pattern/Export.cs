//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Pattern
{
    /// <summary>
    /// BlackFireFramework.Pattern 的导出类。
    /// </summary>
    public sealed class Export : ExportedAssemblyBase
    {
        
        
        /// <summary>
        /// 导出接口事件(该事件会被BlackFire核心程序集反射执行)。
        /// </summary>
        /// <param name="ioc">BlackFireFramework内部的IOC容器。</param>
        protected override void OnExport(ISparrowIoC ioc)
        {
            ioc.RegisterType<MVPModule>().As<IMVPModule>();
#if DEVELOP
            Log.Info("ExportedAssembly::OnExport");
#endif
        }



        #region 程序集生命周期



        protected override void OnBorn()
        {
#if DEVELOP
          Log.Info("ExportedAssembly::OnBorn");
#endif
        }

        protected override void OnAct()
        {
#if DEVELOP
          Log.Info("ExportedAssembly::OnAct");
#endif
        }

        protected override void OnDie()
        {
#if DEVELOP
          Log.Info("ExportedAssembly::OnDie");
#endif
        }



        #endregion

    }
}
