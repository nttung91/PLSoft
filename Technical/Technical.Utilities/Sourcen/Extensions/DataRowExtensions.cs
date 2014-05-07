using System;
using System.Data;

namespace Technical.Utilities.Extensions
{
    public static class DataRowExtensions
    {
        public static decimal? GetDecimalValue(this DataRow dataRow, string columnName)
        {
            decimal? decimalValue;
            object vpObj = dataRow[columnName];

            if (!dataRow.Table.Columns.Contains(columnName))
            {
                decimalValue = null;
            }
            else
            {
                if (vpObj != null && vpObj != DBNull.Value)
                {
                    string toParse = vpObj.ToString();
                    decimal res = 0;
                    if (decimal.TryParse(toParse, out res))
                    {
                        decimalValue = res;
                    }
                    else
                    {
                        decimalValue = null;
                    }
                }
                else
                {
                    decimalValue = null;
                }
            }

            return decimalValue;
        }

        public static T GetValue<T>(this DataRow dataRow, string columnName)
        {
            T result;
            if (dataRow[columnName] != DBNull.Value && dataRow[columnName] != null)
                result = (T) dataRow[columnName];
            else
                result = default(T);

            return result;
        }
    }
}