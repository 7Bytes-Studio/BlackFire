//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class MessageBoxWindowLogic : UguiWindowLogic,IButtonClickHandler<Button>
    {
        public override void OnCreate(UIWindow Window)
        {
            base.OnCreate(Window);
            Log.Info("OnCreate::"+Window.WindowInfo.Id);
        }

        [SerializeField] private Text m_TextContent = null;
        public void SetContent(string content)
        {
            m_TextContent.text = content;
        }

        public void OnButtonClick(Button button)
        {
            Log.Info("Click::"+button.Mark);
        }
    }
}