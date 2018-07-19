//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace Alan
{
    public class BackpackStuff : Stuff
    {
        public BackpackStuff(string owner,int id, string name, string classify, string description, int occupy,int count) :base(id,name,classify,description, occupy)
        {
            Owner = owner;
            Count = count;
        }

        public string Owner { get; private set; }
        public bool IsInBackpack { get; internal set; }
        public int Count { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} ", Owner,Name,Classify,Occupy,Count);
        }
    }
}
