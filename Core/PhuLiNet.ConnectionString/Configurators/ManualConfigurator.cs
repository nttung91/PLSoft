using System.Diagnostics;
using System.Security.Principal;
using Manor.ConnectionStrings.Configuration;
using Manor.ConnectionStrings.DbTypes;
using Manor.Utilities.Extensions;

namespace Manor.ConnectionStrings.Configurators
{
    public class ManualConfigurator : IConnectionStringConfigurator
    {
        private readonly string _dataSource;
        private readonly string _user;
        private readonly string _password;

        public EDbType DbType { get; set; }

        public ManualConfigurator(string dataSource, string user, string password)
        {
            _dataSource = dataSource;
            _user = user;
            _password = password;

            DbType = EDbType.Unkown;
        }

        public void Configure()
        {
            bool connectionStringFromCmdLineExists = false;
            bool connectionStringFromXmlFileExists = false;

            if (!string.IsNullOrEmpty(_user) &&
                !string.IsNullOrEmpty(_password))
            {
                connectionStringFromCmdLineExists = true;
            }

            var loader = new ConnectionStringLoader();
            var connectionStrings = loader.Load();
            if (connectionStrings != null &&
                connectionStrings.Count > 0)
            {
                connectionStringFromXmlFileExists = true;
            }

            OracleConnectionString connectString;

            if (connectionStringFromCmdLineExists)
            {
                connectString = new OracleConnectionString(_dataSource, _user, _password);
            }
            else if (connectionStringFromXmlFileExists)
            {
                connectString = connectionStrings[_dataSource] as OracleConnectionString;

                Debug.Assert(connectString != null, "connectString != null");
                if (connectString.HasProxyUserAndPassword)
                {
                    connectString.User = WindowsIdentity.GetCurrent().NameWithoutDomain();
                    connectString.Password = null;
                }
                Debug.Assert(connectString != null, "ConnectionString not of type OracleConnectionString?");
            }
            else
            {
                throw new ConnectionStringRegistryException(
                    "No Database ConnectionString configuration found. Please use command-line or xml-config.");
            }

            if (DbType == EDbType.Unkown && DbMode == EDatabaseMode.Unkown)
            {
                var databaseTypesLoader = new DatabaseTypesLoader();
                var dbTypes = databaseTypesLoader.Load();
                DbType = dbTypes.GetDbType(_dataSource);
                DbMode = dbTypes.GetDbMode(_dataSource);
            }

            if (DbType == EDbType.Unkown)
                throw new ConnectionStringRegistryException(string.Format("Unkown database type [{0}]", _dataSource));
            if (DbMode == EDatabaseMode.Unkown)
                throw new ConnectionStringRegistryException(string.Format("Unkown database mode [{0}]", _dataSource));

            connectString.ConnectionPooling = true;
            ConnectionStringRegistry.Instance().DatabaseMode = DbMode;
            ConnectionStringRegistry.Instance().Add(DbType, connectString);
        }
    }
}