using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Technical.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the System.Drawing class
    /// </summary>
    public static class DrawingExtensions
    {
        /// <summary>
        /// Split an Icon (that contains multiple icons) into an array of Icon each rapresenting a single icons.
        /// </summary>
        /// <param name="icon">Instance value.</param>
        /// <returns>An array of <see cref="System.Drawing.Icon"/> objects.</returns>
        public static Icon[] SplitIcon(this Icon icon)
        {
            if (icon == null)
            {
                throw new ArgumentNullException("Can't split the icon. Icon is null.");
            }

            // Get multiple .ico file image.
            byte[] srcBuf = null;
            using (var stream = new MemoryStream())
            {
                icon.Save(stream);
                srcBuf = stream.ToArray();
            }

            var splitIcons = new List<Icon>();
            {
                const int sICONDIR = 6; // sizeof(ICONDIR) 
                const int sICONDIRENTRY = 16; // sizeof(ICONDIRENTRY)

                int count = BitConverter.ToInt16(srcBuf, 4); // ICONDIR.idCount

                for (int i = 0; i < count; i++)
                {
                    using (var destStream = new MemoryStream())
                    using (var writer = new BinaryWriter(destStream))
                    {
                        // Copy ICONDIR and ICONDIRENTRY.
                        writer.Write(srcBuf, 0, sICONDIR - 2);
                        writer.Write((short) 1); // ICONDIR.idCount == 1;

                        writer.Write(srcBuf, sICONDIR + sICONDIRENTRY*i, sICONDIRENTRY - 4);
                        writer.Write(sICONDIR + sICONDIRENTRY);
                            // ICONDIRENTRY.dwImageOffset = sizeof(ICONDIR) + sizeof(ICONDIRENTRY)

                        // Copy picture and mask data.
                        int imgSize = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY*i + 8);
                            // ICONDIRENTRY.dwBytesInRes
                        int imgOffset = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY*i + 12);
                            // ICONDIRENTRY.dwImageOffset
                        writer.Write(srcBuf, imgOffset, imgSize);

                        // Create new icon.
                        destStream.Seek(0, SeekOrigin.Begin);
                        splitIcons.Add(new Icon(destStream));
                    }
                }
            }

            return splitIcons.ToArray();
        }

        /// <summary>
        /// Serializes the image in an byte array
        /// </summary>
        /// <param name="image">Instance value.</param>
        /// <param name="format">Specifies the format of the image.</param>
        /// <returns>The image serialized as byte array.</returns>
        public static byte[] ToBytes(this Image image, ImageFormat format)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (format == null)
                throw new ArgumentNullException("format");

            using (var stream = new MemoryStream())
            {
                image.Save(stream, format);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Gets the bounds of the image in pixels
        /// </summary>
        /// <param name="image">Instance value.</param>
        /// <returns>A rectangle that has the same hight and width as given image.</returns>
        public static Rectangle GetBounds(this Image image)
        {
            return new Rectangle(0, 0, image.Width, image.Height);
        }

        /// <summary>
        /// Gets the rectangle that sorrounds the given point by a specified distance.
        /// </summary>
        /// <param name="p">Instance value.</param>
        /// <param name="distance">Distance that will be used to surround the point.</param>
        /// <returns>Rectangle that sorrounds the given point by a specified distance.</returns>
        public static Rectangle Surround(this Point p, int distance)
        {
            return new Rectangle(p.X - distance, p.Y - distance, distance*2, distance*2);
        }
    }
}