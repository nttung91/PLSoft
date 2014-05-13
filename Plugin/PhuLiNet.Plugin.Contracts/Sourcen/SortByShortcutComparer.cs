using System;
using System.Collections.Generic;

namespace PhuLiNet.Plugin.Contracts
{
    public class SortByShortcutComparer : IComparer<IPlugin>
    {
        public int Compare(IPlugin x, IPlugin y)
        {
            return String.Compare(x.Shortcut, y.Shortcut, StringComparison.Ordinal);
        }
    }
}