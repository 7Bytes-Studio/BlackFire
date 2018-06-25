//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static GameManager s_Game = null;
    public static GameManager Game { get { return s_Game = (s_Game ?? GetManager<GameManager>()); } }

}