using System.Collections.Generic;

namespace Techical.Dynamic.Property
{
    public interface IHasDynamicProperties
    {
        IDictionary<string, IDynamicPropertyList> DynamicProperties { get; set; }
    }
}