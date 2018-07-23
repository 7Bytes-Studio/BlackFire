//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    public abstract class ORM
    {
        protected internal abstract void Open();  
        protected internal abstract void Close();
        public abstract bool IsReady { get;}
    }
}
