using System;
using Csla;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Closer
{
    public class TimePeriodMatchChecker
    {
        public static C GetFirstItemWithinPeriodFromListBase<T, C>(T list, DateTime? eftvFrom, DateTime? eftvTo)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>, ITimePeriod
        {
            if (list.Count == 0) return null;
            C result = null;

            foreach (C item in list)
            {
                if (item.EftvFrom <= eftvFrom &&
                    (!item.EftvTo.HasValue && !eftvTo.HasValue ||
                     (item.EftvTo.HasValue && eftvTo.HasValue && item.EftvTo.Value >= eftvTo.Value) ||
                     (!item.EftvTo.HasValue && eftvTo.HasValue)))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static C GetItemWithSamePeriod<T, C>(T list, DateTime? eftvFrom, DateTime? eftvTo)
            where T : FilteredBindingList<C>
            where C : BusinessBase<C>, ITimePeriod
        {
            if (list.Count == 0) return null;
            C result = null;

            foreach (C item in list)
            {
                if (item.EftvFrom == eftvFrom &&
                    ((item.EftvTo.HasValue && eftvTo.HasValue && item.EftvTo == eftvTo) ||
                     (!item.EftvTo.HasValue && !eftvTo.HasValue)))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static C GetFirstItemWithinPeriod<T, C>(T list, DateTime? eftvFrom, DateTime? eftvTo)
            where T : FilteredBindingList<C>
            where C : BusinessBase<C>, ITimePeriod
        {
            if (list.Count == 0) return null;
            C result = null;

            foreach (C item in list)
            {
                if (item.EftvFrom <= eftvFrom &&
                    (!item.EftvTo.HasValue && !eftvTo.HasValue ||
                     (item.EftvTo.HasValue && eftvTo.HasValue && item.EftvTo.Value >= eftvTo.Value) ||
                     (!item.EftvTo.HasValue && eftvTo.HasValue)))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static void GetItemsWithinPeriod<L, T, C>(T list, DateTime? eftvFrom, DateTime? eftvTo, ref L results)
            where L : BusinessBindingListBase<L, C>
            where T : FilteredBindingList<C>
            where C : BusinessBase<C>, ITimePeriod
        {
            foreach (C item in list)
            {
                if (item.EftvFrom <= eftvFrom &&
                    (!item.EftvTo.HasValue && !eftvTo.HasValue ||
                     (item.EftvTo.HasValue && eftvTo.HasValue && item.EftvTo.Value >= eftvTo.Value) ||
                     (!item.EftvTo.HasValue && eftvTo.HasValue)))
                {
                    results.Add(item);
                    break;
                }
            }
        }
    }
}