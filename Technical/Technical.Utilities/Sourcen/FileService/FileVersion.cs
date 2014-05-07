using System;
using System.IO;
using System.Linq;
using Technical.Utilities.Extensions;

namespace Technical.Utilities.FileService
{
    public class FileVersion
    {
        private const string STR_Version = ".Version.";

        public static string GetNewVersion(string destinationFileName)
        {
            int version = GetLastVersion(new FileInfo(destinationFileName)) + 1;
            return destinationFileName + STR_Version + version;
        }

        public static void RenameToVersion(string destinationFileName)
        {
            var originalFile = new FileInfo(destinationFileName);

            var renamedFileName = GetNewVersion(destinationFileName);

            originalFile.Rename(renamedFileName);
        }

        public static bool ClearVersions(string fileName)
        {
            // History löschen
            var fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists) return true;

            var filesToDelete = GetVersionList(fileInfo);

            bool success = true;
            foreach (var item in filesToDelete)
            {
                try
                {
                    if (item.IsWriteable())
                        item.Delete();
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }

        private static int GetLastVersion(FileInfo fileInfo)
        {
            FileInfo[] files = GetVersionList(fileInfo);

            int lastVersion = 0;
            if (files.Length > 0)
            {
                var versionsStringArray =
                    (from f in files
                        select f.Extension.Substring(1));

                lastVersion = versionsStringArray.Select(s => int.Parse(s)).ToArray().Max();
            }

            return lastVersion;
        }

        private static FileInfo[] GetVersionList(FileInfo fileInfo)
        {
            return fileInfo.Directory.GetFiles(String.Format("{0}{1}*", fileInfo.Name, STR_Version));
        }
    }
}