using System.Collections.Generic;
using Csla;

namespace PhuLiNet.Business.Common.Interfaces
{
    public interface IFindWithFilter
    {
        FilteredBindingList<C> FindWithFilter<T, C>(Dictionary<string, object> filter)
            where T : BusinessBindingListBase<T, C>
            where C : BusinessBase<C>;
    }
}