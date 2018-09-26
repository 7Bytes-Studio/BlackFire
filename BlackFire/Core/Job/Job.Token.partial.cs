/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    public static partial class Job
    {
        public sealed class Token
        {
            public bool IsCancellationRequested;

            public void Cancel()
            {
                IsCancellationRequested = true;
            }
        }
    }
}
