using System.Drawing;
using DevExpress.Utils;

namespace Windows.Core.DxExtensions
{
    public static class AppearanceExtension
    {
        public static void SetAppearanceLightGreen(this AppearanceObject appearance, bool gradient = true)
        {
            SetAppearance(appearance, Color.LightGreen, gradient);
        }

        public static void SetAppearanceLightYellow(this AppearanceObject appearance, bool gradient = true)
        {
            SetAppearance(appearance, Color.LightYellow, gradient);
        }

        public static void SetAppearanceGrey(this AppearanceObject appearance, int grey, bool gradient = true)
        {
            SetAppearance(appearance, Color.FromArgb(grey, grey, grey), gradient);
        }

        public static void SetAppearanceFromArgb(this AppearanceObject appearance, int red, int green, int blue,
            bool gradient = true)
        {
            SetAppearance(appearance, Color.FromArgb(red, green, blue), gradient);
        }

        public static void SetAppearanceFromColor(this AppearanceObject appearance, Color color, bool gradient = true)
        {
            SetAppearance(appearance, color, gradient);
        }

        public static void SetAppearanceFromColorName(this AppearanceObject appearance, string colorName,
            bool gradient = true)
        {
            SetAppearance(appearance, Color.FromName(colorName), gradient);
        }

        public static void SetAppearanceFromColorName(this AppearanceObject appearance, KnownColor color,
            bool gradient = true)
        {
            SetAppearance(appearance, Color.FromKnownColor(color), gradient);
        }

        private static void SetAppearance(this AppearanceObject appearance, Color color, bool gradient)
        {
            if (gradient)
            {
                appearance.BackColor2 = color;
                appearance.BackColor = Color.White;
                appearance.ForeColor = Color.Black;
            }
            else
            {
                appearance.BackColor = color;
            }
        }
    }
}