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
    public sealed class DebuggerIteratorGUI : IDebuggerModuleGUI
    {


        public int Priority
        {
            get
            {
                return 11;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Iterator";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }


        public void OnModuleGUI()
        {


                BlackFireGUI.VerticalLayout(() =>
                {

                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {

                        BlackFireGUI.ScrollView("Iterator/IteratorNames", id =>
                        {
                            foreach (var name in BlackFireFramework.Iterator.AllIteratorNames)
                            {
                                GUILayout.Label(string.Format("{0} : {1}","Name".HexColor("yellow"),name.HexColor("green")));
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
