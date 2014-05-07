using System.Windows.Forms;
using DevExpress.XtraBars;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.Helpers;
using Windows.Core.Helpers.PopupHelper;
using Windows.Core.Instructions;
using Windows.Core.Messaging;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.Controls
{
    // ReSharper disable InconsistentNaming
    public partial class UCPreviewGridBase : UCGridBase
        // ReSharper restore InconsistentNaming
    {
        private PopupMenuHelper _popupHelper;

        public IMessageHandler MessageHandler { get; set; }
        public IPhuLiReadOnlyRefreshableBindingListBase BusinessObjectPreviewList { get; set; }

        public bool AddNewRowEnabled { get; set; }
        public bool ChangeRowEnabled { get; set; }
        public bool DeleteRowEnabled { get; set; }

        /// <summary>
        /// Used to set the Details Grid from the selected Master entry. 
        /// </summary>
        public virtual void SetBusinessObjectPreviewListByRoot(IPhuLiReadOnlyBase root)
        {
        }

        /// <summary>
        /// Used to set a grid which contains data in the case of a readonly grid in an editable form.
        /// </summary>
        public virtual void SetBusinessObjectPreviewListByRoot(IPhuLiBusinessBase root)
        {
        }

        public void RefreshPreviewItem(object key, bool wasDeleted = false)
        {
            BusinessObjectPreviewList.RefreshItem(key, wasDeleted);
            ListControl.RefreshData();
            RaiseCurrentDataChanged();
        }

        #region IControlInstructions Members

        public override void ApplyInstruction(IInstruction instruction)
        {
            base.ApplyInstruction(instruction);

            if (instruction is EditInstruction)
            {
                ExecuteEditInstruction(instruction);
            }
        }

        #endregion

        protected virtual void ExecuteEditInstruction(IInstruction instruction)
        {
        }

        public virtual void MessageHandler_OnReceiveMessage(IMessageHandler sender, ReceiveMessageEventArgs e)
        {
            var msg = e.Message as ItemChangedMessage;
            if (msg != null && BusinessObjectPreviewList != null &&
                msg.PreviewItemType == BusinessObjectPreviewList.ItemType)
            {
                var wasDeleted = (msg.Mode == ItemChangedMode.Delete);
                RefreshPreviewItem(msg.BusinessObjectId, wasDeleted);
            }
        }

        protected IPhuLiReadOnlyBase CurrentItem
        {
            get { return BindingSource.BindingSource.Current as IPhuLiReadOnlyBase; }
        }

        protected override sealed object GetRootToBind()
        {
            return BusinessObjectPreviewList;
        }

        protected override void InitControls()
        {
            _popupHelper = new PopupMenuHelper(this, AddNewRowEnabled, ChangeRowEnabled, DeleteRowEnabled);
            _popupHelper.ItemClick += PopupHelperOnItemClick;

            ListControl.MouseDown += ListControl_MouseDown;
            ListControl.MouseDoubleClick += ListControl_MouseDoubleClick;
            ListControl.KeyDown += ListControl_KeyDown;

            base.InitControls();
        }

        private void ListControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ListControl.IsCalcHitInfoInRow(e.Location))
                {
                    ApplyInstruction(InstructionFactory.EditInstruction());
                }
            }
        }

        private void ListControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHelper.IsEditKey(e) && ChangeRowEnabled)
            {
                ApplyInstruction(InstructionFactory.EditInstruction());
                e.Handled = true;
            }
            else if (KeyHelper.IsNewKey(e) && AddNewRowEnabled)
            {
                ApplyInstruction(InstructionFactory.NewInstruction());
                e.Handled = true;
            }
            else if (KeyHelper.IsDeleteKey(e) && DeleteRowEnabled)
            {
                ApplyInstruction(InstructionFactory.DeleteInstruction());
                e.Handled = true;
            }
        }

        private void ListControl_MouseDown(object sender, MouseEventArgs e)
        {
            ListControl.ShowPopup(_popupHelper, e);
        }

        protected virtual void AddPoupMenuItems(PopupMenu popupMenu, BarManager barManager)
        {
        }

        private void PopupHelperOnItemClick(object sender, PopupMenuHelperEventArgs e)
        {
            switch (e.Type)
            {
                case PopupMenuItemType.Create:
                    ApplyInstruction(InstructionFactory.NewInstruction());
                    break;
                case PopupMenuItemType.Edit:
                    ApplyInstruction(InstructionFactory.EditInstruction());
                    break;
                case PopupMenuItemType.Delete:
                    ApplyInstruction(InstructionFactory.DeleteInstruction());
                    break;
            }
        }
    }
}