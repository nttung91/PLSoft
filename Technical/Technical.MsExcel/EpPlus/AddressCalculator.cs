using Manor.MsExcel.Contracts;
using OfficeOpenXml;

namespace Techical.MsExcel.EpPlus
{
    internal class AddressCalculator : IAddressCalculator
    {
        public string GetAddress(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            return ExcelRange.GetAddress(fromRow, fromColumn, toRow, toColumn);
        }
    }
}