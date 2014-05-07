using System;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    [Obsolete("no longer in use. Use instead ISessionProvider interface")]
    public interface IStatelessSessionManager
    {
        IStatelessSession GetStatelessSession();
    }
}