using System.Windows.Forms;

namespace Windows.Core.Helpers
{
    public class KeyHelper
    {
        public static bool IsNewKey(KeyEventArgs e)
        {
            return (e.Modifiers == Keys.Control && e.KeyCode == Keys.N);
        }

        public static bool IsEditKey(KeyEventArgs e)
        {
            return (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter);
        }

        public static bool IsDeleteKey(KeyEventArgs e)
        {
            return (e.Modifiers == Keys.None && e.KeyCode == Keys.Delete);
        }
    }
}