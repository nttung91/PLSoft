using System;
using DevExpress.XtraGrid.Columns;

namespace Windows.Core.DxExtensions
{
    public static class GridColumnExtension
    {
        public static T GetFocusedRowValue<T>(this GridColumn column)
        {
            int rowHandle = column.View.FocusedRowHandle;
            return column.GetValue<T>(rowHandle);
        }

        public static T GetValue<T>(this GridColumn column, int rowHandle)
        {
            object columnObject = column.View.GetRowCellValue(rowHandle, column);

            return GetResult<T>(columnObject);
        }

        private static T GetResult<T>(object columnObject)
        {
            T result;
            if (columnObject != null && columnObject != DBNull.Value)
                result = (T) columnObject;
            else
                result = default(T);

            return result;
        }

        public static bool HasColumnAValue(this GridColumn gridColumn)
        {
            object cellValue = gridColumn.View.GetFocusedRowCellValue(gridColumn);
            return HasValue(cellValue);
        }

        private static bool HasValue(object value)
        {
            bool hasValue = true;

            if (value == null)
            {
                hasValue = false;
            }
            else if (value == DBNull.Value)
            {
                hasValue = false;
            }
            else if (value is string)
            {
                if ((string) value == string.Empty)
                {
                    hasValue = false;
                }
            }

            return hasValue;
        }
    }
}