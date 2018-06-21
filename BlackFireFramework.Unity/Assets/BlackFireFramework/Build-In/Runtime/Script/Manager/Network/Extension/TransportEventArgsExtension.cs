//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System.Text;

namespace BlackFireFramework.Unity
{
    public static class TransportEventArgsExtension 
	{
        public static string MessageString(this TransportEventArgs transportEventArgs,Encoding encoding)
        {
            return encoding.GetString(transportEventArgs.Message,0,transportEventArgs.Length);
        }

        public static string MessageString(this TransportEventArgs transportEventArgs)
        {
            return Encoding.UTF8.GetString(transportEventArgs.Message, 0, transportEventArgs.Length);
        }

    }
}
