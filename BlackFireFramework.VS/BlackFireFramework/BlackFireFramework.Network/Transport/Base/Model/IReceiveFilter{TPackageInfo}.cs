//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    public interface IReceiveFilter<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        TPackageInfo Filter(byte[] readBuffer, int offset, int length);
    }
}