using System;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using DevExpress.XtraEditors;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms
{
    internal partial class FrmInputDialog : FrmDialogBase, ILoadableForm
    {
        public object InputValue { get; set; }

        public Type InputType { get; set; }

        public string InputMessage { get; set; }

        public string DialogTitle { get; set; }

        private BaseEdit _inputControl;

        public FrmInputDialog()
        {
            InitializeComponent();
        }

        protected override void InitBindings()
        {
            var lciInput = lcInput.Root.AddItem();
            _inputControl = InputType == typeof (DateTime) ? new DateEdit() : new TextEdit();
            lciInput.Control = _inputControl;
            lciInput.TextVisible = false;

            if (InputValue != null)
            {
                _inputControl.EditValue = InputValue;
            }

            Text = DialogTitle;
            lblInputInfo.Text = InputMessage;
        }

        #region ILoadableForm Members

        public void LoadBusiness()
        {
            InitBindings();
        }

        #endregion

        protected override void AcceptButtonCloseForm()
        {
            if (!string.IsNullOrEmpty(_inputControl.Text))
            {
                if (InputType == typeof (string))
                {
                    InputValue = _inputControl.Text;
                }
                else if (InputType == typeof (DateTime))
                {
                    InputValue = (DateTime) _inputControl.EditValue;
                }
                else if (InputType == typeof (int))
                {
                    int result;
                    var ok = int.TryParse(_inputControl.Text, out result);
                    if (ok) InputValue = result;
                }
                else
                {
                    Debug.Assert(false, "Type not defined. Please add type here");
                }
            }
            else
            {
                InputType = null;
            }

            DialogResult = DialogResult.OK;
        }
    }
}