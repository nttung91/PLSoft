using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    /// <summary>
    /// Manages contexts and stores them as XML in the filesystem
    /// </summary>
    public class FileSystemWithPathContextHandler : BaseContextHandler
    {
        public FileSystemWithPathContextHandler(string path)
        {
            DataAdapter = new JsonFileDataAdapter(path);
        }
    }
}