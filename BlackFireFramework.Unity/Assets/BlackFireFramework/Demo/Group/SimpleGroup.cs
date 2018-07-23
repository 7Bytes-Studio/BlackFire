//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BlackFireFramework.Unity 
{
    public sealed class SimpleGroup : Group.IGroup
    {
        public SimpleGroup(string groupName, int ability, Group.IGroupLeader groupLeader)
        {
            Name = groupName;
            GroupAbility = ability;
            GroupLeader = groupLeader;
        }

        public string Name { get; private set; }

        public int GroupAbility { get; private set; }

        public int Count { get; private set; }

        public Group.IGroupLeader GroupLeader { get; private set; }

        public int CompareTo(Group.IGroup other)
        {
            return other.GroupAbility - this.GroupAbility;
        }
    }
}
