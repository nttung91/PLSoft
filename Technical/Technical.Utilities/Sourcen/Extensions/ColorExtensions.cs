using System;
using System.Drawing;

namespace Technical.Utilities.Extensions
{
    public static class ColorExtensions
    {
        public static Color FromRgb(this Color color, string colorString)
        {
            Color newColor = Color.Transparent;

            if (IsKnownColor(colorString))
            {
                newColor = Color.FromName(colorString);
            }
            else
            {
                string[] rgb = colorString.Split(",");

                int red = Convert.ToInt32(rgb[0]);
                int green = Convert.ToInt32(rgb[1]);
                int blue = Convert.ToInt32(rgb[2]);

                newColor = Color.FromArgb(red, green, blue);
            }

            return newColor;
        }

        private static bool IsKnownColor(string colorString)
        {
            bool isKnownColor = false;

            foreach (string colorName in Enum.GetNames(typeof (KnownColor)))
            {
                if (colorName == colorString)
                {
                    isKnownColor = true;
                }
            }

            return isKnownColor;
        }
    }
}