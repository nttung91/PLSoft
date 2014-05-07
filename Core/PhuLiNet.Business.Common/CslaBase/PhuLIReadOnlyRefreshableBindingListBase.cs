using System;
using Technical.Utilities.Extensions;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiReadOnlyRefreshableBindingListBase<T, TC> : PhuLiReadOnlyBindingListBase<T, TC>,
        IPhuLiReadOnlyRefreshableBindingListBase
        where T : PhuLiReadOnlyBindingListBase<T, TC>
        where TC : PhuLiReadOnlyBase<TC>, IPhuLiReadOnlyBase
    {
        public void RefreshItem(object key, bool wasDeleted)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            var index = FindIndexByKey(key);
            if (index >= 0)
            {
                RemoveAt(index);
            }
            else
            {
                index = 0;
            }

            if (!wasDeleted)
            {
                InsertPreviewItem(key, index);
            }


            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void InsertPreviewItem(object key, int index)
        {
            var item = LoadPreviewItemFromDatabase(key);
            if (item != null)
            {
                Insert(index, item);
            }
        }

        protected virtual TC LoadPreviewItemFromDatabase(object key)
        {
            return null;
        }

        protected int FindIndexByKey(object key)
        {
            return this.FindIndex(p => p.IdValue.Equals(key));
        }
    }
}