using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Windows.Core.DxExtensions;
using Windows.Core.Localization;
using Techical.Icons;

namespace Windows.Core.Helpers.PopupHelper
{
    public class PopupMenuHelper
    {
        private readonly PopupMenu _popupMenu;

        public event EventHandler<PopupMenuHelperEventArgs> ItemClick;

        public PopupMenuHelper(Control control, bool allowCreate, bool allowEdit, bool allowDelete)
        {
            BarButtonItem item;
            var barManager = new BarManager {Form = control};
            _popupMenu = new PopupMenu(barManager);

            if (allowCreate)
            {
                item = new BarButtonItem(barManager, General.PopupMenuNew)
                {
                    Glyph = IconManager.GetBitmap(EIcons.add_16)
                };
                item.ItemClick += (sender, args) => FireItemClick(PopupMenuItemType.Create);
                _popupMenu.AddItem(item);
            }

            if (allowEdit)
            {
                item = new BarButtonItem(barManager, General.PopupMenuEdit)
                {
                    Glyph = IconManager.GetBitmap(EIcons.write_16)
                };
                item.ItemClick += (sender, args) => FireItemClick(PopupMenuItemType.Edit);
                _popupMenu.AddItem(item);
            }

            if (allowDelete)
            {
                item = new BarButtonItem(barManager, General.PopupMenuDelete)
                {
                    Glyph = IconManager.GetBitmap(EIcons.delete_16)
                };
                item.ItemClick += (sender, args) => FireItemClick(PopupMenuItemType.Delete);
                _popupMenu.AddItem(item);
            }
        }

        public void ShowPopup(GridControl control, GridView view, MouseEventArgs e)
        {
            if (_popupMenu.ItemLinks.Count == 0)
            {
                return;
            }
            _popupMenu.ShowPopup(control, view, e);
        }

        private void FireItemClick(PopupMenuItemType type)
        {
            if (ItemClick != null)
            {
                ItemClick(this, new PopupMenuHelperEventArgs(type));
            }
        }
    }
}