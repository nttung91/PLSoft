using System.Collections.Generic;
using Manor.Plugin.Menu.MainMenu;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal interface IMenuManager
    {
        List<IMenuItem> GetMenu();
        IMenuRepository MenuRepository { get; set; }
    }
}