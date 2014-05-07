using System;
using Csla;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Filter
{
    public class TimePeriodFilter<L, C>
        where L : BusinessBindingListBase<L, C>
        where C : BusinessBase<C>, ITimePeriod
    {
        public static object ApplyTimeView(L list, ETimePeriodFilterTypes timeView, DateTime? referenceDate = null)
        {
            object result = null;

            switch (timeView)
            {
                case ETimePeriodFilterTypes.Past:
                    result = PastFilter<L, C>.ApplyTimeView(list);
                    break;

                case ETimePeriodFilterTypes.Present:
                    result = PresentFilter<L, C>.ApplyTimeView(list);
                    break;

                case ETimePeriodFilterTypes.Future:
                    result = FutureFilter<L, C>.ApplyTimeView(list);
                    break;

                case ETimePeriodFilterTypes.Reference:
                    result = ReferenceFilter<L, C>.ApplyTimeView(list, referenceDate);
                    break;

                case ETimePeriodFilterTypes.PresentFuture:
                    result = PresentFutureFilter<L, C>.ApplyTimeView(list);
                    break;

                case ETimePeriodFilterTypes.All:
                    result = list;
                    break;

                default:
                    result = list;
                    break;
            }

            return result;
        }
    }
}