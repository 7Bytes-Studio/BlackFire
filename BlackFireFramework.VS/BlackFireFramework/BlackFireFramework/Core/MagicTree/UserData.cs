//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework
{
    /// <summary>
    /// 用户数据。
    /// </summary>
    public class UserData
    {
        public UserData()
        {
            InstantiatedTime = DateTime.Now;
        }

        public UserData(object meta):this()
        {
            Meta=meta;
        }

        public UserData(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// 名字。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 出生日期。
        /// </summary>
        public DateTime InstantiatedTime { get; private set; }

        /// <summary>
        /// 附加信息。
        /// </summary>
        public object Meta { get; private set; }

        public override string ToString()
        {
            return string.Format("Name:{0}\nMeta:{1}\n实例化日期:{2}\n ", Name,Meta, InstantiatedTime);
        }
    }

}
