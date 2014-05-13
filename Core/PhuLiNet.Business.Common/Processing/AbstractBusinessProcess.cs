using System;

namespace PhuLiNet.Business.Common.Processing
{
    /// <summary>
    /// Basisklasse für alle Verarbeitungsprozesse
    /// </summary>
    public abstract class AbstractBusinessProcess : IBusinessProcess
    {
        protected bool _useTransaction = true;
        protected bool _isComposable = false;
        protected bool _hasException = false;
        protected IBusinessProcessLogger _logger;

        protected AbstractBusinessProcess()
        {
        }

        #region IBusinessProcess Members

        public virtual void Process()
        {
            throw new NotImplementedException();
        }

        public bool IsComposable
        {
            get { return _isComposable; }
        }

        public bool HasException
        {
            get { return _hasException; }
        }

        public IBusinessProcessLogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        #endregion

        #region ITransactionalBusiness Members

        public bool UseTransaction
        {
            get { return _useTransaction; }
            set { _useTransaction = value; }
        }

        #endregion
    }
}