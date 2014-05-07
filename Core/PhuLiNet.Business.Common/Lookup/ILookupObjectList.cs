using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Lookup
{
    /// <summary>
    /// Basic interface for lookup list classes
    /// </summary>
    public interface ILookupObjectList
    {
        string LookupListName { get; }
        IList<ILookupObject> GetLookupList();
    }
}