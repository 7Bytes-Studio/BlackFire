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
    public sealed class DebuggerPackUp : IDebuggerPackUp
    {
        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public bool PackUp(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}
