//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using SuperSocket.ProtoBase;

namespace BlackFireFramework.Unity
{
    public sealed class BlackFireServerPackageInfo : IPackageInfo<string>
    {
        public BlackFireServerPackageInfo(string key, string json)
        {
            Key = key;
            Json = json;
        }

        public string Key { get; private set; }
        public string Json { get; private set; }
    }
}
