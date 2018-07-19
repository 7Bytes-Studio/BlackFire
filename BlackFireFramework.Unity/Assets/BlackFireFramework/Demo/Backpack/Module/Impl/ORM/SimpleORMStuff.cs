//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using BlackFireFramework;

namespace Alan
{
    public class SimpleORMStuff : ORMStuffBase
    {
        private LinkedList<Stuff> m_FakeDB = new LinkedList<Stuff>(
        new Stuff[] {
                    new Stuff(1,"AK47","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(2,"AK48","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(3,"AK49","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(4,"AK50","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(5,"AK51","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(6,"AK52","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(7,"AK53","武器","这是一把杀伤力极强的枪。",1),
                    new Stuff(8,"AK54","武器","这是一把杀伤力极强的枪。",1)
        });

        public override bool IsReady
        {
            get
            {
                return true;
            }
        }
        protected internal override void Open()
        {

        }

        protected internal override void Close()
        {
          
        }

        public override Stuff GetStuffById(int id)
        {
            var current = m_FakeDB.First;
            while (null!= current)
            {
                if (current.Value.Id == id)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
