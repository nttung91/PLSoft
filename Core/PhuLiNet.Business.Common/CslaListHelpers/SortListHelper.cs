using System.ComponentModel;
using Csla;
using Csla.Core;

namespace PhuLiNet.Business.Common.CslaListHelpers
{
    public class SortListHelper<T, C>
        where T : ExtendedBindingList<C>
        where C : IBusinessObject
    {
        public static SortedBindingList<C> DescendingSortedList(T list, string sortPropertyName)
        {
            var _sortedList = new SortedBindingList<C>(list);
            _sortedList.ApplySort(sortPropertyName, ListSortDirection.Descending);
            return _sortedList;
        }

        public static SortedBindingList<C> AscendingSortedList(T list, string sortPropertyName)
        {
            var _sortedList = new SortedBindingList<C>(list);
            _sortedList.ApplySort(sortPropertyName, ListSortDirection.Ascending);
            return _sortedList;
        }

        public static SortedBindingList<C> DescendingSortedList(FilteredBindingList<C> list, string sortPropertyName)
        {
            var _sortedList = new SortedBindingList<C>(list);
            _sortedList.ApplySort(sortPropertyName, ListSortDirection.Descending);
            return _sortedList;
        }

        public static SortedBindingList<C> AscendingSortedList(FilteredBindingList<C> list, string sortPropertyName)
        {
            var _sortedList = new SortedBindingList<C>(list);
            _sortedList.ApplySort(sortPropertyName, ListSortDirection.Ascending);
            return _sortedList;
        }
    }
}