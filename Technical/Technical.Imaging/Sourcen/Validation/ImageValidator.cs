using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Technical.Imaging.Validation
{
    public class ImageValidator
    {
        private List<ImageFormat> _supportedImageFormats;

        private ImageValidator()
        {
        }

        private void AddImageFormats()
        {
            _supportedImageFormats = new List<ImageFormat>();
            _supportedImageFormats.Add(ImageFormat.Jpeg);
            _supportedImageFormats.Add(ImageFormat.Bitmap);
            _supportedImageFormats.Add(ImageFormat.Png);
            _supportedImageFormats.Add(ImageFormat.Gif);
            _supportedImageFormats.Add(ImageFormat.Wmf);
            _supportedImageFormats.Add(ImageFormat.Tiff);
            _supportedImageFormats.Add(ImageFormat.Icon);
            _supportedImageFormats.Add(ImageFormat.All);
        }

        public string GetSupportedImagesFilter()
        {
            string filter = null;
            int counter = 0;

            foreach (ImageFormat imageFormat in _supportedImageFormats)
            {
                counter++;

                if (counter > 1)
                {
                    filter += "|";
                }

                filter += string.Format("{0} (*.{1})|*.{1}", imageFormat.DisplayName, imageFormat.Extension);
            }

            return filter;
        }

        public bool IsValidImage(string filename)
        {
            bool isValid = false;
            Image newImage = null;

            try
            {
                newImage = Image.FromFile(filename);
                isValid = true;
            }
            catch (OutOfMemoryException)
            {
                // Image.FromFile will throw this if file is invalid.
                // Don't ask me why.
                isValid = false;
            }
            finally
            {
                if (newImage != null)
                {
                    newImage.Dispose();
                    newImage = null;
                }
            }

            return isValid;
        }

        public bool IsValidImage(byte[] imageData)
        {
            bool isValid = false;
            MemoryStream imgStream = null;
            Image newImage = null;

            if (imageData != null)
            {
                try
                {
                    imgStream = new MemoryStream(imageData);
                    newImage = Image.FromStream(imgStream);

                    isValid = true;
                }
                catch (ArgumentException)
                {
                    // Image.FromStream will throw this if byte[] is invalid.
                    // Don't ask me why.
                    isValid = false;
                }
                finally
                {
                    if (imgStream != null)
                    {
                        imgStream.Close();
                        imgStream.Dispose();
                    }
                    if (newImage != null)
                    {
                        newImage.Dispose();
                        newImage = null;
                    }
                }
            }

            return isValid;
        }

        public static ImageValidator GetInstance()
        {
            var validator = new ImageValidator();
            validator.AddImageFormats();
            return validator;
        }
    }
}