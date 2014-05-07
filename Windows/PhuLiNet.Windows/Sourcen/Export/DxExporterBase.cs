using System;
using System.Drawing;
using System.Linq;
using DevExpress.XtraPrinting;

namespace Windows.Core.Export
{
    public abstract class DxExporterBase : ExporterBase
    {
        private static readonly Font ParameterFontNormal = new Font("Tahoma", 8.5f, FontStyle.Regular);
        private static readonly Font ParameterFontBold = new Font("Tahoma", 8.5f, FontStyle.Bold);
        private static readonly Font HeaderFont = new Font("Tahoma", 12f, FontStyle.Bold);
        private static readonly Font DateFont = new Font("Tahoma", 8.5f, FontStyle.Regular);
        public const double Scale = 4.0/3;

        protected override void BeforeCreatingPage(PrintableComponentLink link, ExportOptions options)
        {
            link.CreateReportHeaderArea += (sender, e) => CreateReportHeaderArea(e, options);
        }

        private static void CreateReportHeaderArea(CreateAreaEventArgs e, ExportOptions options)
        {
            var top = 0;
            // Print DateTime
            if (options.ShowDateAndUsername)
            {
                var dateTime = string.Format("{0:G}", DateTime.Now);
                var brick = e.Graph.DrawString(dateTime, Color.Black,
                    new RectangleF(e.Graph.ClientPageSize.Width - 200, 0, 200, 20),
                    BorderSide.None);
                brick.Font = DateFont;
                brick.StringFormat = new BrickStringFormat(StringAlignment.Far);
                var sizeF = GetSizeOfText(dateTime, DateFont);
                top = (int) sizeF.Height;
            }

            if (string.IsNullOrEmpty(options.Title))
            {
                var header2Rect = new RectangleF {Location = new Point(0, top)};
                var sizeF = GetSizeOfText(options.Title, HeaderFont);
                header2Rect.Size = new Size((int) sizeF.Width, (int) sizeF.Height);
                var brick = e.Graph.DrawString(options.Title, Color.Black, header2Rect, BorderSide.None);
                brick.Font = HeaderFont;
                top += (int) sizeF.Height;
            }
            if (options.Parameters.Count > 0)
            {
                top += PrintData("   ", "    ", e, top);

                top = options.Parameters.Aggregate(top,
                    (current, parameter) => WriteParameterValues(parameter.Key, parameter.Value, e, current));

                PrintData("    ", "   ", e, top);
            }
        }

        private static int WriteParameterValues(string key, string value, CreateAreaEventArgs e, int top)
        {
            var height = top;
            var words = value.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var line = string.Empty;
            var isFirstLine = true;

            foreach (var word in words)
            {
                if (GetSizeOfText(line + word, ParameterFontNormal).Width > 700)
                {
                    var keyData = isFirstLine ? key : " ";
                    height += PrintData(keyData, line, e, height);
                    line = word + " ";
                    isFirstLine = false;
                }
                else
                {
                    line += word + " ";
                }
            }
            if (!string.IsNullOrEmpty(line))
            {
                var keyData = isFirstLine ? key : " ";
                height += PrintData(keyData, line, e, height);
            }

            return height;
        }

        private static SizeF GetSizeOfText(string text, Font font)
        {
            return BrickGraphics.MeasureString(text, font, 1000,
                StringFormat.GenericTypographic, GraphicsUnit.Display);
        }

        private static int PrintData(string key, string value, CreateAreaEventArgs e, int top)
        {
            // Draw header
            var header2Rect = new RectangleF {Location = new Point(0, top)};
            var sizeF = GetSizeOfText(key, ParameterFontBold);
            header2Rect.Size = new Size((int) (sizeF.Width*Scale), (int) sizeF.Height);
            var brick = e.Graph.DrawString(key, Color.Black, header2Rect, BorderSide.None);
            brick.Font = ParameterFontBold;
            var height = (int) sizeF.Height;

            // Draw header value
            header2Rect.Location = new Point((int) Math.Max(200, sizeF.Width), top);
            sizeF = GetSizeOfText(value, ParameterFontNormal);
            header2Rect.Size = new Size((int) (sizeF.Width), (int) sizeF.Height);
            brick = e.Graph.DrawString(value, Color.Black, header2Rect, BorderSide.None);
            brick.Font = ParameterFontNormal;

            return height;
        }
    }
}