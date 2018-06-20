//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class DebuggerStyleChangedCallback : IDebuggerStyleChangeCallback
    {
        public int Priority
        {
            get
            {
                return 66666;
            }
        }

        public bool HiddenStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F1);
        }

        public bool MiniStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F2);
        }

        public bool FullStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F3);
        }

    }
}
