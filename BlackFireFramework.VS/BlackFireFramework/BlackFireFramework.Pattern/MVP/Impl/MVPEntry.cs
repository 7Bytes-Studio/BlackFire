//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;

namespace BlackFireFramework.Pattern
{
    internal sealed class VPEntry
    {
        internal Type View;
        internal IEnumerable<Type> Presenters;
    }
    
    internal sealed class MPEntry
    {
        internal Type Model;
        internal IEnumerable<Type> Presenters;   
    }
}