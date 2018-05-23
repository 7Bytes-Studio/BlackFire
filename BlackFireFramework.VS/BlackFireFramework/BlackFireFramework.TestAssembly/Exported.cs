//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.TestAssembly
{
    /// <summary>
    /// TestAssembly 的导出类。
    /// </summary>
    public sealed class Exported : ExportedAssemblyBase
    {
        /// <summary>
        /// 导出接口事件(该事件会被BlackFire核心程序集反射执行)。
        /// </summary>
        /// <param name="ioc">BlackFireFramework内部的IOC容器。</param>
        protected override void OnExport(ISparrowIoC ioc)
        {
            //ioc.RegisterType<EventModule>().As<IEventModule>();
            Log.Info("ExportedAssembly::OnExport");
        }



        #region 程序集生命周期



        protected override void OnBorn()
        {
            Log.Info("ExportedAssembly::OnBorn");
        }

        protected override void OnAct()
        {
            Log.Info("ExportedAssembly::OnAct");
        }

        protected override void OnDie()
        {
            Log.Info("ExportedAssembly::OnDie");
        }



        #endregion

    }
}
