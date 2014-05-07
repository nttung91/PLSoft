using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Core;
using Csla.Rules;
using PhuLiNet.Business.Common.Authorization;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Localization;
using PhuLiNet.Business.Common.Rules;
using Technical.Utilities.Exceptions;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiBusinessBase<T> :
        BusinessBase<T>, IDuplicateBusiness<T>,
        IMarkableAsDuplicate, IPhuLiBusinessBase where T : PhuLiBusinessBase<T>
    {
        private readonly List<IPhuLiReadOnlyBase> _relatedConfirmedToDelete = new List<IPhuLiReadOnlyBase>();

        public virtual BrokenRulesTree GetAllBrokenRules()
        {
            return BusinessRules.GetAllBrokenRules(this, false);
        }

        public virtual void Validate()
        {
            var validator = new EditTreeValidator(this);
            validator.Validate();
        }

        public virtual T Duplicate()
        {
            var duplicator = new EditTreeDuplicator<T>(this as T);
            var copy = duplicator.Duplicate();
            return copy;
        }

        public virtual void MarkAsDuplicate()
        {
        }

        public object IdValue
        {
            get { return GetIdValue(); }
        }

        public virtual CheckCommandResult CanDelete()
        {
            if (DeleteCheckCommand == null)
            {
                return true;
            }
            return DeleteCheckCommand.Execute(this as T);
        }

        protected virtual void EnforceDeletable()
        {
            if (DeleteCheckCommand != null)
            {
                var result = DeleteCheckCommand.ExecuteDatabaseCheckOnly(this as T);
                if (!result.Allowed)
                {
                    var message = result.CreateMessage(CslaBaseMessages.NotAllowedToDelete);
                    throw new NotAllowedException(message);
                }
            }
        }

        protected override void Child_OnDataPortalInvoke(DataPortalEventArgs e)
        {
            if (e.Operation == DataPortalOperations.Update && IsDeleted && DeleteCheckCommand != null)
            {
                EnforceDeletable();
            }

            base.Child_OnDataPortalInvoke(e);
        }

        public bool IsPropertyDirty(IPropertyInfo property)
        {
            return FieldManager.IsFieldDirty(property);
        }

        public void RemoveIsDirtyFlag()
        {
            MarkClean();
        }

        public void RemoveIsDirtyAndIsNewFlag()
        {
            MarkOld();
        }

        #region Delte checks & confirmation

        /// <summary>
        /// Returns all entities of type <see cref="TDelete"/> which are by the user confirmed to delete. Most likely, the records in here will be delete by NHibernate
        /// via cascade deletion. So it should be double-checked that no records were added to the table between the confirmation and the actual deletion.
        /// </summary>
        /// <typeparam name="TDelete"></typeparam>
        /// <returns></returns>
        protected IList<TDelete> GetAndClearConfirmedToDeleteOfType<TDelete>() where TDelete : IPhuLiReadOnlyBase
        {
            var items = _relatedConfirmedToDelete.OfType<TDelete>().ToList();
            items.ForEach(p => _relatedConfirmedToDelete.Remove(p));
            return items;
        }

        public void AddConfirmedToDelete(IEnumerable<IPhuLiReadOnlyBase> items)
        {
            _relatedConfirmedToDelete.AddRange(items);
        }

        protected bool CheckAllLeftAreInRight<TLeft, TRight>(IList<TLeft> left, IList<TRight> right,
            Func<TLeft, TRight, bool> compare)
        {
            return left.All(leftItem => right.Any(rightItem => compare(leftItem, rightItem)));
        }

        protected virtual ICheckCommand<T> DeleteCheckCommand
        {
            get { return null; }
        }

        #endregion
    }
}