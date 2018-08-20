//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    /// <summary>
    /// 传输的包信息。
    /// </summary>
    public interface IPackageInfo<T>:IPackageInfo
    {
        T Key { get; }
    }
}