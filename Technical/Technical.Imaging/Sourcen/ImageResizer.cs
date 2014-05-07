using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Technical.Imaging
{
    /// <summary>
    /// Funktionen zur Bilder Grössenänderung
    /// </summary>
    public class ImageResizer
    {
        /// <summary>
        /// Eine Bitmap unter Einbehaltung der Ratio auf eine bestimmte Höhe skalieren.
        /// </summary>
        /// <param name="bitmap">Zu skalierende Bitmap</param>
        /// <param name="height">Gewünschte Höhe</param>
        /// <returns></returns>
        public static Bitmap ResizeBitmapToHeight(Bitmap bitmap, int height)
        {
            return ResizeBitmapKeepRatio(bitmap, int.MaxValue, height, ResizeType.Zoom);
        }

        /// <summary>
        /// Eine Bitmap unter Einbehaltung der Ratio auf eine bestimmte Breite skalieren.
        /// </summary>
        /// <param name="bitmap">Zu skalierende Bitmap</param>
        /// <param name="width"></param>
        /// <returns>Skalierte Bitmap</returns>
        public static Bitmap ResizeBitmapToWidth(Bitmap bitmap, int width)
        {
            return ResizeBitmapKeepRatio(bitmap, width, int.MaxValue, ResizeType.Zoom);
        }

        /// <summary>
        /// Skaliert das Bild unter Einbehaltung der Ratio.
        /// </summary>
        /// <param name="bitmap">Zu skalierende Bitmap</param>
        /// <param name="maxHeight">Maximale Höhe</param>
        /// <param name="maxWidth">Maximale Breite</param>
        /// <param name="resizeType"></param>
        /// <returns>Skalierte Bitmap</returns>
        public static Bitmap ResizeBitmapKeepRatio(Bitmap bitmap, int maxWidth, int maxHeight, ResizeType resizeType)
        {
            if (bitmap == null)
                return null;

            double imageHeight = (bitmap.Height);
            double imageWidth = (bitmap.Width);

            if (imageHeight == 0 || imageWidth == 0) return bitmap;

            double scaleW = maxWidth/imageWidth;
            double scaleH = maxHeight/imageHeight;

            // Auf jeden Fall soweit verkleinern, dass keine der beiden max-Werte überschritten wird,
            // deswegen den kleineren Scale-Faktor verwenden.
            double scale = scaleW < scaleH ? scaleW : scaleH;

            // Wenn nicht vergroessert werden soll, brauchen wir nichts machen.
            if (scale >= 1.0 && resizeType == ResizeType.ShrinkOnly)
                return bitmap;
            else
                return ResizeBitmapKeepRatio(bitmap, scale);
        }

        /// <summary>
        /// Eine Bitmap unter Einbehaltung der Ratio skalieren.
        /// </summary>
        /// <param name="bitmap">Zu skalierende Bitmap</param>
        /// <param name="scale">Skalierungsfaktor (1=Originalgrösse)</param>
        /// <returns>Skalierte Bitmap</returns>
        public static Bitmap ResizeBitmapKeepRatio(Bitmap bitmap, double scale)
        {
            if (scale == 1.0 || bitmap == null)
                return bitmap;

            // Bildgrösse anpassen
            var width = (int) Math.Round(bitmap.Width*scale, 0);
            var height = (int) Math.Round(bitmap.Height*scale, 0);

            return ResizeBitmap(bitmap, width, height);
        }

        /// <summary>
        /// Skaliert das Bild ohne Berücksichtigung der Ratio.
        /// </summary>
        /// <param name="bitmap">Zu skalierende Bitmap</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ResizeBitmap(Bitmap bitmap, int width, int height)
        {
            if (width <= 0 || height <= 0)
                return (bitmap);
            var s = new Size(width, height);
            bitmap = new Bitmap(bitmap, s);
            return (bitmap);
        }

        private static double getScale(Size originalSize, Size maxSize)
        {
            double scale = 1.0;
            double maxHeight = Convert.ToDouble(maxSize.Height);
            double maxWidth = Convert.ToDouble(maxSize.Width);
            double imageHeight = Convert.ToDouble(originalSize.Height);
            double imageWidth = Convert.ToDouble(originalSize.Width);

            if (imageWidth == 0 || imageHeight == 0) return scale;

            //Zu breit
            if (imageWidth > maxWidth)
            {
                scale = maxWidth/imageWidth;
                double height = imageHeight*scale;
                // Zu hoch
                if (height > maxHeight)
                {
                    scale = maxHeight/imageHeight;
                }
            }

            else if (imageHeight > maxHeight) //Zu hoch
            {
                scale = maxHeight/imageHeight;
            }
            else // Bild muss vergrössert werden
            {
                scale = maxWidth/imageWidth;
                double height = imageHeight*scale;
                if (height > maxHeight)
                {
                    scale = maxHeight/imageHeight;
                }
            }

            return scale;
        }

        /// <summary>
        /// Gibt ein neues Bitmap in neuer Grösse zurück. Wird mit hoher Qualität umgerechnet
        /// </summary>
        /// <param name="originalBitmap">Originalbild</param>
        /// <param name="newSize">Neue Grösse</param>
        /// <param name="shrinkOnly">keine Bildvergrösserung</param>
        /// <returns>Neues Bild</returns>
        public static Bitmap ResizeBitmapInHighquality(Bitmap originalBitmap, Size newSize, bool shrinkOnly)
        {
            Bitmap newBitmap = null;

            if (originalBitmap != null && newSize.Width > 0 && newSize.Height > 0)
            {
                double scale = getScale(originalBitmap.Size, newSize);

                if (scale > 1.0 && shrinkOnly)
                    scale = 1;

                int destWidth = Convert.ToInt32(Convert.ToDouble(originalBitmap.Size.Width)*scale);
                int destHeight = Convert.ToInt32(Convert.ToDouble(originalBitmap.Size.Height)*scale);

                newBitmap = new Bitmap(destWidth, destHeight);
                Graphics graphic = Graphics.FromImage(newBitmap);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphic.DrawImage(originalBitmap, 0, 0, destWidth, destHeight);
                graphic.Dispose();
                GC.Collect();
            }

            return newBitmap;
        }

        /// <summary>
        /// Gibt ein neues Bitmap in neuer Grösse zurück. Wird mit hoher Qualität umgerechnet
        /// </summary>
        /// <param name="originalBitmap">Originalbild</param>
        /// <param name="newSize">Neue Grösse</param>
        /// <param name="shrinkOnly">keine Bildvergrösserung</param>
        /// <returns>Neues Bild</returns>
        public static Image ResizeBitmapInHighquality(Image originalBitmap, Size newSize, bool shrinkOnly)
        {
            double scale = getScale(originalBitmap.Size, newSize);

            if (scale > 1.0 && shrinkOnly)
                scale = 1;

            int destWidth = Convert.ToInt32(Convert.ToDouble(originalBitmap.Size.Width)*scale);
            int destHeight = Convert.ToInt32(Convert.ToDouble(originalBitmap.Size.Height)*scale);

            Image newBitmap = new Bitmap(destWidth, destHeight);
            Graphics graphic = Graphics.FromImage(newBitmap);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            graphic.DrawImage(originalBitmap, 0, 0, destWidth, destHeight);
            graphic.Dispose();
            GC.Collect();

            return newBitmap;
        }

        /// <summary>
        /// Gibt ein neues Bitmap in maximal erlaubter JPEG-Dateigrösse zurück
        /// </summary>
        /// <returns></returns>
        public static Image ResizeBitmapToMaxFileSize(Image originalBitmap)
        {
            Image newImage;

            if (ImageSizeChecker.MaxSizeExceeded(originalBitmap))
            {
                newImage = ResizeBitmapInHighquality(originalBitmap, CommonImageSizeTypes.size1280x800, false);
            }
            else
            {
                newImage = originalBitmap;
            }

            return newImage;
        }
    }
}