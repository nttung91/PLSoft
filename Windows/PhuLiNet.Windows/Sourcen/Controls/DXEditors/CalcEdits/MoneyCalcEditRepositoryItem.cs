using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using PhuLiNet.Business.Common.Defaults;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(true)]
    //The attribute that points to the registration method
    [UserRepositoryItem("RegisterMoneyCalcEdit")]
    public class MoneyCalcEditRepositoryItem : RepositoryItemCalcEdit
    {
        #region Custom Properties

        private string _defaultCurrency = Organisation.EnterpriseCurrency;
        private string _defaultCurrencyDisplay = Organisation.EnterpriseCurrencyDisplay;
        private int _defaultDecimalDigits = 2;
        private bool _roundToPayableAmount = false;

        [Browsable(true)]
        public string DefaultCurrency
        {
            get { return _defaultCurrency; }
            set { _defaultCurrency = value; }
        }

        [Browsable(true)]
        public string DefaultCurrencyDisplay
        {
            get { return _defaultCurrencyDisplay; }
            set { _defaultCurrencyDisplay = value; }
        }

        [Browsable(true)]
        public int DefaultDecimalDigits
        {
            get { return _defaultDecimalDigits; }
            set { _defaultDecimalDigits = value; }
        }

        [Browsable(true)]
        public bool RoundToPayableAmount
        {
            get { return _roundToPayableAmount; }
            set { _roundToPayableAmount = value; }
        }

        #endregion

        //The static constructor which calls the registration method
        static MoneyCalcEditRepositoryItem()
        {
            RegisterMoneyCalcEdit();
        }

        //Initialize new properties
        public MoneyCalcEditRepositoryItem()
        {
        }

        //The unique name for the custom editor
        public const string CustomEditName = "MoneyCalcEdit";

        //Return the unique name
        public override string EditorTypeName
        {
            get { return CustomEditName; }
        }

        //Register the editor
        public static void RegisterMoneyCalcEdit()
        {
            //Icon representing the editor within a container editor's Designer
            var bitmap =
                new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Windows.Core.ManorIcon.bmp"));

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
                typeof (MoneyCalcEdit), typeof (MoneyCalcEditRepositoryItem),
                typeof (CalcEditViewInfo), new ButtonEditPainter(), true, bitmap));
        }

        //Override the Assign method
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as MoneyCalcEditRepositoryItem;
                if (source == null) return;
                _defaultCurrency = source.DefaultCurrency;
                _defaultCurrencyDisplay = source.DefaultCurrencyDisplay;
                _defaultDecimalDigits = source.DefaultDecimalDigits;
                _roundToPayableAmount = source.RoundToPayableAmount;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}