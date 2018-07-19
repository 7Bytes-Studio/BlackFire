//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;

namespace BlackFireFramework.Unity
{
    public class DragGraphic : UIBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform m_CanvasRT = null;

        private Canvas m_Canvas = null;
        public Canvas Canvas { get { return m_Canvas ?? ( m_Canvas = m_CanvasRT.GetComponent<Canvas>() ); } }

        [SerializeField]
        private bool m_CanDrag;

        [SerializeField]
        [Range(0f,1f)]
        private float m_DragSpeed = 1f;
        public bool CanDrag { get { return m_CanDrag; } set { m_CanDrag = value; } }

        private Vector2 m_Offset;

        protected RectTransform m_CachedRectTransform = null;
        public RectTransform CachedRectTransform { get { return m_CachedRectTransform??(m_CachedRectTransform= GetComponent<RectTransform>()); } }


        protected virtual void FindCanvas()
        {
            Canvas target = null;
            Transform current = transform;
            while (null!=current)
            {
                target = current.GetComponent<Canvas>();
                if (null!= target)
                {
                    m_CanvasRT = target.GetComponent<RectTransform>();
                    return;
                }
                current = current.parent;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            FindCanvas();
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {

            if (m_CanDrag)
            {
                Vector2 localPosition;
                var isOnRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRT, eventData.position, eventData.enterEventCamera, out localPosition);
                if (isOnRect)
                {
                    m_Offset = CachedRectTransform.anchoredPosition - localPosition;
                }
            }

        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (m_CanDrag)
            {
                Vector2 localPosition;
                var isOnRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRT, eventData.position, eventData.enterEventCamera, out localPosition);
                if (isOnRect)
                {
                    CachedRectTransform.anchoredPosition = Vector2.LerpUnclamped(CachedRectTransform.anchoredPosition, m_Offset + localPosition,m_DragSpeed);
                }
            }
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}
