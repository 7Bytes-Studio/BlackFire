//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 屏幕截图 (请在一帧的最后调用)。
    /// </summary>
    public sealed class ScreenCapture : CustomYieldInstruction
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="captureRect">截屏的矩形区域。</param>
        /// <param name="imageFormat">照片的生成格式。</param>
        /// <param name="path">照片的保存路径。</param>
        /// <param name="textureFormat">材质的生成格式。</param>
        public ScreenCapture(Rect? captureRect=null,ImageFormat imageFormat=ImageFormat.JPG,string path=null,TextureFormat textureFormat=TextureFormat.RGB24)
        {
            if (null==captureRect)
            {
                captureRect = new Rect(0f,0f,Screen.width,Screen.height);
            }
            
            m_Photo = BlackFireFramework.Unity.Utility.Screen.ScreenCapture(captureRect.Value,textureFormat);
            
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

        /// <summary>
        /// 是否已经保存了文件。
        /// </summary>
        public bool HasSaveFile { get; set; }

        private ulong m_FileSize;
        /// <summary>
        /// 文件大小。
        /// </summary>
        public ulong FileSize
        {
            get { return m_FileSize; }
        }
        
        private Texture2D m_Photo;
       /// <summary>
       /// 照片引用。
       /// </summary>
        public Texture2D Photo
        {
            get { return m_Photo; }
        }
        
        private bool m_KeepWaiting = false;
        /// <summary>
        /// 是否保持等待。
        /// </summary>
        public override bool keepWaiting
        {
            get { return m_KeepWaiting; }
        }

        /// <summary>
        /// 销毁生成照片的材质实例。
        /// </summary>
        public void DestroyPhoto()
        {
            UnityEngine.Object.DestroyImmediate(m_Photo);
            m_Photo = null;
        }
    }

    /// <summary>
    /// 图片格式。
    /// </summary>
    public enum ImageFormat
    {
        /// <summary>
        /// JPG图片格式。
        /// </summary>
        JPG,
        /// <summary>
        /// PNG图片格式。
        /// </summary>
        PNG,
        /// <summary>
        /// EXR图片格式。
        /// </summary>
        EXR
    }
}


