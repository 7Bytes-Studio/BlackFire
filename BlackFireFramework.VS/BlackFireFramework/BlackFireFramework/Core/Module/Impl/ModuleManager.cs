//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 模块管家。
    /// </summary>
    public sealed class ModuleManager : EntityTreeNode, IModuleManager
    {

        public ModuleManager() : base(new UserData("ModuleManager"))
        {

        }

        #region IModuleManager 接口实现

        public IModule GetModule(Type moduleOrModuleInterfaceType)
        {
            CheckModuleImplOrThrow(moduleOrModuleInterfaceType);

            foreach (var child in this)
            {
                if (child.GetType()==moduleOrModuleInterfaceType || moduleOrModuleInterfaceType.IsAssignableFrom(child.GetType()))
                {
                   return child as IModule;
                }
            }
            return null;
        }

        public bool HasModule(Type moduleOrModuleInterfaceType)
        {
            CheckModuleImplOrThrow(moduleOrModuleInterfaceType);
            foreach (var child in this)
            {
                if (child.GetType() == moduleOrModuleInterfaceType || moduleOrModuleInterfaceType.IsAssignableFrom(child.GetType()))
                {
                    return true;
                }
            }
            return false;
        }

        public void Register(IModule module)
        {
            if (null == module)
            {
                Log.Fatal("注册的模块接口引用不能为空。");
            }

            if( !HasModule( module.GetType() ) )
            {
                AddChildNode(module as ModuleBase);
            }
        }

        public void UnRegister(IModule module)
        {
            if (null == module)
            {
                Log.Fatal("注销的模块接口引用不能为空。");
            }

            if ( HasModule( module.GetType() ) )
            {
                RemoveChildNode(module as ModuleBase);
            }
        }

        public void UnRegister(Type moduleOrModuleInterfaceType)
        {
            if (null == moduleOrModuleInterfaceType)
            {
                Log.Fatal("注销的模块接口类型引用不能为空。");
            }
            ModuleBase target = null;
            foreach (var child in this)
            {
                if ( child.GetType() == moduleOrModuleInterfaceType || moduleOrModuleInterfaceType.IsAssignableFrom(child.GetType()) )
                {
                    target = child as ModuleBase;
                    break;
                }
            }

            if (null!= target)
            {
                RemoveChildNode(target);
            }
           
        }

        #endregion

        #region 检查



        /// <summary>
        /// 检查模块的实现类型如果有异常则抛出。
        /// </summary>
        /// <param name="moduleType"></param>
        private void CheckModuleImplOrThrow(Type moduleType)
        {
            if (!typeof(IModule).IsAssignableFrom(moduleType))
                throw new Exception(string.Format("The {0} is not the implementation type for the module.", moduleType));
        }



        #endregion

    }
}
