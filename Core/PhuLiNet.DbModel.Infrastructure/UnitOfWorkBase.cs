using System;
using System.Diagnostics;
using System.Reflection;
using DbModel.Core;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private readonly ISession _session;
        private bool _commit;
        private readonly bool _transactionStarted;

        public ISession Session
        {
            get { return _session; }
        }

        public void Complete()
        {
            _commit = true;
        }

        private void Close()
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod().DeclaringType + " => " + MethodBase.GetCurrentMethod().Name);

            if (_session.IsOpen)
            {
                //Close can not be called when using distributed transaction                
                _session.Dispose();
            }
        }

        /// <summary>
        /// Initializes the unit of work.
        /// </summary>
        [Obsolete]
        protected UnitOfWorkBase(bool createTransaction, ISessionManager sessionManager)
        {
            _session = sessionManager.GetSession();

            if (createTransaction)
            {
                Session.BeginTransaction();
                _transactionStarted = true;
            }
        }

        /// <summary>
        /// Initializes the unit of work.
        /// </summary>
        protected UnitOfWorkBase(bool createTransaction, ISessionProvider sessionProvider)
        {
            _session = sessionProvider.GetSession();

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