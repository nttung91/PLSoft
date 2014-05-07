using System;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    [Obsolete("use ISessionProvider instead")]
    public interface ISessionManager
    {
        ISession GetSession();
        bool HasActiveSession { get; }
        void CloseSession();
    }
}