using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public interface ISessionProvider
    {

        ISession GetSession();

        IStatelessSession GetStatelessSession();

    }
}
