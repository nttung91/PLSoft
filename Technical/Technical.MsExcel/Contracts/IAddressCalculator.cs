namespace Manor.MsExcel.Contracts
{
    public interface IAddressCalculator
    {
        /// <summary>
        /// Get the cell address in the alphanumeric format A1
        /// </summary>
        string GetAddress(int fromRow, int fromColumn, int toRow, int toColumn);
    }
}