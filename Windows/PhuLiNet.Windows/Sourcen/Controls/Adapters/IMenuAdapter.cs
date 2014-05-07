using System;
using System.Drawing;

namespace Windows.Core.Controls.Adapters
{
    public interface IMenuAdapter
    {
        void AddItem(string caption, EventHandler action, bool beginGroup = false);

        void AddItem(string caption, EventHandler action, Image image, Image imageDisabled = null,
            bool beginGroup = false);
    }
}