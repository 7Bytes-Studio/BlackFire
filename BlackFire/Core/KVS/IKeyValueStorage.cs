/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    /// <summary>
    /// 键值对数据存储接口。
    /// </summary>
    public interface IKeyValueStorage
    {
        /// <summary>
        /// 是否存在键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>查询结果。</returns>
        bool HasKey(string key);

        /// <summary>
        /// 通过键获取值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>值。</returns>
        string GetValue(string key);

        /// <summary>
        /// 通过键设置值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        void SetValue(string key,string value);

        /// <summary>
        /// 移除一条键值对记录。
        /// </summary>
        /// <param name="key">键。</param>
        void Del(string key);

        /// <summary>
        /// 移除存储器所有的键值对记录。
        /// </summary>
        void DelAll();
    }
}
