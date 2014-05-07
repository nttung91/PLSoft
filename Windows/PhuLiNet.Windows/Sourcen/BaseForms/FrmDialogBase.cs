using System;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.Core.Binding;
using PhuLiNet.Business.Common.Context.Base;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Base form for "OK-Cancel" dialogs
    /// </summary>
    public partial class FrmDialogBase : FrmBase
    {
        protected AbstractContext _businessContext;
        protected IObjectBindingManager _objectBindingManager;
        protected bool _allowClose = true;

        public FrmDialogBase()
        {
            InitializeComponent();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear all Bindings here
        /// </summary>
        protected override void ClearBindings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Init all Controls here
        /// </summary>
        protected override void InitControls()
        {
            throw new NotImplementedException();
        }

        #endregion

        [Localizable(true)]
        public string AcceptButtonText
        {
            get { return btnOk.Text; }
            set { btnOk.Text = value; }
        }

        [Localizable(true)]
        public string CancelButtonText
        {
            get { return btnCancel.Text; }
            set { btnCancel.Text = value; }
        }

        public bool AcceptButtonVisible
        {
            get { return btnOk.Visible; }
            set { btnOk.Visible = value; }
        }

        public bool CancelButtonVisible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }

        protected virtual void AcceptButtonCloseForm()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void CancelButtonCloseForm()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected virtual void btnOk_Click(object sender, EventArgs e)
        {
            AcceptButtonCloseForm();
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonCloseForm();
        }

        private void FrmCslaDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_allowClose;
        }
    }
}