//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Text;
using BlackFireFramework.Network;

namespace BlackFireFramework.Unity
{
    public static class TransportExtension 
	{
        /// <summary>
        /// 自定义编码发送数据。
        /// </summary>
        public static void Send(this TransportBase transportBase,string message, Encoding encoding)
        {
            var bytes = encoding.GetBytes(message);
            transportBase.Send(bytes);
        }

        /// <summary>
        /// 发送数据。(默认UTF-8编码)
        /// </summary>
        public static void Send(this TransportBase transportBase, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            transportBase.Send(bytes);
        }

    }
}
