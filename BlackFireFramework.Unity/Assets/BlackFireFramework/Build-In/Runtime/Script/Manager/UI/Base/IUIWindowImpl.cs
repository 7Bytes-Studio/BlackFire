//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlackFireFramework.Unity
{
    public interface IUIWindowImpl
    {
        void OnOpen();
        void OnUpdate();
        void OnClose();
        void OnCreate();
        void OnDestroyed();
        void OnLostFocus();
        void OnRefocus();
    }
}


