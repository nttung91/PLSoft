using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using DevExpress.XtraBars;
using Technical.Imaging;
using ImageConverter = Technical.Imaging.ImageConverter;

namespace Windows.Core.Forms.ImageMgmt
{
    internal partial class FrmImage : FrmBase
    {
        public byte[] PictureAsBytes
        {
            get { return peBild.EditValue as byte[]; }
            set
            {
                Initialize(value);
                SetSize();
            }
        }

        private Bitmap _originalBild;
        private Bitmap _neuesBild;

        public FrmImage()
        {
            InitializeComponent();
        }

        private void Initialize(byte[] byteArray)
        {
            peBild.EditValue = byteArray;
            if (byteArray != null)
            {
                _neuesBild = ImageConverter.ConvertToBitmap(byteArray);
                _originalBild = ImageConverter.ConvertToBitmap(byteArray);
                ShowStatus(byteArray);
            }
        }

        private static byte[] ConvertImageToByteArray(Bitmap pictureToConvert, ImageFormat format)
        {
            byte[] result = ImageConverter.ConvertToByteArray(pictureToConvert, format);
            return result;
        }

        private void Rotate(RotateFlipType rotateFlipType)
        {
            if (HasNewPicture())
            {
                _neuesBild.RotateFlip(rotateFlipType);
                Byte[] bytes2 = ConvertImageToByteArray(_neuesBild, ImageFormat.Jpeg);
                SetSize();
                peBild.EditValue = bytes2;
            }
        }

        private void SetSize()
        {
            if (HasNewPicture())
            {
                var size = new Size(_neuesBild.Width, _neuesBild.Height);
                var size2 = new Size(_neuesBild.Width + 10, _neuesBild.Height + 60);
                peBild.Size = size;
                Size = size2;
            }
        }

        private void ShowImg()
        {
            if (HasNewPicture())
            {
                Byte[] bytes = ConvertImageToByteArray(_neuesBild, ImageFormat.Jpeg);
                if (bytes != null)
                {
                    SetSize();
                    peBild.EditValue = bytes;
                    ShowStatus(bytes);
                }
            }
        }

        private void ShowStatus(Byte[] bytes2)
        {
            if (HasNewPicture())
            {
                var groesse = (int) (bytes2.Length/1024);
                bsiGroesse.Caption = String.Format("{0} KB", groesse);
                string fileSize = String.Format("{0}X{1}", _neuesBild.Width, _neuesBild.Height);
                bsibmessung.Caption = fileSize;
                if (groesse > 200)
                {
                    bsiGroesse.ImageIndex = 9;
                }
                else
                {
                    bsiGroesse.ImageIndex = -1;
                }
            }
        }

        /// <summary>
        /// Gibt ein neues in der Grösse um Faktor verändert, basierend auf dem aktuellen Bild, nicht Original
        /// Zum Zoomen
        /// </summary>
        private void ResizeImage(double faktor)
        {
            if (HasNewPicture())
            {
                var width = (int) (faktor*_neuesBild.Width);
                var height = (int) (faktor*_neuesBild.Height);
                var size = new Size(width, height);

                _neuesBild = ImageResizer.ResizeBitmapInHighquality(_neuesBild, size, false);
                ShowImg();

                //Nach speicherintensiver Bildbearbeitung Garbage Collector laufen lassen
                GC.Collect();
            }
        }

        /// <summary>
        /// Neues Bild auf der Basis des Originals und einer neuen Breite
        /// Zum setzen einer festen Grösse (Defaults)
        /// </summary>
        private void ResizeImage(Size size, bool shrinkOnly)
        {
            if (HasOriginalPicture())
            {
                _neuesBild = ImageResizer.ResizeBitmapInHighquality(_originalBild, size, shrinkOnly);
                _originalBild = _neuesBild;
                ShowImg();
            }
        }

        private void bbiUebernehmen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Object obj = peBild.EditValue;
            if (obj != null && obj != DBNull.Value && obj is byte[])
            {
                var byteArray = (byte[]) obj;

                if (ImageSizeChecker.MaxSizeExceeded(byteArray))
                {
                    ShowInfo();
                    ResizeImage(CommonImageSizeTypes.size1024x768, true);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        private void bbiAbbrechen_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            PictureAsBytes = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bbiGroesser_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResizeImage(1.1);
        }

        private void bbiKleiner_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResizeImage(.9);
        }

        private void bbi90p_ItemClick(object sender, ItemClickEventArgs e)
        {
            Rotate(RotateFlipType.Rotate270FlipNone);
        }

        private void bbi90m_ItemClick(object sender, ItemClickEventArgs e)
        {
            Rotate(RotateFlipType.Rotate90FlipNone);
        }

        private void bbiStandard_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResizeImage(CommonImageSizeTypes.size800x600, false);
        }

        private void bbiStandard2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResizeImage(CommonImageSizeTypes.size1024x768, false);
        }

        private void bbiStandard3_ItemClick(object sender, ItemClickEventArgs e)
        {
            ResizeImage(CommonImageSizeTypes.size1280x800, false);
        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (sfdBild.ShowDialog() == DialogResult.OK)
                _neuesBild.Save(sfdBild.FileName);
        }

        private void bbiOriginalBild_ItemClick(object sender, ItemClickEventArgs e)
        {
            PictureAsBytes = ImageConverter.ConvertToByteArray(_originalBild, ImageFormat.Jpeg);
        }

        private void FrmBild_Load(object sender, EventArgs e)
        {
            if (PictureAsBytes == null)
            {
                if (imageOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PictureAsBytes = ImageLoader.GetByteFromFile(ofdBild.FileName);
                }
            }
        }

        private void ShowInfo()
        {
            int size = ImageSizeChecker.GetSizeInKilobyte(PictureAsBytes);
            string message = ImageMessages.MessageMaxSizeAutoresize(size);
            MessageBox.ShowInfo(message, "Bildgrösse");
        }

        private bool HasNewPicture()
        {
            return _neuesBild != null;
        }

        private bool HasOriginalPicture()
        {
            return _originalBild != null;
        }
    }
}