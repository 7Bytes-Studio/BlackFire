//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



namespace BlackFireFramework.Unity
{
    public abstract class NetworkProtocolBase 
	{
        public abstract void Send(byte[] message);

        public abstract void Close();
	}
}
