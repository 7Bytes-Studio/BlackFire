//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    /// <summary>
    /// ORM Backpack.
    /// </summary>
    public abstract class ORMBackpackBase : ORM
    {
        public abstract void PutIn(string owner,int id,int count);

        public abstract void TakeOut(string owner,int id, int count);

        public abstract BackpackStuff[] Provide(string owner);
    }
}
