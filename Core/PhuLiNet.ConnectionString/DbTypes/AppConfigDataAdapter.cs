using System;
using System.Configuration;
using Manor.ConnectionStrings.Configuration;

namespace Manor.ConnectionStrings.DbTypes
{
    public class AppConfigDataAdapter : IDataAdapter
    {
        public DatabaseTypeList Load()
        {
            var result = new DatabaseTypeList();

            var configSection =
                (DbConfigurationSection) ConfigurationManager.GetSection("dbconfig");
            if (configSection != null)
            {
                foreach (DatabaseTypeConfigurationElement dbTypeConfig in configSection.DatabaseTypes)
                {
                    var item = CreateDatabaseType(dbTypeConfig);
                    result.Add(item);
                }
            }

            return result;
        }

        private DatabaseType CreateDatabaseType(DatabaseTypeConfigurationElement dbTypeConfig)
        {
            var dbType = new DatabaseType {DbType = (EDbType) Enum.Parse(typeof (EDbType), dbTypeConfig.Type)};

            foreach (DatabaseConfigurationElement dbConfig in dbTypeConfig.Databases)
            {
                var db = new Database
                {
                    Id = dbConfig.ID,
                    DbMode = (EDatabaseMode) Enum.Parse(typeof (EDatabaseMode), dbConfig.Mode)
                };
                dbType.Databases.Add(db);
            }
            return dbType;
        }

        public void Validate()
        {
            // nothing to do, validated by .NET configuration system.
        }
    }
}