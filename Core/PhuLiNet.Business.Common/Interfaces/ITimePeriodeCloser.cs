using System;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface ITimePeriodeCloser : ITimePeriod
    {
        new DateTime? EftvFrom { get; }
        new DateTime? EftvTo { get; }

        int ArtId { get; }

        void CloseTimePeriod(DateTime? eftvTo);
    }
}