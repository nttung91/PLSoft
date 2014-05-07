using System;
using System.Collections.Generic;
using Csla;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiReadOnlyBindingListBase<T, TC> : ReadOnlyBindingListBase<T, TC>,
        IPhuLiReadOnlyBindingListBase where T : PhuLiReadOnlyBindingListBase<T, TC>
    {
        public Type ItemType
        {
            get { return typeof (TC); }
        }


        protected virtual void FetchChildren(IEnumerable<object> databaseObjects)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            foreach (var item in databaseObjects)
            {
                var previewItem = DataPortal.FetchChild<TC>(item);
                Add(previewItem);
            }

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
    }
}