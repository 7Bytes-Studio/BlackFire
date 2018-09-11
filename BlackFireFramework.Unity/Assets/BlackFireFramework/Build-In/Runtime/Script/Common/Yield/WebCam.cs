//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 摄像头协程类。
    /// </summary>
    public sealed class WebCam : CustomYieldInstruction
    {

        public int RequestedWidth { get; private set; }
        public int RequestedHeight { get; private set; }
        public int RequestedFPS { get; private set; }
        public WebCamTexture WebCamTexture { get; private set; }
        public WebCamDevice WebCamDevice { get; private set; }
        private bool m_KeepWaiting = true;
        private float m_TimeOut = 5f;
        private float m_TempTime = 0f;

        public WebCam(int requestedWidth, int requestedHeight, int requestedFPS=30)
        {
            RequestedWidth = requestedWidth;
            RequestedHeight = requestedHeight;
            RequestedFPS = requestedFPS;
            var waitAO = Application.RequestUserAuthorization(UserAuthorization.WebCam);
            waitAO.completed += ao =>
            {
                WebCamDevice[] device = WebCamTexture.devices;
                if (null != device && 0 < device.Length)
                {
                    WebCamDevice = device[0];
                    var deviceName = device[0].name;
                    WebCamTexture = new WebCamTexture(deviceName, requestedWidth, requestedHeight, requestedFPS);
                    WebCamTexture.Play();
                }
                m_KeepWaiting = false;
            };
        }


        public override bool keepWaiting
        {
            get
            {
                return m_KeepWaiting && (m_TempTime += Time.deltaTime)<=m_TimeOut;
            }
        }
    }
}