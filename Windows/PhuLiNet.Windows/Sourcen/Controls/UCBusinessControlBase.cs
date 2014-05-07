using System;
using System.ComponentModel;
using PhuLiNet.Business.Common.Context.Base;
using Windows.Core.Binding;

namespace Windows.Core.Controls
{
    [ToolboxItem(false)]
    public partial class UCBusinessControlBase : UCBase, IBusinessControl
    {
        protected AbstractContext _businessContext;
        protected IObjectBindingManager _objectBindingManager;

        public UCBusinessControlBase()
        {
            InitializeComponent();

            if (!IsDesignerHosted)
                InitBindingManager();
        }

        #region Binding Methods

        protected virtual void InitBindingManager()
        {
            _objectBindingManager = ObjectBindingManagerReadOnly.GetBindingManager();
        }

        /// <summary>
        /// Init all BindingSources here
        /// </summary>
        protected override void InitBindings()
        {
            if (DesignMode == false)
                throw new NotImplementedException();
        }

        /// <summary>
        /// Load and init all business data here
        /// </summary>
        protected override void InitBusinessData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Init all Controls here
        /// </summary>
        protected override void InitControls()
        {
            if (DesignMode == false)
                throw new NotImplementedException();
        }

        #endregion

        public virtual void InitBusiness()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearBusiness()
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshBusiness()
        {
            throw new NotImplementedException();
        }
    }
}