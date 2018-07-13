//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class CAACTest : MonoBehaviour 
	{

        private RectTransform m_CachedRectTransform = null;
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform ?? (m_CachedRectTransform = GetComponent<RectTransform>()); } }


        private void Update()
        {

            if (Input.GetKey(KeyCode.J))
            {
                CachedRectTransform.localEulerAngles = new Vector3(CachedRectTransform.localEulerAngles.x, CachedRectTransform.localEulerAngles.y, CachedRectTransform.localEulerAngles.z+Time.deltaTime*0.1f);
            }
            else if (Input.GetKey(KeyCode.K))
            {
                CachedRectTransform.localEulerAngles = new Vector3(CachedRectTransform.localEulerAngles.x, CachedRectTransform.localEulerAngles.y, CachedRectTransform.localEulerAngles.z-Time.deltaTime*0.1f);
            }

        }

    }
}
