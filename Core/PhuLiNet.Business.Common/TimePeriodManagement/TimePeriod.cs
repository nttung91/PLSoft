using System;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.TimePeriodManagement
{
    public class TimePeriod : ITimePeriod
    {
        #region ITimePeriod Members

        public DateTime? EftvFrom { get; set; }

        public DateTime? EftvTo { get; set; }

        #endregion
    }
}