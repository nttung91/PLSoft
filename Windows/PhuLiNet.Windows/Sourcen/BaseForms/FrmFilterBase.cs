using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using PhuLiNet.Business.Common.Context.Base;
using PhuLiNet.Business.Common.Interfaces;
using Windows.Core.Binding;
using Windows.Core.Filter;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Base form for "Filter" dialogs
    /// </summary>
    public partial class FrmFilterBase : FrmBase, IFrmFilterEnabled
    {
        protected AbstractContext _businessContext;
        protected IObjectBindingManager _objectBindingManager;
        protected bool _allowClose = true;
        public IFilterSelection Selection { get; set; }

        public FrmFilterBase()
        {
            InitializeComponent();
            InitBindingManager();
        }

        public virtual void LoadBusiness()
        {
            if (Selection == null) return;
            Selection.SeperateWindow = false;
            _objectBindingManager.BindBO(Selection, bsFilterSelection);
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

        public string AcceptButtonText
        {
            get { return btnOk.Text; }
            set { btnOk.Text = value; }
        }

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

        protected virtual void ResetButtonCloseForm()
        {
        }

        protected virtual void BtnOk_Click(object sender, EventArgs e)
        {
            AcceptButtonCloseForm();
        }

        protected virtual void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonCloseForm();
        }

        private void FrmCslaDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_allowClose;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetButtonCloseForm();
        }
    }
}