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
    public interface IExportedAssemblyManager
    {
        /// <summary>
        /// 获取导出程序集的节点的引用实例。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        /// <returns>导出程序集节点。</returns>
        ExportedAssemblyBase GetExportedAssembly(string exportedAssemblyName);

        /// <summary>
        /// 加载导出程序集的节点。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        void LoadExportedAssembly(string exportedAssemblyName);

        /// <summary>
        /// 卸载导出程序集的节点。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        void UnLoadExportAssembly(string exportedAssemblyName);
    }
}