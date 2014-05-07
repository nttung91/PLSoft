using System;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.Binding;

namespace Windows.Core.Controls
{
    public class UCEditBusinessBase : UCBusinessControlBase
    {
        public IPhuLiBusinessBase BusinessObject { get; set; }

        /// <summary>
        /// The binding sources hierarchy used by the control.
        /// Child binding sources are added with AddChild to the BindingSourceNode.
        /// </summary>
        /// <remarks>The binding source hierarchy is bound/rebound/unbound at the correct times.</remarks>
        protected virtual BindingSourceNode BindingSource
        {
            get { throw new NotImplementedException(); }
        }

        public virtual void BestFitColumns()
        {
        }

        #region IBusinessControl Members

        /// <summary>
        /// Set the BusinessObject property based on the root form object before InitBusiness is called
        /// </summary>
        public virtual void SetBusinessObjectFromRoot(IPhuLiBusinessBase rootBusinessObject)
        {
            BusinessObject = rootBusinessObject;
        }

        public override void InitBusiness()
        {
            // Bind the business object to the root source
            InitBindings();
            InitControls();
        }

        public override void ClearBusiness()
        {
            _objectBindingManager.EndEditBinding(BindingSource.BindingSource);
            _objectBindingManager.ClearBindings(BindingSource, true);
        }

        public override void RefreshBusiness()
        {
            InitBindings();
        }

        #endregion

        #region Business Overrides

        protected override sealed void InitBindings()
        {
            _objectBindingManager.BindBO(BusinessObject, BindingSource.BindingSource);
            _objectBindingManager.RestoreBindings(BindingSource, true);
            AfterInitBindings();
        }

        protected override void InitControls()
        {
        }

        /// <summary>
        /// Override this to e.g. enable/disable controls 
        /// </summary>
        protected virtual void AfterInitBindings()
        {
        }

        #endregion
    }
}