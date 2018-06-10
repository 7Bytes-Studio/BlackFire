//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



namespace BlackFireFramework.Network
{
    /// <summary>
    /// 下载错误码。
    /// </summary>
    public enum DownloadErrorCode 
	{
        /// <summary>
        /// 未知错误。
        /// </summary>
        Unknown,

        /// <summary>
        /// 未完成时调用关闭错误。
        /// </summary>
        Stopped,

        /// <summary>
        /// 文件读取错误。
        /// </summary>
        FileIOException,

        /// <summary>
        /// 服务器响应错误。
        /// </summary>
        ServerResponse

    }
}
