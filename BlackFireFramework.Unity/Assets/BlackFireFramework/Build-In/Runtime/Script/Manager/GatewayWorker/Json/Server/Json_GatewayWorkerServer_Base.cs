//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{
    [System.Serializable]
    public class Json_GatewayWorkerServer_Base
    {
        public int code; //状态码

        public string type; //消息类型

        public string from; //谁发的消息

        public string to; //要消息发给谁
    }
}
