//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



using System;

namespace BlackFireFramework.Unity
{
    public abstract class TransportBase
    {
        /// <summary>
        /// 网络连接上时事件。
        /// </summary>
        public abstract event EventHandler<TransportEventArgs> OnConnect;

        /// <summary>
        /// 网络接受到消息事件。
        /// </summary>
        public abstract event EventHandler<TransportEventArgs> OnMessage;

        /// <summary>
        /// 网络关闭事件。
        /// </summary>
        public abstract event EventHandler<TransportEventArgs> OnClose;

        /// <summary>
        /// 网络错误事件。
        /// </summary>
        public abstract event EventHandler<TransportEventArgs> OnError;

        /// <summary>
        /// 连接目标终端。
        /// </summary>
        public abstract void Connect(); 

        /// <summary>
        /// 发送网络消息。
        /// </summary>
        /// <param name="message">消息内容。</param>
        public abstract void Send(byte[] message);

        /// <summary>
        /// 关闭网络连接。
        /// </summary>
        public abstract void Close();
	}
}
