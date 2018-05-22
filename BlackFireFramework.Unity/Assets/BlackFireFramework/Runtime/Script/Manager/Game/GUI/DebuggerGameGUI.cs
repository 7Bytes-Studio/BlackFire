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

        public void OnModuleGUI()
        {
           
        }

        public void OnDestroy()
        {
           
        }
    }
}
