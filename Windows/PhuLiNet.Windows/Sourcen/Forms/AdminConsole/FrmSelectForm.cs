using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.AdminConsole
{
    internal partial class FrmSelectForm : FrmDialogBase, ILoadableForm
    {
        private Form _selectedForm;
        private List<Form> _formList;

        public Form SelectedForm
        {
            get { return _selectedForm; }
            set { _selectedForm = value; }
        }

        public FrmSelectForm()
        {
            InitializeComponent();
        }

        protected override void InitBindings()
        {
            _objectBindingManager.BindBO(_formList, formBindingSource);
        }

        protected override void InitBusinessData()
        {
            _formList = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                _formList.Add(form);
            }
        }

        #region ILoadableForm Members

        public void LoadBusiness()
        {
            InitBusinessData();
            InitBindings();
        }

        #endregion

        protected override void AcceptButtonCloseForm()
        {
            if (formBindingSource.Current != null)
            {
                _selectedForm = formBindingSource.Current as Form;
            }

            DialogResult = DialogResult.OK;
        }

        private void lbcForms_DoubleClick(object sender, EventArgs e)
        {
            AcceptButtonCloseForm();
        }
    }
}