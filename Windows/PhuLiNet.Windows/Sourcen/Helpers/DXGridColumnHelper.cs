using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Helpers
{
    public static class DXGridColumnHelper
    {
        public static T GetColumnObjectValue<T>(GridView view, int rowHandle, GridColumn gridColumn) where T : class
        {
            T result;

            object resultObject = view.GetRowCellValue(rowHandle, gridColumn);
            if ((resultObject != null || resultObject != DBNull.Value) && resultObject is T)
            {
                result = resultObject as T;
            }
            else
            {
                result = default(T);
            }

            return result;
        }

        public static string GetColumnStringValue(GridView view, int rowHandle, GridColumn gridColumn)
        {
            string result;

            object resultObject = view.GetRowCellValue(rowHandle, gridColumn);
            if ((resultObject != null || resultObject != DBNull.Value) && resultObject is string)
            {
                result = resultObject.ToString();
            }
            else
            {
                result = null;
            }

            return result;
        }

        public static int GetColumnIntValue(GridView view, int rowHandle, GridColumn gridColumn)
        {
            int result;

            object resultObject = view.GetRowCellValue(rowHandle, gridColumn);
            if ((resultObject != null || resultObject != DBNull.Value) && resultObject is int)
            {
                result = (int) resultObject;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public static decimal GetColumnDecimalValue(GridView view, int rowHandle, GridColumn gridColumn)
        {
            decimal result;

            object resultObject = view.GetRowCellValue(rowHandle, gridColumn);
            if ((resultObject != null || resultObject != DBNull.Value) && resultObject is decimal)
            {
                result = (decimal) resultObject;
            }
            else
            {
                result = 0m;
            }

            return result;
        }
    }
}