using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PhuLiNet.Business.Common.CslaBase;
using Technical.Utilities.Extensions;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.Helpers.PopupHelper;

namespace Windows.Core.Controls.Adapters
{
    public class GridViewAdapter : ListControlAdapter
    {
        private readonly GridView _gridView;

        public GridViewAdapter(GridView gridView)
        {
            _gridView = gridView;
            GridView.GuessAutoFilterRowValuesFromFilterAfterRestoreLayout = true;
            BestFitMaxRowCount = 100;
            _gridView.KeyDown += OnKeyDown;
            _gridView.MouseDown += OnMouseDown;
            _gridView.GridControl.EmbeddedNavigator.ButtonClick += EmbeddedNavigatorOnButtonClick;
            _gridView.GridControl.MouseDoubleClick += OnMouseDoubleClick;
            _gridView.RowUpdated += RowUpdated;
            _gridView.BeforeLeaveRow += GridViewOnBeforeLeaveRow;
        }

        private void EmbeddedNavigatorOnButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Handled) return;
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                OnDeleteCurrentRow(sender, EventArgs.Empty);
                e.Handled = true;
            }
            else if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                AddRow();
                e.Handled = true;
            }
        }

        public override bool AllowMultiSelection
        {
            get { return _gridView.OptionsSelection.MultiSelect; }
            set { _gridView.OptionsSelection.MultiSelect = value; }
        }

        public int BestFitMaxRowCount
        {
            get { return _gridView.BestFitMaxRowCount; }
            set { _gridView.BestFitMaxRowCount = value; }
        }

        public override bool ShowAutoFilterRow
        {
            get { return _gridView.OptionsView.ShowAutoFilterRow; }
            set { _gridView.OptionsView.ShowAutoFilterRow = value; }
        }

        public override string Name
        {
            get { return _gridView.Name; }
        }

        public override bool Editable
        {
            get { return _gridView.OptionsBehavior.Editable; }
            set { _gridView.OptionsBehavior.Editable = value; }
        }

        public override void SaveLayoutToStream(Stream stream)
        {
            _gridView.SaveLayoutToStream(stream);
        }

        public override void RestoreLayoutFromStream(Stream stream)
        {
            _gridView.RestoreLayoutFromStream(stream);
        }

        public override void BestFitColumns()
        {
            _gridView.BestFitColumns();
        }

        public override void CancelEdit()
        {
            _gridView.HideEditor();
        }

        public override void CommitEdit()
        {
            _gridView.CloseEditor();
        }

        public override void RefreshData()
        {
            _gridView.RefreshData();
        }

        public override void AddRow()
        {
            CommitEdit();
            _gridView.Focus();
            _gridView.AddNewRow();
            // Focus always in the first column of the new line
            _gridView.FocusedColumn = _gridView.VisibleColumns[0];
        }

        public override IEnumerable<IPhuLiBusinessBase> GetSelectedRows()
        {
            var rowHandles = _gridView.GetSelectedRows();
            var items = rowHandles.Select(p => _gridView.GetRow(p)).OfType<IPhuLiBusinessBase>();
            return items;
        }

        private void RowUpdated(object sender, RowObjectEventArgs rowObjectEventArgs)
        {
            if (rowObjectEventArgs.Row != null)
            {
                OnElementUpdated(sender, rowObjectEventArgs.Row);
            }
        }

        public override void ForceLeaveFocus()
        {
            CommitEdit();
            _gridView.UpdateCurrentRow();
        }

        public override int GetScrollbarPosition()
        {
            if (_gridView.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                // For new added row but not focused in any cell
                // we cant get FocusedRowHandle (it's negative).
                // Instead, we get RowCount and multiply -1 so that when restoring, it becomes positive
                return _gridView.RowCount*-1;
            }
            return _gridView.FocusedRowHandle - _gridView.TopRowIndex;
        }

        public override object GetFocusedRow()
        {
            var row = _gridView.GetRow(_gridView.FocusedRowHandle);
            if (row == null) return 0;
            var item = row.CastTo<IPhuLiBusinessBase>();
            return (item == null) ? 0 : item.IdValue;
        }

        public override void RestoreScrollbarPosition(int position)
        {
            _gridView.TopRowIndex = _gridView.FocusedRowHandle - position;
        }

        public override void RestoreFocusedRow(object idValue)
        {
            for (var i = 0; i < _gridView.RowCount; i++)
            {
                var row = _gridView.GetRow(i);
                if (row == null) continue;
                var item = row.CastTo<IPhuLiBusinessBase>();
                if (item == null) continue;
                if (Equals(idValue, item.IdValue))
                {
                    _gridView.FocusedRowHandle = i;
                }
            }
        }

        public override void Print()
        {
            GridPrint.PrintGrid(_gridView.GridControl);
        }

        public override void Export(ExportType exportType)
        {
            GridExport.ExportGrid(_gridView.GridControl, exportType);
        }

        private void GridViewOnBeforeLeaveRow(object sender, RowAllowEventArgs rowAllowEventArgs)
        {
            if (!rowAllowEventArgs.Allow) return;
            rowAllowEventArgs.Allow = OnItemChanging(sender, _gridView.GetRow(rowAllowEventArgs.RowHandle));
        }

        public override void ShowPopup(PopupMenuHelper popupHelper, MouseEventArgs e)
        {
            popupHelper.ShowPopup(_gridView.GridControl, _gridView, e);
        }

        public override bool IsCalcHitInfoInRow(Point location)
        {
            return _gridView.CalcHitInfo(location).InRow;
        }
    }
}