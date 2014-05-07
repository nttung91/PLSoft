using Windows.Core.BaseForms;

namespace Windows.Core.Forms.QuickView
{
    internal partial class FrmQuickView : FrmReadOnlyBase
    {
        private object _businessObject;

        public FrmQuickView(object businessObject)
        {
            _businessObject = businessObject;
            InitializeComponent();
            Text = "QuickView [" + _businessObject.GetType().ToString() + "]";
            InitBindings();
        }

        protected override void InitBindings()
        {
            pgcQuick.SelectedObject = _businessObject;
        }
    }
}