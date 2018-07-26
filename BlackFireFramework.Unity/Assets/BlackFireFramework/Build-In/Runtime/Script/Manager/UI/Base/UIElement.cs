//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public class UIElement : UIBehaviour<IUIElementLogic>, IUIElementLogic
    {
        public override IUIElementLogic Logic
        {
            get
            {
                return this;
            }
        }

        public void BubblingEvent<T>(WindowHandleCallback<T> windowHandleCallback) where T : IUIEventHandler
        {
            var current = transform;
            UIWindow window = null;
            while (null!=current)
            {
                window = current.GetComponent<UIWindow>();
                if (null!=window)
                {
                    if (window.Logic is T)
                    {
                        windowHandleCallback.Invoke((T)window.Logic);
                    }
                }
                current = current.parent;
            }
        }
    }
}
