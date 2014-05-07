using System;
using PhuLiNet.Business.Common.TimePeriodManagement.Filter;

namespace PhuLiNet.Business.Common.TimePeriodManagement
{
    public interface IApplyTimePeriodType
    {
        void ApplyTimeView(ETimePeriodFilterTypes timePeriodType, DateTime? referenceDate = null);
    }
}