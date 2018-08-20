//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Network
{
    public abstract class ReceiveFilterBase<TPackageInfo> : IReceiveFilter<TPackageInfo> where TPackageInfo : IPackageInfo
    {
        public abstract TPackageInfo Filter(byte[] readBuffer, int offset, int length);
    }
}