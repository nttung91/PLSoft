using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Technical.Imaging.Properties;

namespace Technical.Imaging
{
    public class ImageSizeChecker
    {
        public static int MaxSize
        {
            get { return Settings.Default.MaxImageSizeInKB; }
        }

        public static int MaxSizeInByte
        {
            get { return Settings.Default.MaxImageSizeInKB*1024; }
        }

        public static int GetSizeInKilobyte(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return 0;

            return byteArray.Length/1024;
        }

        public static bool MaxSizeExceeded(byte[] byteArray)
        {
            int size = GetSizeInKilobyte(byteArray);
            return size > Settings.Default.MaxImageSizeInKB;
        }

        public static bool MaxSizeExceeded(Image image)
        {
            long jpegByteSize;
            using (var ms = new MemoryStream()) // estimatedLength can be original fileLength
            {
                image.Save(ms, ImageFormat.Jpeg); // save image to stream in Jpeg format
                jpegByteSize = ms.Length;
            }

            return ((jpegByteSize/1024) > MaxSize);
        }
    }
}