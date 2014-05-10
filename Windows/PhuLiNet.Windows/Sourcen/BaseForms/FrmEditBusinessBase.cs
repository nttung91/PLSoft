using System;
using System.Collections.Generic;
using Windows.Core.Commands;
using Windows.Core.Helpers;
using Windows.Core.Localization;
using Windows.Core.Controls;
using Windows.Core.Forms;
using Windows.Core.Forms.Validation;
using Windows.Core.Instructions;
using Windows.Core.Instructions.Manager;
using Windows.Core.Messaging;
using Windows.Core.Messaging.Handler;
using PhuLiNet.Business.Common.CopyManager;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Rules;

namespace Windows.Core.BaseForms
{
    public class FrmEditBusinessBase : FrmEditableBase, ILoadableForm, IFormStatusText, IInitializableForm
    {
        public IPhuLiBusinessBase BusinessObject { get; protected set; }

        public void InitializeForm(object parameter)
        {
            var instructionParam = parameter as FormInstructionInitParameter;
            if (instructionParam != null)
            {
                ApplyInstruction(instructionParam.Instruction, true, instructionParam.EntityKey);
            }
            var paramAsEntity = parameter as IPhuLiBusinessBase;
            if (paramAsEntity != null)
            {
                FrmBrokenRules.ClearInstance();
                BusinessObject = paramAsEntity;
            }
        }

        public virtual IPhuLiBusinessBase LoadEntity(object entityKey)
        {
            return null;
        }

        public virtual IPhuLiBusinessBase CreateEntity()
        {
            return null;
        }

        #region ILoadableForm Members

        /// <summary>
        /// Binds all fields to the business object (and inits controls)
        /// </summary>
        public virtual void LoadBusiness()
        {
            InitBusinessData();
            InitBindings();
            InitControls();
            UserControlsInitBusiness();
        }

        #endregion

        #region IFormStatusText Members

        public string StatusText
        {
            get
            {
                var res = string.Empty;
                var displayText = BusinessObject as IDisplayTexts;
                if (displayText != null)
                    res = displayText.ToDisplayText();
                return res;
            }
        }

        public string StatusTextShort
        {
            get
            {
                var res = string.Empty;
                var displayText = BusinessObject as IDisplayTexts;
                if (displayText != null)
                    res = displayText.ToDisplayTextShort();
                return res;
            }
        }

        #endregion

        #region Instructions

        protected override void InitInstructionManager()
        {
            _instructionManager = InstructionManagerFactory.GetDefaultInstructionManager();
            AddInstructions(_instructionManager);
        }

        protected virtual void AddInstructions(IInstructionManager instructionManager)
        {
        }

        protected override void InstructionManager_OnApplyInstruction(IInstructionManager sender,
            ApplyInstructionEventArgs e)
        {
            ApplyInstruction(e.Instruction, false);
        }

        protected virtual void ApplyInstruction(IInstruction instruction, bool newFormInstance, object entityKey = null)
        {
            CloseBrokenRules();

            if (instruction is NewInstruction)
            {
                if (newFormInstance)
                {
                    // called by InitalizeForm
                    NewInstructionForNewForm();
                }
                else // called by InstructionManager
                {
                    NewInstruction();
                }
            }
            else if (instruction is EditInstruction)
            {
                // This gets called only by InitalizeForm
                EditInstruction(entityKey);
            }
            else if (instruction is DeleteInstruction)
            {
                // Gets called by the InstructionManager
                DeleteInstruction();
            }
            else if (instruction is CopyInstruction)
            {
                // Gets called by the InstructionManager
                CopyInstruction();
            }
        }

        /// <summary>
        /// Set the business object by entity key. Is only called by InitalizeForm.
        /// </summary>
        protected virtual void EditInstruction(object entityKey)
        {
            // We never have to deal with an already loaded entity. 
            BusinessObject = LoadEntity(entityKey);
        }

        /// <summary>
        /// Set the business object to a new empty object. Is only called by InitalizeForm.
        /// </summary>
        protected virtual void NewInstructionForNewForm()
        {
            // Create a new record
            BusinessObject = CreateEntity();
        }

