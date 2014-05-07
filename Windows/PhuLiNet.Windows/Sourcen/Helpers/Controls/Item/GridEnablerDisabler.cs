using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Windows.Core.Colors;

namespace Windows.Core.Helpers.Controls.Item
{
    internal class GridEnablerDisabler : IControlInfo
    {
        public GridEnablerDisabler(GridControl gridControl)
        {
            _ctrl = gridControl;
            var view = gridControl.MainView as GridView;

            if (view != null)
            {
                InitialRowBackColor = view.Appearance.Row.BackColor;
                InitialFocusedCellRowBackColor = view.Appearance.FocusedCell.ForeColor;
            }
        }

        private GridControl _ctrl;

        public Color InitialRowBackColor { get; private set; }
        public Color InitialFocusedCellRowBackColor { get; private set; }

        #region IControlInfo Members

        public bool Enabled
        {
            set
            {
                foreach (BaseView baseView in _ctrl.Views)
                {
                    if (baseView is GridView)
                    {
                        var gridView = _ctrl.MainView as GridView;
                        SetViewColours(value, gridView);
                    }
                }
            }
        }

        public bool IsControl(Control control)
        {
            return _ctrl == control;
        }

        #endregion

        private void SetViewColours(bool enable, GridView gridView)
        {
            if (enable)
            {
                gridView.Appearance.Row.BackColor = InitialRowBackColor;
                gridView.Appearance.FocusedCell.BackColor = InitialFocusedCellRowBackColor;
            }
            else
            {
                gridView.Appearance.Row.BackColor = ColorRepository.ReadOnlyBackColor;
                gridView.Appearance.FocusedCell.BackColor = ColorRepository.ReadOnlyBackColor;
            }
        }
    }
}