using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;

namespace Windows.Core.Controls.DXEditors.Lookups
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public class GenericLookupEdit : LookUpEdit
    {
        static GenericLookupEdit()
        {
            GenericLookupEditRepositoryItem.RegisterGenericLookupEdit();
        }

        public GenericLookupEdit()
            : base()
        {
        }

        public override string EditorTypeName
        {
            get { return GenericLookupEditRepositoryItem.LookupEditName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new GenericLookupEditRepositoryItem Properties
        {
            get { return base.Properties as GenericLookupEditRepositoryItem; }
        }
    }
}