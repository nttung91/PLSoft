using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.DxExtensions
{
    public static class RepositoryItemImageComboBoxExtension
    {
        private static Size _imageSize = new Size(15, 15);

        public static void DrawFilterItems(this RepositoryItemImageComboBox riImageComboBox,
            ColumnFilterPopup.FilterComboBox filterComboBox, ListBoxDrawItemEventArgs eventArgs)
        {
            var filterItem = eventArgs.Item as FilterItem;
            var imageComboBoxItem = GetImageComboBoxItem(riImageComboBox, filterItem);
            if (imageComboBoxItem == null) return;

            FillBackground(eventArgs);
            DrawImage(eventArgs, imageComboBoxItem);
            DrawDescription(eventArgs, imageComboBoxItem);
            eventArgs.Handled = true;
        }

        private static ImageComboBoxItem GetImageComboBoxItem(RepositoryItemImageComboBox riImageComboBox,
            FilterItem filterItem)
        {
            return riImageComboBox.Items.GetItem(filterItem.Value);
        }

        private static void FillBackground(ListBoxDrawItemEventArgs e)
        {
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
        }

        private static void DrawImage(ListBoxDrawItemEventArgs e, ImageComboBoxItem imageComboBoxItem)
        {
            var image = GetImage(imageComboBoxItem);
            if (image == null) return;

            var imageRectangle = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, _imageSize.Width, _imageSize.Height);
            e.Graphics.DrawImage(image, imageRectangle);
        }

        private static Image GetImage(ImageComboBoxItem imageComboBoxItem)
        {
            var imageList = imageComboBoxItem.Images as ImageList;
            return imageList != null ? imageList.Images[imageComboBoxItem.ImageIndex] : null;
        }

        private static void DrawDescription(ListBoxDrawItemEventArgs e, ImageComboBoxItem imageComboBoxItem)
        {
            var textRectangle = e.Bounds;
            textRectangle.X += _imageSize.Width + 3;
            e.Appearance.DrawString(e.Cache, imageComboBoxItem.Description, textRectangle);
        }
    }
}