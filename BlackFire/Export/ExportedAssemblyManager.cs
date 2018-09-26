/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    /// <summary>
    /// 导出的程序集管家。
    /// </summary>
    public sealed class ExportedAssemblyManager : EntityTreeNode, IExportedAssemblyManager
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        public ExportedAssemblyManager() : base(new UserData("ExportedAssemblyManager"))
        {

        }

        /// <summary>
        /// 获取导出程序集的节点的引用实例。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        /// <returns>导出程序集节点。</returns>
        public ExportedAssemblyBase GetExportedAssembly(string exportedAssemblyName)
        {
            foreach (var child in this)
            {
                if ((child as ExportedAssemblyBase).AssemblyName == exportedAssemblyName)
                {
                    return child as ExportedAssemblyBase;
                }
            }
            return null;
        }

        /// <summary>
        /// 加载导出程序集的节点。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        public void LoadExportedAssembly(string exportedAssemblyName)
        {
            var targetTypes = Utility.Reflection.GetImplTypes(exportedAssemblyName,typeof(ExportedAssemblyBase));
            if (0<targetTypes.Length)
            {
                var instance = Activator.CreateInstance(targetTypes[0]);
                var child = instance as ExportedAssemblyBase;
                child.AssemblyName = exportedAssemblyName;
                child.OnExport(Framework.IoC);
                AddChildNode(instance as ExportedAssemblyBase);
            }
        }

        /// <summary>
        /// 卸载导出程序集的节点。
        /// </summary>
        /// <param name="exportedAssemblyName">导出程序集系节点的名字。</param>
        public void UnLoadExportAssembly(string exportedAssemblyName)
        {
            ExportedAssemblyBase target = null;
            foreach (var child in this)
            {
                if ((child as ExportedAssemblyBase).AssemblyName == exportedAssemblyName)
                {
                    target = child as ExportedAssemblyBase;
                    break;
                }
            }

            if (null!=target)
            {
                RemoveChildNode(target);
            }
        }

    }
}
