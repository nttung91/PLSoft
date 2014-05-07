using System;
using System.IO;
using Manor.MsExcel.Contracts;
using OfficeOpenXml;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class EpPlusExcelWrapper : IExcel
    {
        private bool _disposed;
        private ExcelPackage _excel;
        private Workbook _workbook;

        public IWorkbook Create(string file, string firstSheetName, bool deleteIfExists = false)
        {
            var newFile = new FileInfo(file);
            if (newFile.Exists)
            {
                if (deleteIfExists)
                {
                    newFile.Delete();
                }
                else
                {
                    throw new ApplicationException(string.Format("File {0} exists already", file));
                }
            }

            _excel = new ExcelPackage(newFile);

            _workbook = new Workbook(_excel.Workbook);
            _workbook.AddWorksheet(firstSheetName);

            return _workbook;
        }

        public IWorkbook Open(string file)
        {
            var existingFile = new FileInfo(file);
            _excel = new ExcelPackage(existingFile);
            _workbook = new Workbook(_excel.Workbook);
            return _workbook;
        }

        public IWorkbook Workbook
        {
            get { return _workbook; }
        }

        public void Save()
        {
            _excel.Save();
        }

        public void Dispose()
        {
            if (_excel != null && !_disposed)
            {
                _excel.Dispose();
                _disposed = true;
            }
        }

        public IAddressCalculator AddressCalculator
        {
            get { return new AddressCalculator(); }
        }
    }
}