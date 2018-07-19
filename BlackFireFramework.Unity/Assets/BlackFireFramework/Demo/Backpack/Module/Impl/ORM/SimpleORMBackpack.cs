//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using BlackFireFramework;

namespace Alan
{
    public class SimpleORMBackpack : ORMBackpackBase
    {

        private LinkedList<BackpackStuff> m_FakeDB = new LinkedList<BackpackStuff>(
                new BackpackStuff[] {
                    new BackpackStuff("Player",1,"AK47","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",2,"AK48","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",3,"AK49","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",4,"AK50","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",5,"AK51","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",6,"AK52","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",7,"AK53","武器","这是一把杀伤力极强的枪。",1,1),
                    new BackpackStuff("Player",8,"AK54","武器","这是一把杀伤力极强的枪。",1,1)
                }
            );

        public override bool IsReady
        {
            get
            {
                return true;
            }
        }

        protected internal override void Open()
        {
            //连接数据库取数据操作。
        }

        protected internal override void Close()
        {
            //断开数据库操作。
        }



        public override BackpackStuff[] Provide(string owner)
        {
            return m_FakeDB.ToArray();
        }

        public override void PutIn(string owner, int id, int count)
        {
          
        }

        public override void TakeOut(string owner, int id, int count)
        {

        }
    }
}
