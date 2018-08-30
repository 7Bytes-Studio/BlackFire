//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static IMVPManager s_MVP = null;
    public static IMVPManager MVP { get { return s_MVP = (s_MVP ?? GetManager<IMVPManager>()); } }
}