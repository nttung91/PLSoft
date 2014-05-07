using System;
using System.Diagnostics;
using Manor.ConnectionStrings.Configuration;
using Manor.ConnectionStrings.DbTypes;

namespace Manor.ConnectionStrings.Configurators
{
    public class DatabaseModeConfigurator : IConnectionStringConfigurator
    {
        public void Configure()
        {
            //var connectionStringLoader = new ConnectionStringLoader();
            //var connectionStrings = connectionStringLoader.Load();

            //var databaseTypesLoader = new DatabaseTypesLoader();
            //var dbTypes = databaseTypesLoader.Load();

            //foreach (var dbType in dbTypes)
            //{
            //    foreach (var database in dbType.Databases)
            //    {
            //        if (database.DbMode == _databaseMode)
            //        {
            //            if (connectionStrings.ContainsKey(database.Id))
            //            {
            //                ConnectionStringRegistry.Instance().Add(dbType.DbType, connectionStrings[database.Id]);
            //            }
            //            else
            //            {
            //                Debug.Fail(string.Format("ConnectionString missing with Id [{0}]", database.Id));
            //            }
            //        }
            //    }
            //}

            //ConnectionStringRegistry.Instance().DatabaseMode = _databaseMode;
            ////set oracle user-id when proxy authentication is active
            //ConnectionStringRegistry.Instance().SetOracleUserId();
        }
    }
}