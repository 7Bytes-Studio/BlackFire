//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using OpenCVForUnity;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class FaceRecognizerDemo : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_MeshRenderer;
        private IEnumerator Start()
        {
            BlackFire.CG.LoadFaceImages(new string[]
            {
                Application.streamingAssetsPath+"/facerec/facerec_0.bmp",
                Application.streamingAssetsPath+"/facerec/facerec_1.bmp",
                Application.streamingAssetsPath+"/facerec/facerec_2.bmp",
//            }, () =>
//            {
//                var args = BlackFire.CG.FaceRecognition(Application.streamingAssetsPath+"/facerec/alanzeng.bmp");
//                m_MeshRenderer.material.mainTexture = args.FaceRecTexture;
            });
            
            yield return null;

            var webCam = new WebCam(92,112);
            yield return webCam;
            
            Debug.Log(webCam.WebCamTexture.width+"  "+webCam.WebCamTexture.height);
            
            m_MeshRenderer.material.mainTexture = webCam.WebCamTexture;
            
            yield return new WaitForSeconds(2f);
            
            webCam.WebCamTexture.Pause();
            var args = BlackFire.CG.FaceRecognition(webCam.WebCamDevice,webCam.WebCamTexture);
            webCam.WebCamTexture.Play();
            m_MeshRenderer.material.mainTexture = args.FaceRecTexture;
            
           
           // Utils.webCamTextureToMat();
            
        }
    }
}