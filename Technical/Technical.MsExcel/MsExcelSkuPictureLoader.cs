using System.Collections.Generic;
using System.Drawing;
using Manor.MsExcel;
using Manor.MsExcel.Contracts;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel
{
    /// <summary>
    /// This class loads Images from an Excel-Sheet and put them in a List.
    /// The keyColumn is expected to hold a key (eg Variantennummer).
    /// </summary>
    public class MsExcelSkuPictureLoader
    {
        private readonly string _fileName;
        private int? _workSheetIndex;
        private string _workSheetName;

        public int? WorkSheetIndex
        {
            get { return _workSheetIndex; }
            set
            {
                _workSheetIndex = value;
                _workSheetName = null;
            }
        }

        public string WorkSheetName
        {
            get { return _workSheetName; }
            set
            {
                _workSheetName = value;
                _workSheetIndex = null;
            }
        }

        public MsExcelSkuPictureLoader(string fileName)
        {
            _fileName = fileName;
            _workSheetIndex = 0;
        }

        private IWorksheet GetWorksheet(IExcel excel)
        {
            if (_workSheetIndex.HasValue)
            {
                return excel.Workbook.Worksheets[_workSheetIndex.Value];
            }
            if (!string.IsNullOrEmpty(_workSheetName))
            {
                return excel.Workbook.GetWorksheet(_workSheetName);
            }
            return null;
        }

        public List<KeyValuePair<string, Image>> GetImages(int keyColumn, int rowStart, int? rowEnd)
        {
            var list = new List<KeyValuePair<string, Image>>();

            var listWithMultipleImages = GetImagesList(keyColumn, rowStart, rowEnd);
            foreach (var keyValuePair in listWithMultipleImages)
            {
                if (keyValuePair.Value != null && keyValuePair.Value.Count > 0)
                {
                    list.Add(new KeyValuePair<string, Image>(keyValuePair.Key, keyValuePair.Value[0]));
                }
            }

            return list;
        }

        public List<KeyValuePair<string, IList<Image>>> GetImagesList(int keyColumn, int rowStart, int? rowEnd)
        {
            if (rowEnd == 0) rowEnd = null;
            if (rowEnd != null && rowEnd < rowStart) rowEnd = null;

            var list = new List<KeyValuePair<string, IList<Image>>>();

            using (var excel = MsExcelWrapperFactory.GetDefaultInstance())
            {
                excel.Open(_fileName);

                var ws = GetWorksheet(excel);
                var lastRow = ws.LastRow;

                if (rowEnd.HasValue)
                {
                    lastRow = rowEnd.Value;
                }

                for (var rowIndex = rowStart; rowIndex <= lastRow; rowIndex++)
                {
                    var cell = ws.GetCell(rowIndex, keyColumn);

                    if (cell != null && cell.Value != null)
                    {
                        string key = cell.ValueAsString;
                        var bitmaps = GetDrawingsByRowIndex(ws, rowIndex);
                        list.Add(new KeyValuePair<string, IList<Image>>(key, bitmaps));
                    }
                }
            }

            return list;
        }

        private List<Image> GetDrawingsByRowIndex(IWorksheet worksheet, int rowIndex)
        {
            var bitmaps = new List<Image>();

            for (var i = 0; i < worksheet.Drawings.Count; i++)
            {
                var shape = worksheet.Drawings.GetDrawing(i) as IPicture;

                if (shape != null && (shape.PositionFrom.Row + 1) == rowIndex)
                {
                    bitmaps.Add(new Bitmap(shape.Image));
                }
            }

            return bitmaps;
        }
    }
}