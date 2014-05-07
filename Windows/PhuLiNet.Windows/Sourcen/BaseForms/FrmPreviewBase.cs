using System;
using Windows.Core.Helpers;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.Controls;
using Windows.Core.DxExtensions;
using Windows.Core.Helpers;
using Windows.Core.Instructions.Manager;
using Windows.Core.Messaging;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.BaseForms
{
    public class FrmPreviewBase : FrmReadOnlyBase, ILoadableForm, IReloadableForm, IFilterableForm,
        ISaveAndRestoreGridLayout
    {
        protected virtual UCPreviewGridBase UserControl
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual UCPreviewGridBase[] UserControlDetails
        {
            get { return new UCPreviewGridBase[0]; }
        }

        private bool _suppressCurrentDataChangedEvent;

        public bool SuppressCurrentDataChangedEvent
        {
            get { return _suppressCurrentDataChangedEvent; }
            set
            {
                if (_suppressCurrentDataChangedEvent == value)
                    return;

                _suppressCurrentDataChangedEvent = value;

                // Again allowed, so fire it
                if (!value)
                {
                    UserControl.RaiseCurrentDataChanged();
                }
            }
        }

        protected virtual string LoadMessage
        {
            get { return string.Empty; }
        }

        protected override void InitMessageHandler()
        {
            _messageHandler = MessageHandlerFactory.GetDefaultMessageHandler();
            _messageHandler.Add(new ItemChangedMessage());
            AddMessages(_messageHandler);
        }

        protected override void MessageHandler_OnReceiveMessage(IMessageHandler sender, ReceiveMessageEventArgs e)
        {
            UserControl.MessageHandler_OnReceiveMessage(sender, e);
        }

        protected virtual void AddMessages(IMessageHandler messageHandler)
        {
        }

        protected override void InitInstructionManager()
        {
            _instructionManager = InstructionManagerFactory.GetDefaultInstructionManager();
            AddInstructions(_instructionManager);
        }

        protected virtual void AddInstructions(IInstructionManager instructionManager)
        {
        }

        #region Business Overrides

        protected override void InitBusinessData()
        {
            // Needs to be overwritten
        }

        protected override void InitBindings()
        {
            // Needs to be overwritten
        }

        protected override void InitControls()
        {
            UserControl.CurrentChanged += UserControl_CurrentChanged;

            PerformForUserControls(p => { p.MessageHandler = _messageHandler; });
        }

        private void RebindAllControls()
        {
            UserControlsRefreshBusiness();
        }

        private void UnbindAllControls()
        {
            UserControlsClearBusiness();
        }

        #endregion

        #region ILoadableForm Members

        public void LoadBusiness()
        {
            InitBusinessData();
            InitBindings();
            InitControls();
            UserControlsInitBusiness();
        }

        #endregion

        #region Instructions

        protected override void InstructionManager_OnApplyInstruction(IInstructionManager sender,
            ApplyInstructionEventArgs e)
        {
            UserControl.ApplyInstruction(e.Instruction);
        }

        #endregion

        #region IReloadableForm Members

        public void ReloadBusiness()
        {
            using (new StatusBusy(LoadMessage, true))
            {
                // Unbind everything
                UnbindAllControls();

                InitBusinessData();

                // Rebind/Reload everything
                RebindAllControls();
            }
        }

        #endregion

        /// <summary>
        /// Unbind all fields in the UserControls and clear all values.
        /// </summary>
        protected virtual void UserControlsClearBusiness()
        {
            foreach (var control in this.GetAllControls<IBusinessControl>())
            {
                control.ClearBusiness();
            }
        }

        /// <summary>
        /// Bind all fields in the UserControls and refresh all values.
        /// </summary>
        protected virtual void UserControlsInitBusiness()
        {
            foreach (var control in this.GetAllControls<IBusinessControl>())
            {
                control.InitBusiness();
            }
        }

        protected virtual void UserControlsRefreshBusiness()
        {
            foreach (var control in this.GetAllControls<IBusinessControl>())
            {
                control.RefreshBusiness();
            }
        }

        #region IFilterableForm Members

        public void Filter()
        {
            PerformForUserControls(p => p.Filter());
        }

        #endregion

        #region ISaveAndRestoreGridLayout Members

        public void RestoreGridLayout(string layoutName)
        {
            PerformForUserControls(p => p.RestoreGridLayout(layoutName));
        }

        public void SaveGridLayout(string layoutName)
        {
            PerformForUserControls(p => p.SaveGridLayout(layoutName));
        }

        #endregion

        private void PerformForUserControls(Action<UCPreviewGridBase> action)
        {
            action(UserControl);
            if (UserControlDetails != null)
            {
                foreach (var control in UserControlDetails)
                {
                    action(control);
                }
            }
        }

        private void UserControl_CurrentChanged(object sender, CurrentMasterDetailSelectionChanged e)
        {
            if (UserControlDetails == null || SuppressCurrentDataChangedEvent)
            {
                return;
            }
            foreach (var control in UserControlDetails)
            {
                if (e.CurrentItem != null)
                {
                    control.SetBusinessObjectPreviewListByRoot((IPhuLiReadOnlyBase) e.CurrentItem);
                }
                else
                {
                    control.BusinessObjectPreviewList = null;
                }

                control.RefreshBusiness();
            }
        }
    }
}