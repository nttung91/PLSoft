using System;
using NHibernate;

namespace DbModel.Core
{
    /// <summary>
    /// Encapsulates an NHibernate session
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Complete();
    }
}