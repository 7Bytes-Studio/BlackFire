//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    public static UguiManager s_Ugui = null;
    public static UguiManager Ugui { get { return s_Ugui = (s_Ugui ?? GetManager<UguiManager>()); } }

}