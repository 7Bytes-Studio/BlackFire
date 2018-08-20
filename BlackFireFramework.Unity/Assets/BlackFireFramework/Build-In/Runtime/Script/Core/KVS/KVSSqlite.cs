//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
using System.Collections;
using BlackFireFramework.DB;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public class KVSSqlite : IKeyValueStorage
    {

        private SQLiteConnection _connection;

        private IEnumerable<KV> m_KVTable = null;

        public virtual string DatabaseName { get { return "kvs.db"; } }



        public KVSSqlite()
        {

#if UNITY_EDITOR
                var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            try
            {
                _connection.Query<KV>("SELECT Id FROM KV");
            }
            catch (System.Exception ex)
            {
                _connection.CreateTable<KV>();
            }
            
        }


        public void Del(string key)
        {
            _connection.Execute(string.Format("DELETE FROM KV WHERE Key=?",key));
        }

        public void DelAll()
        {
            _connection.DeleteAll<KV>();
        }

        public string GetValue(string key)
        {
            var rows = _connection.Query<KV>("SELECT * FROM KV WHERE Key=?",key);
            if (0 < rows.Count)
            {
                return rows[0].Value;
            }
            return string.Empty;
        }

        public bool HasKey(string key)
        {
            var rows = _connection.Query<KV>(string.Format("SELECT * FROM KV WHERE Key = ?"), key);
            return 0<rows.Count;
        }

        public void SetValue(string key, string value)
        {
            var row = CheckOrInsertRow(key);
            row.Value = value;
            _connection.Update(row);
        }




        private KV CheckOrInsertRow(string key)
        {
            var rows = _connection.Query<KV>(string.Format("SELECT * FROM KV WHERE Key = ?"), key);
            if (0 == rows.Count)
            {
                var row = new KV() { Key = key };
                _connection.Insert(row);
                return row;
            }
            return rows[0];
        }










        public sealed class KV
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [Unique]
            public string Key { get; set; }
            public string Value { get; set; }
        }

    }





}
