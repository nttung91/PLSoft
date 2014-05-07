using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Manor.ConnectionStrings.DbTypes;

namespace Manor.ConnectionStrings
{
    internal class ConnectionStringList : IConnectionStringList
    {
        private readonly Dictionary<string, ConnectionStringEntry> _connectionStrings;

        public ConnectionStringList()
        {
            _connectionStrings = new Dictionary<string, ConnectionStringEntry>();
        }

        public void Add(EDbType dbType, IConnectionString connectionString)
        {
            Add(connectionString, dbType, false);
        }

        private void Add(IConnectionString connectionString, EDbType dbType, bool defaultDatabase)
        {
            Debug.Assert(connectionString != null, "connectionString is null");
            Debug.Assert(!_connectionStrings.ContainsKey(dbType.ToString()),
                string.Format("Connection string for [{0}] exists already", dbType.ToString()));

            _connectionStrings.Add(dbType.ToString(), new ConnectionStringEntry(connectionString, defaultDatabase));
        }

        public IConnectionString Get(EDbType dbType)
        {
            if (_connectionStrings.ContainsKey(dbType.ToString()))
            {
                return _connectionStrings[dbType.ToString()].ConnectionString;
            }

            throw new ConnectionStringRegistryException(
                string.Format("ConnectionString for database type [{0}] not found", dbType.ToString()));
        }

        public void SetOracleUserId()
        {
            var changer = new OracleUserIdChanger();
            foreach (var connectionString in _connectionStrings)
            {
                changer.SetCurrentUser(connectionString.Value.ConnectionString);
            }
        }

        public bool HasDbType(EDbType dbType)
        {
            return _connectionStrings.ContainsKey(dbType.ToString());
        }

        public void Clear()
        {
            _connectionStrings.Clear();
        }

        public bool IsEmpty
        {
            get { return _connectionStrings.Count == 0; }
        }

        public override string ToString()
        {
            var connectionInfoString = new StringBuilder();

            foreach (var connectionStringEntry in _connectionStrings)
            {
                if (connectionStringEntry.Value.ConnectionString is OracleConnectionString)
                {
                    if (connectionInfoString.Length > 0) connectionInfoString.Append(", ");
                    var dataSource = ((OracleConnectionString) connectionStringEntry.Value.ConnectionString).DataSource;
                    connectionInfoString.Append(dataSource.ToUpper());
                }
            }

            return connectionInfoString.ToString();
        }
    }
}