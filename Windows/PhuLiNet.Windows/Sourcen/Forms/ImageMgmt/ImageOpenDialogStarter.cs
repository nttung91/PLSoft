using System.Windows.Forms;
using Technical.Imaging.Validation;
using Technical.Settings;

namespace Windows.Core.Forms.ImageMgmt
{
    internal class ImageOpenDialogStarter
    {
        public static DialogResult Execute(OpenFileDialog ofdImage)
        {
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");

            ofdImage.InitialDirectory = section.GetSetting("ImageLoadPath", @"u:\").Value;

            ImageValidator imageValidator = ImageValidator.GetInstance();
            ofdImage.Filter = imageValidator.GetSupportedImagesFilter();
            ofdImage.FilterIndex = 1;

            DialogResult dialogResult = ofdImage.ShowDialog();
            SaveImageLoadPath(ofdImage);

            return dialogResult;
        }

        private static void SaveImageLoadPath(OpenFileDialog ofdImage)
        {
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");

            if (ofdImage.InitialDirectory != section.GetSetting("ImageLoadPath", @"u:\").Value)
            {
                section.GetSetting<string>("ImageLoadPath").Value = ofdImage.InitialDirectory;
                settingsProvider.SaveSection(section);
            }
        }
    }
}