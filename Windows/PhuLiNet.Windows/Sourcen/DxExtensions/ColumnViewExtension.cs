using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.DxExtensions
{
    public static class ColumnViewExtension
    {
        public static void ReplacePercentInFilterString(this ColumnView columnView)
        {
            var filterString = columnView.ActiveFilterString;
            if (filterString.Contains("[%]"))
                filterString = filterString.Replace("[%]", "[*]");

            columnView.ActiveFilterString = filterString;
        }
    }
}