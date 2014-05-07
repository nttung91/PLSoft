namespace Windows.Core.Forms.ImageMgmt
{
    internal class ImageMessages
    {
        public static string MessageMaxSizeAutoresize(int size)
        {
            return MessageTooBig(size) +
                   System.Environment.NewLine +
                   Windows.Core.Localization.ImageMessages.ResizeAutomatically;
        }

        public static string MessageMaxSizeManualResize(int size)
        {
            return MessageTooBig(size) +
                   System.Environment.NewLine +
                   Windows.Core.Localization.ImageMessages.ResizeManually;
        }

        private static string MessageTooBig(int size)
        {
            return string.Format(Windows.Core.Localization.ImageMessages.FileTooBig, size);
        }
    }
}