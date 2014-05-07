using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Manor.ConnectionStrings
{
    public class OracleConnectionString : IConnectionString
    {
        internal const string ParameterDataSource = "Data Source";
        internal const string ParameterUserId = "User Id";
        internal const string ParameterPassword = "Password";
        internal const string ParameterConnectionTimeout = "Connection Timeout";
        internal const string ParameterEnlist = "Enlist";
        internal const string ParameterPooling = "Pooling";
        internal const string ParameterMinPoolSize = "Min Pool Size";
        internal const string ParameterMaxPoolSize = "Max Pool Size";
        internal const string ParameterIncrPoolSize = "Incr Pool Size";
        internal const string ParameterDecrPoolSize = "Decr Pool Size";
        internal const string ParameterProxyUserId = "Proxy User Id";
        internal const string ParameterProxyPassword = "Proxy Password";

        private Dictionary<string, string> _connectionParameters;

        public OracleConnectionString()
        {
            InitParameters();
        }

        public OracleConnectionString(string connectionString)
        {
            InitParameters();
            var parser = new OracleConnectionStringParser(connectionString);
            parser.Parse();

            DataSource = parser.DataSource;
            if (parser.HasUser) User = parser.User;
            if (parser.HasPassword) Password = parser.Password;
            if (parser.HasConnectionTimeout) ConnectionTimeout = parser.ConnectionTimeout;
            if (parser.HasEnlist) Enlist = parser.Enlist;
            if (parser.HasPooling) ConnectionPooling = parser.Pooling;
            if (parser.HasProxyUser) ProxyUser = parser.ProxyUser;
            if (parser.HasProxyPassword) ProxyPassword = parser.ProxyPassword;
            if (parser.HasMinPoolSize) MinPoolSize = parser.MinPoolSize;
            if (parser.HasMaxPoolSize) MaxPoolSize = parser.MaxPoolSize;
            if (parser.HasIncrPoolSize) IncrPoolSize = parser.IncrPoolSize;
            if (parser.HasDecrPoolSize) DecrPoolSize = parser.DecrPoolSize;
        }

        public OracleConnectionString(string dataSource, string user, string password)
            : this(dataSource, user, password, false)
        {
        }

        public OracleConnectionString(string dataSource, string user, string password, bool connectionPooling)
        {
            InitParameters();

            DataSource = dataSource;
            User = user;
            Password = password;
            ConnectionPooling = connectionPooling;
        }

        private void InitParameters()
        {
            _connectionParameters = new Dictionary<string, string>();
            _connectionParameters.Add(ParameterDataSource, null);
            _connectionParameters.Add(ParameterUserId, null);
            _connectionParameters.Add(ParameterPassword, null);
            _connectionParameters.Add(ParameterProxyUserId, null);
            _connectionParameters.Add(ParameterProxyPassword, null);
            _connectionParameters.Add(ParameterConnectionTimeout, "720");
            _connectionParameters.Add(ParameterEnlist, "true");
            _connectionParameters.Add(ParameterPooling, "false");
            _connectionParameters.Add(ParameterMinPoolSize, "1");
            _connectionParameters.Add(ParameterMaxPoolSize, "3");
            _connectionParameters.Add(ParameterIncrPoolSize, "1");
            _connectionParameters.Add(ParameterDecrPoolSize, "1");
        }

        public string DataSource
        {
            get { return _connectionParameters[ParameterDataSource]; }
            set { _connectionParameters[ParameterDataSource] = value; }
        }

        public string User
        {
            get { return _connectionParameters[ParameterUserId]; }
            set { _connectionParameters[ParameterUserId] = value; }
        }

        public string Password
        {
            get { return _connectionParameters[ParameterPassword]; }
            set { _connectionParameters[ParameterPassword] = value; }
        }

        public bool HasUser
        {
            get { return !string.IsNullOrEmpty(User); }
        }

        public string ProxyUser
        {
            get { return _connectionParameters[ParameterProxyUserId]; }
            set { _connectionParameters[ParameterProxyUserId] = value; }
        }

        public string ProxyPassword
        {
            get { return _connectionParameters[ParameterProxyPassword]; }
            set
            {
                _connectionParameters[ParameterProxyPassword] = value;
                Password = null;
            }
        }

        public bool HasProxyUserAndPassword
        {
            get { return !string.IsNullOrEmpty(ProxyUser) && !string.IsNullOrEmpty(ProxyPassword); }
        }

        public bool ConnectionPooling
        {
            get { return Convert.ToBoolean(_connectionParameters[ParameterPooling]); }
            set { _connectionParameters[ParameterPooling] = value.ToString(CultureInfo.InvariantCulture).ToLower(); }
        }

        public bool Enlist
        {
            get { return Convert.ToBoolean(_connectionParameters[ParameterEnlist]); }
            set { _connectionParameters[ParameterEnlist] = value.ToString(CultureInfo.InvariantCulture).ToLower(); }
        }

        public int ConnectionTimeout
        {
            get { return Convert.ToInt32(_connectionParameters[ParameterConnectionTimeout]); }
            set { _connectionParameters[ParameterConnectionTimeout] = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int MinPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[ParameterMinPoolSize]); }
            set { _connectionParameters[ParameterMinPoolSize] = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int MaxPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[ParameterMaxPoolSize]); }
            set { _connectionParameters[ParameterMaxPoolSize] = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int DecrPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[ParameterDecrPoolSize]); }
            set { _connectionParameters[ParameterDecrPoolSize] = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int IncrPoolSize
        {
            get { return Convert.ToInt32(_connectionParameters[ParameterIncrPoolSize]); }
            set { _connectionParameters[ParameterIncrPoolSize] = value.ToString(CultureInfo.InvariantCulture); }
        }

        #region IConnectionString Members

        public string ConnectionString
        {
            get
            {
                var connectionString = string.Empty;

                foreach (var parameter in _connectionParameters)
                {
                    if (!ConnectionPooling &&
                        (parameter.Key == ParameterMinPoolSize ||
                         parameter.Key == ParameterMaxPoolSize ||
                         parameter.Key == ParameterIncrPoolSize ||
                         parameter.Key == ParameterDecrPoolSize))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(parameter.Value))
                    {
                        connectionString += parameter.Key + "=" + parameter.Value + ";";
                    }
                }

                return connectionString;
            }
            set { Debug.Assert(false, "ConnectionString cannot be set"); }
        }

        #endregion
    }
}