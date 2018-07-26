//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework.Unity
{
    public interface IUIWindowLogic: ILogic
    {
        void OnCreate(UIWindow Window);
        void OnOpen();
        void OnUpdate();
        void OnClose();
        void OnDestroyed();
    }
}
