using System.Windows.Forms;

namespace Windows.Core.Helpers.Controls
{
    internal interface IControlInfo
    {
        bool IsControl(Control control);
        bool Enabled { set; }
    }
}