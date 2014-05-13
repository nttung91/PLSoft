using System;
using System.Collections.Generic;
using PhuLiNet.Plugin.Menu;

namespace Manor.Plugin.Menu
{
    internal class MenuSequenceAndCaptionComparer : IComparer<IMenuItem>
    {
        public int Compare(IMenuItem x, IMenuItem y)
        {
            int pluginCompareResult = x.HasPlugin.CompareTo(y.HasPlugin);
            if (pluginCompareResult != 0)
            {
                return pluginCompareResult;
            }

            int sortSequenceCompareResult = x.SortSequence.CompareTo(y.SortSequence);
            if (sortSequenceCompareResult != 0)
            {
                return sortSequenceCompareResult;
            }

            return String.CompareOrdinal(x.Caption, y.Caption);
        }
    }
}