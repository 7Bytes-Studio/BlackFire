//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static ILoopManager s_Loop = null;
    public static ILoopManager Loop { get { return s_Loop = (s_Loop ?? GetManager<ILoopManager>()); } }

}