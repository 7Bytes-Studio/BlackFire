//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
{
    [System.Serializable]
    public sealed class PackageInfo
    {
        public string classify;

        public string name;

        public string version;

        public string url;

        public string more;



        public override string ToString()
        {
            return string.Format("{0} \n {1} \n {2} \n {3}", name,version,url,more);
        }
    }
}
