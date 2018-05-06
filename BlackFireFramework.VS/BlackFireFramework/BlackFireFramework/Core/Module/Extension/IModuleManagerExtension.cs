//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    /// <summary>
    /// IModuleManager的扩展类。
    /// </summary>
    public static class IModuleManagerExtension
    {
        /// <summary>
        /// 注册模块。
        /// </summary>
        public static void Register<T>(this IModuleManager moduleManager) where T : IModule
        {
            T targetModule = Framework.IoC.Build<T>();
            if (null != targetModule)
            {
                moduleManager.Register(targetModule);
            }
            else
            {
                Log.Fatal("注册的目标模块接口没有注册到内部的IOC。");
            }
        }

        /// <summary>
        /// 注销模块。
        /// </summary>
        /// <typeparam name="T">目标模块类型。</typeparam>
        /// <param name="moduleManager">模块管家。</param>
        public static void UnRegister<T>(this IModuleManager moduleManager) where T : IModule
        {
            moduleManager.UnRegister(typeof(T));
        }


        /// <summary>
        /// 获取模块。
        /// </summary>
        /// <typeparam name="T">目标模块类型</typeparam>
        /// <param name="moduleManager">模块管家。</param>
        public static T GetModule<T>(this IModuleManager moduleManager) where T : IModule
        {
           return (T)moduleManager.GetModule(typeof(T));
        }
    }
}
