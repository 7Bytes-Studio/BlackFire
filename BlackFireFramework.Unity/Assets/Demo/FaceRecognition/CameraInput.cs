//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class CameraInput : MonoBehaviour
    {
        [SerializeField]private PixelImageMaker m_PixelImageMaker;
        //摄像头图像类，继承自texture
        WebCamTexture tex;
        public Image WebCam;
        public MeshRenderer ma;
        private int m_Height=100;
        private int m_Weight=100;
        [SerializeField] private Texture2D m_T2d;
        
        void Start () 
        {
            //开启协程，获取摄像头图像数据
            StartCoroutine(OpenCamera());
        }
   
        IEnumerator OpenCamera()
        {
            //等待用户允许访问
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            //如果用户允许访问，开始获取图像        
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                //先获取设备
                WebCamDevice[] device = WebCamTexture.devices;
            
                string deviceName = device[0].name;
                //然后获取图像
                tex = new WebCamTexture(deviceName,128,128,30);
                //将获取的图像赋值
                ma.material.mainTexture = tex;
                //开始实施获取
                tex.Play();     
                
            }

            yield return new WaitForSeconds(3f);
            tex.Pause();     
            var color32s = tex.GetPixels32();
            m_PixelImageMaker.SetSize(tex.width,tex.height);
            m_PixelImageMaker.MakePixelImages(color32s);
            tex.Play();     
            
            
            m_T2d = new Texture2D(tex.width,tex.height,TextureFormat.RGBA32,false,false);
            m_T2d.SetPixels32(color32s);
            m_T2d.Apply();
            
            Debug.Log(tex.height+" "+tex.width+" "+tex.height*tex.width+"   "+color32s[11]);
            
        }
    }
}