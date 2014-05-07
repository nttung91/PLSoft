using System.Diagnostics;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public class SessionFactoryProvider : ISessionFactoryProvider
    {
        private readonly IConfigurationProvider _configurationProvider;
        private ISessionFactory _sessionFactory;
        private readonly object _lock = new object();

        public SessionFactoryProvider(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                lock (_lock)
                {
                    if (_sessionFactory == null)
                    {
                        Debug.Assert(_configurationProvider != null, "ConfigurationProvider is null");
                        _sessionFactory = _configurationProvider.BuildSessionFactory();
                    }
                }
                return _sessionFactory;
            }
        }
    }
}