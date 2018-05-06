//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 模块管家接口。
    /// </summary>
    public interface IModuleManager
    {

        /// <summary>
        /// 获取模块。
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        IModule GetModule(Type moduleType);

        /// <summary>
        /// 是否存在模块。
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        bool HasModule(Type moduleType);

        /// <summary>
        /// 注册模块。
        /// </summary>
        /// <param name="module"></param>
        void Register(IModule module);

        /// <summary>
        /// 注销模块。
        /// </summary>
        /// <param name="module"></param>
        void UnRegister(IModule module);

        /// <summary>
        /// 注销模块。
        /// </summary>
        /// <param name="moduleType">模块的Type类型。</param>
        void UnRegister(Type moduleType);
    }
} 
