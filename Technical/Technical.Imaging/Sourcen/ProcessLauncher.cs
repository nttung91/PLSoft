using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Technical.Imaging
{
    /// <summary>
    /// Runs an external process or application
    /// </summary>
    public class ProcessLauncher
    {
        public delegate void OnSleepEventHandler();

        public event OnSleepEventHandler OnSleep;

        private string _fileName;
        private bool _fileNameExists = false;
        private bool _waitUntilExit = false;
        private string _arguments = string.Empty;
        private string _workingDirectory = string.Empty;
        private int _sleepTime = 1000;

        public ProcessLauncher(string fileName, bool waitUntilExit)
        {
            var fileInfo = new FileInfo(fileName);
            Debug.Assert(fileInfo.Exists, "Executable does not exist [" + fileName + "]");

            _fileName = fileName;
            _fileNameExists = fileInfo.Exists;
            _waitUntilExit = waitUntilExit;
            _workingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public ProcessLauncher(string fileName, string arguments, bool waitUntilExit) : this(fileName, waitUntilExit)
        {
            _arguments = arguments;
        }

        public ProcessLauncher(string fileName, string workingDirectory, string arguments, bool waitUntilExit)
            : this(fileName, arguments, waitUntilExit)
        {
            _workingDirectory = workingDirectory;
        }

        public void Run()
        {
            if (_fileNameExists)
            {
                // Start a new process for the cmd
                var process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.FileName = _fileName;
                process.StartInfo.Arguments = _arguments;
                process.StartInfo.WorkingDirectory = _workingDirectory;
                process.Start();


                if (_waitUntilExit)
                {
                    // Wait for the process to end, or cancel it
                    while (!process.HasExited)
                    {
                        Thread.Sleep(_sleepTime); // sleep   

                        if (OnSleep != null)
                            OnSleep();
                    }
                }

                process.Close();
                process.Dispose();
            }
            else
            {
                throw new ApplicationException("Executable does not exist [" + _fileName + "]");
            }
        }
    }
}