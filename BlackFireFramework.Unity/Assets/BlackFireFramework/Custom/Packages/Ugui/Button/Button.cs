//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine.EventSystems;

namespace BlackFireFramework.Unity
{
    public class Button : UguiUIElement,IPointerClickHandler
    {
        [UnityEngine.SerializeField] private string m_Mark;
        public string Mark 
        {
            get { return m_Mark; }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            BubblingEvent<IButtonClickHandler<Button>>(i=>i.OnButtonClick(this));
        }
    }    
}