//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 窗口的抽象。
    /// </summary>
    public class UIWindow : UIBehaviour,IPointerEnterHandler,IPointerExitHandler
	{
        public long Id { get; private set; }

        public IUIWindowImpl Impl { get; private set; }

        internal UIManager UIManager { get; set; }




        #region 生命周期

        internal void OnCreate()
        {
            Impl.OnCreate();
        }

        internal void OnOpen()
        {
            Impl.OnOpen();
        }

        internal void OnUpdate()
        {
            Impl.OnUpdate();
        }

        internal void OnClose()
        {
            Impl.OnClose();
        }

        internal void OnDestroyed()
        {
            Impl.OnDestroyed();
        }

        #endregion

        #region PointerHandler

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            OnRefocus();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            OnLostFocus();
        }

        #endregion

        #region 事件

        internal void OnRefocus()
        {
            Impl.OnRefocus();
        }

        internal void OnLostFocus()
        {
            Impl.OnLostFocus();
        }

        #endregion





    }
}


