using System.Collections.Generic;

namespace Techical.MsExcel.Contracts
{
    /// <summary>
    /// Workbook the main Element of a Workbook-Application
    /// </summary>
    public interface IWorkbook
    {
        /// <summary>
        /// List of all Worksheets
        /// </summary>
        List<IWorksheet> Worksheets { get; }

        /// <summary>
        /// Add new worksheet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IWorksheet AddWorksheet(string name);

        /// <summary>
        /// Get worksheet by name
        /// </summary>
        /// <param name="name">Name of the Worksheet</param>
        /// <returns>Worksheet instance</returns>
        IWorksheet GetWorksheet(string name);

        /// <summary>
        /// Get worksheet by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IWorksheet GetWorksheet(int index);
    }
}