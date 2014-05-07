using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using PhuLiNet.Business.Common.Unit;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public class QuantityCalcEdit : CalcEdit
    {
        private Quantity _quantity = null;

        //The static constructor which calls the registration method
        static QuantityCalcEdit()
        {
            QuantityCalcEditRepositoryItem.RegisterQuantityCalcEdit();
        }

        //Initialize the new instance
        public QuantityCalcEdit()
        {
            //...
        }

        //Return the unique name
        public override string EditorTypeName
        {
            get { return QuantityCalcEditRepositoryItem.CustomEditName; }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new QuantityCalcEditRepositoryItem Properties
        {
            get { return base.Properties as QuantityCalcEditRepositoryItem; }
        }

        public override object EditValue
        {
            get { return base.EditValue; }
            set
            {
                if (!string.IsNullOrEmpty(Properties.DefaultUnitOfMeasure))
                    _quantity =
                        Quantity.TryConvert(
                            new Quantity(0, Properties.DefaultUnitOfMeasure, true, Properties.DefaultDecimalDigits,
                                false), value);
                else
                    _quantity = Quantity.TryConvert(_quantity, value);

                base.EditValue = _quantity;
            }
        }
    }
}