using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    // Sort class   
    public class PropertyKeyComparer : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            return first.Key.CompareTo(second.Key);
        }
    }
}