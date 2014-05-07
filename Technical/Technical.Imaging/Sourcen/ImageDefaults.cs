namespace Technical.Imaging
{
    public static class ImageDefaults
    {
        #region static Fields

        private static int _preview_picture_height = 180;
        private static int _preview_picture_width = 180;

        #endregion

        #region static Properties

        public static int PreviewPictureWidth
        {
            get { return _preview_picture_width; }
            set { _preview_picture_width = value; }
        }

        public static int PreviewPictureHeight
        {
            get { return _preview_picture_height; }
            set { _preview_picture_height = value; }
        }

        #endregion
    }
}