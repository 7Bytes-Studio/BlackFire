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
        /// 关闭连接。
        /// </summary>
        void Close();


        /// <summary>
        /// 执行数据库命令。
        /// </summary>
        /// <param name="cmd">数据库命令。</param>
        /// <returns>影响行数。</returns>
        int Execute(string sql, params object[] args);
        
                
        #region 增
        
        /// <summary>
        /// 新创建表。
        /// </summary>
        /// <typeparam name="T">ORM类类型。</typeparam>
        void CreateTable<T>();
        
        /// <summary>
        /// 检查是否存在或者创建新表。
        /// </summary>
        /// <typeparam name="T">ORM类类型。</typeparam>
        bool CheckOrCreateTable<T>() where T : new();
        
        /// <summary>
        /// 插入多个记录（可以是不同ORM类的实例）。
        /// </summary>
        /// <param name="rows">ORM类的实例集合。</param>
        void Insert(IEnumerable rows); 

        /// <summary>
        /// 插入一条记录。
        /// </summary>
        /// <param name="row">ORM类实例。</param>
        /// <typeparam name="T">ORM类类型。</typeparam>
        void Insert<T>(T row);
        
        #endregion
        
        
        
        #region 删

        /// <summary>
        /// 删除表的一条记录。
        /// </summary>
        /// <param name="primaryKey">主键。</param>
        /// <typeparam name="T">ORM类类型。</typeparam>
        void Delete<T>(object primaryKey); 
        
        
        #endregion
        
        
        
        #region 改

        /// <summary>
        /// 更新表的一条记录。
        /// </summary>
        /// <param name="row">ORM类实例。</param>
        /// <typeparam name="T">ORM类类型。</typeparam>
        void Update<T>(T row); 

        /// <summary>
        /// 更新所有表的记录（可以是不同ORM类的实例）。
        /// </summary>
        /// <param name="rows">ORM类的实例集合。</param>
        void UpdateAll(IEnumerable rows); 

        #endregion
        
        
        
        #region 查
        
        /// <summary>
        /// 获取表里面的所有行。
        /// </summary>
        /// <typeparam name="T">ORM类类型。</typeparam>
        /// <returns>ORM类记录集合。</returns>
        IEnumerable<T> Query<T>() where T : new(); 

        /// <summary>
        /// 查询表的某一行。
        /// </summary>
        /// <param name="handler">查询条件回调。</param>
        /// <typeparam name="T">ORM类类型。</typeparam>
        /// <returns>ORM类记录。</returns>
        T Query<T>(Func<T, bool> handler) where T : new();


        /// <summary>
        /// 执行Sql语句查询表（ex："select * from User where Account = ?" ）。
        /// </summary>
        /// <param name="sql">Sql查询语句。</param>
        /// <param name="args">?替换参数。</param>
        /// <typeparam name="T">ORM类类型。</typeparam>
        /// <returns>查询ORM类实例集合。</returns>
        List<T> Query<T>(string sql, params object[] args) where T : new();

        #endregion


    }
}