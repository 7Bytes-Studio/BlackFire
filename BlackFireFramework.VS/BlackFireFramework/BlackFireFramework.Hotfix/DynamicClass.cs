using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackFireFramework.Hotfix
{
    public class DynamicClass
    {
        public DynamicClass()
        {
            Name = GetHashCode().ToString();
        }

        public DynamicClass(string name,int id)
        {
            Name = name;
            Id = id;
        }


        public string Name { get; private set; }
        public int Id { get; private set; }

        public T Test<T>(T t)
        {
            return t;
        }

        public string Test1<T,K>(T t,K k)
        {
            return string.Format("{0}       {1}",t.ToString(),k.ToString());
        }

    }
}
