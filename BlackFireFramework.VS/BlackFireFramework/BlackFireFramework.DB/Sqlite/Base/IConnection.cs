using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackFireFramework.DB
{
    /// <summary>
    /// 连接接口类。
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// 别名。
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// 新创建表。
        /// </summary>
        void CreateTable<T>();

        /// <summary>
        /// 检查是否存在或者创建新表。
        /// </summary>
        void CheckOrCreateTable<T>() where T : new();

        /// <summary>
        /// 插入多个记录，可以是不同表的row。
        /// </summary>
        void Insert(IEnumerable objects); //插入多个记录，可以是不同表的row

        /// <summary>
        /// 插入一个 。
        /// </summary>
        void Insert<T>(T t); //插入一个

        /// <summary>
        /// 获取表里面的所有行 。
        /// </summary>
        IEnumerable<T> Query<T>() where T : new(); //获取表里面的所有行。

        /// <summary>
        /// 查询表的某一行 。
        /// </summary>
        T Query<T>(Func<T, bool> handler) where T : new(); //查询表的某一行。

        /// <summary>
        /// 删除T表的一条row记录，t实例里面的主键要对应。
        /// </summary>
        void Delete<T>(object t); //删除T表的一条row记录，t实例里面的主键要对应。

        /// <summary>
        /// 更新T表的一条row记录，t实例里面的主键要对应。
        /// </summary>
        void Update<T>(T t); //更新T表的一条row记录，t实例里面的主键要对应。

        /// <summary>
        /// 更新记录，可以是不同表的不同row。
        /// </summary>
        void UpdateAll(IEnumerable objects); //更新记录，可以是不同表的不同row。
    }
}