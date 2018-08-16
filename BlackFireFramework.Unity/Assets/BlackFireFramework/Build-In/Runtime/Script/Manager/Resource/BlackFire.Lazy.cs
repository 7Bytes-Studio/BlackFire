//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static IResourceManager s_Resource = null;
    public static IResourceManager Resource { get { return s_Resource = (s_Resource ?? GetManager<IResourceManager>()); } }

}