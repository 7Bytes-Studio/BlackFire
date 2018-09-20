//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class FormUnitTest : MonoBehaviour
    {
        private Asset m_CC919 = null;
        private void Start()
        {
            m_CC919 = Resources.Load<Asset>("CC919");
            Debug.Log(null==m_CC919.GetComponent<CC919>());
        }
    }
}