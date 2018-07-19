//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using NUnit.Framework;
using System.Collections;
using UnityEngine;

namespace Alan
{
    public sealed class BackpackModuleTest
    {
        [Test]
        public void Test()
        {
            IBackpackModule module = new SimpleBackpackModule(new SimpleORMStuff());
            module.AddBackpack(new SimpleBackpack("Player",100), new SimpleORMBackpack());
            module.PutIn("Player",3,66);
            var backpack = module.GetBackpack("Player");
            Debug.Log(backpack.Owner +"  "+ backpack.TotalCapacity+ "  " + backpack.CurrentCapacity);
            var stuffs = backpack.GetAllBackpackStuffs();
            for (int i = 0; i < stuffs.Length; i++)
            {
                Debug.Log(stuffs[i].ToString());
            }
            module.PutIn("Player", 3,40);
        }


        [Test]
        public IEnumerator EnumeratorTest()
        {
            yield return null;
        }
    }
}
