using System;

namespace PhuLiNet.Business.Common.CslaListHelpers
{
    public static class FilterProviderHelper
    {
        /// <summary>
        /// Mit dem Filterprovider kann die Logik angegeben werden, wann ein Item dem Filter entspricht und wann nicht.
        /// Der Default-Provider von CSLA macht dabei einen Check auf Substring.
        /// Möchte man auf Gleichheit testen, kann der hier angebotene EqualFilterProvider verwendet werden.
        /// (ExactFilteredList verwenden)
        /// Für DateTime wird nur der Datumsteil verglichen
        /// </summary>
        public static bool EqualFilterProvider(object item, object filter)
        {
            bool result = false;
            if (item != null && filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) == 0;
                else
                    result = item.ToString() == filter.ToString();
            return result;
        }

        public static bool NotEqualFilterProvider(object item, object filter)
        {
            bool result = false;
            if (item != null && filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) != 0;
                else
                    result = item.ToString() != filter.ToString();
            return result;
        }

        public static bool GreaterFilterProvider(object item, object filter)
        {
            bool result = false;
            if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) == 1;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) == 1;

            return result;
        }

        public static bool NullOrGreaterOrEqualFilterProvider(object item, object filter)
        {
            bool result = false;
            if (item == null)
            {
                result = true;
            }
            else if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) >= 0;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) == 1;

            return result;
        }

        public static bool GreaterOrEqualFilterProvider(object item, object filter)
        {
            bool result = false;

            if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) >= 0;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) == 1;

            return result;
        }

        public static bool NullOrEqualFilterProvider(object item, object filter)
        {
            bool result = false;

            if (item == null)
            {
                result = true;
            }
            else if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) == 0;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) == 0;

            return result;
        }

        public static bool SmallerFilterProvider(object item, object filter)
        {
            bool result = false;
            if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) == -1;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) == -1;
            return result;
        }

        public static bool SmallerOrEqualFilterProvider(object item, object filter)
        {
            bool result = false;
            if (filter != null)
                if (item is DateTime? && filter is DateTime)
                    result = ((DateTime?) item).HasValue &&
                             ((DateTime?) item).Value.Date.CompareTo(((DateTime) filter).Date) <= 0;
                else if (item != null)
                    result = item.ToString().CompareTo(filter) <= 0;
            return result;
        }
    }
}