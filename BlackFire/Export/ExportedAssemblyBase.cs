/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
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
