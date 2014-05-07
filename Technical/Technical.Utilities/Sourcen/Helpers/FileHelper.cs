using System;
using System.IO;
using Technical.Utilities.Extensions;

namespace Technical.Utilities.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Returns the filename without an extension
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtention(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            return fileInfo.Name.Replace(fileInfo.Extension, string.Empty);
        }

        /// <summary>
        /// Checks if the file exists and is not locked by another process
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsAccessible(string fileName)
        {
            bool isAccessible = true;
            FileInfo fileInfo = null;

            try
            {
                fileInfo = new FileInfo(fileName);
            }
            catch
            {
                return false;
            }

            if (!fileInfo.Directory.Exists)
            {
                isAccessible = false;
            }
            else if (fileInfo.Exists)
            {
                isAccessible = fileInfo.IsWriteable();
            }

            return isAccessible;
        }

        /// <summary>
        /// Checks if the path of a file exists
        /// </summary>
        /// <param name="fileName">Full Filename including path</param>
        /// <param name="msg">In case of an error: Message of thrown exception. Otherwise null</param>
        /// <returns>true, if path exists or was successfully created.</returns>
        public static bool CheckPath(string fileName, out string msg)
        {
            FileInfo fInfo = null;
            try
            {
                fInfo = new FileInfo(fileName);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }

            msg = null;
            return fInfo.Directory.Exists;
        }

        /// <summary>
        /// Checks if the path of a file exists. If not, try to create it.
        /// Hint: A similar function, but with User-Dialog, can be found under Manor.Windows.Helper.FileHelperDialog
        /// </summary>
        /// <param name="fileName">Full Filename including path</param>
        /// <param name="msg">In case of an error: Message of thrown exception. Otherwise null</param>
        /// <returns>true, if path exists or was successfully created.</returns>
        public static bool CreatePath(string fileName, out string msg)
        {
            var fInfo = new FileInfo(fileName);
            try
            {
                fInfo = new FileInfo(fileName);
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }

            if (!fInfo.Directory.Exists)
            {
                try
                {
                    fInfo.Directory.Create();
                }
                catch (Exception e)
                {
                    msg = e.Message;
                    return false;
                }
            }

            msg = null;
            return true;
        }
    }
}