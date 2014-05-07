using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    // Sort class   
    public class PropertyDescriptionComparerDesc : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            return second.Description.CompareTo(first.Description);
        }
    }
}