        /// <summary>
        /// Replaces the currently loaded instance by a completely emtpty new one.
        /// </summary>
        protected virtual void NewInstruction()
        {
            // Create a new entity in the same form, this gets only called from an Edit-Form
            // Commit the changes made on this form to the BindingSource
            CommitChanges(BindingSource);

            if (AskAndSave())
            {
                UnbindAllControls();

                BusinessObject = CreateEntity();

                RebindAllControls();

                SetFormCaption();
            }
        }

        protected virtual void DeleteInstruction()
        {
            var deleteCmd = new DeleteBusinessObjectCommand(BusinessObject, GetItemPreviewType());
            CommandExecutor.Execute(deleteCmd);
        }

        protected virtual ICopyManager<IPhuLiBusinessBase> GetCopyManager()
        {
            return new StandardCopyManager(BusinessObject);
        }

        protected virtual void CopyInstruction()
        {
            CopyInstruction(GetCopyManager());
        }

        protected void CopyInstruction(ICopyManager<IPhuLiBusinessBase> copyManager)
        {
            var cmd = new StartEditFormCopyBusinessObject(GetType(), copyManager);
            CommandExecutor.Execute(cmd);
        }

        #endregion

        #region Messages

        protected override void InitMessageHandler()
        {
            _messageHandler = MessageHandlerFactory.GetDefaultMessageHandler();
            _messageHandler.Add(new CloseMessage());
            _messageHandler.Add(new ItemChangedMessage());
            AddMessages(_messageHandler);
        }

        protected virtual void AddMessages(IMessageHandler messageHandler)
        {
        }

        protected override void MessageHandler_OnReceiveMessage(IMessageHandler sender, ReceiveMessageEventArgs e)
        {
            var closeMsg = e.Message as CloseMessage;
            if (closeMsg != null && closeMsg.PreviewItemType == GetItemPreviewType() &&
                BusinessObject.IdValue.Equals(closeMsg.BusinessObjectId))
            {
                closeMsg.Handled = true;

                if (!closeMsg.Save)
                {
                    _saveOnClosing = false;
                }
                Close();
                if (!Visible)
                {
                    closeMsg.Closed = true;
                }
            }
        }

        protected virtual Type GetItemPreviewType()
        {
            throw new NotImplementedException();
        }

        private IMessage CreateItemChangedMessage()
        {
            var previewType = GetItemPreviewType();
            return new ItemChangedMessage(BusinessObject.IdValue, previewType);
        }

        #endregion

        #region Business Overrides

        protected override void InitBusinessData()
        {
        }

        protected override void InitBindings()
        {
            _objectBindingManager.BindBO(BusinessObject, BindingSource);
        }

        protected override void InitControls()
        {
            SetFormCaption();
        }

        private void SetFormCaption()
        {
            Text = StatusText;
        }

        protected void RebindAllControls()
        {
            UserControlsRefreshBusiness();
            InitBindings();
            _objectBindingManager.RestoreBindings(BindingSource, true);
        }

        protected void UnbindAllControls()
        {
            UserControlsClearBusiness();
            _objectBindingManager.ClearBindings(BindingSource, false);
        }

        #endregion Business Overrides

        #region Form Business Overrides

        public override void ReloadBusiness()
        {
            // Commit the changes made on this form to the BindingSource
            CommitChanges(BindingSource);

            // Save (or don't, just don't press Cancel)
            bool notCanceled = AskAndSave();
            if (notCanceled)
            {
                // We don't allow this action if it's a new record and it was never saved before
                if (BusinessObject.IsNew)
                {
                    MessageBox.ShowWarning(General.ReloadThenSave, General.Reload);
                    return;
                }

                using (new StatusBusy(General.Loading, true))
                {
                    ReloadEntityFromDatabase();
                }
            }
        }

