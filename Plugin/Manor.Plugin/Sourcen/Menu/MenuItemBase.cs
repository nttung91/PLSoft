using System.Collections.Generic;
using System.Drawing;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Menu.Plugins;
using Technical.Utilities.Extensions;

namespace PhuLiNet.Plugin.Menu
{
    internal abstract class MenuItemBase : IMenuItem
    {
        private string _pluginId;
        private bool _isVisible = true;
        private List<IMenuItem> _subMenus;
        private MenuItemBase _parent;

        #region IMenuItem Members

        public string Id { get; internal set; }

        public int SortSequence { get; internal set; }

        public string Caption { get; internal set; }

        public Image Image { get; internal set; }

        public string ToolTipText { get; internal set; }

        public IPlugin Plugin { get; internal set; }

        public bool HasPlugin
        {
            get { return (_pluginId != null); }
        }

        public bool HasPluginAssigned
        {
            get
            {
                if (Plugin is PluginProxy) return false;
                return Plugin != null;
            }
        }

        public bool IsPluginValid
        {
            get { return (HasPlugin && HasPluginAssigned && Plugin.IsValid); }
        }

        public bool IsValid
        {
            get
            {
                return (Id != null && Caption != null && !HasPlugin) ||
                       (Id != null && Caption != null && HasPlugin && IsPluginValid);
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        public bool SupportsAutoStart { get; internal set; }

        public string PluginId
        {
            get { return _pluginId; }
            internal set { _pluginId = value; }
        }

        public IEnumerable<IMenuItem> SubMenus
        {
            get { return _subMenus; }
        }

        public bool HasSubMenu
        {
            get { return (SubMenuDepth > 0); }
        }

        public bool HasVisibleSubMenuItems
        {
            get
            {
                bool hasVisibleSubMenuItems = false;

                if (HasSubMenu)
                {
                    foreach (MenuItemBase item in _subMenus)
                    {
                        if (item.IsValid && item.IsVisible)
                        {
                            hasVisibleSubMenuItems = true;
                            break;
                        }
                    }
                }

                return hasVisibleSubMenuItems;
            }
        }

        public int SubMenuDepth
        {
            get { return Depth.Count; }
        }

        public void SortMenus(IComparer<IMenuItem> comparer)
        {
            if (_subMenus == null) return;
            SortMenus(this, comparer);
        }

        private void SortMenus(MenuItemBase menuItem, IComparer<IMenuItem> comparer)
        {
            if (menuItem._subMenus == null) return;
            menuItem._subMenus.Sort(comparer);
            foreach (var item in menuItem.SubMenus)
            {
                SortMenus((MenuItemBase) item, comparer);
            }
        }

        private List<MenuItemBase> Depth
        {
            get
            {
                var path = new List<MenuItemBase>();
                if (_subMenus != null)
                {
                    foreach (MenuItemBase item in _subMenus)
                    {
                        List<MenuItemBase> tmp = item.Depth;
                        if (tmp.Count > path.Count)
                            path = tmp;
                    }
                    path.Insert(0, this);
                }
                return path;
            }
        }


        public void AddSubMenu(IMenuItem menuItem)
        {
            ((MenuItemBase) menuItem)._parent = this;

            if (_subMenus == null)
            {
                _subMenus = new List<IMenuItem>();
            }

            _subMenus.Add(menuItem);
        }

        #endregion

        public override string ToString()
        {
            return Caption;
        }

        public IMenuItem Parent
        {
            get { return _parent; }
        }

        public IList<IMenuItem> Childs
        {
            get
            {
                if (_subMenus != null)
                    return _subMenus.Cast<IMenuItem>();
                return new List<IMenuItem>();
            }
        }
    }
}