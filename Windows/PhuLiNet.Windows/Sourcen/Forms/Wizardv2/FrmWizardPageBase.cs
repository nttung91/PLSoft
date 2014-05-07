using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Windows.Core.BaseForms;
using Windows.Core.Binding;

namespace Windows.Core.Forms.Wizardv2
{
    public partial class FrmWizardPageBase : FrmReadOnlyBase, IEditableForm, IDataModelBind
    {
        protected IDataModel _dataModel;
        protected bool _isLoaded = false;

        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }

        public FrmWizardPageBase()
        {
            InitializeComponent();
        }

        protected override void InitBindingManager()
        {
            _objectBindingManager = ObjectBindingManagerEditable.GetBindingManager();
        }

        #region IEditableForm Members

        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { return _dataModel.IsDirty; }
        }

        [Browsable(false)]
        public virtual bool IsValid
        {
            get { return _dataModel.IsValid; }
        }

        [Browsable(false)]
        public virtual bool IsReadOnly { get; set; }

        #endregion

        #region IDataModelBind Members

        public virtual void BindDataModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
            InitBindings();
        }

        public virtual void UnbindDataModel()
        {
            throw new NotImplementedException();
        }

        #endregion

        public SimpleButton WizardBackButton
        {
            get { return btnBack; }
        }

        public SimpleButton WizardCancelButton
        {
            get { return btnCancel; }
        }

        public SimpleButton WizardNextButton
        {
            get { return btnNext; }
        }

        public SimpleButton WizardHelpButton
        {
            get { return null; }
        }

        public SimpleButton WizardFinishButton
        {
            get { return btnFinish; }
        }
    }
}