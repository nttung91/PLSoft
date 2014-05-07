using Techical.Dynamic.Property;

namespace PhuLiNet.Business.Common.Lookup
{
    /// <summary>
    /// Basic interface for lookup classes
    /// </summary>
    public interface ILookupObject
    {
        bool Selected { get; set; }
        object LookupKey { get; }
        string LookupName { get; }
        IDynamicPropertyList LookupAdditionalValues { get; }
    }
}