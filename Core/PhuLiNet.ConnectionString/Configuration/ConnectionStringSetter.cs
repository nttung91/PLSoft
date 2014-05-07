using System;
using System.Collections.Generic;
using System.Diagnostics;
using Manor.ConnectionStrings.DbTypes;

namespace Manor.ConnectionStrings.Configuration
{
    public class ConnectionStringSetter
    {
        private readonly IDictionary<string, IConnectionString> _connectionStringsLoaded =
            new Dictionary<string, IConnectionString>();

        private ConnectionStringSetter()
        {
            try
            {
                var loader = new ConnectionStringLoader();
                _connectionStringsLoaded = loader.Load();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("failed to load connection strings: " + ex);
            }
        }

        internal void SetConnectionString(EDbType dbType, string dataSource, string user, string password)
        {
            if (!ConnectionStringRegistry.Instance().HasDbType(dbType))
            {
                IConnectionString oraConnect;
                if (_connectionStringsLoaded.ContainsKey(dataSource))
                {
                    oraConnect = _connectionStringsLoaded[dataSource];
                }
                else
                {
                    oraConnect = new OracleConnectionString(dataSource, user, password) {ConnectionPooling = true};
                }
                ConnectionStringRegistry.Instance().Add(dbType, oraConnect);
            }
        }

        private const string TestUser = "itest_user";
        private const string TestUserPwd = "plsqlt2st";

        public static void SetPkopieTesting()
        {
            new ConnectionStringSetter().SetConnectionString(EDbType.Wws, "pkopie", TestUser, TestUserPwd);
        }

        public static void SetHautesTesting()
        {
            new ConnectionStringSetter().SetConnectionString(EDbType.WwHaus, "hautes", TestUser, TestUserPwd);
        }

        public static void SetMainDbTesting()
        {
            new ConnectionStringSetter().SetConnectionString(EDbType.MainDb, "maites", TestUser, TestUserPwd);
        }
    }
}