using System.Collections.Generic;
using System.Configuration;

namespace Manor.ConnectionStrings.Configuration
{
    public class AppConfigDataAdapter : IDataAdapter
    {
        public IDictionary<string, IConnectionString> Load()
        {
            var result = new Dictionary<string, IConnectionString>();

            var configSection =
                (DbConfigurationSection) ConfigurationManager.GetSection("dbconfig");
            if (configSection != null)
            {
                foreach (ConnectionStringConfigurationElement connectionConfig in configSection.ConnectionStrings)
                {
                    IConnectionString c = CreateConnectionString(connectionConfig);
                    result.Add(connectionConfig.ID, c);
                }
            }

            return result;
        }

        private IConnectionString CreateConnectionString(ConnectionStringConfigurationElement connectionConfig)
        {
            var connectionString = connectionConfig.ConnectionString;
            var isCrypted = connectionConfig.Crypted;

            if (isCrypted)
            {
                var decrypter = new ConnectionStringDecrypter();
                connectionString = decrypter.Decrypt(connectionString);
            }

            var oracleConnectionString = new OracleConnectionString(connectionString);
            return oracleConnectionString;
        }

        public void Validate()
        {
            // nothing to do, validated by .NET configuration system.
        }
    }
}