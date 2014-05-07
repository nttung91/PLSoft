using System;

namespace Technical.Utilities.Helpers
{
    /// <summary>
    /// Helper class for DateTime compare
    /// </summary>
    public static class DateTimeComparer
    {
        /// <summary>
        /// Compares DateTime instances only to milliseconds.
        /// The normal DateTime compares the values to sub millisecond and
        /// this causes problems when you have rounding differences.
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns>Returns true if the values are the same.</returns>
        public static bool Match(DateTime? dt1, DateTime? dt2)
        {
            bool match = false;

            if (!dt1.HasValue && !dt2.HasValue)
            {
                match = true;
            }
            else if (dt1.HasValue && dt2.HasValue)
            {
                if (dt1.Value.Date == dt2.Value.Date &&
                    dt1.Value.Hour == dt2.Value.Hour &&
                    dt1.Value.Minute == dt2.Value.Minute &&
                    dt1.Value.Second == dt2.Value.Second &&
                    dt1.Value.Millisecond == dt2.Value.Millisecond)
                {
                    match = true;
                }
            }

            return match;
        }
    }
}