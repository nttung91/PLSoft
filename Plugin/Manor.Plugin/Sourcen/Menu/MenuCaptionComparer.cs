using System;
using System.Collections.Generic;
using PhuLiNet.Plugin.Menu;

namespace Manor.Plugin.Menu
{
    internal class MenuCaptionComparer : IComparer<IMenuItem>
    {
        public int Compare(IMenuItem x, IMenuItem y)
        {
            int pluginCompareResult = x.HasPlugin.CompareTo(y.HasPlugin);
            if (pluginCompareResult != 0)
            {
                return pluginCompareResult;
            }

            return String.CompareOrdinal(x.Caption, y.Caption);
        }
    }
}