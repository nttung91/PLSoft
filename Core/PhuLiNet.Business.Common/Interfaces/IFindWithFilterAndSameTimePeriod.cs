using System.Collections.Generic;
using Csla;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface IFindWithFilterAndSameTimePeriod
    {
        C FindWithFilterAndSameTimePeriod<T, C>(Dictionary<string, object> filter, ITimePeriod timePeriod)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>;
    }
}