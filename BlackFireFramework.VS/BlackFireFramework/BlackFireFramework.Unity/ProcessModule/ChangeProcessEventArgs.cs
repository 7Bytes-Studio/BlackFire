//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    internal sealed class ChangeProcessEventArgs: EventArgs
    {
        public Type FromProcessType;
        public Type ToProcessType;
    }
}
