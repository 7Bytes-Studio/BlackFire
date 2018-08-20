using BlackFireFramework.DB;

namespace BlackFireFramework.Unity
{
    public interface IStorageManager:IManager
    {
        IConnection CreateConnection(string connectionAlias, string databasePath);
        IConnection AcquireConnection(string connectionAlias);
        void CloseConnection(string connectionAlias);
    }
}