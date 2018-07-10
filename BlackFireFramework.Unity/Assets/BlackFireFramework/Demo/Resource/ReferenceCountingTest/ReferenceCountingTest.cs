//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan
{
	public sealed class ReferenceCountingTest : MonoBehaviour 
	{
        //private Texture m_Texture = null;

        private void OnGUI()
        {

            if (GUILayout.Button("加载使用"))
            {
                var test = Resources.Load<Texture>("test");
                var testt = Instantiate<Texture>(test);
                GetComponent<MeshRenderer>().material.mainTexture = test;
            }

            if (GUILayout.Button("删除贴图"))
            {
                GetComponent<MeshRenderer>().material.mainTexture = null;
            }

            //if (GUILayout.Button("删除引用"))
            //{
            //    m_Texture = null;
            //}


            if (GUILayout.Button("卸载"))
            {
                Resources.UnloadUnusedAssets();
            }

        }

    }
}
