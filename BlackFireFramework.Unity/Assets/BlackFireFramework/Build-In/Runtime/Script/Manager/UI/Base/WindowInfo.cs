//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework.Unity
{
    public sealed class WindowInfo
    {
        public long Id { get; internal set; }
        public long GroupId { get; internal set; }

        public override string ToString()
        {
            return string.Format("Id : {0}\n GroupId : {1}\n", Id, GroupId);
        }
    }
}
