using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    // Sort class   
    public class PropertyDisplayNameComparerDesc : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            return second.DisplayName.CompareTo(first.DisplayName);
        }
    }
}