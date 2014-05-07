using System.IO;

namespace Technical.Utilities.FileService
{
    public class CopyParameter
    {
        public CopyParameter(string sourceDirectoryString, string destinationDirectoryString)
        {
            SourceDirectoryInfo = new DirectoryInfo(sourceDirectoryString);
            DestinationDirectoryInfo = new DirectoryInfo(destinationDirectoryString);
        }

        public CopyParameter(DirectoryInfo sourceDirectoryInfo, DirectoryInfo destinationDirectoryInfo)
        {
            SourceDirectoryInfo = sourceDirectoryInfo;
            DestinationDirectoryInfo = destinationDirectoryInfo;
        }

        public string SourceDirectoryString
        {
            get { return SourceDirectoryInfo.FullName; }
        }

        public string DestinationDirectoryString
        {
            get { return DestinationDirectoryInfo.FullName; }
            set { DestinationDirectoryInfo = new DirectoryInfo(value); }
        }

        public bool ExistsSourceDirectory
        {
            get { return SourceDirectoryInfo.Exists; }
        }

        public bool ExistsDestinationDirectory
        {
            get { return DestinationDirectoryInfo.Exists; }
        }

        public DirectoryInfo SourceDirectoryInfo { get; private set; }
        public DirectoryInfo DestinationDirectoryInfo { get; private set; }
    }
}