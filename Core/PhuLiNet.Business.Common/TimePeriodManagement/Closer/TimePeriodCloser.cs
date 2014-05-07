using System;
using System.Collections.Generic;
using Csla;
using Csla.Core;
using Technical.Utilities.Helpers;
using PhuLiNet.Business.Common.CslaListHelpers;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Closer
{
    public class TimePeriodCloser
    {
        public static void SyncEftvToList<T, C>(T list)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase, ITimePeriod, IValidateBusiness
        {
            if (list.Count == 0) return;

            SortedBindingList<C> sortedList = SortListHelper<T, C>.DescendingSortedList(list, "EftvFrom");
            syncEftvToList<C>(sortedList);
        }

        public static void SyncEftvToList<T, C>(FilteredBindingList<C> list)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase, ITimePeriod, IValidateBusiness
        {
            if (list.Count == 0) return;

            SortedBindingList<C> sortedList = SortListHelper<T, C>.DescendingSortedList(list, "EftvFrom");
            syncEftvToList<C>(sortedList);
        }

        private static void syncEftvToList<C>(SortedBindingList<C> sortedList)
            where C : BusinessBase, ITimePeriod, IValidateBusiness
        {
            bool first = true;
            C lastItem = null;
            foreach (C listItem in sortedList)
            {
                if (first)
                {
                    first = false;
                    lastItem = listItem;
                    if (lastItem.EftvTo.HasValue)
                    {
                        lastItem.EftvTo = null;
                    }
                }
                else
                {
                    listItem.EftvTo = lastItem.EftvFrom.Value.AddDays(-1);
                    lastItem = listItem;
                }
            }
        }

        public static List<TimePeriodClosingInfo> SyncTimePeriodClosing<T, C>(T list)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase, ITimePeriodeCloser
        {
            var result = new List<TimePeriodClosingInfo>();
            if (list.Count == 0) return result;

            SortedBindingList<C> sortedList = SortListHelper<T, C>.DescendingSortedList(list, "EftvFrom");

            return syncTimePeriodClosing<C>(result, sortedList);
        }

        public static List<TimePeriodClosingInfo> SyncTimePeriodClosing<T, C>(FilteredBindingList<C> list)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase, ITimePeriodeCloser
        {
            var result = new List<TimePeriodClosingInfo>();
            if (list.Count == 0) return result;

            SortedBindingList<C> sortedList = SortListHelper<T, C>.DescendingSortedList(list, "EftvFrom");

            return syncTimePeriodClosing<C>(result, sortedList);
        }

        private static List<TimePeriodClosingInfo> syncTimePeriodClosing<C>(List<TimePeriodClosingInfo> result,
            SortedBindingList<C> sortedList)
            where C : BusinessBase, ITimePeriodeCloser
        {
            bool first = true;
            C lastItem = null;
            foreach (C listItem in sortedList)
            {
                if (first)
                {
                    first = false;
                    lastItem = listItem;
                    if (lastItem.EftvTo.HasValue)
                    {
                        setEftvTo<C>(result, listItem, null);
                    }
                }
                else
                {
                    DateTime? newEftvTo = lastItem.EftvFrom.Value.AddDays(-1);
                    if (isDifferent(listItem.EftvTo, newEftvTo))
                    {
                        setEftvTo<C>(result, listItem, newEftvTo);
                    }
                    lastItem = listItem;
                }
            }

            return result;
        }

        private static void setEftvTo<C>(List<TimePeriodClosingInfo> result, C listItem, DateTime? newEftvTo)
            where C : BusinessBase, ITimePeriodeCloser
        {
            listItem.CloseTimePeriod(newEftvTo);
            bool valid = validateItem<C>(listItem, "EftvTo");
            var info = new TimePeriodClosingInfo(valid, listItem.ArtId, listItem.EftvTo);
            result.Add(info);
        }

        private static bool isDifferent(DateTime? newEftvTo, DateTime? originalEftvTo)
        {
            return AssignmentHelper.AssignNullableValue(ref originalEftvTo, newEftvTo);
        }

        private static bool validateItem<C>(C item, string propertyName)
            where C : BusinessBase, ITimePeriodeCloser

        {
            bool valid = true;
            if (item is IValidateBusiness)
            {
                ((IValidateBusiness) item).Validate();
                valid = BusinessPropertyValidator<C>.GetValidator().IsValid(item, propertyName);
            }
            return valid;
        }
    }
}