using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;

namespace Windows.Core.Helpers
{
    public class VGridControlHelper
    {
        public static void SetReadOnly(VGridControl vGrid, bool enable)
        {
            foreach (var item in vGrid.Rows)
            {
                if (item is EditorRow)
                {
                    var editorRow = item as EditorRow;
                    editorRow.Properties.ReadOnly = !enable;
                }
                else if (item is MultiEditorRow)
                {
                    var multiEditorRow = item as MultiEditorRow;
                    multiEditorRow.Properties.ReadOnly = !enable;
                }
            }
        }
    }
}