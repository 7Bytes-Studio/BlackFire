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
        [SerializeField] private float bili=0.1f;
        [SerializeField] private FuckingMap m_FuckingMap = null;

        [SerializeField] private Transform m_Cube = null;

        private Vector3 m_LastPosition;
        private float m_LastAngle;

        private void Update()
        {
            if (m_LastPosition==Vector3.zero)
            {
                m_LastPosition = m_Cube.transform.localPosition;
            }

            if (m_LastAngle == 0f)
            {
                m_LastAngle = m_Cube.transform.localEulerAngles.y;
            }


            var v = bili*(m_Cube.transform.localPosition - m_LastPosition);
            var a = m_Cube.transform.localEulerAngles.y - m_LastAngle;
            m_FuckingMap.Move(v.x,v.z,a);
            m_LastPosition = m_Cube.transform.localPosition;
            m_LastAngle = m_Cube.transform.localEulerAngles.y;
        }

    }
}
