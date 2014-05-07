using System;
using System.Diagnostics;

namespace Technical.Utilities.Extensions
{
    public static class StopwatchExtensions
    {
        public static TimeSpan MeasureExecutionTime(this Stopwatch stopwatch, Action action)
        {
            var sw = Stopwatch.StartNew();

            action();

            return sw.Elapsed;
        }
    }
}