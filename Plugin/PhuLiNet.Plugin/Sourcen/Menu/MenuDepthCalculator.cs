using System.Collections.Generic;

namespace PhuLiNet.Plugin.Menu
{
    internal class MenuDepthCalculator
    {
        private readonly List<IMenuItem> _menuList;
        private int _maxDepth;

        public MenuDepthCalculator(List<IMenuItem> menuList)
        {
            _menuList = menuList;
        }

        public int GetMaxDepth()
        {
            foreach (IMenuItem m in _menuList)
            {
                if (m.SubMenuDepth > _maxDepth)
                {
                    _maxDepth = m.SubMenuDepth;
                }
            }

            return _maxDepth;
        }
    }
}