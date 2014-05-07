using System;
using System.Drawing;
using DevExpress.Utils.Menu;

namespace Windows.Core.Controls.Adapters
{
    public class DxMenuAdapter : IMenuAdapter
    {
        private readonly DXPopupMenu _menu;

        public DxMenuAdapter(DXPopupMenu menu)
        {
            _menu = menu;
        }

        public void AddItem(string caption, EventHandler action, bool beginGroup = false)
        {
            AddItem(caption, action, null, null, beginGroup);
        }

        public void AddItem(string caption, EventHandler action, Image image, Image imageDisabled = null,
            bool beginGroup = false)
        {
            var item = new DXMenuItem(caption, action, image, imageDisabled);
            if (beginGroup)
            {
                item.BeginGroup = true;
            }
            _menu.Items.Add(item);
        }
    }
}