//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.DB
{
    /// <summary>
    /// Sqlite模块接口。
    /// </summary>
    public interface ISqliteModule:IModule
    {
        /// <summary>
        /// Sqlite的连接器工厂。
        /// </summary>
        Func<string,string,IConnection> ConnectionFactory { get; set; }

        /// <summary>
        /// 连接或创建数据库并返回数据服务。
        /// </summary>
        /// <param name="databaseName">数据库相对于StreamingAssets的路径。</param>
        /// <returns>Connection</returns>
        IConnection CreateConnection(string connectionAlias, string databasePath);

        /// <summary>
        /// 获取数据库连接服务类。
        /// </summary>
        /// <param name="connectionAlias">服务别名。</param>
        /// <returns>数据库连接服务类实例。</returns>
        IConnection AcquireConnection(string connectionAlias);

        /// <summary>
        /// 关闭服务。
        /// </summary>
        /// <param name="connectionAlias">服务别名。</param>
        void CloseConnection(string connectionAlias);
    }
}