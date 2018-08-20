//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.DB;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed partial class StorageManager
    {
        public IConnection CreateConnection(string connectionAlias, string databasePath)
        {
            return m_SqliteModule.CreateConnection(connectionAlias, databasePath);
        }

        public IConnection AcquireConnection(string connectionAlias)
        {
            return m_SqliteModule.AcquireConnection(connectionAlias);
        }

        public void CloseConnection(string connectionAlias)
        {
            m_SqliteModule.CloseConnection(connectionAlias);
        }
    }
}