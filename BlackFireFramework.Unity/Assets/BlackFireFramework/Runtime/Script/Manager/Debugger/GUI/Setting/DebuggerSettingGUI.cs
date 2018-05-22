//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework 
{
    public sealed class DebuggerSettingGUI : IDebuggerModuleGUI
    {

        private DebuggerManager m_DebuggerManager = null;
        private string settingText = string.Empty;



        public int Priority
        {
            get
            {
                return 10;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Setting";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
            m_DebuggerManager = debuggerManager;
        }


        public void OnModuleGUI()
        {


                BlackFireGUI.VerticalLayout(() =>
                {

                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {

                        GUILayout.Label("Window Scale : ", GUILayout.Width(100));

                        settingText = GUILayout.TextField(settingText);
                        float scale = 1f;
                        if (float.TryParse(settingText, out scale))
                        {
                            if (3f >= scale && 1f <= scale)
                            {
                                m_DebuggerManager.WindowScale = scale;
                            }
                        }

                        if (GUILayout.Button("-"))
                        {
                            m_DebuggerManager.WindowScale -= 0.1f;
                            if (1.0f>=m_DebuggerManager.WindowScale)
                            {
                                m_DebuggerManager.WindowScale = 1.0f;
                            }
                        }

                        if (GUILayout.Button("+"))
                        {
                            m_DebuggerManager.WindowScale += 0.1f;

                        }

                        if (GUILayout.Button("Reset"))
                        {
                            m_DebuggerManager.WindowScale = 1.0f;
                            settingText = string.Empty;
                        }

                    });


                    //BlackFireGUI.BoxHorizontalLayout(()=> {

                    //    Application.runInBackground = GUILayout.Toggle(Application.runInBackground, "RunInBackground");

                    //});

                });

        }

        public void OnDestroy()
        {
            
        }




    }
}
