//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using BlackFireFramework.DB;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class StorageManager
    {
        
        public sealed class DefaultSqliteConnection : IConnection
        {
          
            public DefaultSqliteConnection(string alias, SQLiteConnection sqliteConnection)
            {
                Alias = alias;
                SQLiteConnection = sqliteConnection;
            }
        
          
            public void Close()
            {
                SQLiteConnection.Close();
            }

            public int Execute(string sql, params object[] args)
            {
                return SQLiteConnection.Execute(sql, args);
            }


            public List<T> Query<T>(string sql, params object[] args) where T : new()
            {
                return SQLiteConnection.Query<T>(sql, args);
            }


            public string Alias { get; private set; }
        

            public SQLiteConnection SQLiteConnection { get; private set; }
        
    
            public void CreateTable<T>()
            {
                SQLiteConnection.DropTable<T>(); // 清除原来的数据表
                SQLiteConnection.CreateTable<T>(); //创建新表
            }
        
         
            public bool CheckOrCreateTable<T>() where T : new()
            {
                var list = SQLiteConnection.GetTableInfo(typeof(T).Name);
                if (0 == list.Count)
                {
                    SQLiteConnection.CreateTable<T>(); //创建新表
                    //Log.Info("创建新表:" + typeof(T).Name);
                    return true;
                }
                return false;
            }
        
           
            public void Insert(IEnumerable objects) 
            {
                SQLiteConnection.InsertAll(objects);
            }
        
            
            public void Insert<T>(T t) 
            {
                SQLiteConnection.Insert(t);
            }
        
          
            public IEnumerable<T> Query<T>() where T : new() 
            {
                return SQLiteConnection.Table<T>();
            }
        
            
            public T Query<T>(Func<T, bool> handler) where T : new() 
            {
                if (null == handler) throw new Exception("查询委托不能为空！");
                return SQLiteConnection.Table<T>().Where(x => handler(x)).FirstOrDefault();
            }
        
           
            public void Delete<T>(object t) 
            {
                SQLiteConnection.Delete<T>(t);
            }
        
            
            public void Update<T>(T t) 
            {
                SQLiteConnection.Update(t);
            }
        

            public void UpdateAll(IEnumerable objects) 
            {
                SQLiteConnection.UpdateAll(objects);
            }
        }
    }
}