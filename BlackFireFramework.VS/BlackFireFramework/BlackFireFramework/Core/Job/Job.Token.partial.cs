//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFireFramework
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
