using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.BaseForms;
using Windows.Core.Helpers.PopupHelper;

namespace Windows.Core.Controls.Adapters
{
    public abstract class ListControlAdapter
    {
        public abstract bool AllowMultiSelection { get; set; }
        public abstract bool ShowAutoFilterRow { get; set; }
        public abstract string Name { get; }

        public abstract bool Editable { get; set; }

        public bool NotAllowToAddOrDeleteRow { get; set; }

        public abstract void SaveLayoutToStream(Stream stream);
        public abstract void RestoreLayoutFromStream(Stream stream);

        public abstract void BestFitColumns();
        public abstract void CancelEdit();
        public abstract void CommitEdit();
        public abstract void ForceLeaveFocus();
        public abstract void Print();
        public abstract void Export(ExportType exportType);
        public abstract void RefreshData();

        public abstract void AddRow();
        public abstract IEnumerable<IPhuLiBusinessBase> GetSelectedRows();

        public virtual int GetScrollbarPosition()
        {
            return 0;
        }

        public virtual void RestoreScrollbarPosition(int position)
        {
        }

        public virtual object GetFocusedRow()
        {
            return 0;
        }

        public virtual void RestoreFocusedRow(object focusedRow)
        {
        }

        public virtual void ShowPopup(PopupMenuHelper popupHelper, MouseEventArgs e)
        {
        }

        public virtual bool IsCalcHitInfoInRow(Point location)
        {
            return false;
        }

        public event EventHandler DeleteCurrentRow;

        protected void OnDeleteCurrentRow(object sender, EventArgs e)
        {
            if (DeleteCurrentRow != null)
            {
                DeleteCurrentRow(sender, e);
            }
        }

        public event KeyEventHandler KeyDown;

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Handled && KeyDown != null)
            {
                KeyDown(sender, e);
            }
        }

        public event MouseEventHandler MouseDown;

        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
            {
                MouseDown(sender, e);
            }
        }

        public event MouseEventHandler MouseDoubleClick;

        protected void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MouseDoubleClick != null)
            {
                MouseDoubleClick(sender, e);
            }
        }

        public event ElementUpdatedEventHandler ElementUpdated;

        protected void OnElementUpdated(object sender, object element)
        {
            if (ElementUpdated != null)
            {
                ElementUpdated(sender, new ElementUpdatedEventArgs {Element = element});
            }
        }

        public event ItemChangingEventHandler ItemChanging;

        protected bool OnItemChanging(object sender, object element)
        {
            if (ItemChanging != null)
            {
                var args = new ItemChangingEventArgs {Allow = true, NewElement = element};
                ItemChanging(sender, args);
                return args.Allow;
            }
            return true;
        }
    }
}