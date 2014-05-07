using System;
using System.IO;
using System.Reflection;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    /// <summary>
    /// Manages contexts and stores them as XML in the U-Drive (user home drive)
    /// </summary>
    public class UDriveContextHandler : BaseContextHandler
    {
        private const string _driverLetter = "U";
        private const string _rootPath = _driverLetter + ":\\AppData\\Manor";
        private string _appName;

        public UDriveContextHandler() : base()
        {
            InitDataAdapter();
        }

        public UDriveContextHandler(string appName) : base()
        {
            _appName = appName;
            InitDataAdapter();
        }

        private void InitDataAdapter()
        {
            string configPath = ReturnConfigPath();

            var drive = new DriveInfo(_driverLetter);
            if (drive.IsReady)
            {
                if (!Directory.Exists(configPath))
                {
                    Directory.CreateDirectory(configPath);
                }

                DataAdapter = new JsonFileDataAdapter(configPath);
            }
            else
            {
                DataAdapter = new EmptyDataAdapter();
            }
        }

        private string ReturnConfigPath()
        {
            string configPath = null;

            if (_appName != null)
            {
                configPath = Path.Combine(_rootPath, _appName);
            }
            else
            {
                string[] assemblyFullName = Assembly.GetEntryAssembly()
                    .FullName.Split(new string[1] {", "}, StringSplitOptions.RemoveEmptyEntries);
                string assembly = assemblyFullName[0];
                configPath = Path.Combine(_rootPath, assembly);
            }

            return configPath;
        }
    }
}