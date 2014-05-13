using System;
using Techical.MsExcel.Contracts;

namespace Manor.MsExcel.Contracts
{
    /// <summary>
    /// Excel-Wrapper used for Read and Write to Excel-Files
    /// </summary>
    public interface IExcel : IDisposable
    {
        /// <summary>
        /// Create new excel file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        IWorkbook Create(string file, string firstSheetName, bool deleteIfExists = false);

        /// <summary>
        /// Open excel file
        /// </summary>
        /// <param name="file">Name (incl. Path) of the File to Open</param>
        /// <returns>Workbook instance if file exists, if file not exists returns NULL</returns>
        IWorkbook Open(string file);

        /// <summary>
        /// Workbook reference
        /// </summary>
        IWorkbook Workbook { get; }

        /// <summary>
        /// Get address calculator
        /// </summary>
        IAddressCalculator AddressCalculator { get; }

        /// <summary>
        /// Save excel file
        /// </summary>
        void Save();
    }
}