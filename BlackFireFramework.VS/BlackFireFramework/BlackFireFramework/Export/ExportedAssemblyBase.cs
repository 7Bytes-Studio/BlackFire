//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    /// <summary>
    /// 导出的程序集节点抽象类。
    /// </summary>
    public abstract class ExportedAssemblyBase : EntityTreeNode
    {
        public ExportedAssemblyBase() : base(null)
        {
            Value = new UserData(string.Format("ExportedAssembly:{0}", GetType().FullName));
        }

        /// <summary>
        /// 目标加载的程序集名字。
        /// </summary>
        internal string AssemblyName { get; set; }

        /// <summary>
        /// 导出接口事件(该事件会被BlackFire核心程序集反射执行)。
        /// </summary>
        /// <param name="ioc">BlackFire内部的IOC容器。</param>
        protected internal abstract void OnExport(ISparrowIoC ioc);

    }
}
