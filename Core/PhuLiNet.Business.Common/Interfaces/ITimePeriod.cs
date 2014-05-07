using System;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface ITimePeriod
    {
        DateTime? EftvFrom { get; set; }
        DateTime? EftvTo { get; set; }
    }
}