//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class ScreenCapture : CustomYieldInstruction
    {
        public ScreenCapture(Rect? captureRect=null,ImageFormat imageFormat=ImageFormat.JPG,string path=null)
        {
            if (null==captureRect)
            {
                captureRect = new Rect(0f,0f,Screen.width,Screen.height);
            }
            
            m_Photo = BlackFireFramework.Unity.Utility.Screen.ScreenCapture(captureRect.Value);
            if (null == path)
            {
                m_KeepWaiting = true;
                m_FileSize =(ulong)m_Photo.GetRawTextureData().Length;
            }
            else
            {
                Action callback = () => 
                {
                    m_KeepWaiting = true;
                    HasSaveFile = true;
                };
                
                switch (imageFormat)
                {
                    case ImageFormat.JPG : m_FileSize = BlackFireFramework.Unity.Utility.Texture.ToJPGFile(path,m_Photo,callback);break;
                    case ImageFormat.PNG : m_FileSize = BlackFireFramework.Unity.Utility.Texture.ToPNGFile(path,m_Photo,callback);break;
                    case ImageFormat.EXR : m_FileSize = BlackFireFramework.Unity.Utility.Texture.ToEXRFile(path,m_Photo,callback);break;
                    default : break;
                }
            }
        }


        public bool HasSaveFile { get; set; }

        private ulong m_FileSize;
        public ulong FileSize
        {
            get { return m_FileSize; }
        }
        
        private Texture2D m_Photo;
        public Texture2D Photo
        {
            get { return m_Photo; }
        }
        
        private bool m_KeepWaiting = false;
        public override bool keepWaiting
        {
            get { return m_KeepWaiting; }
        }
        
    }

    public enum ImageFormat
    {
        JPG,
        PNG,
        EXR
    }
}