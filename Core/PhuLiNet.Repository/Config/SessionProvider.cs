using Core.DbModel.Infrastructure;

namespace PhuLiNet.Repository.Config
{
    internal class SessionProvider : SessionProviderBase
    {
        public SessionProvider()
            : base(new SessionFactoryProvider(
                        new MainDbConfigProvider()))
        {
        }

        private static ISessionProvider _sessionProvider;

        public static ISessionProvider GetSessionProvider()
        {
            if (_sessionProvider == null)
            {
                _sessionProvider = new SessionProvider();
            }

            return _sessionProvider;
        }


    }
}
