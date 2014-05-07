using Windows.Core.BaseForms;

namespace Windows.Core.Forms.ObjectSpy
{
    internal partial class FrmObjectSpy : FrmEditableBase
    {
        public FrmObjectSpy()
        {
            InitializeComponent();
            _saveOnClosing = false;
        }

        public void SetDataSource(object dataSource)
        {
            gcSpy.DataSource = dataSource;

            gcSpy.RefreshDataSource();
            gcSpy.ForceInitialize();
            gvSpy.BestFitColumns();
        }
    }
}