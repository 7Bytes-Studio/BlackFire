//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{
    public sealed class WindowInfo
    {
        public WindowInfo(long id, string name, long groupId,int gmWeight=0)
        {
            Id = id;
            Name = name;
            GroupId = groupId;
            GroupMemberWeight = gmWeight;
        }

        public long Id { get; internal set; }
        public string Name{ get; internal set; }
        public long GroupId { get; internal set; }
        public int GroupMemberWeight { get; internal set; }

        public override string ToString()
        {
            return string.Format("Id : {0}\nName : {1}\nGroupId : {2}\n", Id,Name,GroupId);
        }
    }
}
