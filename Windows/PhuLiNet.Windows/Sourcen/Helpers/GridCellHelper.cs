using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Helpers
{
    public static class GridCellHelper
    {
        public static void CustomDrawColor(RowCellCustomDrawEventArgs e, Color[] colors)
        {
            //Create the gradient brush
            var brush = new LinearGradientBrush(e.Bounds, Color.White, Color.Black, LinearGradientMode.ForwardDiagonal);

            //Provide custom color blending
            var colorBlend = new ColorBlend();
            colorBlend.Colors = colors;
            colorBlend.Positions = new float[] {0.0f, 0.5f, 1.0f};

            brush.InterpolationColors = colorBlend;

            //Fill the cell's background
            using (brush)
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            e.Appearance.ForeColor = Color.Black;
        }

        public static void CustomDrawYellow(RowCellCustomDrawEventArgs e)
        {
            var colors = new Color[]
            {
                Color.LemonChiffon,
                Color.White,
                Color.Gold
            };

            CustomDrawColor(e, colors);
        }

        public static void CustomDrawGreen(RowCellCustomDrawEventArgs e)
        {
            var colors = new Color[]
            {
                Color.Green,
                Color.White,
                Color.White
            };

            CustomDrawColor(e, colors);
        }

        public static void CustomDrawOrange(RowCellCustomDrawEventArgs e)
        {
            var colors = new Color[]
            {
                Color.Orange,
                Color.White,
                Color.White
            };

            CustomDrawColor(e, colors);
        }

        public static void CustomDrawRed(RowCellCustomDrawEventArgs e)
        {
            var colors = new Color[]
            {
                Color.Red,
                Color.White,
                Color.White
            };

            CustomDrawColor(e, colors);
        }

        public static void CustomDrawReadOnly(RowCellCustomDrawEventArgs e)
        {
            CustomDrawColor(e, new Color[] {Color.White, Color.FromArgb(236, 236, 236), Color.FromArgb(236, 236, 236)});
        }
    }
}