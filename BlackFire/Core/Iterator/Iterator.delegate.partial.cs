/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using System.Collections.Generic;

namespace BlackFire
{
    public delegate void IteratorStartCallback(string name,IEnumerator enumerator);
        
    public delegate void IteratorCancelCallback(string name,IEnumerator enumerator);
}