namespace Technical.Imaging.Validation
{
    internal class ImageFormat
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DisplayName { get; set; }

        public ImageFormat(string name, string extension, string displayName)
        {
            Name = name;
            Extension = extension;
            DisplayName = displayName;
        }

        internal static ImageFormat Jpeg
        {
            get { return new ImageFormat("Jpeg", "jpg", "Jpeg-Images"); }
        }

        internal static ImageFormat Bitmap
        {
            get { return new ImageFormat("Bitmap", "bmp", "Bitmap-Images"); }
        }

        internal static ImageFormat Gif
        {
            get { return new ImageFormat("Gif", "gif", "Gif-Images"); }
        }

        internal static ImageFormat Png
        {
            get { return new ImageFormat("Png", "png", "Png-Images"); }
        }

        internal static ImageFormat Wmf
        {
            get { return new ImageFormat("Wmf", "wmf", "Wmf-Images"); }
        }

        internal static ImageFormat Tiff
        {
            get { return new ImageFormat("Tiff", "tif", "Tiff-Images"); }
        }

        internal static ImageFormat Icon
        {
            get { return new ImageFormat("Icon", "ico", "Icons"); }
        }

        internal static ImageFormat All
        {
            get { return new ImageFormat("*", "*", "Alle Dateien"); }
        }
    }
}