using System.Windows.Forms;
using DevExpress.XtraLayout;

namespace Windows.Core.Helpers.XtraLayout
{
    public class FormsLayoutControlInfos : IFormsLayoutControlInfos
    {
        public LayoutControl LayoutControl { get; set; }
        public string LayoutFileName { get; set; }
        public string RegistryLayoutName { get; set; }
        public Form Form { get; set; }


        public FormsLayoutControlInfos(LayoutControl layoutControl, string layoutFileName, string registryLayoutName,
            Form form)
        {
            LayoutControl = layoutControl;
            LayoutFileName = layoutFileName;
            Form = form;
            RegistryLayoutName = registryLayoutName;
        }
    }
}