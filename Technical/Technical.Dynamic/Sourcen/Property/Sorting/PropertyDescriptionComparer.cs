using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    // Sort class   
    public class PropertyDescriptionComparer : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            return first.Description.CompareTo(second.Description);
        }
    }
}