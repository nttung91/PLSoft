using System.Collections.Generic;

namespace Manor.ConnectionStrings.Configuration
{
    public class ConnectionStringLoader
    {
        private readonly IDataAdapter _dataAdapter;

        public ConnectionStringLoader(IDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public ConnectionStringLoader()
            : this(new AppConfigDataAdapter())
        {
        }

        public IDictionary<string, IConnectionString> Load()
        {
            _dataAdapter.Validate();
            return _dataAdapter.Load();
        }
    }
}