//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BlackFireFramework.DB
{
    /// <summary>
    /// 数据库连接服务类（连接隔离类）
    /// </summary>
    public sealed class Connection : IConnection
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="sqliteConnection">SQLite连接类</param>
        public Connection(string alias, SQLiteConnection sqliteConnection)
        {
            Alias = alias;
            SQLiteConnection = sqliteConnection;
        }
        
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// SQLite数据库连接类
        /// </summary>
        public SQLiteConnection SQLiteConnection { get; private set; }

        /// <summary>
        /// 新创建表
        /// </summary>
        public void CreateTable<T>()
        {
            SQLiteConnection.DropTable<T>(); // 清除原来的数据表
            SQLiteConnection.CreateTable<T>(); //创建新表
        }

        /// <summary>
        /// 检查是否存在或者创建新表。
        /// </summary>
        public void CheckOrCreateTable<T>() where T : new()
        {
            var list = SQLiteConnection.GetTableInfo(typeof(T).Name);
            if (0 == list.Count)
            {
                SQLiteConnection.CreateTable<T>(); //创建新表
                //Log.Info("创建新表:" + typeof(T).Name);
            }
        }


        /// <summary>
        /// 插入多个记录，可以是不同表的row
        /// </summary>
        public void Insert(IEnumerable objects) //插入多个记录，可以是不同表的row
        {
            SQLiteConnection.InsertAll(objects);
        }

        /// <summary>
        /// 插入一个 
        /// </summary>
        public void Insert<T>(T t) //插入一个
        {
            SQLiteConnection.Insert(t);
        }

        /// <summary>
        /// 获取表里面的所有行 
        /// </summary>
        public IEnumerable<T> Query<T>() where T : new() //获取表里面的所有行
        {
            return SQLiteConnection.Table<T>();
        }

        /// <summary>
        /// 查询表的某一行 
        /// </summary>
        public T Query<T>(Func<T, bool> handler) where T : new() //查询表的某一行
        {
            if (null == handler) throw new Exception("查询委托不能为空！");
            return SQLiteConnection.Table<T>().Where(x => handler(x)).FirstOrDefault();
        }

        /// <summary>
        /// 删除T表的一条row记录，t实例里面的主键要对应
        /// </summary>
        public void Delete<T>(object t) //删除T表的一条row记录，t实例里面的主键要对应
        {
            SQLiteConnection.Delete<T>(t);
        }

        /// <summary>
        /// 更新T表的一条row记录，t实例里面的主键要对应 
        /// </summary>
        public void Update<T>(T t) //更新T表的一条row记录，t实例里面的主键要对应
        {
            SQLiteConnection.Update(t);
        }

        /// <summary>
        /// 更新记录，可以是不同表的不同row
        /// </summary>
        public void UpdateAll(IEnumerable objects) //更新记录，可以是不同表的不同row
        {
            SQLiteConnection.UpdateAll(objects);
        }
    }
}
