using System.Drawing;

namespace Windows.Core.Style
{
    internal class DefaultFont
    {
        internal static Font Get()
        {
            return new Font("Tahoma", 8.25f, FontStyle.Regular);
        }
    }
}