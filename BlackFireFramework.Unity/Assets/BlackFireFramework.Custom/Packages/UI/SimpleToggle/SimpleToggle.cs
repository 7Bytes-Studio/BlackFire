//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BlackFireFramework
{
    [RequireComponent(typeof(Image))]
    public sealed class SimpleToggle : UIBehaviour ,IPointerClickHandler
	{
        [SerializeField] private bool m_On = true;
        [SerializeField] private RectTransform m_HandleRT;
        [SerializeField] private RectTransform m_OnRT;
        [SerializeField] private RectTransform m_OffRT;

        private RectTransform m_RectTransform = null;
        public RectTransform RectTransform { get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); } }

        public bool On { get { return m_On; } set { m_On = value; } }

        [System.Serializable] public sealed class ToggleChangeEvent : UnityEvent<object,bool> { }
        [SerializeField] private ToggleChangeEvent m_OnToggleChange =null;
        public ToggleChangeEvent OnToggleChange { get { return m_OnToggleChange; } }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            m_HandleRT.anchoredPosition = m_On ? m_OnRT.anchoredPosition : m_OffRT.anchoredPosition;
        }
#endif

        protected override void Awake()
        {
            base.Awake();
            m_HandleRT.anchoredPosition = m_On ? m_OnRT.anchoredPosition : m_OffRT.anchoredPosition;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_On = !m_On;
            m_HandleRT.anchoredPosition = m_On ? m_OnRT.anchoredPosition : m_OffRT.anchoredPosition;
            if (null!= OnToggleChange)
            {
                OnToggleChange.Invoke(this,m_On);
            }
        }

    }
}
