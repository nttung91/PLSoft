using System;
using Techical.MsExcel.Contracts;

namespace Manor.MsExcel.Contracts
{
    public interface ICellRange
    {
        /// <summary>
        /// Cell-Range-Address (Example "A" for Cell's A1/A2/A3/...)
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Read's the object of this Cell (ony kind of object)
        /// </summary>
        /// <returns></returns>
        object Value { get; set; }

        /// <summary>
        /// Return's the String-Value of the Cell 
        /// </summary>
        /// <returns>String Value of the Cell, NULL if there is no String-Prepresentation</returns>
        string ValueAsString { get; }

        /// <summary>
        /// Return's the Date-Value of the Cell 
        /// </summary>
        /// <returns>Date Value of the Cell, NULL if there is no Date-Prepresentation</returns>
        DateTime? ValueAsDate { get; }

        /// <summary>
        /// Return's the Decimal-Value of the Cell  (Number-Value)
        /// </summary>
        /// <returns>Decimal Value of the Cell, NULL if there is no Decimal-Prepresentation</returns>
        Decimal? ValueAsDecimal { get; }

        /// <summary>
        /// Formular (Use english formular names only)
        /// </summary>
        string Formular { set; }

        /// <summary>
        /// Merge cells
        /// </summary>
        bool Merge { set; }

        /// <summary>
        /// Autofit columns
        /// </summary>
        void AutoFitColumns();

        /// <summary>
        /// Set Autofilter for Range
        /// </summary>
        bool AutoFilter { set; }

        /// <summary>
        /// Style
        /// </summary>
        IStyle Style { get; }
    }
}