using System.Drawing;
using PhuLiNet.Plugin.Menu;
using Techical.Icons;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class MenuItemImageHandler
    {
        public enum EImageSize
        {
            Small,
            Middle,
            Large
        }

        private readonly EImageSize _imageSize;
        private readonly Bitmap _defaultImage;
        private readonly Bitmap _oracleFormsImage;
        private readonly Bitmap _folder;

        public MenuItemImageHandler(EImageSize imageSize)
        {
            _imageSize = imageSize;

            if (_imageSize == EImageSize.Small)
            {
                _defaultImage = IconManager.GetBitmap(EIcons.window_info_16);
                _oracleFormsImage = IconManager.GetBitmap(EIcons.oracleforms_16);
                _folder = IconManager.GetBitmap(EIcons.folder_16);
            }
            else if (_imageSize == EImageSize.Middle)
            {
                _defaultImage = IconManager.GetBitmap(EIcons.window_info_24);
                _oracleFormsImage = IconManager.GetBitmap(EIcons.oracleforms_24);
                _folder = IconManager.GetBitmap(EIcons.folder_24);
            }
            else if (_imageSize == EImageSize.Large)
            {
                _defaultImage = IconManager.GetBitmap(EIcons.window_info_32);
                _oracleFormsImage = IconManager.GetBitmap(EIcons.oracleforms_32);
                _folder = IconManager.GetBitmap(EIcons.folder_32);
            }
        }

        public Image GetImage(IMenuItem menuItem)
        {
            var image = menuItem.Image ?? _defaultImage;
            return image;
        }

        public Image GetImageForFolder(IMenuItem menuItem)
        {
            var image = menuItem.Image ?? _folder;
            return image;
        }
    }
}