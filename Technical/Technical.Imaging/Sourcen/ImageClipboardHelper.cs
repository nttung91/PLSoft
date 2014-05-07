using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Technical.Imaging
{
    /// <summary>
    /// Hilfsfunktionen für Bilder Copy/Paste aus Clipboard
    /// </summary>
    public static class ImageClipboardHelper
    {
        public static bool ContainsImage()
        {
            return Clipboard.ContainsImage();
        }

        public static byte[] GetByteArray()
        {
            Bitmap image = GetBitmapFromClipboard();
            if (image == null)
                return null;

            return ImageConverter.ConvertToByteArray(image, ImageFormat.Jpeg);
        }

        public static Bitmap GetBitmapFromClipboard()
        {
            Image image = null;
            if (ContainsImage())
            {
                Cursor.Current = Cursors.WaitCursor;
                image = Clipboard.GetImage();
                Cursor.Current = Cursors.Default;
            }
            return image as Bitmap;
        }
    }
}