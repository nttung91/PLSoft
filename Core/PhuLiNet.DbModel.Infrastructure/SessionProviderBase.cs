using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public abstract class SessionProviderBase : ISessionProvider
    {

        private readonly ISessionFactoryProvider _sessionFactoryProvider;

        protected SessionProviderBase(ISessionFactoryProvider sessionFactoryProvider)
        {
            _sessionFactoryProvider = sessionFactoryProvider;
        }

        public virtual ISession GetSession()
        {
            return
                _sessionFactoryProvider.SessionFactory.OpenSession(new VersionCheckInterceptor());

        }

        public virtual IStatelessSession GetStatelessSession()
        {
            return _sessionFactoryProvider.SessionFactory.OpenStatelessSession();
        }
    }
}
