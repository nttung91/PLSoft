using System;
using System.Collections.Generic;

namespace Techical.Dynamic.Property.Sorting
{
    public class PropertySortCriteriaComparerDesc : IComparer<IDynamicProperty>
    {
        public int Compare(IDynamicProperty first, IDynamicProperty second)
        {
            if (first.SortCriteria != null && second.SortCriteria != null)
            {
                if (second.SortCriteria is IComparable)
                {
                    return ((IComparable) second.SortCriteria).CompareTo(first.SortCriteria);
                }
                else
                {
                    string strSecond = second.SortCriteria.ToString();
                    string strFirst = string.Empty;
                    if (first.SortCriteria != null)
                    {
                        strFirst = first.SortCriteria.ToString();
                    }
                    return strSecond.CompareTo(strFirst);
                }
            }
            else if (first.SortCriteria == null && second.SortCriteria != null)
            {
                return 1;
            }
            else if (first.SortCriteria != null && second.SortCriteria == null)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}