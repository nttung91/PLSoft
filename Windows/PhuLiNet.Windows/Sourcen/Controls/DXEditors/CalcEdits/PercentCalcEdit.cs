using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using PhuLiNet.Business.Common.Unit;

namespace Windows.Core.Controls.DXEditors.CalcEdits
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public class PercentCalcEdit : CalcEdit
    {
        private Percent _percent = null;

        //The static constructor which calls the registration method
        static PercentCalcEdit()
        {
            PercentCalcEditRepositoryItem.RegisterPercentCalcEdit();
        }

        //Initialize the new instance
        public PercentCalcEdit()
        {
            //...
        }

        //Return the unique name
        public override string EditorTypeName
        {
            get { return PercentCalcEditRepositoryItem.CustomEditName; }
        }

        //Override the Properties property
        //Simply type-cast the object to the custom repository item type
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new PercentCalcEditRepositoryItem Properties
        {
            get { return base.Properties as PercentCalcEditRepositoryItem; }
        }

        public override object EditValue
        {
            get { return base.EditValue; }
            set
            {
                if (_percent == null)
                {
                    _percent = Percent.TryConvert(new Percent(0, Properties.DefaultDecimalDigits, false), value);
                }
                else
                {
                    _percent = Percent.TryConvert(_percent, value);
                }
                base.EditValue = _percent;
            }
        }
    }
}