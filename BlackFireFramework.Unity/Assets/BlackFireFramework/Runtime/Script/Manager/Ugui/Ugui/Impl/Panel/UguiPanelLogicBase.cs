//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@gmail.com
//Website: http://www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    public abstract class UguiPanelLogicBase : UguiLogicBase 
	{
        private UguiPanelViewBase m_CachedUguiPanelView = null;

        /// <summary>
        /// Ugui显示类的引用。
        /// </summary>
        public UguiPanelViewBase PanelView { get { return m_CachedUguiPanelView ?? (m_CachedUguiPanelView = GetUguiView() as UguiPanelViewBase); } }

    }
}