//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Editor
{
    public sealed class HttpDownloadInfo
    {
        public string Url;
        public string SavePath;
        public string TempFileExtension;
        public int DownloadBufferUnit = 512;
    }
}
