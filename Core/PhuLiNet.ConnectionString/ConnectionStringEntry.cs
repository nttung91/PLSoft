namespace Manor.ConnectionStrings
{
    internal class ConnectionStringEntry
    {
        private IConnectionString _connectionString;
        private readonly bool _default;

        public IConnectionString ConnectionString
        {
            get { return _connectionString; }
        }

        public bool Default
        {
            get { return _default; }
        }

        public ConnectionStringEntry(IConnectionString connectionString, bool defaultConnectionString)
        {
            _connectionString = connectionString;
            _default = defaultConnectionString;
        }
    }
}