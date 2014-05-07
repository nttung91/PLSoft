using System;
using System.Linq;
using Csla;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Filter
{
    public class PresentFilter<L, C>
        where L : BusinessBindingListBase<L, C>
        where C : BusinessBase<C>, ITimePeriod
    {
        public static object ApplyTimeView(L list)
        {
            var dummy = from filteredList
                in list
                where
                    filteredList.EftvFrom.HasValue && filteredList.EftvFrom.Value.Date.CompareTo(DateTime.Now.Date) <= 0 &&
                    (!filteredList.EftvTo.HasValue || filteredList.EftvTo.Value.Date.CompareTo(DateTime.Now.Date) >= 0)
                select filteredList;


            return dummy;
        }
    }
}