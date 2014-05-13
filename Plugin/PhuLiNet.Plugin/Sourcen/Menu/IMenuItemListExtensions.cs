using System.Collections.Generic;
using PhuLiNet.Plugin.Contracts;
using Technical.Utilities.GenericTree;

namespace PhuLiNet.Plugin.Menu
{
    internal static class MenuItemListExtensions
    {
        internal static void SortBySequenceAndCaption(this List<IMenuItem> menuItems)
        {
            var comparer = new MenuSequenceAndCaptionComparer();
            menuItems.Sort(comparer);
            foreach (var menuItem in menuItems)
            {
                menuItem.SortMenus(comparer);
            }
        }

        internal static void SortByCaption(this List<IMenuItem> menuItems)
        {
            var comparer = new MenuCaptionComparer();
            menuItems.Sort(comparer);
            foreach (var menuItem in menuItems)
            {
                menuItem.SortMenus(comparer);
            }
        }

        internal static IMenuItem FindForPlugin(this List<IMenuItem> menuItems, IPlugin plugin)
        {
            foreach (var menuItem in menuItems)
            {
                var found = menuItem.FirstOrDefaultDescendant(item => ReferenceEquals(item.Plugin, plugin));
                if (found != null) return found;
            }
            return null;
        }
    }
}