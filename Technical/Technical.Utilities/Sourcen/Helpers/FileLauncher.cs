using System.Diagnostics;
using System.IO;
using Technical.Utilities.Exceptions;

namespace Technical.Utilities.Helpers
{
    /// <summary>
    /// Shows an external file by it's default application
    /// </summary>
    public class FileLauncher
    {
        private string _fileName;
        private bool _fileNameExists = false;

        public FileLauncher(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            Debug.Assert(fileInfo.Exists, "Filename does not exist [" + fileName + "]");

            _fileName = fileName;
            _fileNameExists = fileInfo.Exists;
        }

        public void Run()
        {
            if (_fileNameExists)
            {
                // Start a new process for the cmd
                Process.Start(_fileName);
            }
            else
            {
                throw new PhuLiException("Filename does not exist [" + _fileName + "]");
            }
        }
    }
}