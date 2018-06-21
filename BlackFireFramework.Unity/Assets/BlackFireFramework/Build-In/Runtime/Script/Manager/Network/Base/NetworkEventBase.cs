//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
    /// <summary>
    /// 网络事件基类。
    /// </summary>
	public abstract class NetworkEventBase  
	{
        /// <summary>
        /// 网络连接上时事件。
        /// </summary>
        /// <param name="message">消息字节数组。</param>
        protected abstract void OnConnect(byte[] message);

        /// <summary>
        /// 网络接受到消息事件。
        /// </summary>
        /// <param name="message">消息字节数组。</param>
        protected abstract void OnMessage(byte[] message);

        /// <summary>
        /// 网络关闭事件。
        /// </summary>
        /// <param name="message">消息字节数组。</param>
        protected abstract void OnClose(byte[] message);

    }
}
