using System.Windows.Forms;
using DevExpress.XtraLayout;

namespace Windows.Core.Helpers.XtraLayout
{
    public interface IFormsLayoutControlInfos
    {
        LayoutControl LayoutControl { get; set; }
        string LayoutFileName { get; set; }
        string RegistryLayoutName { get; set; }
        Form Form { get; set; }
    }
}