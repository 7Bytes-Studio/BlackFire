//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static GraphicsManager s_Graphics = null;
    public static GraphicsManager Graphics { get { return s_Graphics = (s_Graphics ?? GetManager<GraphicsManager>()); } }
}