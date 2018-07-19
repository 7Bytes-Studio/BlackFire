//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    public interface IBackpackModule  
	{
        void AddBackpack(BackpackBase backpack,ORMBackpackBase ormBackpack);
        BackpackBase GetBackpack(string owner);
        BackpackBase[] GetAllBackpacks();



        void PutIn(string owner,int id, int count);

        bool TakeOut(string owner, int id ,int count);

        bool DelBackpack(string owner);
    }
}
