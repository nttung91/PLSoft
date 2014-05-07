using System;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    /// <summary>
    /// Manages contexts and stores them as XML in the filesystem
    /// </summary>
    public class FileSystemContextHandler : BaseContextHandler
    {
        public FileSystemContextHandler()
        {
            DataAdapter = new JsonFileDataAdapter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
    }
}