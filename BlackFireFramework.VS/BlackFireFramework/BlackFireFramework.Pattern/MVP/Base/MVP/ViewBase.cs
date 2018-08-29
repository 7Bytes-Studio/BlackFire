//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Pattern
{
    /// <summary>
    /// 显示层。
    /// </summary>
    public abstract class ViewBase : PatternEntityTreeNode
    {
       
        internal PresenterBase Presenter=null;
        
        /// <summary>
        /// 显示层曝露出来的接口，用于显示层的数据设置（一般单向设置）。
        /// </summary>
        protected internal virtual IView View
        {
            get { return (IView)(object)this; }
        }

        /// <summary>
        /// 发出事件。
        /// </summary>
        /// <param name="fireCallback">事件执行回调。</param>
        /// <typeparam name="T">事件接口类型。</typeparam>
        protected void Fire<T>(Action<T> fireCallback) where T : IViewEventHandler
        {
            if (null!=fireCallback && Presenter is T)
            {
                fireCallback.Invoke((T)(object)Presenter);
            }
        }


        
    }
}