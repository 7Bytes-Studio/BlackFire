//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static CGManager s_CG = null;
    public static CGManager CG { get { return s_CG = (s_CG ?? GetManager<CGManager>()); } }
}