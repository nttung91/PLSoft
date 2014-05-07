using System.ComponentModel;
using Csla.Rules;
using DevExpress.XtraEditors.Controls;
using PhuLiNet.Business.Common.Rules;
using Windows.Core.Controls;
using Windows.Core.Localization;

namespace Windows.Core.Validation
{
    [ToolboxItem(true)]
    public partial class UCBrokenRules : UCBusinessControlBase
    {
        public delegate void OnJumpToClickDelegate(object link);

        public event OnJumpToClickDelegate OnJumpToClick;

        private ExtendedBrokenRulesCollection _brokenRules = new ExtendedBrokenRulesCollection();

        public UCBrokenRules()
        {
            InitializeComponent();
            InitControls();
            InitBindings();
        }

        protected override void InitControls()
        {
            riicSeverity.Items.AddEnum(typeof (RuleSeverity));
            riicSeverity.Items[0].Description = BrokenRulesMessages.SeverityError;
            riicSeverity.Items[0].ImageIndex = 0;
            riicSeverity.Items[1].Description = BrokenRulesMessages.SeverityWarning;
            riicSeverity.Items[1].ImageIndex = 1;
            riicSeverity.Items[2].Description = BrokenRulesMessages.SeverityInformation;
            riicSeverity.Items[2].ImageIndex = 2;
        }

        protected override void InitBindings()
        {
            if (IsDesignerHosted) return;
            _objectBindingManager.ClearBindings(bsExtendedBrokenRule, false);
            _objectBindingManager.BindBO(_brokenRules, bsExtendedBrokenRule);
            _objectBindingManager.RestoreBindings(bsExtendedBrokenRule, true);
        }

        public void Collect(IBrokenRulesCollector collector)
        {
            collector.Collect();
            _brokenRules = collector.BrokenRules;
            ShowBrokenRules();
        }

        public void ShowBrokenRules(ExtendedBrokenRulesCollection brokenRules)
        {
            _brokenRules = brokenRules;
            ShowBrokenRules();
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Error.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountError
        {
            get
            {
                if (_brokenRules != null)
                    return _brokenRules.CountError;
                return 0;
            }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Warning.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountWarning
        {
            get
            {
                if (_brokenRules != null)
                    return _brokenRules.CountWarning;
                return 0;
            }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Information.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountInformation
        {
            get
            {
                if (_brokenRules != null)
                    return _brokenRules.CountInformation;
                return 0;
            }
        }

        public int CountAll
        {
            get
            {
                if (_brokenRules != null)
                    return _brokenRules.Count;
                return 0;
            }
        }

        public void ShowBrokenRules()
        {
            InitBindings();
        }

        public void ClearBrokenRules()
        {
            _brokenRules.ClearBrokenRules();
        }

        private void ribeJumpTo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (_brokenRules != null)
            {
                var br = bsExtendedBrokenRule.Current as ExtendedBrokenRule;

                if (OnJumpToClick != null && br != null)
                    OnJumpToClick(br.Link);
            }
        }
    }
}