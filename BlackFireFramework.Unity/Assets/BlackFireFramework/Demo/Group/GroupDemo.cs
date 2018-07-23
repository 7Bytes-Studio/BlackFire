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
	public sealed class GroupDemo : MonoBehaviour 
	{
        private void Start()
        {

            Group.RegisterGroup(new SimpleGroup("Demo",100,new SimpleGroupLeader("Alan",100)));
            var groupLeader = Group.AcquireGroup("Demo").GroupLeader;
            groupLeader.AddGroupMember(new GroupMember("1",1));
            groupLeader.AddGroupMember(new GroupMember("2",2));
            groupLeader.AddGroupMember(new GroupMember("3",3));
            groupLeader.AddGroupMember(new NroupMember("4",4));
            groupLeader.AddGroupMember(new GroupMember("5",5));
            groupLeader.AddGroupMember(new NroupMember("6",6));
            groupLeader.AddGroupMember(new GroupMember("7",7));
            groupLeader.AddGroupMember(new NroupMember("8",8));
            groupLeader.AddGroupMember(new GroupMember("9",9));
            groupLeader.ExecuteCommand<ISay>("6", i => i.Say("Fucking"));
            groupLeader.ExecuteCommand<ISay>(i => { i.Say("Fucking"); return false; });
            groupLeader.ExecuteChainCommand<ISay>((i,r)=> { Debug.Log( "r:"+r ); return i.Say(null==r?"Fucking":r.ToString()); });
        }
    }

    public interface ISay : Group.ICommand
    {
        string Say(string sth);
    }

    internal sealed class GroupMember : Group.IGroupMember
    {

        public GroupMember(string name,int ability)
        {
            Name = name;
            Ability = ability;
        }

        public string Name { get; private set; }

        public int Ability { get; private set; }

        public int CompareTo(Group.IGroupMember other)
        {
            return other.Ability - this.Ability;
        }
    }

    internal sealed class NroupMember : Group.IGroupMember,ISay
    {
        public NroupMember(string name, int ability)
        {
            Name = name;
            Ability = ability;
        }

        public string Name { get; private set; }

        public int Ability { get; private set; }

        public int CompareTo(Group.IGroupMember other)
        {
            return other.Ability - this.Ability;
        }

        string ISay.Say(string sth)
        {
            Debug.Log(string.Format("{0}:{1}",Name,sth));
            return sth+=string.Format("{0}:{1}", Name, sth);
        }
    }
}
