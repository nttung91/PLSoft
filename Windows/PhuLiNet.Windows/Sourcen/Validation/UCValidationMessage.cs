using System.Collections.Generic;
using System.ComponentModel;
using PhuLiNet.Business.Common.Messages;
using Windows.Core.Controls;
using Windows.Core.Localization;

namespace Windows.Core.Validation
{
    [ToolboxItem(true)]
    public partial class UCValidationMessage : UCBusinessControlBase
    {
        private IList<IValidationMessage> _validationMessageList;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<IValidationMessage> ValidationMessageList
        {
            set
            {
                if (_validationMessageList != null)
                {
                    _validationMessageList = null;
                }

                _validationMessageList = value;
            }
            get { return _validationMessageList; }
        }

        public UCValidationMessage()
        {
            InitializeComponent();
        }

        protected override void InitControls()
        {
            if (riicSeverity.Items.Count == 0)
            {
                riicSeverity.Items.AddEnum(typeof (MessageSeverity));
                riicSeverity.Items[0].Description = BrokenRulesMessages.SeverityError;
                riicSeverity.Items[0].ImageIndex = 0;
                riicSeverity.Items[1].Description = BrokenRulesMessages.SeverityWarning;
                riicSeverity.Items[1].ImageIndex = 1;
                riicSeverity.Items[2].Description = BrokenRulesMessages.SeverityInformation;
                riicSeverity.Items[2].ImageIndex = 2;
            }
        }

        protected override void InitBindings()
        {
            if (_validationMessageList != null)
            {
                _objectBindingManager.ClearBindings(iValidationMessageBindingSource, false);
                _objectBindingManager.BindBO(_validationMessageList, iValidationMessageBindingSource);
                _objectBindingManager.RestoreBindings(iValidationMessageBindingSource, true);
            }
            else
            {
                _objectBindingManager.ClearBindings(iValidationMessageBindingSource, false);
            }
        }

        #region IBusinessControl Members

        public override void InitBusiness()
        {
            InitControls();
            InitBindings();
        }

        public override void ClearBusiness()
        {
            _objectBindingManager.ClearBindings(iValidationMessageBindingSource, false);
            _validationMessageList = null;
        }

        public override void RefreshBusiness()
        {
            InitControls();
            InitBindings();
        }

        #endregion
    }
}