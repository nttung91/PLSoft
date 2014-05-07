using System.Windows.Forms;
using PhuLiNet.Business.Common.Navigator.Interfaces;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.Navigator
{
    public partial class FrmNavigator : FrmReadOnlyBase
    {
        public FrmNavigator()
        {
            InitializeComponent();
        }

        public void BuildTree<T>(IBuildBusinessObjectTree<T> treeBuilder, T businessObject)
        {
            ucNavigator.BuildTree<T>(treeBuilder, businessObject);
            Show();
        }

        private static FrmNavigator _instance;

        public static FrmNavigator GetInstance()
        {
            if (_instance == null)
                _instance = new FrmNavigator();

            return _instance;
        }

        public static void ClearInstance()
        {
            if (_instance != null)
            {
                _instance.Close();
                _instance.Dispose();
                _instance = null;
            }
        }

        private void FrmNavigator_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}