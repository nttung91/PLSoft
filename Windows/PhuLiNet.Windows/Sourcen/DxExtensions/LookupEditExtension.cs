using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.DxExtensions
{
    public static class LookupEditExtension
    {
        /// <summary>
        /// Is the editor != null or editvalue != null or !=DBNull or !=string.empty
        /// </summary>
        /// <param name="lookupEdit">Devexpress Lookupeditor</param>
        /// <returns>True if editvalue has a Value</returns>
        public static bool HasValue(this LookUpEdit lookupEdit)
        {
            bool result;
            if (lookupEdit != null && lookupEdit.EditValue != null && lookupEdit.EditValue != DBNull.Value &&
                lookupEdit.EditValue.ToString() != string.Empty)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Clears the Editvalue if no longer in DataSource
        /// </summary>
        public static T GetEditValue<T>(this LookUpEdit lookupEdit)
        {
            T editValue;
            if (lookupEdit.HasValue())
            {
                editValue = (T) lookupEdit.EditValue;
            }
            else
            {
                editValue = default(T);
            }

            return editValue;
        }

        public static bool IsEditValueInDataSource(this LookUpEdit lookupEdit)
        {
            if (lookupEdit.Properties.DataSource == null || !lookupEdit.HasValue()) return false;

            bool result;
            if (lookupEdit.Properties.DataSource is DataTable)
            {
                var dtLookup = lookupEdit.Properties.DataSource as DataTable;
                result = DataTableContainsValue(dtLookup, lookupEdit.Properties.ValueMember, lookupEdit.EditValue);
            }
            else if (lookupEdit.Properties.DataSource is BindingSource)
            {
                var bsLookup = lookupEdit.Properties.DataSource as BindingSource;
                result = BindingSourceContainsValue(bsLookup, lookupEdit.Properties.ValueMember, lookupEdit.EditValue);
            }
            else
            {
                result = false;
            }

            return result;
        }

        private static bool DataTableContainsValue(DataTable dtLookup, string columnName, object value)
        {
            return dtLookup.Select(GetLookupFilter(columnName, value)).Length > 0;
        }

        private static bool BindingSourceContainsValue(BindingSource bsLookup, string columnName, object value)
        {
            string originalFilter = bsLookup.Filter;
            bsLookup.Filter = GetLookupFilter(columnName, value);
            bool result = bsLookup.Count == 1;
            bsLookup.Filter = originalFilter;
            return result;
        }

        private static string GetLookupFilter(string columnName, object value)
        {
            string filter;
            if (value is string)
            {
                filter = string.Format("{0}='{1}'", columnName, value);
            }
            else
            {
                filter = string.Format("{0}={1}", columnName, value);
            }
            return filter;
        }

        /// <summary>
        /// Clears the Editvalue if no longer in DataSource
        /// </summary>
        public static void CheckEditValueInAgainstDataSource(this LookUpEdit lookupEdit)
        {
            if (!lookupEdit.HasValue()) return;

            if (!lookupEdit.IsEditValueInDataSource())
            {
                lookupEdit.EditValue = null;
            }
        }
    }
}