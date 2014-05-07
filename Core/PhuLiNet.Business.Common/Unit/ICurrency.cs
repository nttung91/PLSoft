using System;

namespace PhuLiNet.Business.Common.Unit
{
    public interface ICurrency
    {
        string CurrId { get; }
        int DecPlcs { get; }
        string Descr { get; }
        string EdiCurrCd { get; }
        DateTime EftvFrom { get; }
        DateTime? EftvTo { get; }
    }
}