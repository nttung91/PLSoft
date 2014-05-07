using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;

namespace Windows.Core.Helpers
{
    internal static class EditorHelper
    {
        public static bool EndEdit(BaseEdit editor)
        {
            bool result = true;
            if (isInVerticalGrid(editor))
            {
                result = forceEndEditOnVerticalGrid(editor);
            }
            if (isInGrid(editor))
            {
                result = forceEndEditOnGrid(editor);
            }
            return result;
        }

        private static bool forceEndEditOnGrid(BaseEdit edit)
        {
            bool result = true;
            if (edit.Parent == null) return result;
            var grid = edit.Parent as GridControl;
            if (grid != null)
            {
                result = GridHelper.EndEditGrid(grid);
            }
            return result;
        }

        // Wenn im VGrid der Editor nicht verlassen wurde, dann hat nur ein sendkey geholfen, damit 
        // ein Endedit stattfindet, der Tipp von DevExpress mit DoValidate alleine hilft nicht
        private static bool forceEndEditOnVerticalGrid(BaseEdit edit)
        {
            if (edit.Parent == null) return true;
            var vgrid = edit.Parent as VGridControl;
            if (vgrid != null)
            {
                vgrid.ActiveEditor.SendKey(new KeyEventArgs(Keys.Enter));
            }
            return edit.DoValidate();
        }

        private static bool isInVerticalGrid(BaseEdit edit)
        {
            bool result = false;
            if (edit.Parent != null)
            {
                result = edit.Parent is VGridControl;
            }
            return result;
        }

        private static bool isInGrid(BaseEdit edit)
        {
            bool result = false;
            if (edit.Parent != null)
            {
                result = edit.Parent is GridControl;
            }
            return result;
        }
    }
}