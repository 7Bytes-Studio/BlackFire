//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DebuggerGameGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 4;
            }
        }

        public string ModuleName { get { return "Game"; } }

        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        private int m_ToggleBarSelect;
        public void OnModuleGUI()
        {
            if (null == BlackFire.Game) return;

            BlackFireGUI.VerticalLayout(() => {

                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("Game Setting :".HexColor("green"), GUILayout.ExpandWidth(false));

                });

                BlackFireGUI.BoxVerticalLayout(() => {

                    BlackFireGUI.HorizontalLayout(() => {
                        BlackFire.Game.RunInBackground = GUILayout.Toggle(BlackFire.Game.RunInBackground,"RunInBackground");
                    });
                    GUILayout.Space(5);
                    BlackFireGUI.HorizontalLayout(() => {
                        GUILayout.Label(string.Format("Game Speed : {0:0.00}".HexColor("yellow"), BlackFire.Game.GameSpeed));
                    });
                    BlackFireGUI.HorizontalLayout(() => {
                        m_ToggleBarSelect = GUILayout.Toolbar(m_ToggleBarSelect, new string[]
                        {
                            string.Format("GameSpeed(1~100)").HexColor("yellow"),
                            string.Format("GameSpeed(0~1)").HexColor("yellow"),
                        });
                    });

                    BlackFireGUI.HorizontalLayout(() => {
                        Debug.Log(m_ToggleBarSelect);
                        if (0== m_ToggleBarSelect)
                        {
                            BlackFire.Game.GameSpeed = GUILayout.HorizontalSlider(BlackFire.Game.GameSpeed, 1f, 100f, GUILayout.ExpandWidth(true));
                        }
                        else 
                        {
                            BlackFire.Game.GameSpeed = GUILayout.HorizontalSlider(BlackFire.Game.GameSpeed, 0f, 1f, GUILayout.ExpandWidth(true));
                        }
                    });

                });

            });

        
        }

        public void OnDestroy()
        {
           
        }
    }
}
