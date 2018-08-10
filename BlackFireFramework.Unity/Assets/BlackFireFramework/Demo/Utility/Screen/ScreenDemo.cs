//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class ScreenDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            var o = new ScreenCapture(new Rect(0f,0f,1920f,1080f),ImageFormat.PNG,Application.dataPath+"/test.png");
            yield return o;
            o.DestroyPhoto();
            Debug.Log(o.HasSaveFile);
            Debug.Log(o.FileSize);
            
//            var photo = BlackFireFramework.Unity.Utility.Screen.ScreenCapture(new Rect(0f,0f,1920f,1080f));
//            GetComponent<MeshRenderer>().material.mainTexture = photo;
//            
//            BlackFireFramework.Unity.Utility.Texture.ToJPGFile(Application.dataPath+"/test.jpg",photo, () =>
//            {
//                Debug.Log("Save!");
//            });
            
        }
    }
}