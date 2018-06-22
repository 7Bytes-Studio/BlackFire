//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static GatewayWorkerManager s_GatewayWorker = null;
    public static GatewayWorkerManager GatewayWorker { get { return s_GatewayWorker = (s_GatewayWorker ?? GetManager<GatewayWorkerManager>()); } }
}