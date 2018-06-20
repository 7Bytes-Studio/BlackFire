//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Editor
{
    public sealed class HttpDownloaderProgressEventArgs : EventArgs
    {
        public HttpDownloaderProgressEventArgs(float progress)
        {
            DownloadProgress=progress;
        }

        public float DownloadProgress { get; private set; }
    }

}
