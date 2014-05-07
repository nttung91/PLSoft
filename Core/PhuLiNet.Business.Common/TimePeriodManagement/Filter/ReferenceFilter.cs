using System;
using System.Linq;
using Csla;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Filter
{
    public class ReferenceFilter<L, C>
        where L : BusinessBindingListBase<L, C>
        where C : BusinessBase<C>, ITimePeriod
    {
        public static object ApplyTimeView(L list, DateTime? referenceDate)
        {
            if (!referenceDate.HasValue)
                return list;

            var dummy = from filteredList
                in list
                where
                    filteredList.EftvFrom.HasValue &&
                    filteredList.EftvFrom.Value.Date.CompareTo(referenceDate.Value.Date) <= 0 &&
                    (!filteredList.EftvTo.HasValue ||
                     filteredList.EftvTo.Value.Date.CompareTo(referenceDate.Value.Date) >= 0)
                select filteredList;

            return dummy;
        }
    }
}