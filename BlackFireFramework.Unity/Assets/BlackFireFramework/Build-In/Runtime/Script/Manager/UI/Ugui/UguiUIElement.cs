//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public class UguiUIElement : UIElement 
	{
        [SerializeField]
        private bool m_Interactable = true;

        /// <summary>
        /// CanvasGroup组件缓存。
        /// </summary>
        private CanvasGroup m_CachedCanvasGroup = null;

        /// <summary>
        /// CanvasGroup。
        /// </summary>
        public CanvasGroup CanvasGroup { get { return m_CachedCanvasGroup ?? (m_CachedCanvasGroup = GetComponent<CanvasGroup>()); } }

        /// <summary>
        /// 图形组件缓存。
        /// </summary>
        private Graphic m_CachedGraphic = null;

        /// <summary>
        /// 图形组件。
        /// </summary>
        public Graphic Graphic { get { return m_CachedGraphic ?? (m_CachedGraphic = GetComponent<Graphic>()); } }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public virtual bool Interactable
        {
            get
            {
                return null != CanvasGroup ? CanvasGroup.interactable : false;
            }

            set
            {
                if (null != Graphic)
                {
                    Graphic.raycastTarget = value;
                }

                if (null != CanvasGroup)
                {
                    CanvasGroup.interactable = value;
                }
            }
        }
    }
}
