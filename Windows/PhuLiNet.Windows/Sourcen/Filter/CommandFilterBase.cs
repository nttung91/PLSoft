using Windows.Core.BaseForms;
using PhuLiNet.Business.Common.Interfaces;
using Windows.Core.BaseForms;
using Windows.Core.Commands;

namespace Windows.Core.Filter
{
    public class CommandFilterBase<T> : BaseDialogCommand where T : FrmBase, IFrmFilterEnabled, new()
    {
        public IFilterSelection Selection;

        #region IApplicationCommand Members

        public override void Execute()
        {
            var frmFilter = WindowManager.PrepareShowDialog<T>(false);
            if (frmFilter == null) return;
            frmFilter.Selection = Selection;
            frmFilter.LoadBusiness();
            DialogResult = frmFilter.ShowDialog();
            Selection = frmFilter.Selection;
            frmFilter.Dispose();
        }

        #endregion
    }
}