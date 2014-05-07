using System;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace Windows.Core.Dynamic
{
    public class ColumnOptions : ICloneable
    {
        public ColumnOptions()
        {
            HorzAlign = HorzAlignment.Default;
            AllowFilter = true;
            AllowSort = DefaultBoolean.Default;
            DisplayFormatType = null;
        }

        public bool AddSummaryItem { get; set; }
        public SummaryItemType SummaryType { get; set; }
        public HorzAlignment? HorzAlign { get; set; }
        public bool AllowFilter { get; set; }
        public DefaultBoolean AllowSort { get; set; }
        public RepositoryItem ColumnEdit { get; set; }
        public int? MinWidth { get; set; }
        public FormatType? DisplayFormatType { get; set; }
        public string DisplayFormatString { get; set; }

        public object Clone()
        {
            return new ColumnOptions()
            {
                AddSummaryItem = AddSummaryItem,
                SummaryType = SummaryType,
                HorzAlign = HorzAlign,
                AllowFilter = AllowFilter,
                AllowSort = AllowSort,
                ColumnEdit = ColumnEdit,
                MinWidth = MinWidth,
                DisplayFormatString = DisplayFormatString,
                DisplayFormatType = DisplayFormatType
            };
        }
    }
}