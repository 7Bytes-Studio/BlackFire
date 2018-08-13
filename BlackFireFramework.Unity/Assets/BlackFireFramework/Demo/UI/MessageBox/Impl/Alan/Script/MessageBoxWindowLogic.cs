//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    public sealed class MessageBoxWindowLogic : UguiWindowLogic,
        IMessageBoxWindowLogic,IColourfulMessageBoxWindowLogic,IShakeMessageBoxWindowLogic,
        IButtonClickHandler<Button>
    {
        public override void OnCreate(UIWindow Window)
        {
            base.OnCreate(Window);
            Log.Info("OnCreate::"+Window.WindowInfo.ToString());
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

        public void UseColourful()
        {
            StartCoroutine(ColourfulYield());
        }

        private IEnumerator ColourfulYield()
        {
            while (true)
            {
                yield return null;
                GetComponentInChildren<Graphic>().color = Color.white;
                yield return null;
                GetComponentInChildren<Graphic>().color = Color.red;
                yield return null;
                GetComponentInChildren<Graphic>().color = Color.yellow;
                yield return null;
                GetComponentInChildren<Graphic>().color = Color.gray;
                yield return null;
                GetComponentInChildren<Graphic>().color = Color.green;
            }
        }
        
        

        public void Shake()
        {
            StartCoroutine(ShakeYield());
;        }
        
        private IEnumerator ShakeYield()
        {               
            var p = GetComponentInChildren<Graphic>().rectTransform.position;
            var minX = p.x - 10;
            var maxX = p.x + 10;
            var minY = p.y - 10;
            var maxY = p.y + 10;
            while (true)
            {                
                yield return null;
                GetComponentInChildren<Graphic>().rectTransform.position = 
                    new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),p.z);
            }
        }
    }

}