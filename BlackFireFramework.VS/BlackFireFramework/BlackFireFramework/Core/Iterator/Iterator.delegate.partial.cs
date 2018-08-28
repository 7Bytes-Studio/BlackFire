//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework
{
    public delegate void IteratorStartCallback(string name,IEnumerator enumerator);
        
    public delegate void IteratorCancelCallback(string name,IEnumerator enumerator);
}