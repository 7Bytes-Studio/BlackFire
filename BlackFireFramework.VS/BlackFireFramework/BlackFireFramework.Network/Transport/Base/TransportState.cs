//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Network
{
    public enum TransportState 
	{
        Unknow,
        Connect,
        ReceiveMessage,
        CloseByRemote,
        CloseByUser,
        Error
    }
}
