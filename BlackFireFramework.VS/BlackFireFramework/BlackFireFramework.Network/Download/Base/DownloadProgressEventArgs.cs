//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;


namespace BlackFireFramework.Network
{
    public sealed class DownloadProgressEventArgs : EventArgs
    {
        public DownloadProgressEventArgs(long downloadPosition, long downloadRealContentSize, long downloadRealSize, long downloadContentSize, float progress)
        {
            DownloadPosition = downloadPosition;
            DownloadRealContentSize = downloadRealContentSize;
            DownloadRealSize = downloadRealSize;
            DownloadContentSize = downloadContentSize;
            Progress = progress;
        }

        public long DownloadPosition { get; private set; }
        public long DownloadRealSize { get; private set; }
        public long DownloadRealContentSize { get; private set; }
        public long DownloadContentSize { get; private set; }
        public float Progress { get; private set; }
    }
}