        private void ReloadEntityFromDatabase()
        {
            // Unbind everything
            UnbindAllControls();

            // Get the last saved version of our business object
            BusinessObject = LoadEntity(BusinessObject.IdValue);

            // Rebind/Reload everything
            RebindAllControls();

            SetFormCaption();
        }

        protected virtual void PrepareForSave()
        {
        }

        public override bool Save()
        {
            CommitChanges(BindingSource);

            // Save focused rows of all UserControls to restore later
            var focusedRows = GetFocusedRows();

            UserControlsClearBusiness();

            PrepareForSave();

            // Validate, prepare the message and save
            ValidateBusinessObject();
            var saved = _objectSaveManager.Save(BusinessObject, BindingSource, true);
            BusinessObject = (IPhuLiBusinessBase) BindingSource.Current;

            // Update some needed fields
            if (saved)
            {
                SetFormCaption();
            }

            UserControlsRefreshBusiness();

            // Restore focused row positions
            RestoreFocusedRows(focusedRows);

            // Notify other controls
            if (saved)
            {
                CloseBrokenRules();

                var message = CreateItemChangedMessage();
                _messageHandler.Send(message);
            }
            else
            {
                CollectBrokenRules();
            }

            return saved;
        }

        protected virtual void ValidateBusinessObject()
        {
            _objectSaveManager.ValidateBO(BusinessObject, BindingSource);
        }

        /// <summary>
        /// Collect the broken business rules to show them in a form after Save method completed.
        /// </summary>
        protected virtual void CollectBrokenRules()
        {
            FrmBrokenRules.GetInstance().Collect(new BrokenRulesCollectorEx(BusinessObject));
        }

        protected virtual void CloseBrokenRules()
        {
            FrmBrokenRules.ClearInstance();
        }

        public override object GetIdValueData()
        {
            return BusinessObject.IdValue;
        }

        public override bool IsDirty
        {
            get { return (BusinessObject != null && BusinessObject.IsDirty); }
        }

        public override bool IsValid
        {
            get { return (BusinessObject != null && BusinessObject.IsValid); }
        }

        #endregion

        #region UserControl Methods

        /// <summary>
        /// Unbind all fields in the UserControls and clear all values.
        /// </summary>
        private void UserControlsClearBusiness()
        {
            PerformForUserControls<IBusinessControl>(p => p.ClearBusiness());
        }

        protected virtual void PropagateBusinessObjectToControls()
        {
            PerformForUserControls<UCEditBusinessBase>(p => p.SetBusinessObjectFromRoot(BusinessObject));
            PerformForUserControls<UCPreviewGridBase>(p => p.SetBusinessObjectPreviewListByRoot(BusinessObject));
            PerformForUserControls<UCEditBusinessListBase>(p => p.SetBusinessObjectToBindFromRoot(BusinessObject));
        }

        /// <summary>
        /// Bind all fields in the UserControls.
        /// </summary>
        protected virtual void UserControlsInitBusiness()
        {
            PropagateBusinessObjectToControls();

            PerformForUserControls<IBusinessControl>(p => p.InitBusiness());

            UserControlsBestFitColumns();
        }

        /// <summary>
        /// Rebind all fields in the UserControls.
        /// </summary>
        protected virtual void UserControlsRefreshBusiness()
        {
            PropagateBusinessObjectToControls();

            PerformForUserControls<IBusinessControl>(p => p.RefreshBusiness());

            UserControlsBestFitColumns();
        }

        private void UserControlsBestFitColumns()
        {
            PerformForUserControls<UCEditBusinessBase>(p => p.BestFitColumns());
            PerformForUserControls<UCGridBase>(p => p.BestFitColumns());
        }

        private IDictionary<string, object> GetFocusedRows()
        {
            var result = new Dictionary<string, object>();
            PerformForUserControls<UCEditBusinessListBase>(p => p.GetFocusedRow(result));
            return result;
        }

        private void RestoreFocusedRows(IDictionary<string, object> focusedRows)
        {
            PerformForUserControls<UCEditBusinessListBase>(p => p.RestoreFocusedRows(focusedRows), true);
        }

        #endregion
    }
}