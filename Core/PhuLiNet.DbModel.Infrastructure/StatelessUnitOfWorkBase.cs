using System;
using System.Diagnostics;
using System.Reflection;
using DbModel.Core;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public abstract class StatelessUnitOfWorkBase : IStatelessUnitOfWork
    {
        private readonly IStatelessSession _session;
        private bool _commit;
        private readonly bool _transactionStarted;

        public IStatelessSession Session
        {
            get { return _session; }
        }

        public void Complete()
        {
            _commit = true;
        }

        public void Close()
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod().DeclaringType + " => " + MethodBase.GetCurrentMethod().Name);

            if (_session.IsOpen)
            {
                //_session.Close();  //InvalidOperationException when using distributed transactions => Disconnect cannot be called while a transaction is in progress.
                _session.Dispose();
            }
        }

        /// <summary>
        /// Initializes the unit of work.
        /// </summary>
        [Obsolete]
        protected StatelessUnitOfWorkBase(bool createTransaction, IStatelessSessionManager sessionManager)
        {
            _session = sessionManager.GetStatelessSession();

            if (createTransaction)
            {
                Session.BeginTransaction();
                _transactionStarted = true;
            }
        }

        /// <summary>
        /// Initializes the unit of work.
        /// </summary>
        protected StatelessUnitOfWorkBase(bool createTransaction, ISessionProvider sessionProvider)
        {
            _session = sessionProvider.GetStatelessSession();

            if (createTransaction)
            {
                Session.BeginTransaction();
                _transactionStarted = true;
            }
        }

        private void Commit()
        {
            if (_transactionStarted)
            {
                if (_commit)
                    Session.Transaction.Commit();
                else
                    Session.Transaction.Rollback();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources               
            }

            Commit();
            Close();
        }
    }
}