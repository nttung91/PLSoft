using System.Drawing;
using System.Drawing.Text;

namespace Technical.Imaging
{
    public class BarcodeImage
    {
        public static Bitmap GetBarcodeAsBitmap(string barcode, string font)
        {
            var bmBarcode = new Bitmap(1, 1);
            var barcodeFont = new Font(font, 60, FontStyle.Regular, GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(bmBarcode);
            SizeF barcodeSize = graphics.MeasureString(barcode, barcodeFont);
            bmBarcode = new Bitmap(bmBarcode, barcodeSize.ToSize());

            graphics = Graphics.FromImage(bmBarcode);

            graphics.Clear(Color.White);
            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            graphics.DrawString(barcode, barcodeFont, new SolidBrush(Color.Black), 0, 0);
            graphics.Flush();

            barcodeFont.Dispose();
            graphics.Dispose();

            return bmBarcode;
        }
    }
}