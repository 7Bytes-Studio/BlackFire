//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework
{
    /// <summary>
    /// Ugui逻辑对象抽象基类。
    /// </summary>
	public abstract class UguiLogicBase : UguiBehaviourBase
    {
        #region Assets

        [SerializeField] private string m_Id = string.Empty;

        /// <summary>
        /// ID。
        /// </summary>
        public virtual string Id
        {
            get
            {
                return m_Id;
            }

            set
            {
                m_Id = value;
            }
        }

        #endregion

        #region Call View

        private UguiViewBase m_CachedUguiView = null;

        /// <summary>
        /// Ugui显示层对象引用。
        /// </summary>
        /// <returns>对象实例</returns>
        public virtual UguiViewBase GetUguiView()
        {
            return m_CachedUguiView??(m_CachedUguiView=GetComponent<UguiViewBase>());
        }

        /// <summary>
        /// 显示层对象被重新使用。
        /// </summary>
        public virtual void Reuse()
        {
            var view = GetUguiView();
            if (null != view)
            {
                view.OnReuse();
            }
        }

        /// <summary>
        /// 显示层对象被打开。
        /// </summary>
        public virtual void Open()
        {
            gameObject.SetActive(true);
            var view = GetUguiView();
            if (null!=view)
            {
                view.OnOpen();
            }
        }

        /// <summary>
        /// 显示层对象由暂停到继续。
        /// </summary>
        public virtual void Resume()
        {
            m_IsUpdating = true;
            var view = GetUguiView();
            if (null != view)
            {
                view.OnResume();
            }
        }

        /// <summary>
        /// 显示层对象被暂停。
        /// </summary>
        public virtual void Pause()
        {
            m_IsUpdating = false;
            var view = GetUguiView();
            if (null != view)
            {
                view.OnPause();
            }
        }

        /// <summary>
        /// 显示层对象被关闭。
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
            var view = GetUguiView();
            if (null != view)
            {
                view.OnClose();
            }
        }

        /// <summary>
        /// 显示层对象被销毁事件。
        /// </summary>
        public virtual void Destroyed()
        {
            var view = GetUguiView();
            if (null != view)
            {
                view.OnDestroyed();
            }
        }

        /// <summary>
        /// 播放声音事件。
        /// </summary>
        /// <param name="soundId">声音资产Id。</param>
        public virtual void PlaySound(string soundAssetsId)
        {
            GetUguiView().OnPlaySound(soundAssetsId);
        }

        /// <summary>
        /// 播放特效事件。
        /// </summary>
        /// <param name="effectAssetsId">特效资产Id。</param>
        public virtual void PlayEffects(string effectAssetsId)
        {
            GetUguiView().OnPlayEffects(effectAssetsId);
        }

        /// <summary>
        /// 播放动画事件。
        /// </summary>
        /// <param name="animationAssetsId">动画资产Id。</param>
        public virtual void PlayAnimation(string animationAssetsId)
        {
            GetUguiView().OnPlayAnimation(animationAssetsId);
        }

        #endregion

        #region Unity Event

        protected override void OnEnable()
        {
            base.OnEnable();
            if (gameObject.activeSelf)
            {
                Open();
            }
               
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (!gameObject.activeSelf)
            {
                Close();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Destroyed();
        }


        private bool m_IsUpdating = true;
        protected virtual void Update()
        {
            if (m_IsUpdating)
            {
                var view = GetUguiView();
                if (null != view)
                {
                    view.OnUpdate();
                }
            }
        }

        #endregion
    }
}