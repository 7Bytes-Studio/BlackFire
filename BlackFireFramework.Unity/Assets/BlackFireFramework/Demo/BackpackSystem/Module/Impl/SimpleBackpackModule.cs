//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;

namespace Alan
{
    public sealed class SimpleBackpackModule : IBackpackModule
    {
        public SimpleBackpackModule(ORMStuffBase ormStuff)
        {
            ORMStuff = ormStuff;
        }

        private sealed class BackpackDataBinder {
            public BackpackDataBinder(BackpackBase backpack, ORMBackpackBase ormBackpack)
            {
                Backpack = backpack;
                ORMBackpack = ormBackpack;
            }
            public BackpackBase Backpack;
            public ORMBackpackBase ORMBackpack;
        }

        private Dictionary<string, BackpackDataBinder> m_Dic = new Dictionary<string, BackpackDataBinder>();

        private ORMStuffBase ORMStuff { get; set; }

        public void AddBackpack(BackpackBase backpack,ORMBackpackBase ormBackpack)
        {
            if (null == backpack) throw new System.Exception("Backpack instance can not be null!");
            if (null == ormBackpack) throw new System.Exception("ORMBackpack instance can not be null!");

            if (!m_Dic.ContainsKey(backpack.Owner))
            {
                var array = ormBackpack.Provide(backpack.Owner);
                for (int i = 0; i < array.Length; i++)
                {
                    backpack.PutIn(array[i]); //将数据库内记录的放入背包。
                }
                m_Dic.Add(backpack.Owner,new BackpackDataBinder(backpack,ormBackpack));
            }
        }

        public bool DelBackpack(string owner)
        {
            if (m_Dic.ContainsKey(owner))
            {
                m_Dic[owner].ORMBackpack.Close();
                return m_Dic.Remove(owner);
            }
            return false;
        }

        public BackpackBase[] GetAllBackpacks()
        {
            BackpackBase[] array = new BackpackBase[m_Dic.Count];
            int index = 0;
            foreach (var kv in m_Dic)
            {
                array[index++] = kv.Value.Backpack;
            }
            return array;
        }

        public BackpackBase GetBackpack(string owner)
        {
            if (m_Dic.ContainsKey(owner))
            {
               return m_Dic[owner].Backpack;
            }
            return null;
        }

        public void PutIn(string owner,int id, int count)
        {
            if (m_Dic.ContainsKey(owner))
            {
                var stuff =ORMStuff.GetStuffById(id);
                if (null!=stuff)
                {
                    var backpackStuff = Clone(owner,stuff, count);
                    m_Dic[owner].ORMBackpack.PutIn(owner,id,count); //放入背包。
                    m_Dic[owner].Backpack.PutIn(backpackStuff); //数据库纳入背包数据。
                }
            }
        }

        public bool TakeOut(string owner,int id, int count)
        {
            if (m_Dic.ContainsKey(owner))
            {
                m_Dic[owner].Backpack.TakeOut(id); //从背包拿出。
                m_Dic[owner].ORMBackpack.TakeOut(owner,id,count); //数据库更新背包数据。
            }
            return false;
        }

        private BackpackStuff Clone(string owner,Stuff stuff,int count)
        {
            return new BackpackStuff(owner, stuff.Id, stuff.Name, stuff.Classify, stuff.Description, stuff.Occupy, count); ;
        }
    }
}
