using System;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface IEftvFromChange
    {
        DateTime? EftvFrom { get; set; }
        DateTime? EftvFromOriginal { get; set; }

        bool IsNew { get; }
    }
}