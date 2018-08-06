//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using SuperSocket.ProtoBase;

namespace BlackFireFramework.Unity
{
    public sealed class DefaultPackageInfo : IPackageInfo
    {
        public DefaultPackageInfo(byte[] data)
        {
            Data = data;
        }

        public byte[] Data { get; private set; }
    }
}
