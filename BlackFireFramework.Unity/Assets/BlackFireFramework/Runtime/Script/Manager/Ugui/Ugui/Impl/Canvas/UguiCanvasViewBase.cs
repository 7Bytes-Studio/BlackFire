//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UguiCanvasViewBase : UguiViewBase
    {
        private Canvas m_CachedCanvas = null;

        public Canvas Canvas { get { return m_CachedCanvas ?? (m_CachedCanvas = GetComponent<Canvas>()); }  }


        private GraphicRaycaster m_CachedGraphicRaycaster = null;

        public GraphicRaycaster GraphicRaycaster { get { return m_CachedGraphicRaycaster ?? (m_CachedGraphicRaycaster = GetComponent<GraphicRaycaster>()); } }

        public override bool Interactable
        {
            get
            {
                return null!=GraphicRaycaster?GraphicRaycaster.enabled:false;
            }

            set
            {
                if (null!=GraphicRaycaster)
                {
                    GraphicRaycaster.enabled = value;
                }
            }
        }

        public override int DisplayLevel { get { return Canvas.sortingOrder; } set { Canvas.sortingOrder = value; } }

       
    }
}