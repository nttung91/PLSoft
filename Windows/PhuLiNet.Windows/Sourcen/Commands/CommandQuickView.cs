using Windows.Core.Forms.QuickView;

namespace Windows.Core.Commands
{
    public class CommandQuickView : BaseWindowCommand
    {
        private object _objectToView;

        public CommandQuickView(object objectToView)
            : base()
        {
            _objectToView = objectToView;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (_objectToView != null)
            {
                var quickView = new FrmQuickView(_objectToView);
                quickView.Show();
            }
        }

        #endregion
    }
}