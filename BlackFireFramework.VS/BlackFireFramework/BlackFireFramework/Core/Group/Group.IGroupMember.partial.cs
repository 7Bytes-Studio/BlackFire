//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    public static partial class Group
    {
        /// <summary>
        /// 组员接口。
        /// </summary>
        public interface IGroupMember:IComparable<IGroupMember>
        {
            /// <summary>
            /// 小组的名字。
            /// </summary>
            string Name { get; }

            /// <summary>
            /// 能力值。
            /// </summary>
            int Ability { get; }
        }
    }

}
