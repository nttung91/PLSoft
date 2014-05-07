using System.ComponentModel;
using System.Windows.Forms;
using Technical.Imaging;
using Windows.Core.Commands;

namespace Windows.Core.Forms.ImageMgmt
{
    public partial class ClipboardImagePasterWithCheck : Component
    {
        public ClipboardImagePasterWithCheck()
        {
            InitializeComponent();
        }

        public byte[] PictureAsBytes { get; set; }

        public ClipboardImagePasterWithCheck(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public bool Execute()
        {
            bool result;
            if (ImageClipboardHelper.ContainsImage())
            {
                PictureAsBytes = ImageClipboardHelper.GetByteArray();
                if (ImageSizeChecker.MaxSizeExceeded(PictureAsBytes))
                {
                    ShowInfo();
                    result = StartImageViewer();
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                MessageBox.ShowError("Fehler", "Kein Bild in der Zwischenablage", "Bild einfügen");
                result = false;
            }

            return result;
        }

        private void ShowInfo()
        {
            int size = ImageSizeChecker.GetSizeInKilobyte(PictureAsBytes);
            MessageBox.ShowInfo(ImageMessages.MessageMaxSizeManualResize(size), "Bildgrösse");
        }

        private bool StartImageViewer()
        {
            var starter = new CommandStartFrmImage(PictureAsBytes);
            starter.Execute();
            PictureAsBytes = starter.Picture;
            return starter.DialogResult == DialogResult.OK;
        }
    }
}