//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 命令分配器接口。
    /// </summary>
    public interface ICommandDispatcher<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        void Dispatch(TransportBase transport,TPackageInfo info,List<CommandBase<TPackageInfo>> commands);
    }
}