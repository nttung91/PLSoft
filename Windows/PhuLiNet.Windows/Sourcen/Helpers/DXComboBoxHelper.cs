using Csla;
using Csla.Core;
using DevExpress.XtraEditors;

namespace Windows.Core.Helpers
{
    public static class DXComboBoxHelper
    {
        public static void SetList<L, O>(ComboBoxEdit comboBoxEdit, L lookupList)
            where L : ReadOnlyBindingListBase<L, O>
            where O : IBusinessObject
        {
            foreach (O item in lookupList)
            {
                comboBoxEdit.Properties.Items.Add(item);
            }
        }
    }
}