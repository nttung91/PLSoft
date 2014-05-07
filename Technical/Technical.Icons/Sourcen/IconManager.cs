using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Resources;

namespace Techical.Icons
{
    public static class IconManager
    {
        public static Bitmap GetBitmap(string iconName)
        {
            return (Bitmap) IconLibrary.ResourceManager.GetObject(iconName);
        }

        public static Icon GetIcon(string iconName)
        {
            Icon icon = null;
            object resourceItem = IconLibrary.ResourceManager.GetObject(iconName);
            if (resourceItem != null)
            {
                if (resourceItem is Bitmap)
                {
                    icon = Icon.FromHandle(((Bitmap) resourceItem).GetHicon());
                }
                else if (resourceItem is Icon)
                {
                    icon = (Icon) resourceItem;
                }
            }

            return icon;
        }

        public static Bitmap GetBitmap(EIcons icon)
        {
            return GetBitmap(icon.ToString());
        }

        public static Icon GetIcon(EIcons icon)
        {
            return GetIcon(icon.ToString());
        }

        public static bool HasIcon(string iconName)
        {
            return (IconLibrary.ResourceManager.GetObject(iconName) != null);
        }

        public static bool HasIcon(EIcons icon)
        {
            return HasIcon(icon.ToString());
        }

        public static IList<IconInfo> GetBitmaps()
        {
            IList<IconInfo> iconList = new List<IconInfo>();

            ResourceSet resourceSet = IconLibrary.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true,
                true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                if (entry.Value is Bitmap)
                {
                    iconList.Add(new IconInfo {Icon = (Bitmap) entry.Value, Name = entry.Key.ToString()});
                }
            }

            return iconList;
        }
    }
}