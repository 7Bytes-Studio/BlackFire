//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class FaceRecognizerDemo : MonoBehaviour
    {
        [SerializeField] private Texture _T2D;
        private void Start()
        {
            BlackFire.CG.LoadFaceImages(new string[]
            {
                Application.streamingAssetsPath+"/facerec/facerec_0.bmp",
                Application.streamingAssetsPath+"/facerec/facerec_1.bmp"
            }, () => { var args = BlackFire.CG.FaceRecognition(Application.streamingAssetsPath+"/facerec/facerec_sample_1.bmp");
                _T2D = args.FaceRecTexture;
            });
        }
    }
}