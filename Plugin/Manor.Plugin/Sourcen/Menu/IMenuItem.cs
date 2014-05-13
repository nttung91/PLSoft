using System.Collections.Generic;
using System.Drawing;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using Technical.Utilities.GenericTree;

namespace PhuLiNet.Plugin.Menu
{
    public interface IMenuItem : ITreeNode<IMenuItem>
    {
        /// <summary>
        /// Key of menu item
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Sort sequence
        /// </summary>
        int SortSequence { get; }

        /// <summary>
        /// Name of menu item
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// Menu item image
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// Tool tip text
        /// </summary>
        string ToolTipText { get; }

        /// <summary>
        /// Referenced plugin class
        /// </summary>
        IPlugin Plugin { get; }

        /// <summary>
        /// Is Plugin valid
        /// </summary> 
        bool IsPluginValid { get; }

        /// <summary>
        /// Has menuitem a plugin defined
        /// </summary> 
        bool HasPlugin { get; }

        /// <summary>
        /// Has menuitem a plugin assigned
        /// </summary> 
        bool HasPluginAssigned { get; }

        /// <summary>
        /// Is valid
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Is visible
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Plugin identifier
        /// </summary>
        string PluginId { get; }

        /// <summary>
        /// Is autostart feature supported
        /// </summary>
        bool SupportsAutoStart { get; }

        /// <summary>
        /// Sub menu items
        /// </summary>
        IEnumerable<IMenuItem> SubMenus { get; }

        /// <summary>
        /// Add sub menu item
        /// </summary>
        /// <param name="menuItem"></param>
        void AddSubMenu(IMenuItem menuItem);

        /// <summary>
        /// Has this menu item sub menus
        /// </summary>
        bool HasSubMenu { get; }

        /// <summary>
        /// Has this menu item visible and valid sub menu items
        /// </summary>
        bool HasVisibleSubMenuItems { get; }

        /// <summary>
        /// Sub menu depth (How much sub menu levels are under this menu item?)
        /// </summary>
        int SubMenuDepth { get; }

        /// <summary>
        /// Sort all menu entries (including all childs) by given comparer
        /// </summary>
        /// <param name="comparer"></param>
        void SortMenus(IComparer<IMenuItem> comparer);
    }
}