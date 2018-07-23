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
        /// 组接口。
        /// </summary>
        public interface IGroup : IComparable<IGroup>
        {
            /// <summary>
            /// 组的名字。
            /// </summary>
            string Name { get; }

            /// <summary>
            /// 小组能力值。
            /// </summary>
            int GroupAbility { get; }

            /// <summary>
            /// 小组的组员数量。
            /// </summary>
            int Count { get; }

            /// <summary>
            /// 组长。
            /// </summary>
            IGroupLeader GroupLeader { get; }
        }
    }

}
