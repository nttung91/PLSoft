using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Manor.ConnectionStrings
{
    public class OracleConnectionStringParser
    {
        private readonly string _connectionString;
        private Dictionary<string, string> _connectionParameters;

        public Dictionary<string, string> Parameters
        {
            get { return _connectionParameters; }
        }

        public string DataSource
        {
            get { return _connectionParameters[OracleConnectionString.ParameterDataSource]; }
        }

        public string User
        {
            get { return _connectionParameters[OracleConnectionString.ParameterUserId]; }
        }

        public bool HasUser
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterUserId); }
        }

        public string Password
        {
            get { return _connectionParameters[OracleConnectionString.ParameterPassword]; }
        }

        public bool HasPassword
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterPassword); }
        }

        public int ConnectionTimeout
        {
            get { return Convert.ToInt32(_connectionParameters[OracleConnectionString.ParameterConnectionTimeout]); }
        }

        public bool HasConnectionTimeout
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterConnectionTimeout); }
        }

        public bool Enlist
        {
            get { return Convert.ToBoolean(_connectionParameters[OracleConnectionString.ParameterEnlist]); }
        }

        public bool HasEnlist
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterEnlist); }
        }

        public bool Pooling
        {
            get { return Convert.ToBoolean(_connectionParameters[OracleConnectionString.ParameterPooling]); }
        }

        public bool HasPooling
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterPooling); }
        }

        public string ProxyUser
        {
            get { return _connectionParameters[OracleConnectionString.ParameterProxyUserId]; }
        }

        public bool HasProxyUser
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterProxyUserId); }
        }

        public string ProxyPassword
        {
            get { return _connectionParameters[OracleConnectionString.ParameterProxyPassword]; }
        }

        public bool HasProxyPassword
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterProxyPassword); }
        }

        public int MinPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[OracleConnectionString.ParameterMinPoolSize]); }
        }

        public bool HasMinPoolSize
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterMinPoolSize); }
        }

        public int MaxPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[OracleConnectionString.ParameterMaxPoolSize]); }
        }

        public bool HasMaxPoolSize
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterMaxPoolSize); }
        }

        public int IncrPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[OracleConnectionString.ParameterIncrPoolSize]); }
        }

        public bool HasIncrPoolSize
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterIncrPoolSize); }
        }

        public int DecrPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[OracleConnectionString.ParameterDecrPoolSize]); }
        }

        public bool HasDecrPoolSize
        {
            get { return _connectionParameters.ContainsKey(OracleConnectionString.ParameterDecrPoolSize); }
        }

        public OracleConnectionStringParser(string connectionString)
        {
            _connectionString = connectionString;
            _connectionParameters = new Dictionary<string, string>();
        }

        public bool IsValidConnectionString()
        {
            return Regex.IsMatch(_connectionString, @"^([^=;]+=[^;]*)(;[^=;]+=[^;]*)*;?$");
        }

        public void Parse()
        {
            var regex = new Regex("([^=;]*)=([^;]*)");
            var matchCollection = regex.Matches(_connectionString);

            foreach (Match match in matchCollection)
            {
                string key = match.Groups[1].Value;
                string keyValue = match.Groups[2].Value;

                _connectionParameters.Add(key, keyValue);
            }
        }
    }
}