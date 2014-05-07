using System;
using System.Collections.Generic;
using Csla;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Localization;
using PhuLiNet.Business.Common.Rules;
using Technical.Utilities.Exceptions;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiBusinessBindingListBase<T, TC> : BusinessBindingListBase<T, TC>, IDuplicateBusiness<T>,
        IPhuLiBusinessBindingListBase
        where T : PhuLiBusinessBindingListBase<T, TC>
        where TC : IPhuLiBusinessBase
    {
        protected override void RemoveItem(int index)
        {
            if (!AllowRemove)
                return;

            var item = Items[index];
            if (!item.IsNew)
            {
                var result = item.CanDelete();
                if (!result.Allowed)
                {
                    var msg = result.CreateMessage(CslaBaseMessages.NotAllowedToRemoveChild);
                    throw new NotAllowedException(msg);
                }
            }
            base.RemoveItem(index);
        }

        protected virtual void FetchChildren(IEnumerable<object> databaseObjects)
        {
            RaiseListChangedEvents = false;

            foreach (var item in databaseObjects)
            {
                Add(DataPortal.FetchChild<TC>(item));
            }

            RaiseListChangedEvents = true;
        }

        public virtual T Duplicate()
        {
            var duplicate = DataPortal.CreateChild<T>();

            foreach (TC element in this)
            {
                duplicate.Add(((IDuplicateBusiness<TC>) element).Duplicate());
            }

            return duplicate;
        }

        #region Validation

        public bool AreValid
        {
            get
            {
                var validator = new EditTreeValidator(this);
                validator.Validate();
                return IsValid;
            }
        }

        #endregion
    }
}