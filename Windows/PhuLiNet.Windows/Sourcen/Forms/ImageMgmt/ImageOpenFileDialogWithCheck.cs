using System.ComponentModel;
using System.Windows.Forms;
using Windows.Core.Commands;
using Windows.Core.Forms.ImageMgmt;
using Technical.Imaging;
using Technical.Imaging.Validation;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Forms.ImageMgmt
{
    public partial class ImageOpenFileDialogWithCheck : Component
    {
        public ImageOpenFileDialogWithCheck()
        {
            InitializeComponent();
        }

        public byte[] PictureAsBytes { get; set; }

        public ImageOpenFileDialogWithCheck(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public string FileName
        {
            get { return ofdImage.FileName; }
        }

        public DialogResult ShowDialog()
        {
            DialogResult dialogResult = ImageOpenDialogStarter.Execute(ofdImage);
            if (dialogResult == DialogResult.OK)
            {
                if (ImageValidator.GetInstance().IsValidImage(ofdImage.FileName))
                {
                    PictureAsBytes = ImageLoader.GetByteFromFile(ofdImage.FileName);

                    if (ImageSizeChecker.MaxSizeExceeded(PictureAsBytes))
                    {
                        ShowInfo();
                        dialogResult = StartImageViewer(dialogResult);
                    }
                }
                else
                {
                    MessageBox.ShowInfo(Windows.Core.Localization.ImageMessages.UnkownImageFileFormatMsg,
                        Windows.Core.Localization.ImageMessages.UnkownImageFileFormat);
                    dialogResult = DialogResult.Cancel;
                }
            }
            return dialogResult;
        }

        private void ShowInfo()
        {
            int size = ImageSizeChecker.GetSizeInKilobyte(PictureAsBytes);
            MessageBox.ShowInfo(ImageMessages.MessageMaxSizeManualResize(size), "Bildgrösse");
        }

        private DialogResult StartImageViewer(DialogResult dialogResult)
        {
            var starter = new CommandStartFrmImage(PictureAsBytes);
            starter.Execute();
            dialogResult = starter.DialogResult;
            PictureAsBytes = starter.Picture;

            return dialogResult;
        }
    }
}