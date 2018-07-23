//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    public abstract class BackpackBase
    {
        public abstract string Owner{ get; protected set; }

        public abstract int TotalCapacity { get; protected set; }

        public abstract int CurrentCapacity { get; }

        public abstract BackpackStuff[] GetAllBackpackStuffs();
        public abstract BackpackStuff GetStuff(int id);

        public abstract BackpackStuff[] GetUnuseBackpackStuffs();

        protected internal abstract void PutIn(BackpackStuff backpackStuff);

        protected internal abstract bool TakeOut(int id);
    }
}
