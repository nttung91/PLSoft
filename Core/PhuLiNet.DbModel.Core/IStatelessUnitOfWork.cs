using System;
using NHibernate;

namespace DbModel.Core
{
    /// <summary>
    /// Encapsulates an NHibernate stateless session
    /// </summary>
    public interface IStatelessUnitOfWork : IDisposable
    {
        IStatelessSession Session { get; }
        void Complete();
    }
}