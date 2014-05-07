using System.Drawing;
using System.Drawing.Imaging;

namespace Technical.Imaging
{
    /// <summary>
    /// Creates a image thumbnail for preview
    /// </summary>
    public class ThumbnailCreator
    {
        private Bitmap _originalBitmap;

        public ThumbnailCreator(byte[] image)
        {
            _originalBitmap = ImageConverter.ConvertToBitmap(image);
        }

        public ThumbnailCreator(Bitmap image)
        {
            _originalBitmap = image;
        }

        public byte[] GetThumbnailAsByte()
        {
            return ImageConverter.ConvertToByteArray(GetThumbnailAsBitmap(), ImageFormat.Jpeg);
        }

        public Bitmap GetThumbnailAsBitmap()
        {
            return ImageResizer.ResizeBitmapInHighquality(_originalBitmap, new Size(200, 200), true);
        }
    }
}