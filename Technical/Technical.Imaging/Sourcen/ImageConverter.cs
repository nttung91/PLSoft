using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Technical.Imaging
{
    /// <summary>
    /// Funktionen zur Bild Konvertierung
    /// </summary>
    public class ImageConverter
    {
        /// <summary>
        /// Konvertiert ein Bitmap-Objekt in einen Byte-Array
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
        public static byte[] ConvertToByteArray(Bitmap originalPicture, ImageFormat imageFormat)
        {
            Debug.Assert(originalPicture != null, "imageToConvert is null");

            byte[] byteArr = null;

            using (var ms = new MemoryStream())
            {
                originalPicture.Save(ms, imageFormat);
                byteArr = ms.ToArray();
            }

            return byteArr;
        }

        /// <summary>
        /// Konvertiert ein Byte-Array in ein Bitmap-Objekt
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static Bitmap ConvertToBitmap(byte[] byteArray)
        {
            if (byteArray == null) return null;

            var memStream = new MemoryStream(byteArray);
            try
            {
                return (Bitmap) Image.FromStream(memStream);
            }
            finally
            {
                // Bitte Memory stream hier nicht schliessen
            }
        }

        /// <summary>
        /// Konvertiert ein Byte-Array in ein Bitmap-Objekt
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static Bitmap ConvertToBitmap(byte[] byteArray, bool dispose)
        {
            if (byteArray == null) return null;

            using (var memStream = new MemoryStream(byteArray))
            {
                return (Bitmap) Image.FromStream(memStream);
            }
        }

        public static Bitmap ConvertToBitmap(string filePath)
        {
            return (Bitmap) Bitmap.FromFile(filePath);
        }
    }
}