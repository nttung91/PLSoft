using System;
using System.IO;
using Technical.Imaging.Properties;

namespace Technical.Imaging
{
    /// <summary>
    /// Hilfsklasse zum Bearbeiten eines Bildes in einem externen Programm (e.d.R. Paint.Net)
    /// </summary>
    public class PaintNetHelper
    {
        public static bool EditPicture()
        {
            byte[] dummy = null;
            return EditPicture(ref dummy);
        }

        public static bool EditPicture(ref byte[] picture)
        {
            string fileName = null;
            if (picture != null)
            {
                fileName = Path.GetTempPath() + @"\image.jpg";
                if (!TryToSaveFileFromBitmap(picture, fileName, out fileName))
                    return false;
            }
            bool wait = (picture != null);
            var processLauncher = new ProcessLauncher(Settings.Default.FavoritePaintProgram, fileName, wait);
            processLauncher.Run();

            if (picture != null)
            {
                // File zurückladen
                picture = ImageLoader.GetByteFromFile(fileName);
                try
                {
                    DeleteTempPicFiles(fileName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }

        private static bool TryToSaveFileFromBitmap(byte[] picture, string fileName, out string resFileName)
        {
            if (picture == null) throw new ApplicationException("Bild ist leer");

            int errorCnt = 0;
            resFileName = fileName;
            do
            {
                try
                {
                    File.WriteAllBytes(resFileName, picture);
                    return true;
                }
                catch (IOException)
                {
                    resFileName =
                        Path.GetDirectoryName(fileName) + @"\" +
                        Path.GetFileNameWithoutExtension(fileName) + "_" + errorCnt.ToString() +
                        Path.GetExtension(fileName);
                }

                if (errorCnt++ > 10) return false;
            } while (true);
        }

        private static void DeleteTempPicFiles(string fileName)
        {
            string dir = Path.GetDirectoryName(fileName);
            var di = new DirectoryInfo(dir);
            string searchPattern =
                Path.GetFileNameWithoutExtension(fileName) + "*" + Path.GetExtension(fileName);
            FileInfo[] fileInfos = di.GetFiles(searchPattern);
            foreach (FileInfo fileInfo in fileInfos)
            {
                try
                {
                    fileInfo.Delete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}