using System;
using System.Windows.Forms;
using PhuLiNet.Business.Common.Rules;
using Windows.Core.BaseForms;
using Windows.Core.Localization;

namespace Windows.Core.Forms.Validation
{
    public partial class FrmBrokenRules : FrmReadOnlyBase
    {
        private static FrmBrokenRules _instance;

        private FrmBrokenRules()
        {
            InitializeComponent();
        }

        private void SetTopMessage()
        {
            if (brokenRulesControl.CountError > 0)
            {
                lblMessage.Text = BrokenRulesMessages.SaveNotPossiblePleaseCorrectErrors;
            }
            else if (brokenRulesControl.CountInformation > 0 || brokenRulesControl.CountWarning > 0)
            {
                lblMessage.Text = BrokenRulesMessages.SavingDonePleaseCheckWarnings;
            }
        }

        public void Collect(IBrokenRulesCollector collector)
        {
            brokenRulesControl.ClearBrokenRules();
            brokenRulesControl.Collect(collector);
            SetTopMessage();
            ShowOrHide();
        }

        public void ShowBrokenRules(ExtendedBrokenRulesCollection brokenRules)
        {
            brokenRulesControl.ClearBrokenRules();
            brokenRulesControl.ShowBrokenRules(brokenRules);
            SetTopMessage();
            ShowOrHide();
        }

        private void ShowOrHide()
        {
            if (brokenRulesControl.CountError > 0)
                Show();
            else if (brokenRulesControl.CountInformation > 0 || brokenRulesControl.CountWarning > 0)
                Show();
            else
                Hide();
        }

        public static FrmBrokenRules GetInstance()
        {
            if (_instance == null)
                _instance = new FrmBrokenRules();

            return _instance;
        }

        public static void ClearInstance()
        {
            if (_instance != null)
            {
                _instance.Close();
                _instance.Dispose();
                _instance = null;
            }
        }

        private void FrmBrokenRules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}