//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// UGUI的显示层对象抽象类。
    /// </summary>
	public abstract class UguiViewBase : UguiBehaviourBase
    {
        [SerializeField]
        [Range(0f,1f)]
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
        /// 图形组件缓存。
        /// </summary>
        private Graphic m_CachedGraphic = null;

        /// <summary>
        /// 图形组件。
        /// </summary>
        public Graphic Graphic { get { return m_CachedGraphic ?? (m_CachedGraphic= GetComponent<Graphic>()); } }


        /// <summary>
        /// CanvasGroup组件缓存。
        /// </summary>
        private CanvasGroup m_CachedCanvasGroup = null;

        /// <summary>
        /// CanvasGroup。
        /// </summary>
        public CanvasGroup CanvasGroup { get { return m_CachedCanvasGroup ?? (m_CachedCanvasGroup = GetComponent<CanvasGroup>()); } }

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



        #region Unity Event

        protected override void Awake()
        {
            base.Awake();
            OnInit();
        }

        #endregion


        /// <summary>
        /// 显示层对象被创建事件。
        /// </summary>
        public abstract void OnInit();

        /// <summary>
        /// 显示层对象被打开事件。
        /// </summary>
        public abstract void OnOpen();

        /// <summary>
        /// 显示层对象由暂停到继续事件。
        /// </summary>
        public abstract void OnResume();

        /// <summary>
        /// 显示层对象被更新事件。
        /// </summary>
        public abstract void OnUpdate();

        /// <summary>
        /// 显示层对象被暂停事件。
        /// </summary>
        public abstract void OnPause();

        /// <summary>
        /// 显示层对象被关闭事件。
        /// </summary>
        public abstract void OnClose();

        /// <summary>
        /// 显示层对象被销毁事件。
        /// </summary>
        public abstract void OnDestroyed();

        /// <summary>
        /// 被重新使用事件。
        /// </summary>
        public abstract void OnReuse();

        /// <summary>
        /// 播放声音事件。
        /// </summary>
        /// <param name="soundId">声音资产Id。</param>
        public abstract void OnPlaySound(string soundAssetsId);

        /// <summary>
        /// 播放特效事件。
        /// </summary>
        /// <param name="effectAssetsId">特效资产Id。</param>
        public abstract void OnPlayEffects(string effectAssetsId);

        /// <summary>
        /// 播放动画事件。
        /// </summary>
        /// <param name="animationAssetsId">动画资产Id。</param>
        public abstract void OnPlayAnimation(string animationAssetsId);

    }
}