using System.Linq;
using System.Windows.Forms;
using Csla;
using Csla.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using PhuLiNet.Business.Common.Lookup;
using Technical.Utilities.Extensions;

namespace Windows.Core.Helpers
{
    public static class DXCheckedComboBoxEditHelper
    {
        public static L GetLookupListFromCheckedComboboxEdit<L, O>(CheckedComboBoxEdit checkedComboBoxEdit, L lookupList)
            where L : ReadOnlyBindingListBase<L, O>
            where O : IBusinessObject
        {
            foreach (CheckedListBoxItem item in checkedComboBoxEdit.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    if (item.Value is O)
                    {
                        var lookupObject = (O) item.Value;
                        lookupList.Add(lookupObject);
                    }
                }
            }

            return lookupList;
        }

        public static void PopulateCheckedListBox<T, C>(CheckedComboBoxEdit checkedComboBoxEdit, T list, T selectedList)
            where T : ReadOnlyBindingListBase<T, C>, ILookupObjectList
            where C : ILookupObject
        {
            checkedComboBoxEdit.Properties.Items.BeginUpdate();

            checkedComboBoxEdit.Properties.Items.Clear();
            CheckedListBoxItem clb;
            string editValue = string.Empty;
            foreach (C element in list)
            {
                clb = new CheckedListBoxItem(element);
                checkedComboBoxEdit.Properties.Items.Add(clb);
                string selected = CheckSelected<T, C>(clb, selectedList, element);
                if (!string.IsNullOrEmpty(selected))
                {
                    if (!string.IsNullOrEmpty(editValue))
                        editValue += ", ";
                    editValue += selected;
                }
            }
            checkedComboBoxEdit.EditValue = editValue;
            checkedComboBoxEdit.Properties.Items.EndUpdate();
        }

        private static string CheckSelected<T, C>(CheckedListBoxItem clb, T list, C element)
            where T : ReadOnlyBindingListBase<T, C>, ILookupObjectList
            where C : ILookupObject
        {
            string editValue = string.Empty;
            if (list == null) return editValue;
            foreach (C wg in list)
            {
                if (element.LookupKey.Equals(wg.LookupKey))
                {
                    editValue = element.ToString();
                    clb.CheckState = CheckState.Checked;
                    break;
                }
            }
            return editValue;
        }

        public static int CountChecked(CheckedComboBoxEdit checkedComboBoxEdit)
        {
            int res = 0;
            foreach (CheckedListBoxItem item in checkedComboBoxEdit.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    res++;
                }
            }

            return res;
        }

        public static void ClearSelection(CheckedComboBoxEdit checkedComboBoxEdit)
        {
            foreach (
                CheckedListBoxItem item in
                    checkedComboBoxEdit.Properties.Items.Cast<CheckedListBoxItem>()
                        .Where(item => item.CheckState == CheckState.Checked))
            {
                item.CheckState = CheckState.Unchecked;
            }
        }
    }
}