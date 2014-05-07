using System;
using System.Collections.Generic;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Helpers
{
    public class FixableColumnHandler
    {
        private IFixableBandColumns _parentForm;
        private IDictionary<BandedGridColumn, GridBand> _dictOrigOwnerBands;

        public const string FIX_LEFT = "Fix Column Left";
        public const string FIX_RIGHT = "Fix column Right";
        public const string UNFIX_LEFT = "Undo Fix Column Left";
        public const string UNFIX_RIGHT = "Undo Fix Column Right";

        public IDictionary<BandedGridColumn, GridBand> DictOrigOwnerBands
        {
            get
            {
                if (_dictOrigOwnerBands == null)
                {
                    _dictOrigOwnerBands = new Dictionary<BandedGridColumn, GridBand>();
                }
                return _dictOrigOwnerBands;
            }
        }

        public FixableColumnHandler(IFixableBandColumns parentForm)
        {
            _parentForm = parentForm;

            _parentForm.LefFixedBand.Tag = _parentForm.LefFixedBand.Caption;
            _parentForm.RightFixedBand.Tag = _parentForm.RightFixedBand.Caption;
        }

        public void ExtendGridMenu(PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null || !e.MenuType.ToString().ToUpper().Equals("COLUMN")) return;

            var bgcCurrent = e.HitInfo.Column as BandedGridColumn;
            if (bgcCurrent == null) return;

            if (_parentForm.LefFixedBand != null && !_parentForm.LefFixedBand.Columns.Contains(bgcCurrent))
            {
                var menuItem = new DXMenuItem(FIX_LEFT, new EventHandler(menuClicked));
                menuItem.Tag = bgcCurrent;
                menuItem.Enabled = true;
                e.Menu.Items.Add(menuItem);
            }

            if (_parentForm.RightFixedBand != null && !_parentForm.RightFixedBand.Columns.Contains(bgcCurrent))
            {
                var menuItem = new DXMenuItem(FIX_RIGHT, new EventHandler(menuClicked));
                menuItem.Tag = bgcCurrent;
                menuItem.Enabled = true;
                e.Menu.Items.Add(menuItem);
            }

            if (_parentForm.LefFixedBand != null && _parentForm.LefFixedBand.Columns.Contains(bgcCurrent) &&
                DictOrigOwnerBands.ContainsKey(bgcCurrent))
            {
                var menuItem = new DXMenuItem(UNFIX_LEFT, new EventHandler(menuClicked));
                menuItem.Tag = bgcCurrent;
                menuItem.Enabled = true;
                e.Menu.Items.Add(menuItem);
            }

            if (_parentForm.RightFixedBand != null && _parentForm.RightFixedBand.Columns.Contains(bgcCurrent) &&
                DictOrigOwnerBands.ContainsKey(bgcCurrent))
            {
                var menuItem = new DXMenuItem(UNFIX_RIGHT, new EventHandler(menuClicked));
                menuItem.Tag = bgcCurrent;
                menuItem.Enabled = true;
                e.Menu.Items.Add(menuItem);
            }
        }

        private void menuClicked(object sender, EventArgs e)
        {
            var selMI = sender as DXMenuItem;
            var selCol = selMI.Tag as BandedGridColumn;

            bool columnFixed = false;

            if (selMI.Caption.Equals(FIX_LEFT))
            {
                DictOrigOwnerBands[selCol] = selCol.OwnerBand;

                selCol.OwnerBand.Columns.Remove(selCol);
                _parentForm.LefFixedBand.Columns.Add(selCol);
                columnFixed = true;
            }

            if (selMI.Caption.Equals(FIX_RIGHT))
            {
                DictOrigOwnerBands[selCol] = selCol.OwnerBand;

                selCol.OwnerBand.Columns.Remove(selCol);
                _parentForm.RightFixedBand.Columns.Add(selCol);
                columnFixed = true;
            }

            if (selMI.Caption.Equals(UNFIX_LEFT))
            {
                _parentForm.LefFixedBand.Columns.Remove(selCol);
                _parentForm.LefFixedBand.Caption = _parentForm.LefFixedBand.Tag.ToString();

                DictOrigOwnerBands[selCol].Columns.Add(selCol);
                DictOrigOwnerBands[selCol].Visible = true;
            }

            if (selMI.Caption.Equals(UNFIX_RIGHT))
            {
                _parentForm.RightFixedBand.Columns.Remove(selCol);
                _parentForm.RightFixedBand.Caption = _parentForm.RightFixedBand.Tag.ToString();

                DictOrigOwnerBands[selCol].Columns.Add(selCol);
                DictOrigOwnerBands[selCol].Visible = true;
            }

            if (!columnFixed) return;

            if (DictOrigOwnerBands[selCol].Columns.Count == 0)
            {
                DictOrigOwnerBands[selCol].Visible = false;
                selCol.OwnerBand.Caption = DictOrigOwnerBands[selCol].Caption + " / " + selCol.OwnerBand.Tag.ToString();
            }
        }
    }
}