//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Alan 
{
	public class Stuff 
	{
        public Stuff(int id, string name, string classify, string description,int occupy)
        {
            Id = id;
            Name = name;
            Classify = classify;
            Description = description;
            Occupy = occupy;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Classify { get; private set; }
        public string Description { get; private set; }
        public int Occupy { get; private set; }

    }
}
