using Manor.MsExcel.Contracts;

namespace Techical.MsExcel.Contracts
{
    /// <summary>
    /// Worksheet is a part of a Workbook that contains the main data
    /// </summary>
    public interface IWorksheet
    {
        /// <summary>
        /// Name of the Sheet
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Get single cell by row and column index
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        ICellRange GetCell(int row, int column);

        /// <summary>
        /// Get range of cells by row and column index
        /// </summary>
        /// <param name="fromRow"></param>
        /// <param name="fromColumn"></param>
        /// <param name="toRow"></param>
        /// <param name="toColumn"></param>
        /// <returns></returns>
        ICellRange GetCellRange(int fromRow, int fromColumn, int toRow, int toColumn);

        /// <summary>
        /// Get complete row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        IRow Row(int row);

        /// <summary>
        /// Get complete column
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        IColumn Column(int column);

        /// <summary>
        /// Last row index
        /// </summary>
        int LastRow { get; }

        /// <summary>
        /// Last column index
        /// </summary>
        int LastColumn { get; }

        /// <summary>
        /// Pictures and shapes
        /// </summary>
        IDrawings Drawings { get; }

        /// <summary>
        /// Printer orientation
        /// </summary>
        EPrintOrientation Orientation { get; set; }

        /// <summary>
        /// Print: Fit To one Page.
        /// </summary>
        bool FitToPage { get; set; }

        /// <summary>
        /// Print: Fit the With to Page.
        /// </summary>
        bool FitToWidth { get; set; }


        /// <summary>
        /// We can Freeze the first Rows or/and the first Columns
        /// </summary>
        /// <param name="row">Until this row it will by freezed</param>
        /// <param name="column">Until this column it will by freezed</param>
        void FreezePanes(int row, int column);
    }
}