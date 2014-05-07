using System.Drawing;
using System.Drawing.Imaging;
using Technical.Imaging.Properties;

namespace Technical.Imaging
{
    /// <summary>
    /// Eine Singleton Klasse die ein Dummy-Bild (als Platzhalter) zurückgibt, wenn kein Bild vorhanden ist
    /// </summary>
    public class NoImage
    {
        private Bitmap _dummy;
        private byte[] _dummyByte;

        private static NoImage _instance;

        public Bitmap DummyBitmap
        {
            get { return _dummy; }
        }

        public byte[] DummyBitmapAsByte
        {
            get { return _dummyByte; }
        }

        /// <summary>
        /// Dummy-Bild nur einmal  erzeugen, es wird immer die gleiche Instanz zurückgegeben
        /// </summary>
        private NoImage()
        {
            _dummy = Resources.NoImage;
            _dummyByte = ImageConverter.ConvertToByteArray(_dummy, ImageFormat.Png);
        }

        public static NoImage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NoImage();
            }

            return _instance;
        }
    }
}