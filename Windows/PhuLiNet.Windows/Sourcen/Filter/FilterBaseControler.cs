using System.Windows.Forms;
using Windows.Core.BaseForms;
using PhuLiNet.Business.Common.Interfaces;
using Windows.Core.BaseForms;
using Windows.Core.Commands;
using Windows.Core.Localization;
using Windows.Core.WindowsManager;

namespace Windows.Core.Filter
{
    // TF = Type of Filter-Form (Selection)
    // TV = Type of View-Form (Data-Display)
    public class FilterBaseControler<TF, TV>
        where TF : FrmBase, IFrmFilterEnabled, new()
        where TV : FrmBase, IFrmFilterEnabled, new()
    {
        private IFrmFilterEnabled _view;
        private readonly IFilterSelection _oldModel;
        private IFilterSelection _model;
        private bool _selectionOk;

        public FilterBaseControler(IFilterSelection model)
        {
            _oldModel = model;
            _model = _oldModel.Clone();
        }

        public void ShowFilterView()
        {
            var commandStartSelection = new CommandFilterBase<TF> {Selection = _model};
            CommandExecutor.Execute(commandStartSelection);
            _selectionOk = commandStartSelection.DialogResult == DialogResult.OK;
            if (!_selectionOk) return;
            _model = commandStartSelection.Selection;
        }

        public void ShowDataView(IWindowManager windowManager)
        {
            if (_model.SeperateWindow)
            {
                // new View
                _view = windowManager.PrepareShowWindow<TV>(CommandRes.DataLoading, true, false);
            }
            else if (_oldModel.WindowId == 0)
            {
                // find any View
                _view = windowManager.FindWindowInstance<TV>();
            }
            else
            {
                // reuse OldModel
                _oldModel.Overwrite(_model);
                _model = _oldModel;
                // find View by ID
                _view = windowManager.FindWindowInstanceByData<TV>(_model.WindowId);
            }

            if (_view == null)
            {
                // no View found
                _view = windowManager.PrepareShowWindow<TV>(CommandRes.DataLoading, true, false);
            }

            if (!_selectionOk || _model == null) return;
            _view.Selection = _model;
            _model.WindowId = _view.GetHashCode();
            _view.LoadBusiness();
            _view.Show();
        }
    }
}