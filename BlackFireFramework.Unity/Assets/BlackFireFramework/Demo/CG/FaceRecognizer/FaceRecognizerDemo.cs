//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class FaceRecognizerDemo : MonoBehaviour
    {
        [SerializeField] private RawImage m_RawImage_Face;
        [SerializeField] private RawImage m_RawImage_FaceToLib;
        [SerializeField] private RawImage m_RawImage_FaceToRec;
        [SerializeField] private UnityEngine.UI.Text m_Text_Confidence = null;

        private Texture2D m_Texture2D = null;
        private WebCam m_WebCam = null;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3f);
            //读取库中的图片。
            var faceLibFolder = Application.streamingAssetsPath + "/facelib/";
            DirectoryInfo di = new DirectoryInfo(faceLibFolder);
            var fis = di.GetFiles();
            List<string> uris = new List<string>();
            foreach (var fi in fis)
            {
                if(fi.Extension.Contains("meta")) continue;
                uris.Add(fi.FullName);
            }
            BlackFire.Graphics.LoadFaceImages(uris);
            
            m_Texture2D = new Texture2D(160,120,TextureFormat.RGBA32,true);
            m_WebCam = new WebCam(160,120);
            yield return m_WebCam;
            m_RawImage_Face.texture = m_WebCam.WebCamTexture;

            BlackFireFramework.Utility.IO.ExistsOrCreateFolder(Application.persistentDataPath + "/face");
            var tmpPath = Application.persistentDataPath + "/face/facerec_tmp.png";
            while (true)
            {
                yield return new WaitForSeconds(0.618f);
                
                m_WebCam.WebCamTexture.Pause();
                m_Texture2D.SetPixels32(m_WebCam.WebCamTexture.GetPixels32());
                m_Texture2D.Apply();
                m_WebCam.WebCamTexture.Play();
            
                Utility.Texture.ToPNGFile(tmpPath,m_Texture2D);
                yield return new WaitForEndOfFrame();
                var args = BlackFire.Graphics.FaceRecognition(tmpPath);

                if (args.RecognitionFailure)
                {
                    m_RawImage_FaceToRec.texture = m_Texture2D;
                    continue;
                }
                
                m_RawImage_FaceToRec.texture = args.FaceRecTexture;
                if (0!=args.Confidence)
                {
                    m_Text_Confidence.text = string.Format("FaceId : {0}   Confidence : {1}",args.PredictedLabel,args.Confidence.ToString());
                   // Log.Info("认证成功! 可信度 : "+args.Confidence);
                }
            }
            
        }


        public void FaceSample(Texture2D texture2D,string faceId)
        {
            StartCoroutine(_FaceSample(texture2D,faceId));
        }

        private IEnumerator _FaceSample(Texture2D texture2D,string faceId)
        {
            m_WebCam.WebCamTexture.Pause();
            texture2D.SetPixels32(m_WebCam.WebCamTexture.GetPixels32());
            texture2D.Apply();
            
            var path = Application.streamingAssetsPath + "/facelib/" + faceId + ".png";
            Utility.Texture.ToPNGFile(path,texture2D);
            yield return new WaitForEndOfFrame();
            BlackFire.Graphics.LoadFaceImages(new string[]{path});
            m_WebCam.WebCamTexture.Play();
        }



        private void OnGUI()
        {
            if (GUILayout.Button("人脸采集"))
            {
                var faceId = "Fucker_"+UnityEngine.Random.Range(999,9999);
                var texture2D = new Texture2D(160,120,TextureFormat.RGBA32,true);
                FaceSample(texture2D,faceId);
                m_RawImage_FaceToLib.texture = texture2D;
            }
            
            
            
        }
    }
}