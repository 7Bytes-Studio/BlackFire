//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 框架子程序集提供者。
    /// </summary>
	public interface IAssemblyProvider
	{
        /// <summary>
        /// 接口执行的优先级(比如0的优先级比1的高)。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 需要加载管理的程序集。
        /// </summary>
        string[] Assemblies { get; }
    }
}
