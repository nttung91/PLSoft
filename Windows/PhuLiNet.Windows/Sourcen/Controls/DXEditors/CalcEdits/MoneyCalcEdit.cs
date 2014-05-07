using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using PhuLiNet.Business.Common.Unit;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public class MoneyCalcEdit : CalcEdit
    {
        private Money _money = null;

        //The static constructor which calls the registration method
        static MoneyCalcEdit()
        {
            MoneyCalcEditRepositoryItem.RegisterMoneyCalcEdit();
        }

        //Initialize the new instance
        public MoneyCalcEdit()
        {
            //...
        }

        //Return the unique name
        public override string EditorTypeName
        {
            get { return MoneyCalcEditRepositoryItem.CustomEditName; }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new MoneyCalcEditRepositoryItem Properties
        {
            get { return base.Properties as MoneyCalcEditRepositoryItem; }
        }

        public override object EditValue
        {
            get { return base.EditValue; }
            set
            {
                if (!string.IsNullOrEmpty(Properties.DefaultCurrency) &&
                    !string.IsNullOrEmpty(Properties.DefaultCurrencyDisplay) && _money == null)
                {
                    _money =
                        Money.TryConvert(
                            new Money(0, Properties.DefaultCurrency, Properties.DefaultCurrencyDisplay,
                                Properties.DefaultDecimalDigits), value);
                }
                else
                {
                    _money = Money.TryConvert(_money, value);
                    if (_money != null && Properties.RoundToPayableAmount)
                    {
                        _money = _money.RoundToPayableAmount();
                    }
                }
                base.EditValue = _money;
            }
        }
    }
}