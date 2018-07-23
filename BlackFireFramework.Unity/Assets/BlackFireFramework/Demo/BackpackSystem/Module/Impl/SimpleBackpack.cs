//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using BlackFireFramework;

namespace Alan
{
    public sealed class SimpleBackpack : BackpackBase
    {
        public SimpleBackpack(string owner,int totalOccupy)
        {
            Owner = owner;
            TotalCapacity = totalOccupy;
        }

        public override string Owner { get;protected set; }

        public override int TotalCapacity { get; protected set;}

        public override int CurrentCapacity { get {
                int t = 0;
                m_In.Foreach(current => {
                    t += current.Value.Occupy * current.Value.Count;
                });
                return t;
            } }

        private LinkedList<BackpackStuff> m_In = new LinkedList<BackpackStuff>();
        private LinkedList<BackpackStuff> m_Out = new LinkedList<BackpackStuff>();

        public override BackpackStuff[] GetAllBackpackStuffs()
        {
            return Utility.Array.Merge<BackpackStuff>(m_In,m_Out);
        }

        public override BackpackStuff GetStuff(int id)
        {
            var current_in = m_In.First;
            var current_out = m_In.First;
            while (null!= current_in || null != current_out)
            {
                if (null!= current_in)
                {
                    if (current_in.Value.Id==id)
                    {
                        return current_in.Value;
                    }
                    current_in = current_in.Next;
                }
                if (null != current_out)
                {
                    if (current_out.Value.Id == id)
                    {
                        return current_out.Value;
                    }
                    current_out = current_out.Next;
                }
            }
            return null;
        }

        public override BackpackStuff[] GetUnuseBackpackStuffs()
        {
            return m_Out.ToArray();
        }

        protected internal override void PutIn(BackpackStuff backpackStuff)
        {
            if (HasOverTotalOccupy(backpackStuff))
            {
#if ALAN_LOG
                Log.Warn(string.Format("<Backpack:{0}> 已经超出容量{1}!", Owner,TotalCapacity));
#endif
                return; 
            }

            var result = Contains(m_In, backpackStuff);
            if (null== result)
            {
                m_In.AddLast(backpackStuff);
            }
            else
            {
                result.Count += backpackStuff.Count;
            }
        }

        protected internal override bool TakeOut(int id)
        {
            var current = m_In.First;
            while (null!= current)
            {
                if (current.Value.Id == id)
                {
                    m_In.Remove(current);
                    if (null!=Contains(m_Out,current.Value))
                    {
                        m_Out.AddFirst(current);
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private BackpackStuff Contains(LinkedList<BackpackStuff> list, BackpackStuff backpackStuff)
        {
            var current = list.First;
            while (null != current)
            {
                if (current.Value.Equals(backpackStuff) || current.Value.Id == backpackStuff.Id)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }


        private bool HasOverTotalOccupy(BackpackStuff backpackStuff)
        {
            int t = 0;
            t += backpackStuff.Occupy * backpackStuff.Count;
            m_In.Foreach(current=> {
                t+=current.Value.Occupy * current.Value.Count;
            });
            
            return t > TotalCapacity;
        }
    }
}
