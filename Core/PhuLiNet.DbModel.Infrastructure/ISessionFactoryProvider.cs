using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public interface ISessionFactoryProvider
    {
        ISessionFactory SessionFactory { get; }
    }
}