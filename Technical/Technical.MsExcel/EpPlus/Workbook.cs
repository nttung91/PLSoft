using System.Collections.Generic;
using Manor.MsExcel.Contracts;
using OfficeOpenXml;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Workbook : IWorkbook
    {
        private readonly ExcelWorkbook _excelWorkbook;

        public Workbook(ExcelWorkbook excelWorkbook)
        {
            _excelWorkbook = excelWorkbook;
        }

        public List<IWorksheet> Worksheets
        {
            get
            {
                var worksheets = new List<IWorksheet>();

                foreach (var item in _excelWorkbook.Worksheets)
                {
                    worksheets.Add(new Worksheet(item));
                }

                return worksheets;
            }
        }

        public IWorksheet AddWorksheet(string name)
        {
            ExcelWorksheet worksheet = _excelWorkbook.Worksheets.Add(name);
            return new Worksheet(worksheet);
        }

        public IWorksheet GetWorksheet(string name)
        {
            ExcelWorksheet worksheet = _excelWorkbook.Worksheets[name];
            if (worksheet == null)
                return null;
            else
                return new Worksheet(worksheet);
        }

        public IWorksheet GetWorksheet(int index)
        {
            return new Worksheet(_excelWorkbook.Worksheets[index]);
        }

        public void Dispose()
        {
        }
    }
}