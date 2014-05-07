using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Distribution
{
    public interface IDistributable
    {
        IDictionary<string, decimal> GetDistributedQuantities();
    }

    public interface IDistributable<T>
    {
        IDictionary<T, decimal> GetDistributedQuantities();
    }
}