//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    public static NetworkManager s_Network = null;
    public static NetworkManager Network { get { return s_Network = (s_Network ?? GetManager<NetworkManager>()); } }

}