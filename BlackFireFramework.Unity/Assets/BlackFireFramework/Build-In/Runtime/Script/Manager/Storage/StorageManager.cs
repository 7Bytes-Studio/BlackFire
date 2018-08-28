//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.DB;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 存储管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Storage")]
    public sealed partial class StorageManager : ManagerBase, IStorageManager
    {
        private ISqliteModule m_SqliteModule = null;

        protected override void OnStart()
        {
            base.OnStart();
            InitModules();
        }

        private void InitModules()
        {
            RegisterModule<ISqliteModule>();
            m_SqliteModule = GetModule<ISqliteModule>();
            m_SqliteModule.ConnectionFactory = (alias, path) => new DefaultSqliteConnection(alias,new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create));
        }
    }
}