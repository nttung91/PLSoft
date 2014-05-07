using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Windows.Core.Localization;

namespace Windows.Core.Controls.DXEditors.GridLookups
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public class GenericGridLookUpEdit : GridLookUpEdit
    {
        private NavigatorCustomButton _clearButton;
        private static ImageList _imageListClearButton;

        static GenericGridLookUpEdit()
        {
            GenericGridLookUpEditRepositoryItem.RegisterGenericRepositoryItemGridLookUpEdit();
            _imageListClearButton = new ImageList();
            //NTG TODO
            //_imageListClearButton.Images.Add(IconManager.GetIcon(EIcons.close_a_16));
        }

        public override string EditorTypeName
        {
            get { return GenericGridLookUpEditRepositoryItem.EditorName; }
        }

        public GenericGridLookUpEdit()
            : base()
        {
            Properties.View.GridControl.UseEmbeddedNavigator = true;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.ImageList = _imageListClearButton;
            Properties.View.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Clear();
            _clearButton = Properties.View.GridControl.EmbeddedNavigator.Buttons.CustomButtons.Add();
            _clearButton.ImageIndex = 0;
            _clearButton.Hint = ControlsRes.GenericGridLookUpEdit_Clear;
            Properties.View.GridControl.EmbeddedNavigator.ButtonClick +=
                new NavigatorButtonClickEventHandler(Navigator_ButtonClick);
        }

        private void Navigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            // only if nullAllowed
            if (Properties.AllowNullInput == DefaultBoolean.False) return;

            if (e.Button != _clearButton) return;
            // We close popup with Cancel mode so that some events
            // (e.g. EditValueChanging, EditValueChanged...) is not fired twice
            // (one for the last item and one for null)
            ClosePopup(PopupCloseMode.Cancel);
            EditValue = null;
        }

        protected override void DoShowPopup()
        {
            _clearButton.Visible = Properties.AllowNullInput != DefaultBoolean.False;
            base.DoShowPopup();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new GenericGridLookUpEditRepositoryItem Properties
        {
            get { return base.Properties as GenericGridLookUpEditRepositoryItem; }
        }
    }
}