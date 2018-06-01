//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFireFramework 
{
	public sealed class UguiManagerGraphicRaycaster : GraphicRaycaster
    {
        private PointerEventData m_PointerEventData = null;
        private List<RaycastResult> m_RaycastResultList = null;
        public PointerEventData PointerEventData
        {
            get
            {
                return m_PointerEventData;
            }
        }

        public List<RaycastResult> RaycastResultList
        {
            get
            {
                return m_RaycastResultList;
            }
        }

        public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
        {
            m_PointerEventData = eventData;
            m_RaycastResultList = resultAppendList;
            base.Raycast(eventData, resultAppendList);
        }

    }
}
