//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 命令接口。
    /// </summary>
    /// <typeparam name="TPackageInfo">包类型。</typeparam>
    public interface ICommand<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="transport">传输实现类实例。</param>
        /// <param name="packageInfo">包实现类实例。</param>
        void ExecuteCommand(TransportBase transport,TPackageInfo packageInfo);
    }
}