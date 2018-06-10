//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



using System;

namespace BlackFireFramework.Network
{
    public sealed class DownloadFailureEventArgs : EventArgs
    {
        public DownloadFailureEventArgs(DownloadErrorCode downloadErrorCode,string errorMessage = null)
        {
            DownloadErrorCode = downloadErrorCode;
            ErrorMessage = errorMessage;
        }


        public DownloadErrorCode DownloadErrorCode { get; private set; }

        public string ErrorMessage { get; private set; }	
	}
}
