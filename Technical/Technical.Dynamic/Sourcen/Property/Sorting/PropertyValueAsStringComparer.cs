using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    // Sort class   
    public class PropertyValueAsStringComparer : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            return first.ValueAsString.CompareTo(second.ValueAsString);
        }
    }
}