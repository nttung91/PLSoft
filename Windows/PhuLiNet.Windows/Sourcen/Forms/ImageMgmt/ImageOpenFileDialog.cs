using System.ComponentModel;
using System.Windows.Forms;
using Technical.Imaging;
using Technical.Imaging.Validation;

namespace Windows.Core.Forms.ImageMgmt
{
    public partial class ImageOpenFileDialog : Component
    {
        public ImageOpenFileDialog()
        {
            InitializeComponent();
        }

        public byte[] PictureAsBytes { get; set; }

        public ImageOpenFileDialog(IContainer container)
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
    }
}