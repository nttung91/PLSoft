using System.Diagnostics;
using System.IO;
using Technical.Utilities.Extensions;

namespace Technical.Utilities.FileService
{
    public static class FileCopier
    {
        public static bool CopyToForced(this FileInfo file, DirectoryInfo targetDirectory)
        {
            Debug.Assert(file != null, "Files ist null");
            Debug.Assert(targetDirectory != null, "targetDirectory ist null");

            if (file == null || targetDirectory == null)
                return false;

            if (!targetDirectory.Exists)
                targetDirectory.Create();

            var destinationFileName = Path.Combine(targetDirectory.FullName, file.Name);
            var destinationFileInfo = new FileInfo(destinationFileName);

            FileVersion.ClearVersions(destinationFileInfo.FullName);

            if (destinationFileInfo.Exists && !destinationFileInfo.IsWriteable())
                FileVersion.RenameToVersion(destinationFileName);

            file.CopyTo(destinationFileName, true);

            return true;
        }
    }
}