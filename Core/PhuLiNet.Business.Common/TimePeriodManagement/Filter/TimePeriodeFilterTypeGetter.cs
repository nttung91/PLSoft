using System;
using System.Diagnostics;

namespace PhuLiNet.Business.Common.TimePeriodManagement.Filter
{
    public class TimePeriodeFilterTypeGetter
    {
        public static ETimePeriodFilterTypes GetEnum(object value)
        {
            Debug.Assert(Enum.IsDefined(typeof (ETimePeriodFilterTypes), value),
                String.Format("Der TimeViewType ist nicht definiert:{0}", value));

            var timeView = (ETimePeriodFilterTypes) Enum.Parse(typeof (ETimePeriodFilterTypes), value.ToString());
            return timeView;
        }
    }
}