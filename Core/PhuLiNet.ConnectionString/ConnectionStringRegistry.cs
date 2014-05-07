namespace Manor.ConnectionStrings
{
    public static class ConnectionStringRegistry
    {
        private static volatile IConnectionStringList _connectionStrings;

        public static IConnectionStringList Instance()
        {
            if (_connectionStrings == null)
            {
                _connectionStrings = new ConnectionStringList();
            }

            return _connectionStrings;
        }
    }
}