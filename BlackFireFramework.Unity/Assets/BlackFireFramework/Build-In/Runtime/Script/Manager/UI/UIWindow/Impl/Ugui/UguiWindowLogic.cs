//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// Ugui窗口逻辑类。
    /// </summary>
    [RequireComponent(typeof(UIWindow))]
    public abstract class UguiWindowLogic : UIBehaviourEx, IUIWindowLogic
    {

        private Canvas m_Canvas = null;
        public Canvas Canvas { get { return m_Canvas ?? (m_Canvas = GetComponent<Canvas>()); } }

        [SerializeField]
        [Range(0f, 1f)]
        private float m_Alpha = 1f;

        [SerializeField]
        private bool m_Interactable = true;

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            Alpha = m_Alpha;
            Interactable = m_Interactable;
        }
#endif

        /// <summary>
        /// CanvasGroup组件缓存。
        /// </summary>
        private CanvasGroup m_CachedCanvasGroup = null;

        /// <summary>
        /// CanvasGroup。
        /// </summary>
        public CanvasGroup CanvasGroup { get { return m_CachedCanvasGroup ?? (m_CachedCanvasGroup = GetComponent<CanvasGroup>()); } }

        /// <summary>
        /// GraphicRaycaster组件缓存。
        /// </summary>
        private GraphicRaycaster m_GraphicRaycaster = null;

        /// <summary>
        /// GraphicRaycaster。
        /// </summary>
        public GraphicRaycaster GraphicRaycaster { get { return m_GraphicRaycaster ?? (m_GraphicRaycaster = GetComponent<GraphicRaycaster>()); } }


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
                if (null != GraphicRaycaster)
                {
                    GraphicRaycaster.enabled = value;
                }

                if (null != CanvasGroup)
                {
                    CanvasGroup.interactable = value;
                }
            }
        }

        /// <summary>
        /// Alpha值。
        /// </summary>
        public virtual float Alpha
        {
            get
            {
                return null != CanvasGroup ? CanvasGroup.alpha : 1f;
            }

            set
            {
                if (null != CanvasGroup)
                {
                    CanvasGroup.alpha = value;
                }
            }
        }

        /// <summary>
        /// 显示的层级。
        /// </summary>
        public virtual int DisplayLevel
        {
            get
            {
                return SiblingIndex;
            }
            set
            {
                SiblingIndex = value;
            }
        }

        #region Rect

        /// <summary>
        /// 宽度属性。
        /// </summary>
        public virtual float Width
        {
            get
            {
                return CachedRectTransform.rect.width;
            }

            set
            {
                var rect = CachedRectTransform.rect;
                CachedRectTransform.sizeDelta = new Vector2(value, rect.height);
            }
        }

        /// <summary>
        /// 高度属性。
        /// </summary>
        public virtual float Height
        {
            get
            {
                return CachedRectTransform.rect.height;
            }

            set
            {
                var rect = CachedRectTransform.rect;
                CachedRectTransform.sizeDelta = new Vector2(rect.width, value);
            }
        }

        /// <summary>
        /// 矩形区域顶部与父级矩形框的距离。
        /// </summary>
        public virtual float Top
        {
            get
            {
                return -CachedRectTransform.offsetMax.y;
            }

            set
            {
                CachedRectTransform.offsetMax = new Vector2(CachedRectTransform.offsetMax.y, -value);
            }
        }

        /// <summary>
        /// 矩形区域底部与父级矩形框的距离。
        /// </summary>
        public virtual float Bottom
        {
            get
            {
                return CachedRectTransform.offsetMin.y;
            }

            set
            {
                CachedRectTransform.offsetMin = new Vector2(CachedRectTransform.offsetMin.x, value);
            }
        }

        /// <summary>
        /// 矩形区域右边与父级矩形框的距离。
        /// </summary>
        public virtual float Right
        {
            get
            {
                return -CachedRectTransform.offsetMax.x;
            }

            set
            {
                CachedRectTransform.offsetMax = new Vector2(-value, CachedRectTransform.offsetMax.y);
            }
        }

        /// <summary>
        /// 矩形区域左边与父级矩形框的距离。
        /// </summary>
        public virtual float Left
        {
            get
            {
                return CachedRectTransform.offsetMin.x;
            }

            set
            {
                CachedRectTransform.offsetMin = new Vector2(value, CachedRectTransform.offsetMin.y);
            }
        }
        #endregion

        #region Event

        public int Layer
        {
            get { return Canvas.sortingOrder; }
            set { Canvas.sortingOrder = value; }
        }
        
        public virtual void OnCreate(UIWindow Window) { gameObject.SetActive(false); }
        public virtual void OnOpen() { gameObject.SetActive(true); }
        public virtual void OnUpdate() { }
        public virtual void OnClose() {  gameObject.SetActive(false); }
        public virtual void OnDestroyed() { DestroyImmediate(gameObject); }

        #endregion



    }
}
