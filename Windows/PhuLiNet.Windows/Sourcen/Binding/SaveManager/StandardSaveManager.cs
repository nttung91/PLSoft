using System;
using System.Security;
using System.Windows.Forms;
using Windows.Core.Helpers;
using Csla.Core;
using Csla.Rules;
using PhuLiNet.Business.Common.Authorization.State;
using PhuLiNet.Business.Common.Rules;
using Technical.Utilities.Exceptions;
using Windows.Core.Helpers;
using Windows.Core.Localization;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Binding.SaveManager
{
    public class StandardSaveManager : SaveManagerBase
    {
        private StandardSaveManager(IObjectBindingManager objectBindingManager)
            : base(objectBindingManager)
        {
        }

        public static SaveManagerBase GetSaveManager(IObjectBindingManager objectBindingManager)
        {
            return new StandardSaveManager(objectBindingManager);
        }

        public override void ValidateBO(IValidateBusiness businessObject, BindingSource bindingSource)
        {
            ObjectBindingManager.EndEditBinding(bindingSource);

            businessObject.Validate();
        }

        private bool PreSaveChecksOk(object businessObject, BindingSource bindingSource)
        {
            if (!Enabled)
            {
                if (!TestMode)
                    MessageBox.ShowInfo(SaveManagerMessages.SaveManagerDisabled,
                        SaveManagerMessages.SaveManagerDisabledCaption);
                return false;
            }

            var stateAuthorization = businessObject as IObjectStateAuthorization;
            if (stateAuthorization != null)
            {
                if (!stateAuthorization.Authorization.AllowEdit())
                {
                    if (!TestMode) MessageBox.ShowInfo(SaveManagerMessages.AllowEditFalse);
                    return false;
                }
            }

            var trackStatus = businessObject as ITrackStatus;
            if (trackStatus != null)
            {
                ObjectBindingManager.EndEditBinding(bindingSource);
                if (!trackStatus.IsDirty)
                {
                    return false;
                }

                if (!trackStatus.IsValid)
                {
                    if (!TestMode && ShowDataNotSavedErrorMessage)
                        MessageBox.ShowInfo(_dataNotSavedErrorMessage, SaveManagerMessages.DataNotSavedCaption);
                    return false;
                }
            }

            if (!BusinessRules.HasPermission(AuthorizationActions.EditObject, businessObject))
            {
                MessageBox.ShowInfo(SaveManagerMessages.NotAuthorized);
                return false;
            }

            return true;
        }

        public override bool Save(IBusinessObject businessObject, BindingSource bindingSource, bool rebind)
        {
            return Save(businessObject, bindingSource, new BindingSource[] {}, rebind);
        }

        public override bool Save(IBusinessObject businessObject, BindingSource bindingSource,
            BindingSource[] childBindingSources, bool rebind)
        {
            Func<bool> preSaveCheck = () => PreSaveChecksOk(businessObject, bindingSource);
            Action saveAction =
                () => ObjectBindingManager.SaveBO(businessObject, bindingSource, childBindingSources, rebind);

            return Save(preSaveCheck, saveAction);
        }

        public override bool Save(IBusinessObject businessObject, BindingSourceNode bindingSourceNode, bool rebind)
        {
            Func<bool> preSaveCheck = () => PreSaveChecksOk(businessObject, bindingSourceNode.BindingSource);
            Action saveAction = () => ObjectBindingManager.SaveBO(businessObject, bindingSourceNode, rebind);

            return Save(preSaveCheck, saveAction);
        }

        private bool Save(Func<bool> preSaveCheck, Action saveAction)
        {
            bool saved = false;

            if (preSaveCheck.Invoke())
            {
                try
                {
                    using (new StatusBusy(SaveManagerMessages.SavingData, ShowWaitForm))
                    {
                        saveAction.Invoke();
                        saved = true;
                    }
                }
                catch (ValidationException)
                {
                    if (ShowDataNotSavedErrorMessage)
                        MessageBox.ShowInfo(_dataNotSavedErrorMessage, SaveManagerMessages.DataNotSavedCaption);
                }
                catch (ConcurrencyException)
                {
                    MessageBox.ShowInfo(SaveManagerMessages.AnotherUserHasChangedData,
                        SaveManagerMessages.AnotherUserHasChangedDataCaption);
                }
                catch (InvalidStateException)
                {
                    MessageBox.ShowInfo(SaveManagerMessages.SaveNotAllowedInvalidState);
                }
                catch (NotAllowedException)
                {
                    MessageBox.ShowInfo(SaveManagerMessages.OperationNowAllowed,
                        SaveManagerMessages.OperationNowAllowedCaption);
                }
                catch (SecurityException)
                {
                    MessageBox.ShowInfo(SaveManagerMessages.NotAuthorized);
                }
                catch (Exception ex)
                {
                    MessageBox.ShowError(SaveManagerMessages.SaveException, ex.Message,
                        SaveManagerMessages.SaveException);
                    throw;
                }
            }

            return saved;
        }
    }
}