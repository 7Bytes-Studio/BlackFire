
//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public class DoubleClickButton : UnityEngine.UI.Button 
	{
        [SerializeField][Range(0.6f,2.0f)]private float m_DoubleClickIntervel = 0.6f;
        private float m_DoubleClickTimer = 0f;
        private int m_ClickCount = 0;

        [Serializable]public sealed class DoubleClickEvent : UnityEvent<object,EventArgs> { }
        [SerializeField]private DoubleClickEvent m_OnDoubleClick = new DoubleClickEvent();
        public DoubleClickEvent OnDoubleClick { get { return m_OnDoubleClick;  } set { m_OnDoubleClick = value; } }

        protected virtual void Update()
        {
            DoubleClickTrigger();
        }


        private void DoubleClickTrigger()
        {
            m_DoubleClickTimer += Time.unscaledDeltaTime;

            if (m_DoubleClickTimer >= m_DoubleClickIntervel)
            {
                //在指定的时间间隔内执行。
                //如果用户在这个时间间隔内点击了两次以上，那么判断为双击操作。
                if (2 <= m_ClickCount)
                {
                    //触发双击事件。
                    if (null!= OnDoubleClick)
                    {
                        OnDoubleClick.Invoke(this,new DoubleClickButtonEventArgs(this,m_EventData,m_ClickCount, m_DoubleClickIntervel- m_DoubleClickTimer));
                    }
                }

                //重置点击次数。
                m_ClickCount = 0;
                //重置双击计时器。
                m_DoubleClickTimer = 0f;
            }
        }

        private PointerEventData m_EventData;
        public override void OnPointerClick(PointerEventData eventData)
        {
            m_EventData = eventData;
            base.OnPointerClick(eventData);
            m_ClickCount++;
            Debug.Log(m_ClickCount);
        }



    }

    public sealed class DoubleClickButtonEventArgs : EventArgs
    {
        public DoubleClickButtonEventArgs(DoubleClickButton button,PointerEventData eventData,int clickCount, float clickDeltaTime)
        {
            Button = button;
            EventData = eventData;
            ClickCount = clickCount;
            ClickDeltaTime = clickDeltaTime;
        }

        public DoubleClickButton Button { get; private set; }

        public PointerEventData EventData { get; private set; }

        public int ClickCount { get; private set; }

        public float ClickDeltaTime { get; private set; }
    }

}
