using System;
using System.Windows.Forms;
using Csla.Core;
using PhuLiNet.Business.Common.Rules;
using Windows.Core.Localization;

namespace Windows.Core.Binding.SaveManager
{
    public abstract class SaveManagerBase
    {
        protected string _dataNotSavedErrorMessage = SaveManagerMessages.DataNotSaved;

        public string DataNotSavedErrorMessage
        {
            get { return _dataNotSavedErrorMessage; }
            set { _dataNotSavedErrorMessage = value; }
        }

        public bool ShowDataNotSavedErrorMessage { get; set; }
        public bool ShowWaitForm { get; set; }
        public bool Enabled { get; set; }
        public bool TestMode { get; set; }

        protected IObjectBindingManager ObjectBindingManager;

        protected SaveManagerBase(IObjectBindingManager objectBindingManager)
        {
            ObjectBindingManager = objectBindingManager;
            ShowWaitForm = false;
            Enabled = true;
            ShowDataNotSavedErrorMessage = false;
        }

        public virtual void ValidateBO(IValidateBusiness businessObject, BindingSource bindingSource)
        {
            throw new NotImplementedException();
        }

        public virtual bool Save(IBusinessObject businessObject, BindingSource bindingSource, bool rebind)
        {
            throw new NotImplementedException();
        }

        public virtual bool Save(IBusinessObject businessObject, BindingSource bindingSource,
            BindingSource[] childBindingSources, bool rebind)
        {
            throw new NotImplementedException();
        }

        public virtual bool Save(IBusinessObject businessObject, BindingSourceNode bindingSourceNode, bool rebind)
        {
            throw new NotImplementedException();
        }
    }
}