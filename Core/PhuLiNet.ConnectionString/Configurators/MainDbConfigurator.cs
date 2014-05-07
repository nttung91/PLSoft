using Manor.ConnectionStrings.Configuration;
using Manor.ConnectionStrings.DbTypes;

namespace Manor.ConnectionStrings.Configurators
{
    public class MainDbConfigurator : IConnectionStringConfigurator
    {
        public void Configure()
        {
            var dbMode = ConnectionStringRegistry.Instance().DatabaseMode;

            if (dbMode != EDatabaseMode.Unkown)
            {
                var databaseTypesLoader = new DatabaseTypesLoader();
                var dbTypes = databaseTypesLoader.Load();

                string databaseId = dbTypes.GetDatabaseId(EDbType.MainDb, dbMode);

                if (databaseId != null)
                {
                    var connectionStringLoader = new ConnectionStringLoader();
                    var connectionStrings = connectionStringLoader.Load();

                    ConnectionStringRegistry.Instance().Add(EDbType.MainDb, connectionStrings[databaseId]);
                }
            }
        }
    }
}