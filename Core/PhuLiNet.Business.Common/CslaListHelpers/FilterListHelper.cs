using System;
using System.Collections.Generic;
using System.Reflection;
using Csla;
using Csla.Core;
using Technical.Reflection;

namespace PhuLiNet.Business.Common.CslaListHelpers
{
    public class FilterListHelper<T, C>
        where T : ExtendedBindingList<C>
        where C : IBusinessObject
    {
        public static FilterListHelper<T, C> GetFilterListHelper()
        {
            return new FilterListHelper<T, C>();
        }

        public FilteredBindingList<C> ExactFilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.EqualFilterProvider);
        }

        public FilteredBindingList<C> ExactFilteredList(FilteredBindingList<C> list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.EqualFilterProvider);
        }


        public FilteredBindingList<C> GreaterFilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.GreaterFilterProvider);
        }

        public FilteredBindingList<C> GreaterFilteredList(FilteredBindingList<C> list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.GreaterFilterProvider);
        }

        public FilteredBindingList<C> NullOrGreaterOrEqualFilteredList(FilteredBindingList<C> list,
            Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.NullOrGreaterOrEqualFilterProvider);
        }


        public FilteredBindingList<C> SmallerFilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.SmallerFilterProvider);
        }

        public FilteredBindingList<C> SmallerFilteredList(FilteredBindingList<C> list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.SmallerFilterProvider);
        }


        public FilteredBindingList<C> SmallerOrEqualFilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.SmallerOrEqualFilterProvider);
        }

        public FilteredBindingList<C> SmallerOrEqualFilteredList(FilteredBindingList<C> list,
            Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.SmallerOrEqualFilterProvider);
        }


        public FilteredBindingList<C> NullOrEqualFilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.NullOrEqualFilterProvider);
        }

        public FilteredBindingList<C> NullOrEqualFilteredList(FilteredBindingList<C> list,
            Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, FilterProviderHelper.NullOrEqualFilterProvider);
        }


        public FilteredBindingList<C> FilteredList(T list, Dictionary<string, object> filter)
        {
            return FilteredList(list, filter, null);
        }

        public FilteredBindingList<C> FilteredList(T list, Dictionary<string, object> filter,
            FilterProvider FilterProvider)
        {
            var filteredList = new FilteredBindingList<C>(list);
            if (list.Count == 0) return filteredList;

            return FilteredList(filteredList, filter, FilterProvider);
        }


        public FilteredBindingList<C> FilteredList(FilteredBindingList<C> filteredList,
            Dictionary<string, object> filter, FilterProvider FilterProvider)
        {
            FilteredBindingList<C> filteredListDummy;

            if (filteredList.Count == 0) return filteredList;

            int counter = 0;
            foreach (KeyValuePair<string, object> filterElement in filter)
            {
                if (filteredList.Count == 0) break;

                C item = filteredList[0];
                PropertyInfo property = PropertyReflectionHelper.GetPropertyInfo(item, filterElement.Key);
                if (property == null)
                {
                    throw new FilterPropertyException(String.Format("{0} Property existiert nicht in {1}",
                        filterElement.Key, filteredList[0]));
                }
                if (FilterProvider != null)
                {
                    filteredList.FilterProvider = FilterProvider;
                }
                filteredList.ApplyFilter(filterElement.Key, filterElement.Value);

                counter++;
                if (counter < filter.Count)
                {
                    filteredListDummy = new FilteredBindingList<C>(filteredList);
                    filteredList = filteredListDummy;
                }
            }
            return filteredList;
        }
    }
}