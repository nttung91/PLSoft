using System.Collections.Generic;
using System.Diagnostics;
using Manor.Plugin.Menu.MainMenu;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal class MenuManager : IMenuManager
    {
        private List<IMenuItem> _menuTree;
        private IMenuRepository _menuRepository;

        public IMenuRepository MenuRepository
        {
            get { return _menuRepository; }
            set { _menuRepository = value; }
        }

        public void Init()
        {
            Debug.Assert(_menuRepository != null, "MenuRepository is null");
            _menuTree = _menuRepository.Load();
            _menuTree.SortBySequenceAndCaption();
        }

        public void Cleanup()
        {
            _menuRepository = null;
        }

        public List<IMenuItem> GetMenu()
        {
            return _menuTree;
        }
    }
}