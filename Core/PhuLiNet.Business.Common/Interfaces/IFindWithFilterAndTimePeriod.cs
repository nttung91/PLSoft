using System.Collections.Generic;
using Csla;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface IFindWithFilterAndTimePeriod
    {
        C FindWithFilterAndTimePeriod<T, C>(Dictionary<string, object> filter, ITimePeriod timePeriod)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>;
    }
}