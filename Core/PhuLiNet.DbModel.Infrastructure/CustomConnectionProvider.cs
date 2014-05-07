//using Manor.ConnectionStrings;
//using Manor.ConnectionStrings.DbTypes;
using System.Collections.Generic;
using NHibernate.Connection;
using Environment = NHibernate.Cfg.Environment;

namespace Core.DbModel.Infrastructure
{
    public class CustomConnectionProvider : DriverConnectionProvider
    {
        protected override string GetNamedConnectionString(IDictionary<string, string> settings)
        {
            string connectionName = settings[Environment.ConnectionStringName];
            //var dbType = (EDbType)Enum.Parse(typeof(EDbType), connectionName);
            //return ConnectionStringRegistry.Instance().Get(dbType).ConnectionString;
            return @"Data Source=.\SQLSERVER;Initial Catalog=PLDB;Integrated Security=True";
        }
    }
}
