//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace BlackFireFramework
{


    [System.Serializable]
    public sealed class PackageInfoList
    {
        public List<PackageInfoDic> packages;
    }

    [System.Serializable]
    public sealed class PackageInfoDic
    {
        public string classify;

        public List<PackageInfo> packageInfos;
    }


}
