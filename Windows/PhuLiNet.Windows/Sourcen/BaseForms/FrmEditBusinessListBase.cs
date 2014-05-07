using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Rules;
using Technical.Utilities.Extensions;
using Windows.Core.Controls;
using Windows.Core.DxExtensions;
using Windows.Core.Forms.Validation;
using Windows.Core.Helpers;
using Windows.Core.Instructions;
using Windows.Core.Instructions.Manager;
using Windows.Core.Localization;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.BaseForms
{
    public class FrmEditBusinessListBase : FrmEditableBase, ILoadableForm, IFilterableForm, ISaveAndRestoreGridLayout,
        IInitializableForm
    {
        protected IPhuLiBusinessBase BusinessObjectListContainer;

        protected virtual UCEditBusinessListBase[] UserControls
        {
            get { throw new NotImplementedException(); }
        }

        protected virtual UCEditBusinessListBase[] UserControlDetails
        {
            get { return new UCEditBusinessListBase[0]; }
        }

        public virtual IPhuLiBusinessBase LoadListContainer()
        {
            return null;
        }

        public virtual void InitializeForm(object parameter)
        {
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
            ApplyInstruction(e.Instruction);
        }

        protected virtual void ApplyInstruction(IInstruction instruction)
        {
            CloseBrokenRules();

            foreach (var userControl in UserControls.Where(userControl => userControl.ActiveControl != null))
            {
                userControl.ApplyInstruction(instruction);
            }
        }

        #endregion

        #region Messages

        protected override void InitMessageHandler()
        {
            _messageHandler = MessageHandlerFactory.GetDefaultMessageHandler();
            AddMessages(_messageHandler);
        }

        protected virtual void AddMessages(IMessageHandler messageHandler)
        {
        }

        protected override void MessageHandler_OnReceiveMessage(IMessageHandler sender, ReceiveMessageEventArgs e)
        {
        }

        #endregion

        #region Business Overrides

        protected override void InitBusinessData()
        {
            BusinessObjectListContainer = LoadListContainer();
        }

        protected override void InitBindings()
        {
            _objectBindingManager.BindBO(BusinessObjectListContainer, BindingSource);
        }

        protected override void InitControls()
        {
            foreach (var master in UserControls)
            {
                master.CurrentChanged += Master_CurrentChanged;
            }
        }

        private void Master_CurrentChanged(object sender, CurrentMasterDetailSelectionChanged e)
        {
            if (UserControlDetails == null)
            {
                return;
            }
            foreach (var control in UserControlDetails)
            {
                control.SetBusinessObjectToBindFromRoot((IPhuLiBusinessBase) e.CurrentItem);
                control.RefreshBusiness();
            }
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
                using (new StatusBusy(General.Loading, true))
                {
                    BeforeReloadListFromDatabase();
                    ReloadListFromDatabase();
                    AfterReloadListFromDatabase();
                }
            }
        }

        protected virtual void BeforeReloadListFromDatabase()
        {
        }

        protected virtual void AfterReloadListFromDatabase()
        {
        }

        /// <summary>
        /// Reloads the list during ReloadBusiness.
        /// </summary>
        protected virtual void ReloadListFromDatabase()
        {
            // Unbind everything
            UnbindAllControls();

            // Reload data
            InitBusinessData();

            // Rebind everything
            RebindAllControls();
        }

        protected virtual void PrepareForSave()
        {
        }

        public override bool Save()
        {
            CommitChanges(BindingSource);

            // Save current scrollbar position of all UserControls to restore later
            var scrollbarPositions = GetScrollbarPositions();

            // Save focused rows of all UserControls to restore later
            var focusedRows = GetFocusedRows();

            // Unbind everything on the UserControls / on the form
            UserControlsClearBusiness();

            PrepareForSave();

            ValidateBusinessObject();
            var saved = _objectSaveManager.Save(BusinessObjectListContainer, BindingSource, true);
            BusinessObjectListContainer = (IPhuLiBusinessBase) BindingSource.DataSource;

            // Rebind everything on the UserControls / on the form
            UserControlsRefreshBusiness();

            // Restore scrollbar positions
            RestoreScrollbarPositions(scrollbarPositions);

            // Restore focused rows
            RestoreFocusedRows(focusedRows);

            if (saved)
            {
                CloseBrokenRules();
            }
            else
            {
                CollectBrokenRules();
            }

            return saved;
        }

        protected virtual void ValidateBusinessObject()
        {
            _objectSaveManager.ValidateBO(BusinessObjectListContainer, BindingSource);
        }

        /// <summary>
        /// Collect the broken business rules to show them in a form after Save method completed.
        /// </summary>
        protected virtual void CollectBrokenRules()
        {
            FrmBrokenRules.GetInstance().Collect(new BrokenRulesCollectorEx(BusinessObjectListContainer));
        }

        protected virtual void CloseBrokenRules()
        {
            FrmBrokenRules.ClearInstance();
        }

        public override bool IsDirty
        {
            get { return (BusinessObjectListContainer != null && BusinessObjectListContainer.IsDirty); }
        }

        public override bool IsValid
        {
            get { return (BusinessObjectListContainer != null && BusinessObjectListContainer.IsValid); }
        }

        #endregion

        #region UserControl Methods

        /// <summary>
        /// Unbind all fields in the UserControls and clear all values.
        /// </summary>
        protected virtual void UserControlsClearBusiness()
        {
            PerformForUserControls<IBusinessControl>(p => p.ClearBusiness());
        }

        protected virtual void PropagateBusinessObjectToControls()
        {
            // do not propagate for control details. They are initalized by current item selection in the master grid.
            foreach (var listControl in UserControls)
            {
                listControl.SetBusinessObjectToBindFromRoot(BusinessObjectListContainer);
            }
        }

        /// <summary>
        /// Bind all fields in the UserControls and refresh all values.
        /// </summary>
        protected virtual void UserControlsInitBusiness()
        {
            PropagateBusinessObjectToControls();

            PerformForUserControls<IBusinessControl>(p => p.InitBusiness());

            UserControlsBestFitColumns();
        }

        protected virtual void UserControlsRefreshBusiness()
        {
            PropagateBusinessObjectToControls();

            PerformForUserControls<IBusinessControl>(p => p.RefreshBusiness());

            UserControlsBestFitColumns();
        }

        private void UserControlsBestFitColumns()
        {
            PerformForUserControls<UCEditBusinessListBase>(p => p.BestFitColumns());
        }

        private IDictionary<string, int> GetScrollbarPositions()
        {
            var result = new Dictionary<string, int>();
            PerformForUserControls<UCEditBusinessListBase>(p => p.GetScrollbarPosition(result));
            return result;
        }

        private void RestoreScrollbarPositions(IDictionary<string, int> scrollbarPositions)
        {
            PerformForUserControls<UCEditBusinessListBase>(p => p.SetScrollbarPositions(scrollbarPositions));
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

        #region IFilterableForm Members

        public void Filter()
        {
            this.GetAllControls<IFilterableControl>().ForEach(c => c.Filter());
        }

        #endregion

        #region ISaveAndRestoreGridLayout Members

        public void RestoreGridLayout(string layoutName)
        {
            PerformForUserControls<UCEditBusinessListBase>(p => p.RestoreGridLayout(layoutName));
        }

        public void SaveGridLayout(string layoutName)
        {
            PerformForUserControls<UCEditBusinessListBase>(p => p.SaveGridLayout(layoutName));
        }

        #endregion
    }
}