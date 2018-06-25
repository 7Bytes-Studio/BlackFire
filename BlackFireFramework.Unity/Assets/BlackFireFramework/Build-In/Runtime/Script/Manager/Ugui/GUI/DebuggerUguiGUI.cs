//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DebuggerUguiGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 5;
            }
        }

        public string ModuleName
        {
            get
            {
                return "UGUI";
            }
        }

        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        private string m_CaptureEventData = null;
        private bool m_UseCapture;

        public void OnModuleGUI()
        {
            if (null==BlackFire.Ugui) return;

            if (null!=BlackFire.Ugui.PointerEventData)
            {
                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("PointerEventData :".HexColor("green"), GUILayout.ExpandWidth(false));

                    m_UseCapture = GUILayout.Toggle(m_UseCapture, "UseCapture", GUILayout.ExpandWidth(false));

                    if (GUILayout.Button("Clear", GUILayout.ExpandWidth(false)))
                    {
                        m_CaptureEventData = null;
                    }
                });

                if (m_UseCapture)
                {
                    if (BlackFire.Ugui.PointerEventData.pointerCurrentRaycast.isValid)
                    {
                        m_CaptureEventData = BlackFire.Ugui.PointerEventData.ToString();
                    }

                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {
                        BlackFireGUI.ScrollView("Ugui/UseCapture", id =>
                        {
                            GUILayout.Label(m_CaptureEventData ?? BlackFire.Ugui.PointerEventData.ToString());
                        });
                    });
                }
                else
                {
                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {
                        BlackFireGUI.ScrollView("Ugui/DontUseCapture", id =>
                        {
                            GUILayout.Label(BlackFire.Ugui.PointerEventData.ToString());
                        });
                    });
                }

            }

        }
        public void OnDestroy()
        {
           
        }
    }
}
