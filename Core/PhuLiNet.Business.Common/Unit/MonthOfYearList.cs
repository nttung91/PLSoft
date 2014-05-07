using System;
using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Unit
{
    public class MonthOfYearList : List<MonthOfYear>
    {
        private MonthOfYearList()
        {
        }

        public static MonthOfYearList GetMonthOfYearList(MonthOfYear from, MonthOfYear to)
        {
            var list = new MonthOfYearList();
            list.InitMonthInYear(from, to);
            return list;
        }

        internal void InitMonthInYear(MonthOfYear from, MonthOfYear to)
        {
            var lastDate = new DateTime(to.Year, to.Month, 1);
            DateTime nextDate = lastDate;
            while (true)
            {
                Add(new MonthOfYear(nextDate.Year, nextDate.Month));
                nextDate = nextDate.AddMonths(-1);

                if ((nextDate.Year == from.Year && nextDate.Month < from.Month) || (nextDate.Year < from.Year))
                    break;
            }
        }
    }
}