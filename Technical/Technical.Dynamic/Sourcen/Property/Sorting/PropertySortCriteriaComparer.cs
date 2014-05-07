using System;
using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    public class PropertySortCriteriaComparer : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            if (first.SortCriteria != null)
            {
                if (first.SortCriteria is IComparable)
                {
                    return ((IComparable) first.SortCriteria).CompareTo(second.SortCriteria);
                }
                else
                {
                    string strFirst = first.SortCriteria.ToString();
                    string strSecond = string.Empty;
                    if (second.SortCriteria != null)
                    {
                        strSecond = second.SortCriteria.ToString();
                    }
                    return strFirst.CompareTo(strSecond);
                }
            }
            else
            {
                return 1;
            }
        }
    }
}